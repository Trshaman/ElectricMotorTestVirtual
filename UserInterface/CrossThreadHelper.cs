using NumericTextBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.GraphPlotter;

namespace UserInterface
{
  public static class CrossThreadHelper
  {
    delegate void SetControlOfEnableCallback(bool enable, Control control);
    delegate void SetControlOfVisibleCallback(bool visible, Control control);
    delegate void SetControlOfTextCallback(string text, Control control);
    delegate string ReadControlOfTextCallback(string text, Control control);
    delegate void AddRowToDataGridViewCallback(object[] values, DataGridView grid);
    delegate void RemoveControlFromDataGridViewCallback(Control control, DataGridView grid);
    delegate void SetCheckBoxStateCallback(bool value, CheckBox ctrl);
    delegate void SetValueOfProgressBarCallback(ProgressBar control, int value);
    delegate void SetComboBoxIndexCallback(ComboBox comboBox, int index);
    delegate void ClearRowDataGridViewCallback(DataGridView grid);
    delegate void SetCellValueDataGridViewCallback(DataGridView dataGridView, object value, int colIndex, int rowIndex);
    delegate void CloseFormCallback(Form frm);
    delegate void SetToggleSwitchValueCallback(ToggleSwitch toggleSwitch, bool value);
    delegate void SetLedDisplayCallback(bool value, LedDisplay led);
    delegate void SetTrackBarPropertiesCallback(TrackBar trackbar, int maximum, int minumum, int tickFrequency);
    delegate void SetControlOfFocusCallback(Control control);
    delegate void GraphUpdateCallBack(RealTimeGraph realTimeGraph, string curvename, float Xval, float Yval, bool markpoint, bool clear);
    delegate void SetImageOfToolStripItemCallback(ToolStrip strip, ToolStripItem item, Image image);
    delegate void SetTextOfToolStripItemCallback(ToolStrip strip, ToolStripItem item, string text);
    delegate void SetTextOfToolStripStatusLabelCallback(StatusStrip strip, ToolStripStatusLabel label, string text);
    delegate void SetEnableOfToolStripItemCallback(ToolStrip strip, ToolStripItem item, bool enabled);
    delegate void SetFormOfWindowStateCallback(Form form, FormWindowState formWindowState);



