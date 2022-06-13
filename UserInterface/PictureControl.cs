using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace UserInterface
{
  public partial class PictureControl : UserControl
  {


    private PictureBox _picBox;
    public PictureControl()
    {
      InitializeComponent();
      _picBox = new PictureBox();
      this.Controls.Add(_picBox);
      _picBox.Dock = DockStyle.Fill;
      _picBox.MouseCaptureChanged += (object sender, EventArgs e) => { OnMouseCaptureChanged(e); };
      _picBox.MouseDown += (object sender, MouseEventArgs e) => { this.OnMouseDown(ConvertArgumentToParent(e)); };
      _picBox.MouseEnter += (object sender, EventArgs e) => { OnMouseEnter(e); };
      _picBox.MouseHover += (object sender, EventArgs e) => { OnMouseHover(e); };
      _picBox.MouseLeave += (object sender, EventArgs e) => { OnMouseLeave(e); };
      _picBox.MouseMove += (object sender, MouseEventArgs e) => { this.OnMouseMove(ConvertArgumentToParent(e)); };
      _picBox.MouseUp += (object sender, MouseEventArgs e) => { this.OnMouseUp(ConvertArgumentToParent(e)); };
      _picBox.MouseWheel += (object sender, MouseEventArgs e) => { this.OnMouseWheel(ConvertArgumentToParent(e)); };

    }


    private MouseEventArgs ConvertArgumentToParent(MouseEventArgs e)
    {
      int xTrans = e.X;
      int yTrans = e.Y;
      if (BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
      {
        xTrans += SystemInformation.Border3DSize.Width;
        yTrans += SystemInformation.Border3DSize.Height;
      }
      else if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
      {
        xTrans += SystemInformation.BorderSize.Width;
        yTrans += SystemInformation.BorderSize.Height;
      }
      return new MouseEventArgs(e.Button, e.Clicks, xTrans, yTrans, e.Delta);
    }



    [Localizable(true)]
    [RefreshProperties(RefreshProperties.All)]
    [EditorAttribute(typeof(ExtentedFileNameEditor), typeof(UITypeEditor)), DefaultValue("")]
    public string ImageLocation
    {
      get { return _picBox.ImageLocation; }
      set
      {
        try
        {
          _picBox.ImageLocation = value;
          _picBox.Image = Image.FromFile(value);
        }
        catch
        {
          _picBox.Image = _picBox.ErrorImage;
        }
      }
    }

    [Localizable(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    public PictureBoxSizeMode SizeMode
    {
      get { return _picBox.SizeMode; }
      set { _picBox.SizeMode = value; }
    }

    public new BorderStyle BorderStyle
    {
      get { return _picBox.BorderStyle; }
      set { _picBox.BorderStyle = value; }
    }

  }



}
