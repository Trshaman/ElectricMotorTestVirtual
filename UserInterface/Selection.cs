using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlobalFunctions;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace UserInterface
{
  public enum GrapHandleRecs
  {
    NW, N, NE, W, E, SW, S, SE, Move,
    Tags
  }
  public delegate void ShowPropertiesRequestHandler(Control sender, Point MouseDownLocation);
  public delegate void ClosePropertiesRequestHandler(Control sender);
  [ToolboxItem(false)]
  public partial class Selection : UserControl
  {
    //TODO: ilker graphic copy paste problem var. (Properties copy problem).
    //TODO: Grid Aligment yapılacak.
    //TODO: Çoklu seçimlerde özellikle size eşitlemelerinde hangi kontrole göre yapılacağı için algoritma gerekli.
    //TODO: Front ve back işlemlerinde problem 
    //TODO : ilk seçimler de seçili değilken ilk oluşturmada mdimain muhtemelen parent olarak kalıyor.
    public event ShowPropertiesRequestHandler ShowPropertiesRequest;
    #region Enum Descriptions
    public enum Aligment
    {
      Left, Right, Top, Bottom, HorizontalCenter, VerticalCenter, Center
    }
    public enum MakeSameSizes
    {
      Width, Height, All
    }
    public enum MakeSameSpace
    {
      Horizontal,
      Vertical
    }
    public enum SpaceAdjustment
    {
      IncreaseHorzSpace,
      DecreaseHorzSpace,
      RemoveHorzSpace,
      IncreaseVertSpace,
      DecreaseVertSpace,
      RemoveVertSpace,
    }
    public enum Direction
    {
      NW,
      N,
      NE,
      W,
      E,
      SW,
      S,
      SE,
      None
    }
    public enum GrapHandleRecs
    {
      NW, N, NE, W, E, SW, S, SE, Move,
      Tags
    }
    private enum RateSelection
    {
      WithVertical, WithHorizantal, WithMaxOne, WithMinOne
    }
    #endregion

    #region Properties
    public Control ChildControl { get; set; }
    /// <summary>
    /// Store Selected controls
    /// </summary>
    private static List<Selection> CreatedSelections
    {
      get { return Selection.createdSelections; }
      set { Selection.createdSelections = value; }
    }
    /// <summary>
    /// Last left control
    /// </summary>
    internal Control LeftControl { get; set; }
    /// <summary>
    /// Last left point
    /// </summary>
    internal Point LeftPosition { get; set; }
    /// <summary>
    /// to check control inside in a control
    /// </summary>
    internal bool ControlInside { get; set; }
    #endregion

    #region LocalVariable
    private static List<Selection> createdSelections = new List<Selection>();
    private static List<Control> copiedControls = new List<Control>();
    private static bool selectionInside;
    private Point MouseDownLocation;
    private Direction direction;
    private Dictionary<GrapHandleRecs, Rectangle> grapRecs = new Dictionary<GrapHandleRecs, Rectangle>();
    Rectangle NW, N, NE, W, E, SW, S, SE;
    private PictureBox picBoxMove;
    private PictureBox picBoxTag;
    private Point ofset;
    private List<Control> AllControlList;
    public static int DRAG_HANDLE_SIZE = 7;
    private static Size _dragHandleSize = new Size(7, 7);
    public static Size MIN_CONTROL_SIZE = new Size(40, 40);
    private Type _parentFormType;
    private Size _borderSize;
    private Control _oldParent;
    private Color _oldParentColor;
    #endregion

    #region Ctor
    public Selection(Control childControl, Control parent, Point mouseDownLocation, List<Control> allControlList, Type parentFormType, bool multiSelect = false)
    {
      InitializeComponent();
      this.ResizeRedraw = true;
      _parentFormType = parentFormType;
      grapRecs.Add(GrapHandleRecs.NW, NW);
      grapRecs.Add(GrapHandleRecs.N, N);
      grapRecs.Add(GrapHandleRecs.NE, NE);
      grapRecs.Add(GrapHandleRecs.W, W);
      grapRecs.Add(GrapHandleRecs.E, E);
      grapRecs.Add(GrapHandleRecs.SW, SW);
      grapRecs.Add(GrapHandleRecs.S, S);
      grapRecs.Add(GrapHandleRecs.SE, SE);
      ChildControl = childControl;
      ChildControl.Parent = this;
      //UserControl border adjustment
      UserControl ctrl = ChildControl as UserControl;
      if (ctrl != null && ctrl.BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
        _borderSize = SystemInformation.Border3DSize;
      else if (ctrl != null && ctrl.BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
        _borderSize = SystemInformation.BorderSize;
      else
        _borderSize = new Size(0, 0);
      //UserControl border adjustment
      MouseDownLocation = mouseDownLocation - _borderSize - _dragHandleSize;
      if (Functions.IsContainer(childControl))
      {
        InitPicBox(ref picBoxMove, UserInterface.Properties.Resources.canvas_size);
        picBoxMove.MouseMove += picBoxMove_MouseMove;
        picBoxMove.MouseLeave += picBoxMove_MouseLeave;
        picBoxMove.MouseDown += picBoxMove_MouseDown;
        picBoxMove.MouseUp += ChildControl_MouseUp;
      }
      InitPicBox(ref picBoxTag, UserInterface.Properties.Resources.Plus);
      picBoxTag.MouseDown += picBoxTag_MouseDown;
      picBoxTag.MouseHover += picBoxTag_MouseHover;
      picBoxTag.MouseLeave += picBoxTag_MouseLeave;

      InitEvents();
      Rectangle rec = ChildControl.Bounds;
      rec.Inflate(_dragHandleSize);
      this.Bounds = rec;
      childControl.Location = new Point(_dragHandleSize);
      this.Parent = parent;
      this.BackColor = parent.FindForm().BackColor;
      AllControlList = allControlList;
      CreatedSelections.Add(this);
      this.Name = "Selection" + CreatedSelections.Count.ToString();
      ofset = new Point(this.ParentForm.MdiParent.Controls.OfType<MdiClient>().First().Bounds.Location.X, this.ParentForm.MdiParent.Controls.OfType<MdiClient>().First().Bounds.Location.Y);
      this.ParentChanged += Selection_ParentChanged;
    }

    void Selection_ParentChanged(object sender, EventArgs e)
    {


    }
    private void InitEvents()
    {
      this.HandleDestroyed += new EventHandler(Selection_HandleDestroyed);
      this.MouseMove += new MouseEventHandler(Selection_MouseMove);
      this.MouseDown += new MouseEventHandler(Selection_MouseDown);
      ChildControl.PreviewKeyDown += ChildControl_PreviewKeyDown;
      this.PreviewKeyDown += ChildControl_PreviewKeyDown;
      if (!Functions.IsContainer(ChildControl))
      {
        ChildControl.MouseMove += new MouseEventHandler(ChildControl_MouseMove);
        ChildControl.MouseDown += new MouseEventHandler(ChildControl_MouseDown);
        ChildControl.MouseUp += new MouseEventHandler(ChildControl_MouseUp);
      }
      else
      {
        ChildControl.MouseMove += (object sender, MouseEventArgs e) => { this.Cursor = Cursors.Default; };
        ChildControl.MouseUp += ContainerControl_MouseUp;
      }
    }
    #endregion

    #region Event
    protected override void OnPaintBackground(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
      DrawControlBorder(this, e.Graphics, DRAG_HANDLE_SIZE, ref grapRecs);
    }

    private void Selection_HandleDestroyed(object sender, EventArgs e)
    {
      ChildControl.MouseMove -= ChildControl_MouseMove;
      ChildControl.MouseDown -= ChildControl_MouseDown;
      ChildControl.MouseUp -= ChildControl_MouseUp;
      ChildControl.PreviewKeyDown -= ChildControl_PreviewKeyDown;
      if (Functions.IsContainer(ChildControl))
      {
        picBoxMove.MouseMove -= picBoxMove_MouseMove;
        picBoxMove.MouseLeave -= picBoxMove_MouseLeave;
        picBoxMove.MouseDown -= picBoxMove_MouseDown;
        picBoxMove.MouseUp -= ChildControl_MouseUp;
        ChildControl.MouseUp -= ContainerControl_MouseUp;
      }
      picBoxTag.MouseDown -= picBoxTag_MouseDown;
      picBoxTag.MouseHover -= picBoxTag_MouseHover;
      picBoxTag.MouseLeave -= picBoxTag_MouseLeave;

    }

    private void Selection_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.BringToFront();
        this.MouseDownLocation = new Point(-e.X + DRAG_HANDLE_SIZE, -e.Y + DRAG_HANDLE_SIZE);
      }
    }

    private void Selection_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && direction != Direction.None)
      {
        this.Bounds = GetNewPosRec(this, direction, MousePosition, MouseDownLocation, MIN_CONTROL_SIZE);
        this.Visible = true;
        Rectangle rec = this.ClientRectangle;
        rec.Inflate(-DRAG_HANDLE_SIZE, -DRAG_HANDLE_SIZE);
        ChildControl.Size = rec.Size;
      }
      else
      {
        Cursor tmpCursor = FindDirectionAndCursor(e.Location, out direction, grapRecs);
        if (direction != Direction.None)
          this.Cursor = tmpCursor;
        else
          this.Cursor = Cursors.Default;
      }
    }

    private List<Control> GetControls(Control form)
    {
      List<Control> controlList = new List<Control>();
      foreach (Control childControl in form.Controls)
      {
        // Recurse child controls.
        controlList.AddRange(GetControls(childControl));
        controlList.Add(childControl);
      }
      return controlList;
    }

    private Control test(Control parent, Control ctrl)
    {
      List<Control> ctrlist = GetControls(parent);
      foreach (Control c in ctrlist)
      {
        if (c != this && Functions.IsContainer(c) && c.Bounds.Contains(ctrl.Bounds))
        {
          Cursor = Cursors.SizeAll;
          return c;
        }
      }
      Cursor = Cursors.No;
      return null;
    }

    private void ChildControl_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (!selectionInside)
          SetAllParentOldPosition(this.Parent);
        else
        {
          if (this.ParentForm != null)
          {
            if (this.ParentForm.ActiveMdiChild != null)
            {
              RemoveAllSelection(this.ParentForm.ActiveMdiChild);
              Control ctrl = null;
              CheckControlInsideContainer(this, this.ParentForm.ActiveMdiChild, ref ctrl);
              if (ctrl != null)
                SetNewParentWithPosition(this.Parent, ctrl);
              else
                SetNewParentWithPosition(this.Parent, this.ParentForm.ActiveMdiChild);
            }
          }
        }
        if (_oldParent != null)
        {
          _oldParent.BackColor = _oldParentColor;
          _oldParent = null;
        }
        this.ParentForm.Activate();
        this.BringToFront();
      }
    }

    private void ChildControl_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.MouseDownLocation = new Point(-e.X, -e.Y) - _borderSize - _dragHandleSize;
        this.BringToFront();
        if (Control.ModifierKeys == Keys.Control)
        {
         // Control prnt = this.Parent;
          CopySelectedChilds(this.Parent, AllControlList);
          PasteSelectedChilds(this.Parent, false, true, AllControlList, _parentFormType);
          //List<Control> ctrl = Selection.(prnt);
          direction = Direction.None;
        }
        foreach (Selection sel in CreatedSelections)
        {
          if (this.Parent == sel.Parent)
          {
            sel.LeftPosition = sel.Location;
            sel.LeftControl = this.Parent;
          }
        }
        SetNewParentWithPosition(this.Parent, this.TopLevelControl);
      }
    }

    private void ChildControl_MouseMove(object sender, MouseEventArgs e)
    {
      ChildControl.Focus();
      if (e.Button == MouseButtons.Left || ChildControl.Capture)
      {
        direction = Direction.None;
        if (direction == Direction.None)
        {
          //this.TopLevelControl.Invalidate();
          SetNewParentWithPosition(this.Parent, this.TopLevelControl);
          Rectangle rec1 = GetNewPosRec(this, direction, MousePosition, MouseDownLocation, MIN_CONTROL_SIZE);
          Point diff = new Point(rec1.Location.X - this.Bounds.Location.X, rec1.Location.Y - this.Bounds.Location.Y);
          SetAllSelectionLocation(this.Parent, CreatedSelections, diff);
          selectionInside = CheckControlLocation(CreatedSelections.Where(sel => sel.Parent == this.Parent).ToList(), ((Form)this.TopLevelControl).MdiChildren, ofset, _parentFormType);
          Cursor = selectionInside ? Cursors.SizeAll : Cursors.No;
        }
      }
      else
        this.Cursor = FindDirectionAndCursor(e.Location, out direction, grapRecs);
    }

    private void CheckControlInsideContainer(Control control, Control parentForm, ref Control container)
    {
      foreach (Control ctrl in parentForm.Controls)
      {
        if (Functions.IsContainer(ctrl) && ctrl.ClientRectangle.Contains(ConvertRectangleControlToControl(this.Parent, ctrl, this.Bounds)))
        {

          if (ctrl.GetType() == typeof(TabControl))
          {
            TabControl tb = ctrl as TabControl;
            container = tb.SelectedTab;
          }
          else
            container = ctrl;
          CheckControlInsideContainer(control, container, ref container);
        }
      }

    }

    private void ContainerControl_MouseUp(object sender, MouseEventArgs e)
    {
      //Control ctrl = (Control)sender;
      this.BringToFront();
    }

    private void picBoxMove_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.MouseDownLocation = new Point(-picBoxMove.Left - e.X, -picBoxMove.Top - e.Y);
        if (Control.ModifierKeys == Keys.Control)
        {
          CopySelectedChilds(this.Parent, AllControlList);
          PasteSelectedChilds(this.Parent, false, true, AllControlList, _parentFormType);
        }
        else
        {
          this.BringToFront();
          foreach (Selection sel in CreatedSelections)
          {
            if (this.Parent == sel.Parent)
            {
              sel.LeftPosition = sel.Location;
              sel.LeftControl = this.Parent;
            }
          }
          SetNewParentWithPosition(this.Parent, this.TopLevelControl);
        }
      }
    }

    private void picBoxMove_MouseLeave(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Default;
    }

    private void picBoxMove_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left || picBoxMove.Capture)
      {
        direction = Direction.None;
        if (direction == Direction.None)
        {
          picBoxMove.Capture = true; // Group box ve tab control de ctrl ile kopyalama yaparken mouse capture yapamadığı için koydum
          SetNewParentWithPosition(this.Parent, this.TopLevelControl);
          Rectangle rec1 = GetNewPosRec(this, direction, MousePosition, MouseDownLocation, MIN_CONTROL_SIZE);
          Point diff = new Point(rec1.Location.X - this.Bounds.Location.X, rec1.Location.Y - this.Bounds.Location.Y);
          SetAllSelectionLocation(this.Parent, CreatedSelections, diff);
          selectionInside = CheckControlLocation(CreatedSelections.Where(sel => sel.Parent == this.Parent).ToList(), ((Form)this.TopLevelControl).MdiChildren, ofset, _parentFormType);
          Cursor = selectionInside ? Cursors.SizeAll : Cursors.No;
        }
      }
      else
      {
        this.Cursor = Cursors.SizeAll;
        direction = Direction.None;
      }
    }

    private void picBoxTag_MouseDown(object sender, MouseEventArgs e)
    {
      if (ShowPropertiesRequest != null)
        ShowPropertiesRequest(ChildControl, picBoxTag.PointToScreen(e.Location));
    }

    private void picBoxTag_MouseLeave(object sender, EventArgs e)
    {
      picBoxTag.Cursor = Cursors.Default;
    }

    private void picBoxTag_MouseHover(object sender, EventArgs e)
    {
      picBoxTag.Cursor = Cursors.Hand;
    }

    private void ChildControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      if (e.Shift)
      {
        switch (e.KeyCode)
        {
          case Keys.Up:
            this.Height--;
            break;
          case Keys.Down:
            this.Height++;
            break;
          case Keys.Right:
            this.Width++;
            break;
          case Keys.Left:
            this.Width--;
            break;
        }
      }
      else
      {
        Rectangle rc = this.Bounds;
        int step = 1;
        if (e.Control)
          step = 20;
        switch (e.KeyCode)
        {
          case Keys.Up:
            rc.Y -= step;
            break;
          case Keys.Down:
            rc.Y += step;
            break;
          case Keys.Right:
            rc.X += step;
            break;
          case Keys.Left:
            rc.X -= step;
            break;
        }
        Point diff = new Point(rc.Location.X - this.Bounds.Location.X, rc.Location.Y - this.Bounds.Location.Y);
        SetAllSelectionLocation(this.Parent, CreatedSelections, diff);
      }
    }
    #endregion

    #region Subs
    public static void BringFront()
    {
      CreatedSelections.ForEach(sel1 =>
      {
        sel1.BringToFront();
      });
    }

    public static void SendBack()
    {
      CreatedSelections.ForEach(sel1 =>
      {
        sel1.SendToBack();
      });
    }

    public static void RemoveSelection(Control childControl)
    {
      Selection foundSel = CreatedSelections.First(sel => sel.ChildControl == childControl);
      RemoveChild(foundSel);
      CreatedSelections.Remove(foundSel);
      foundSel.Dispose();
    }

    /// <summary>
    /// For delete selection controls from parent also contained controls
    /// </summary>
    /// <param name="parent"></param>
    public static void RemoveAllSelection(Control parent)
    {
      List<Selection> selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).ToList();
      foreach (Selection sel in selList)
      {
        sel.ChildControl.Visible = false;
        RemoveChild(sel);
        CreatedSelections.Remove(sel);
        sel.ChildControl.Visible = true;
        sel.Dispose();
      }
    }

    public static void RemoveAllExcept(Selection selection)
    {
      List<Selection> selList = CreatedSelections.Where(sel => sel.Parent == selection.Parent && sel != selection).ToList();
      foreach (Selection sel in selList)
      {
        RemoveChild(sel);
        CreatedSelections.Remove(sel);
        sel.Dispose();
      }
    }

    public static void AddSelections(List<Control> controlList, Control parent, List<Control> allControlList, Type parentFormType)
    {
      foreach (Control ctrl in controlList)
      {
        Selection sel = new Selection(ctrl, parent, Point.Empty, allControlList, parentFormType, true);
      }
    }

    public static void DeleteSelectedChilds(Control parent, List<Control> allControlList)
    {
      List<Selection> selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).ToList();
      foreach (Selection sel in selList)
      {
        CreatedSelections.Remove(sel);
        RecursiveClearControlList(sel.ChildControl, allControlList);
        sel.ChildControl.Dispose();
        sel.Dispose();
      }
    }
    /// <summary>
    /// For clean all control list
    /// </summary>
    /// <param name="control"></param>
    public static void RecursiveClearControlList(Control control, List<Control> AllControlList)
    {
      foreach (Control ctrl in control.Controls)
        RecursiveClearControlList(ctrl, AllControlList);
      AllControlList.Remove(control);
      control.Dispose();
    }

    /// <summary>
    /// Get list of Selected controls
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static List<Control> GetSelectedControls(Control parent)
    {
      List<Selection> selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).ToList();
      List<Control> ctrlList = new List<Control>();
      foreach (Selection sel in selList)
      {
        List<Control> tmpLst = new List<Control>();
        ctrlList.Add(sel.ChildControl);
        GetRecursiveSelList(sel.ChildControl, ref tmpLst);
        ctrlList.AddRange(tmpLst);
      }
      return ctrlList;
    }

    private static void GetRecursiveSelList(Control control, ref List<Control> controls)
    {
      foreach (Control ctrl in control.Controls)
      {
        controls.Add(ctrl);
        GetRecursiveSelList(ctrl, ref controls);
      }
    }

    public static void AlignSelection(Control parent, Aligment align)
    {
      int first = 0;
      List<Selection> selList = CreatedSelections.Where(sel => sel.ParentForm == parent).ToList();
      foreach (Selection sel in selList)
      {
        switch (align)
        {
          case Aligment.Left:
            if (selList.IndexOf(sel) == 0)
              first = sel.Left;
            else
              sel.Left = first;
            break;
          case Aligment.Right:
            if (selList.IndexOf(sel) == 0)
              first = sel.Left + sel.Width;
            else
              sel.Left = first - sel.Width;
            break;
          case Aligment.VerticalCenter:
            if (selList.IndexOf(sel) == 0)
              first = sel.Left + sel.Width / 2;
            else
              sel.Left = first - sel.Width / 2;
            break;
          case Aligment.Top:
            if (selList.IndexOf(sel) == 0)
              first = sel.Top;
            else
              sel.Top = first;
            break;
          case Aligment.Bottom:
            if (selList.IndexOf(sel) == 0)
              first = sel.Top + sel.Height;
            else
              sel.Top = first - sel.Height;
            break;
          case Aligment.HorizontalCenter:
            if (selList.IndexOf(sel) == 0)
              first = sel.Top + sel.Height / 2;
            else
              sel.Top = first - sel.Height / 2;
            break;
        }
      }
    }

    public static void MakeSameSize(Control parent, MakeSameSizes enumSize)
    {
      int firstHeight = 0;
      int firstWidth = 0;
      List<Selection> selList = CreatedSelections.Where(sel => sel.ParentForm == parent).ToList();
      foreach (Selection sel in selList)
      {
        switch (enumSize)
        {
          case MakeSameSizes.Height:
            if (selList.IndexOf(sel) == 0)
              firstHeight = sel.Height;
            else
              sel.Height = firstHeight;
            break;
          case MakeSameSizes.Width:
            if (selList.IndexOf(sel) == 0)
              firstWidth = sel.Width;
            else
              sel.Width = firstWidth;
            break;
          case MakeSameSizes.All:
            if (selList.IndexOf(sel) == 0)
            {
              firstWidth = sel.Width;
              firstHeight = sel.Height;
            }
            else
            {
              sel.Width = firstWidth;
              sel.Height = firstHeight;
            }
            break;
        }
        Rectangle rec = sel.ClientRectangle;
        rec.Inflate(-DRAG_HANDLE_SIZE, -DRAG_HANDLE_SIZE);
        sel.ChildControl.Size = rec.Size;
        sel.ChildControl.Invalidate();
      }
    }

    public static void CutSelectedChilds(Control parent, List<Control> allControlList)
    {
      CopySelectedChilds(parent, allControlList);
      DeleteSelectedChilds(parent, allControlList);
    }

    public static void CopySelectedChilds(Control parent, List<Control> allControlList)
    {
      if (CreatedSelections.Count != 0)
      {
        copiedControls.ForEach(ctrl => ctrl.Dispose());
        copiedControls.Clear();
        CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).ToList().ForEach(sel1 =>
        {
          Control ctrl;
          RecursiveCopyControl(sel1.ChildControl, out ctrl, parent, allControlList);
          Rectangle rec = sel1.Bounds;
          rec.Inflate(-DRAG_HANDLE_SIZE, -DRAG_HANDLE_SIZE);
          ctrl.Location = rec.Location;
          ctrl.Parent = null;
          copiedControls.Add(ctrl);
          ctrl.Visible = false;
        });
      }
    }

    public static void PasteSelectedChilds(Control parent, bool useCopyLocation, bool clearCopyMem, List<Control> allControlList, Type parentFormType)
    {
      PasteSelectedChilds(parent, useCopyLocation, allControlList, parentFormType);
      if (clearCopyMem)
      {
        copiedControls.ForEach(ctrl => ctrl.Dispose());
        copiedControls.Clear();
      }
    }

    public static void PasteSelectedChilds(Control parent, bool useCopyLocation, List<Control> allControlList, Type parentFormType)
    {
      RemoveAllSelection(parent);
      foreach (Control copyCtrl in copiedControls)
      {
        Control ctrl;
        RecursiveCopyControl(copyCtrl, out ctrl, parent, allControlList, true);

        if (ctrl != null)
        {
          //ctrl.Name = ctrl.GetType().ToString() + parent.Controls.Count.ToString();
          Point nextPosition = Point.Empty;
          if (!useCopyLocation)
            nextPosition = ctrl.PointToClient(MousePosition);
          Selection sel1 = new Selection(ctrl, parent, new Point(-nextPosition.X - DRAG_HANDLE_SIZE, -nextPosition.Y - DRAG_HANDLE_SIZE), allControlList, parentFormType, true);
          if (sel1.picBoxMove != null)
          {
            if (useCopyLocation)
              sel1.MouseDownLocation = new Point(-3 * DRAG_HANDLE_SIZE, -DRAG_HANDLE_SIZE);
            sel1.picBoxMove.Capture = true;
          }
          else
          {
            if (useCopyLocation)
              sel1.MouseDownLocation = new Point(-sel1.Width / 2, -sel1.Height / 2);
            sel1.ChildControl.Capture = true;
          }
          sel1.BringToFront();
        }
      }
    }

    public static void MakeSpaceEqual(Control parent, MakeSameSpace way)
    {
      List<Selection> selList = new List<Selection>();
      if (way == MakeSameSpace.Horizontal)
        selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).OrderBy(ss => ss.Left).ToList();
      else
        selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).OrderBy(ss => ss.Top).ToList();
      int totalSpace = 0;
      int index;
      if (selList.Count > 1)
      {
        if (way == MakeSameSpace.Horizontal)
        {
          foreach (Selection sl in selList)
          {
            index = selList.IndexOf(sl) + 1;
            totalSpace += selList[index].Left - (sl.Left + sl.Width);
            if (index == (selList.Count - 1))
              break;
          }
          if (totalSpace < 0) totalSpace = 0;
          foreach (Selection sl in selList)
          {
            index = selList.IndexOf(sl) + 1;
            selList[index].Left = sl.Left + sl.Width + totalSpace / (selList.Count - 1);
            if (index == (selList.Count - 1))
              break;
          }
        }
        else
        {
          foreach (Selection sl in selList)
          {
            index = selList.IndexOf(sl) + 1;
            totalSpace += selList[index].Top - (sl.Top + sl.Height);
            if (index == (selList.Count - 1))
              break;
          }
          if (totalSpace < 0) totalSpace = 0;
          foreach (Selection sl in selList)
          {
            index = selList.IndexOf(sl) + 1;
            selList[index].Top = sl.Top + sl.Height + totalSpace / (selList.Count - 1);
            if (index == (selList.Count - 1))
              break;
          }
        }
      }
    }

    public static void AdjustSpacing(Control parent, SpaceAdjustment way)
    {
      List<Selection> selList = new List<Selection>();
      if (way == SpaceAdjustment.IncreaseHorzSpace || way == SpaceAdjustment.DecreaseHorzSpace || way == SpaceAdjustment.RemoveHorzSpace)
        selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).OrderBy(ss => ss.Left).ToList();
      else
        selList = CreatedSelections.Where(sel => sel.Parent == parent || sel.ParentForm == parent).OrderBy(ss => ss.Top).ToList();
      if (selList.Count > 1)
      {
        int index;
        int step = 5;
        foreach (Selection sl in selList)
        {
          index = selList.IndexOf(sl) + 1;
          if (way == SpaceAdjustment.IncreaseHorzSpace)
            selList[index].Left = selList[index].Left + index * step;
          if (way == SpaceAdjustment.DecreaseHorzSpace)
            selList[index].Left = selList[index].Left - index * step;
          if (way == SpaceAdjustment.RemoveHorzSpace)
            selList[index].Left = sl.Left + sl.Width;
          if (way == SpaceAdjustment.IncreaseVertSpace)
            selList[index].Top = selList[index].Top + index * step;
          if (way == SpaceAdjustment.DecreaseVertSpace)
            selList[index].Top = selList[index].Top - index * step;
          if (way == SpaceAdjustment.RemoveVertSpace)
            selList[index].Top = sl.Top + sl.Height;
          if (index == (selList.Count - 1))
            break;
        }
      }
    }

    /// <summary>
    /// For calculate new position and new size also change parent to mdi
    /// for null parentForm Return Client Rec
    /// If control type is a GaugeBase it use WidthHeightRatio otherwise WidthHeightRatio=0
    /// </summary>
    /// <param name="control"></param>
    /// <param name="direction"></param>
    /// <param name="mousePosition"></param>
    /// <param name="mouseOfset"></param>
    /// <param name="minSize"></param>
    /// <returns></returns>
    public static Rectangle GetNewPosRec(Control control, Direction direction, Point mousePosition, Point mouseOfset, Size minSize)
    {
      float WidthHeightRatio = 0;
      Type t = ((Selection)control).ChildControl.GetType();
      if (t.BaseType == typeof(AnalogBase))
        WidthHeightRatio = (((AnalogBase)((Selection)control).ChildControl)).WidthHeightRatio;
      if (t.BaseType == typeof(DigitalBase))
        WidthHeightRatio = (((DigitalBase)((Selection)control).ChildControl)).WidthHeightRatio;
      Rectangle clientRec = control.Bounds;
      Point newLocation;
      Size newSize;
      if (control.Parent == null) return clientRec;
      Point pos = control.Parent.PointToClient(mousePosition);
      switch (direction)
      {
        case Direction.NW:
          //north west, location and width, height change
          newLocation = pos;
          newSize = new Size(clientRec.Size.Width - (newLocation.X - clientRec.Location.X), clientRec.Size.Height - (newLocation.Y - clientRec.Location.Y));
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithMaxOne);
          newLocation = new Point(clientRec.Location.X - (newSize.Width - clientRec.Size.Width), clientRec.Location.Y - (newSize.Height - clientRec.Size.Height));
          break;
        case Direction.SE:
          //south east, width and height change
          newLocation = pos;
          newSize = new Size(clientRec.Size.Width + (newLocation.X - clientRec.Size.Width - clientRec.Location.X), clientRec.Height + (newLocation.Y - clientRec.Height - clientRec.Location.Y));
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithMaxOne);
          newLocation = clientRec.Location;
          break;
        case Direction.N:
          //north, location and height change
          newLocation = new Point(clientRec.Location.X, pos.Y);
          newSize = new Size(clientRec.Width, clientRec.Height - (pos.Y - clientRec.Location.Y));
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithVertical);
          newLocation = new Point(clientRec.Location.X - (newSize.Width - clientRec.Size.Width), clientRec.Location.Y - (newSize.Height - clientRec.Size.Height));
          //clientRec.Location = newLocation;
          break;
        case Direction.S:
          //south, only the height changes
          newLocation = clientRec.Location;
          newSize = new Size(clientRec.Width, pos.Y - clientRec.Location.Y);
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithVertical);
          break;
        case Direction.W:
          //west, location and width will change
          newLocation = new Point(pos.X, clientRec.Location.Y);
          newSize = new Size(clientRec.Width - (pos.X - clientRec.Location.X), clientRec.Height);
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithHorizantal);
          newLocation = new Point(clientRec.Location.X - (newSize.Width - clientRec.Size.Width), clientRec.Location.Y - (newSize.Height - clientRec.Size.Height));
          break;
        case Direction.E:
          //east, only width changes
          newLocation = clientRec.Location;
          newSize = new Size(pos.X - clientRec.Location.X, clientRec.Height);
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithHorizantal);
          break;
        case Direction.SW:
          //south west, location, width and height change
          newLocation = new Point(pos.X, clientRec.Location.Y);
          newSize = new Size(clientRec.Width - (pos.X - clientRec.Location.X), pos.Y - clientRec.Location.Y);
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithMaxOne);
          newLocation = new Point(clientRec.Location.X - (newSize.Width - clientRec.Size.Width), clientRec.Location.Y);
          break;
        case Direction.NE:
          //north east, location, width and height change
          newLocation = new Point(clientRec.Location.X, pos.Y);
          newSize = new Size(pos.X - clientRec.Location.X, clientRec.Height - (pos.Y - clientRec.Location.Y));
          newSize = RateSize(newSize, WidthHeightRatio, RateSelection.WithMaxOne);
          newLocation = new Point(clientRec.Location.X, clientRec.Location.Y - (newSize.Height - clientRec.Size.Height));
          break;
        default:
          Point nextPosition;
          nextPosition = control.Parent.PointToClient(mousePosition);
          nextPosition.Offset(mouseOfset);
          newLocation = nextPosition;
          newSize = clientRec.Size;
          break;
      }
      if (newSize.Width < minSize.Width || newSize.Height < minSize.Height)
        return control.Bounds;
      else
      {
        return new Rectangle(newLocation, newSize);
      }
    }

    /// <summary>
    /// For copy control with its childs
    /// </summary>
    /// <param name="sourceControl"></param>
    /// <param name="targetControl"></param>
    /// <param name="parent"></param>
    /// <param name="makeVisible">During to copy control visible set to false if you paste control you must be set true</param>
    private static void RecursiveCopyControl(Control sourceControl, out Control targetControl, Control parent, List<Control> AllControlList, bool makeVisible = false)
    {
      if (sourceControl != null)
      {
        List<string> testlist = new List<string>();
        AllControlList.ForEach(t => { testlist.Add(t.Name); });
        Type ctrltype = sourceControl.GetType();
        targetControl = (Control)Activator.CreateInstance(ctrltype);
        CopyProperties(targetControl, sourceControl);
        if (makeVisible)
        {
          testlist.Clear();
          AllControlList.ForEach(t => { testlist.Add(t.Name); });
          targetControl.Name = Functions.GetIndexedName(targetControl.GetType(), AllControlList);
          AllControlList.Add(targetControl); //makeVisible mean control added.
          testlist.Clear();
          AllControlList.ForEach(t => { testlist.Add(t.Name); });
          targetControl.Visible = makeVisible;
        }
        targetControl.Size = sourceControl.Size;
        targetControl.Parent = parent;
        if (Functions.IsContainer(sourceControl))
        {
          foreach (Control ctrl in sourceControl.Controls)
          {
            Control newControl;
            RecursiveCopyControl(ctrl, out newControl, targetControl, AllControlList, makeVisible);
          }
        }
      }
      else
        targetControl = null;
    }

    /// <summary>
    /// To Copy Properties from source to target control
    /// </summary>
    /// <param name="targetControl"></param>
    /// <param name="sourceControl"></param>
    private static void CopyProperties(Control targetControl, Control sourceControl)
    {
      List<PropertyInfo> properties = sourceControl.GetType().GetProperties().ToList();
      foreach (PropertyInfo myProperty in properties)
      {
        //TODO: TabControl de padding de hata veriyor geçici olarak alt satırdaki if bloğunu koydum.Başka problem çıkarabilir.
        if (myProperty.Name != "Padding" && myProperty.Name != "ChannelName")
        {
          PropertyInfo prop = targetControl.GetType().GetProperty(myProperty.Name, BindingFlags.Public | BindingFlags.Instance);
          if (null != prop && prop.CanWrite && prop.Name != "WindowTarget" && prop.Name != "ActiveControl" && prop.Name != "Cursor")
            prop.SetValue(targetControl, myProperty.GetValue(sourceControl, null), null);
        }
      }
    }

    /// <summary>
    /// To aply ratio for controls
    /// </summary>
    /// <param name="size"></param>
    /// <param name="WidthHeightRatio"></param>
    /// <param name="rateSelection"></param>
    /// <returns></returns>
    private static Size RateSize(Size size, float WidthHeightRatio, RateSelection rateSelection)
    {
      if (WidthHeightRatio != 0)
      {
        if (rateSelection == RateSelection.WithHorizantal)
          size.Height = (int)(size.Width / WidthHeightRatio);
        else if (rateSelection == RateSelection.WithVertical)
          size.Width = (int)(size.Height * WidthHeightRatio);
        else if (rateSelection == RateSelection.WithMaxOne)
        {
          if (size.Width > size.Height)
            size.Height = (int)(size.Width / WidthHeightRatio);
          else
            size.Width = (int)(size.Height * WidthHeightRatio);
        }
      }
      return size;
    }

    /// <summary>
    /// For move all selected controls
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="selList"></param>
    /// <param name="delta"></param>
    private static void SetAllSelectionLocation(Control parent, List<Selection> selList, Point delta)
    {
      if (delta != Point.Empty)
      {
        foreach (Selection sel in CreatedSelections)
        {
          if (sel.Parent == parent)
          {
            Rectangle rec = sel.Bounds;
            rec.Offset(delta);
            sel.Location = rec.Location;
          }
        }

      }
    }

    private static void RemoveChild(Selection selection)
    {
      selection.ChildControl.Parent = selection.Parent;
      Rectangle rec = selection.Bounds;
      rec.Inflate(-DRAG_HANDLE_SIZE, -DRAG_HANDLE_SIZE);
      selection.ChildControl.Bounds = rec;
      selection.ChildControl.BringToFront();
    }
    /// <summary>
    /// Find control position with mouse location
    /// </summary>
    /// <param name="frm"></param>
    /// <param name="mousePosition"></param>
    /// <param name="mouseOfset"></param>
    /// <returns></returns>
    private Point FindControlRelativePosition(Control frm, Point mousePosition, Point mouseOfset)
    {
      if (frm != null)
      {
        Point nextPosition = new Point();
        nextPosition = frm.PointToClient(mousePosition);
        nextPosition.Offset(mouseOfset);
        return nextPosition;
      }
      else
        return new Point(0, 0);
    }

    private Cursor FindDirectionAndCursor(Point loc, out Direction direction, Dictionary<GrapHandleRecs, Rectangle> GrapRectangles)
    {
      Cursor Cursor;
      if (CheckLocation(GrapRectangles[GrapHandleRecs.NW], loc))
      {
        direction = Direction.NW;
        Cursor = Cursors.SizeNWSE;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.N], loc))
      {
        direction = Direction.N;
        Cursor = Cursors.SizeNS;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.NE], loc))
      {
        direction = Direction.NE;
        Cursor = Cursors.SizeNESW;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.W], loc))
      {
        direction = Direction.W;
        Cursor = Cursors.SizeWE;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.E], loc))
      {
        direction = Direction.E;
        Cursor = Cursors.SizeWE;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.SW], loc))
      {
        direction = Direction.SW;
        Cursor = Cursors.SizeNESW;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.S], loc))
      {
        direction = Direction.S;
        Cursor = Cursors.SizeNS;
      }
      else if (CheckLocation(GrapRectangles[GrapHandleRecs.SE], loc))
      {
        direction = Direction.SE;
        Cursor = Cursors.SizeNWSE;
      }
      else
      {
        direction = Direction.None;
        Cursor = Cursors.SizeAll;
      }
      return Cursor;
    }

    private bool CheckLocation(Rectangle controlArea, Point pos)
    {
      return ((controlArea.X <= pos.X) && ((controlArea.X + controlArea.Width) >= pos.X)) && ((controlArea.Y <= pos.Y) && ((controlArea.Y + controlArea.Height) >= pos.Y));
    }

    /// <summary>
    /// To check control inside form with current location
    /// If selectList or formlist count is zero return false
    /// </summary>
    /// <param name="selectList"></param>
    /// <param name="formList"></param>
    /// <returns></returns>
    private bool CheckControlLocation(List<Selection> selectList, Form[] formList, Point mdiOfset, Type parentFormType)
    {
      if (selectList.Count == 0 || formList.Length == 0)
        return false;
      List<Form> sortedFormlist = new List<Form>();  // Active form index making 0 for checking first.
      sortedFormlist.Add(formList[0].MdiParent.ActiveMdiChild);
      foreach (Form frm in formList)
      {
        if (frm != frm.MdiParent.ActiveMdiChild && frm.GetType() == parentFormType)
          sortedFormlist.Add(frm);
      }
      bool insidecheck = true;
      foreach (Form frm in sortedFormlist)
      {
        insidecheck = true;
        Rectangle rec = frm.Bounds;
        Point temp = (Point)(rec.Size - frm.ClientSize);
        rec.Offset(temp.X / 2, temp.Y - temp.X / 2);
        rec.Size = rec.Size - (Size)temp;
        rec.Offset(mdiOfset); //To calculate mdi client area
        foreach (Selection sel in selectList)
          sel.ControlInside = rec.Contains(sel.Bounds);
        selectList.ForEach(sel1 => insidecheck = sel1.ControlInside && insidecheck);
        if (insidecheck)
        {
          Control ctrl = null;
          CheckControlInsideContainer(this, ((Form)this.Parent).ActiveMdiChild, ref ctrl);
          if(ctrl != null)
          {
            Rectangle rec1 = ctrl.ClientRectangle;
            rec.Inflate(-100,-100);
            ControlPaint.DrawContainerGrabHandle(ctrl.CreateGraphics(), ctrl.ClientRectangle);
            //ControlPaint.DrawFocusRectangle(ctrl.CreateGraphics(), ctrl.ClientRectangle ,Color.Blue,Color.White);
          }
            

          if (ctrl == null && _oldParent != null)
          {
            _oldParent.Invalidate();
            _oldParent = null;
          }
          if (ctrl != null && ctrl != _oldParent)
          {
            if (_oldParent != null)
              _oldParent.Invalidate();
            _oldParent = ctrl;
          }

          frm.Activate();
          break;
        }
      }
      return insidecheck;
    }

    private static Point ConvertPointControlToControl(Control current, Control target, Point point)
    {
      return target.PointToClient(current.PointToScreen(point));
    }

    private static Rectangle ConvertRectangleControlToControl(Control current, Control target, Rectangle rectangle)
    {
      return target.RectangleToClient(current.RectangleToScreen(rectangle));
    }

    private static void SetNewParentWithPosition(Control oldParent, Control newParent)
    {
      foreach (Selection sel in CreatedSelections)
      {

        if (sel.Parent == oldParent && sel.Parent != newParent)
        {
          //sel.ChildControl.Visible = false;
          sel.Parent = newParent;
          sel.Location = ConvertPointControlToControl(oldParent, newParent, sel.Location);
          //sel.ChildControl.Visible = true;
        }
      }
    }

    private void SetAllParentOldPosition(Control currentParent)
    {
      foreach (Selection sel in CreatedSelections)
      {
        if (sel.Parent == currentParent)
        {
          if (sel.LeftControl != null)
          {
            sel.Parent = sel.LeftControl;
            sel.Location = sel.LeftPosition;
          }
        }
      }
    }

    private void InitPicBox(ref PictureBox picbox, Bitmap backPicture)
    {
      picbox = new PictureBox();
      picbox.Parent = this;
      picbox.SizeMode = PictureBoxSizeMode.StretchImage;
      picbox.Image = backPicture;
      picbox.Size = new Size(2 * DRAG_HANDLE_SIZE, 2 * DRAG_HANDLE_SIZE);
      picbox.BringToFront();
    }

    /// <summary>
    /// To draw selection border and graphandle rectangle
    /// </summary>
    /// <param name="control"></param>
    /// <param name="g"></param>
    /// <param name="dragHandleSize"></param>
    /// <param name="GraphRectangles"></param>
    private void DrawControlBorder(Control control, Graphics g, int dragHandleSize, ref Dictionary<GrapHandleRecs, Rectangle> GraphRectangles)
    {
      Rectangle Border = control.ClientRectangle;
      Border.Inflate(-dragHandleSize / 2, -dragHandleSize / 2);
      GraphRectangles[GrapHandleRecs.NW] = new Rectangle(0, 0, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.N] = new Rectangle(control.Width / 2 - dragHandleSize / 2, 0, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.NE] = new Rectangle(control.Width - dragHandleSize, 0, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.W] = new Rectangle(0, control.Height / 2 - dragHandleSize / 2, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.E] = new Rectangle(control.Width - dragHandleSize, control.Height / 2 - dragHandleSize / 2, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.SW] = new Rectangle(0, control.Height - dragHandleSize, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.S] = new Rectangle(control.Width / 2 - dragHandleSize / 2, control.Height - dragHandleSize, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.SE] = new Rectangle(control.Width - dragHandleSize, control.Height - dragHandleSize, dragHandleSize, dragHandleSize);
      GraphRectangles[GrapHandleRecs.Move] = new Rectangle(2 * dragHandleSize, 0, 2 * dragHandleSize, 2 * dragHandleSize);
      GraphRectangles[GrapHandleRecs.Tags] = new Rectangle(control.Width - 4 * dragHandleSize, 0, 2 * dragHandleSize, 2 * dragHandleSize);
      //new Rectangle(2 * dragHandleSize, 0, 2 * dragHandleSize, 2 * dragHandleSize);
      ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.NW], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.N], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.NE], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.W], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.E], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.SW], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.S], true, true);
      ControlPaint.DrawGrabHandle(g, GraphRectangles[GrapHandleRecs.SE], true, true);
      if (Functions.IsContainer(ChildControl))
        picBoxMove.Bounds = GraphRectangles[GrapHandleRecs.Move];
      picBoxTag.Bounds = GraphRectangles[GrapHandleRecs.Tags];

    }
    #endregion
  }
}