    delegate void BringToFrontControlCallback(Control control);
    delegate void ClearComboboxItemsCallback(ComboBox comboBox);
    delegate void AddComboboxItemCallback(ComboBox comboBox, object item);
    delegate void RemoveComboboxItemCallback(ComboBox comboBox, object item);
    delegate void ClearListboxItemsCallback(ListBox Listbox);
    delegate void AddListboxItemCallback(ListBox Listbox, object item);
    delegate void RemoveListboxItemCallback(ListBox Listbox, object item);
    delegate void SetListboxSelectedIndexCallback(ListBox Listbox, int selectedIndex);
    delegate void SetControlOfCursorCallback(Control control, Cursor cursor);
    delegate void ShowMessageBoxCallback(Control owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    delegate void SetNumericControlOfValueCallback(NumericUpDown control, decimal value);
    delegate void RemoveControlCallback(Control control, Control removingControl);
    delegate void AddControlCallback(Control control, Control removingControl);
    delegate void ShowFormCallback(Form frm);
    delegate void ClearGraphCallBack(GraphBase graph);
    delegate void SetCheckStateOfToolStripButtonCallback(ToolStrip strip, ToolStripButton toolStripButton, bool checkState);
    delegate void SetEnableOfMultiToolStripItemCallback(ToolStrip strip, ToolStripItem[] items, bool enabled);
    delegate void SetPictureBoxOfImageCallback(Icon icon, PictureBox pictureBox);
    delegate void SetControlOfSizeCallback(Size size, Control control);
    delegate void SetControlOfLeftCallback(int left, Control control);
    delegate void SetControlOfTopCallback(int top, Control control);
    delegate void SetTrackBarOfValueCallback(TrackBar trackBar, int value);



    /// <summary>
    /// Cross set track ber of value
    /// </summary>
    /// <param name="trackBar"></param>
    /// <param name="value"></param>
    public static void SetTrackBarOfValue(TrackBar trackBar, int value)
    {
      if (trackBar.InvokeRequired)
      {
        SetTrackBarOfValueCallback d = new SetTrackBarOfValueCallback(SetTrackBarOfValue);
        trackBar.Invoke(d, new object[] { trackBar, value });
      }
      else
        trackBar.Value = value;
    }

    public static void ClearGraph(GraphBase graph)
    {
      if (graph.InvokeRequired)
      {
        ClearGraphCallBack d = new ClearGraphCallBack(ClearGraph);
        graph.Invoke(d, new object[] { graph });
      }
      else
        graph.Clear();
    }

    public static void ShowForm(Form frm)
    {
      if (frm.InvokeRequired)
      {
        ShowFormCallback d = new ShowFormCallback(ShowForm);
        frm.Invoke(d, new object[] { frm });
      }
      else
        frm.Show();
    }

    public static void SetNumericControlOfValue(NumericUpDown control, decimal value)
    {
      if (control.InvokeRequired)
      {
        SetNumericControlOfValueCallback d = new SetNumericControlOfValueCallback(SetNumericControlOfValue);
        control.Invoke(d, new object[] { control, value });
      }
      else
        control.Value = value;
    }

    public static void SetControlOfCursor(Control control, Cursor cursor)
    {
      if (control.InvokeRequired)
      {
        SetControlOfCursorCallback d = new SetControlOfCursorCallback(SetControlOfCursor);
        control.Invoke(d, new object[] { control, cursor });
      }
      else
        control.Cursor = cursor;
    }

    public static void SetListboxSelectedIndex(ListBox listBox, int selectedIndex)
    {
      if (listBox.InvokeRequired)
      {
        SetListboxSelectedIndexCallback d = new SetListboxSelectedIndexCallback(SetListboxSelectedIndex);
        listBox.Invoke(d, new object[] { listBox, selectedIndex });
      }
      else
        listBox.SelectedIndex = selectedIndex;
    }

    public static void ClearListboxItems(ListBox listBox)
    {
      if (listBox.InvokeRequired)
      {
        ClearListboxItemsCallback d = new ClearListboxItemsCallback(ClearListboxItems);
        listBox.Invoke(d, new object[] { listBox });
      }
      else
        listBox.Items.Clear();
    }

    /// <summary>
    /// Add item to listbox from crossthread
    /// </summary>
    /// <param name="listbox"></param>
    /// <param name="item"></param>
    public static void AddListboxItem(ListBox listbox, object item)
    {
      if (listbox.InvokeRequired)
      {
        AddListboxItemCallback d = new AddListboxItemCallback(AddListboxItem);
        listbox.Invoke(d, new object[] { listbox, item });
      }
      else
        listbox.Items.Add(item);
    }

    /// <summary>
    /// Remove item to listbox from crossthread
    /// </summary>
    /// <param name="listbox"></param>
    /// <param name="item"></param>
    public static void RemoveListboxItem(ListBox listbox, object item)
    {
      if (listbox.InvokeRequired)
      {
        RemoveListboxItemCallback d = new RemoveListboxItemCallback(RemoveListboxItem);
        listbox.Invoke(d, new object[] { listbox, item });
      }
      else
        listbox.Items.Remove(item);
    }


    public static void ClearComboboxItems(ComboBox comboBox)
    {
      if (comboBox.InvokeRequired)
      {
        ClearComboboxItemsCallback d = new ClearComboboxItemsCallback(ClearComboboxItems);
        comboBox.Invoke(d, new object[] { comboBox });
      }
      else
        comboBox.Items.Clear();
    }

    /// <summary>
    /// Add item to combobox from crossthread
    /// </summary>
    /// <param name="comboBox"></param>
    /// <param name="item"></param>
    public static void AddComboboxItem(ComboBox comboBox, object item)
    {
      if (comboBox.InvokeRequired)
      {
        AddComboboxItemCallback d = new AddComboboxItemCallback(AddComboboxItem);
        comboBox.Invoke(d, new object[] { comboBox, item });
      }
      else
        comboBox.Items.Add(item);
    }

    /// <summary>
    /// Remove item to combobox from crossthread
    /// </summary>
    /// <param name="comboBox"></param>
    /// <param name="item"></param>
    public static void RemoveComboboxItem(ComboBox comboBox, object item)
    {
      if (comboBox.InvokeRequired)
      {
        RemoveComboboxItemCallback d = new RemoveComboboxItemCallback(RemoveComboboxItem);
        comboBox.Invoke(d, new object[] { comboBox, item });
      }
      else
        comboBox.Items.Remove(item);
    }

    /// <summary>
    /// Set tool strip status Label text from cross thread.
    /// </summary>
    /// <param name="strip"></param>
    /// <param name="label"></param>
    /// <param name="text"></param>
    public static void SetTextOfToolStripStatusLabel(ToolStrip strip, ToolStripStatusLabel label, string text)
    {
      if (strip.InvokeRequired)
      {
        SetTextOfToolStripStatusLabelCallback d = new SetTextOfToolStripStatusLabelCallback(SetTextOfToolStripStatusLabel);
        strip.Invoke(d, new object[] { strip, label, text });
      }
      else
        label.Text = text;
    }

    /// <summary>
    /// Set toolstrip item text from cross thread.
    /// </summary>
    /// <param name="strip"></param>
    /// <param name="item"></param>
    /// <param name="text"></param>
    public static void SetEnableOfToolStripItem(ToolStrip strip, ToolStripItem item, bool enabled)
    {
      if (strip.InvokeRequired)
      {
        SetEnableOfToolStripItemCallback d = new SetEnableOfToolStripItemCallback(SetEnableOfToolStripItem);
        strip.Invoke(d, new object[] { strip, item, enabled });
      }
      else
      {
        item.Enabled = enabled;
      }
    }

    /// <summary>
    /// Set multi toolstrip items text from cross thread.
    /// </summary>
    /// <param name="strip"></param>
    /// <param name="items"></param>
    /// <param name="text"></param>
    public static void SetEnableOfMultiToolStripItem(ToolStrip strip, ToolStripItem[] items, bool enabled)
    {
      if (strip.InvokeRequired)
      {
        SetEnableOfMultiToolStripItemCallback d = new SetEnableOfMultiToolStripItemCallback(SetEnableOfMultiToolStripItem);
        strip.Invoke(d, new object[] { strip, items, enabled });
      }
      else
      {
        for (int i = 0; i < items.Length; i++)
          items[i].Enabled = enabled;

      }
    }



    /// <summary>
    /// Set toolstrip button checked state.
    /// </summary>
    /// <param name="strip"></param>
    /// <param name="toolStripButton"></param>
    /// <param name="checkState"></param>
    public static void SetCheckStateOfToolStripButton(ToolStrip strip, ToolStripButton toolStripButton, bool checkState)
    {
      if (strip.InvokeRequired)
      {
        SetCheckStateOfToolStripButtonCallback d = new SetCheckStateOfToolStripButtonCallback(SetCheckStateOfToolStripButton);
        strip.Invoke(d, new object[] { strip, toolStripButton, checkState });
      }
      else
      {
        toolStripButton.Checked = checkState;
      }
    }

    /// <summary>
    /// Set toolstrip item text from cross thread.
    /// </summary>
    /// <param name="strip"></param>
    /// <param name="item"></param>
    /// <param name="text"></param>
    public static void SetTextOfToolStripItem(ToolStrip strip, ToolStripItem item, string text)
    {
      if (strip.InvokeRequired)
      {
        SetTextOfToolStripItemCallback d = new SetTextOfToolStripItemCallback(SetTextOfToolStripItem);
        strip.Invoke(d, new object[] { strip, item, text });
      }
      else
      {
        item.Text = text;
      }
    }

    /// <summary>
    /// Set toolstrip item image from cross thread.
    /// </summary>
    /// <param name="strip"></param>
    /// <param name="item"></param>
    /// <param name="image"></param>
    public static void SetImageOfToolStripItem(ToolStrip strip, ToolStripItem item, Image image)
    {
      if (strip.InvokeRequired)
      {

        SetImageOfToolStripItemCallback d = new SetImageOfToolStripItemCallback(SetImageOfToolStripItem);
        strip.Invoke(d, new object[] { strip, item, image });
      }
      else
      {
        item.Image = image;
      }
    }

    /// <summary>
    /// Set focus of a control from cross thread
    /// </summary>
    /// <param name="control"></param>
    public static void SetControlOfFocus(Control control)
    {
      if (control.InvokeRequired)
      {
        SetControlOfFocusCallback d = new SetControlOfFocusCallback(SetControlOfFocus);
        control.Invoke(d, new object[] { control });
      }
      else
      {
        control.Focus();
      }
    }

    /// <summary>
    /// Set some trackbar properties from cross thread
    /// </summary>
    /// <param name="trackbar"></param>
    /// <param name="maximum"></param>
    /// <param name="minumum"></param>
    /// <param name="tickFrequency"></param>
    public static void SetTrackBarProperties(TrackBar trackbar, int maximum, int minumum, int tickFrequency)
    {
      if (trackbar.InvokeRequired)
      {
        SetTrackBarPropertiesCallback d = new SetTrackBarPropertiesCallback(SetTrackBarProperties);
        trackbar.Invoke(d, new object[] { trackbar, maximum, minumum, tickFrequency });
      }
      else
      {
        trackbar.Maximum = maximum;
        trackbar.Minimum = minumum;
        trackbar.TickFrequency = tickFrequency;
      }
    }

    /// <summary>
    /// Set ComboBox selected index from crossthread
    /// </summary>
    /// <param name="comboBox"></param>
    /// <param name="index"></param>
    public static void SetComboBoxIndex(ComboBox comboBox, int index)
    {
      if (comboBox.InvokeRequired)
      {
        SetComboBoxIndexCallback d = new SetComboBoxIndexCallback(SetComboBoxIndex);
        comboBox.Invoke(d, new object[] { comboBox, index });
      }
      else
      {
        comboBox.SelectedIndex = index;
      }
    }

    /// <summary>
    /// To set visible of control at cross thread;
    /// </summary>
    /// <param name="visible"></param>
    /// <param name="ctrl"></param>
    public static void SetControlOfVisible(bool visible, Control ctrl)
    {
      if (ctrl.InvokeRequired)
      {
        SetControlOfVisibleCallback d = new SetControlOfVisibleCallback(SetControlOfVisible);
        ctrl.Invoke(d, new object[] { visible, ctrl });
      }
      else
      {
        ctrl.Visible = visible;
      }
    }

    /// <summary>
    /// To set enable of control at cross thread;
    /// </summary>
    /// <param name="enable"></param>
    /// <param name="control"></param>
    public static void SetControlOfEnable(bool enable, Control control)
    {
      if (control.InvokeRequired)
      {
        SetControlOfEnableCallback d = new SetControlOfEnableCallback(SetControlOfEnable);
        control.Invoke(d, new object[] { enable, control });
      }
      else
      {
        control.Enabled = enable;
      }
    }

    /// <summary>
    /// To set value of ProgressBar at cross thread;
    /// </summary>
    /// <param name="progressBar"></param>
    /// <param name="value"></param>
    public static void SetProgressBarOfValue(ProgressBar progressBar, int value)
    {
      if (progressBar.InvokeRequired)
      {
        SetValueOfProgressBarCallback d = new SetValueOfProgressBarCallback(SetProgressBarOfValue);
        progressBar.Invoke(d, new object[] { progressBar, value });
      }
      else
      {
        progressBar.Value = value;
      }
    }

    /// <summary>
    /// To set text of control at cross thread;
    /// </summary>
    /// <param name="text"></param>
    /// <param name="control"></param>
    public static void SetControlOfText(string text, Control control)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (control.InvokeRequired)
      {
        SetControlOfTextCallback d = new SetControlOfTextCallback(SetControlOfText);
        control.Invoke(d, new object[] { text, control });
      }
      else
      {
        control.Text = text;
      }
    }


    /// <summary>
    ///  Remove a control from control
    /// </summary>
    /// <param name="control"></param>
    /// <param name="removingControl"></param>
    public static void RemoveControl(Control control, Control removingControl)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (control.InvokeRequired)
      {
        RemoveControlCallback d = new RemoveControlCallback(RemoveControl);
        control.Invoke(d, new object[] { control, removingControl });
      }
      else
      {
        control.Controls.Remove(removingControl);
      }
    }

    /// <summary>
    ///  Add a control in a control
    /// </summary>
    /// <param name="control"></param>
    /// <param name="addingControl"></param>
    public static void AddControl(Control control, Control addingControl)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (control.InvokeRequired)
      {
        AddControlCallback d = new AddControlCallback(AddControl);
        control.Invoke(d, new object[] { control, addingControl });
      }
      else
      {
        control.Controls.Add(addingControl);
      }
    }

    /// <summary>
    /// Set check box state from cross thread.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="ctrl"></param>
    public static void SetCheckBoxState(bool value, CheckBox ctrl)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (ctrl.InvokeRequired)
      {
        SetCheckBoxStateCallback d = new SetCheckBoxStateCallback(SetCheckBoxState);
        ctrl.Invoke(d, new object[] { value, ctrl });
      }
      else
      {
        ctrl.Checked = value;
      }
    }

    /// <summary>
    /// Add Raw values from cross thread
    /// </summary>
    /// <param name="values"></param>
    /// <param name="dataGridView"></param>
    public static void AddRowToDataGridView(object[] values, DataGridView dataGridView)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (dataGridView.InvokeRequired)
      {
        AddRowToDataGridViewCallback d = new AddRowToDataGridViewCallback(AddRowToDataGridView);
        dataGridView.Invoke(d, new object[] { values, dataGridView });
      }
      else
      {
        dataGridView.Rows.Add(values);
      }
    }

    /// <summary>
    /// Remove a control from data grid view
    /// </summary>
    /// <param name="control"></param>
    /// <param name="grid"></param>
    public static void RemoveControlFromDataGridView(Control control, DataGridView grid)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (grid.InvokeRequired)
      {
        RemoveControlFromDataGridViewCallback d = new RemoveControlFromDataGridViewCallback(RemoveControlFromDataGridView);
        grid.Invoke(d, new object[] { control, grid });
      }
      else
      {
        grid.Controls.Remove(control);
      }
    }

    /// <summary>
    /// Clear Datagridview rows from cross thread
    /// </summary>
    /// <param name="dataGridView"></param>
    public static void ClearRowDataGridView(DataGridView dataGridView)
    {
      if (dataGridView.InvokeRequired)
      {
        ClearRowDataGridViewCallback d = new ClearRowDataGridViewCallback(ClearRowDataGridView);
        dataGridView.Invoke(d, new object[] { dataGridView });
      }
      else
      {
        dataGridView.Rows.Clear();
      }
    }
    /// <summary>
    /// Close form from cross thread
    /// </summary>
    /// <param name="form"></param>
    public static void CloseForm(Form form)
    {
      if (form.InvokeRequired)
      {
        CloseFormCallback d = new CloseFormCallback(CloseForm);
        form.Invoke(d, new object[] { form });
      }
      else
        form.Close();
    }

    /// <summary>
    /// Set cell value of data grid view from 
    /// </summary>
    /// <param name="dataGridView"></param>
    /// <param name="value"></param>
    /// <param name="colIndex"></param>
    /// <param name="rowIndex"></param>
    public static void SetCellValueDataGridView(DataGridView dataGridView, object value, int colIndex, int rowIndex)
    {
      if (dataGridView.InvokeRequired)
      {
        SetCellValueDataGridViewCallback d = new SetCellValueDataGridViewCallback(SetCellValueDataGridView);
        dataGridView.Invoke(d, new object[] { dataGridView, value, colIndex, rowIndex });
      }
      else
      {
        dataGridView.Rows[rowIndex].Cells[colIndex].Value = value;
      }
    }

    /// <summary>
    ///  Set toggle switch value from cross thread
    /// </summary>
    /// <param name="toggleSwitch"></param>
    /// <param name="value"></param>
    public static void SetToggleSwitchValue(ToggleSwitch toggleSwitch, bool value)
    {
      if (toggleSwitch.InvokeRequired)
      {
        SetToggleSwitchValueCallback d = new SetToggleSwitchValueCallback(SetToggleSwitchValue);
        toggleSwitch.Invoke(d, new object[] { toggleSwitch, value });
      }
      else
      {
        toggleSwitch.Value = value;
      }
    }

    /// <summary>
    /// Set Ni led value from cross thread
    /// </summary>
    /// <param name="value"></param>
    /// <param name="led"></param>
    public static void SetLedDisplay(bool value, LedDisplay led)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (led.InvokeRequired)
      {
        SetLedDisplayCallback d = new SetLedDisplayCallback(SetLedDisplay);
        led.Invoke(d, new object[] { value, led });
      }
      else
      {
        led.Value = value;
      }
    }

    /// <summary>
    /// Bu sub graph cross thread den update için kullanılmaktadır.
    /// </summary>
    /// <param name="realTimeGraph"></param>
    /// <param name="curvename"></param>
    /// <param name="Xval"></param>
    /// <param name="Yval"></param>
    /// <param name="markpoint"></param>
    public static void UpdateRealTimeGraph(RealTimeGraph realTimeGraph, string curvename, float Xval, float Yval, bool markpoint, bool clear)
    {
      if (realTimeGraph.InvokeRequired)
      {
        GraphUpdateCallBack d = new GraphUpdateCallBack(UpdateRealTimeGraph);
        realTimeGraph.Invoke(d, new object[] { realTimeGraph, curvename, Xval, Yval, markpoint, clear });
      }
      else
      {
        realTimeGraph.AddPoint(curvename, Xval, Yval, markpoint);
        if (clear) realTimeGraph.Clear();
      }
    }

    public static void SetFormOfWindowState(Form form, FormWindowState formWindowState)
    {
      if (form.InvokeRequired)
      {
        SetFormOfWindowStateCallback d = new SetFormOfWindowStateCallback(SetFormOfWindowState);
        form.Invoke(d, new object[] { form, formWindowState });
      }
      else
      {
        form.WindowState = formWindowState;
      }
    }

    public static void BringToFrontControl(Control control)
    {
      if (control.InvokeRequired)
      {
        BringToFrontControlCallback d = new BringToFrontControlCallback(BringToFrontControl);
        control.Invoke(d, new object[] { control });
      }
      else
      {
        control.BringToFront();
      }
    }

    public static void ShowMessageBox(Control owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
      if (owner.InvokeRequired)
      {
        ShowMessageBoxCallback d = new ShowMessageBoxCallback(ShowMessageBox);
        owner.Invoke(d, new object[] { owner, text, caption, buttons, icon });
      }
      else
      {
        MessageBox.Show(owner, text, caption, buttons, icon);
      }
    }

    public static void SetPictureBoxOfImage(Icon icon, PictureBox pictureBox)
    {
      if (pictureBox.InvokeRequired)
      {
        SetPictureBoxOfImageCallback d = new SetPictureBoxOfImageCallback(SetPictureBoxOfImage);
        pictureBox.Invoke(d, new object[] { icon, pictureBox });
      }
      else
      {
        pictureBox.Image = icon.ToBitmap();
      }
    }


    internal static void SetControlOfSize(Size size, Control control)
    {
      if (control.InvokeRequired)
      {
        SetControlOfSizeCallback d = new SetControlOfSizeCallback(SetControlOfSize);
        control.Invoke(d, new object[] { size, control });
      }
      else
      {
        control.Size = size;
      }
    }

    internal static void SetControlOfLeft(int left, Control control)
    {
      if (control.InvokeRequired)
      {
        SetControlOfLeftCallback d = new SetControlOfLeftCallback(SetControlOfLeft);
        control.Invoke(d, new object[] { left, control });
      }
      else
      {
        control.Left = left;
      }
    }

    internal static void SetControlOfTop(int top, Control control)
    {
      if (control.InvokeRequired)
      {
        SetControlOfTopCallback d = new SetControlOfTopCallback(SetControlOfTop);
        control.Invoke(d, new object[] { top, control });
      }
      else
      {
        control.Top = top;
      }
    }
  }
}
