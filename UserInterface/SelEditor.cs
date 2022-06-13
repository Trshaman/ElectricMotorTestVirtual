using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace UserInterface
{
  /// <summary>
  /// This class for add channel list to channel name property
  /// </summary>
  public class SelEditor : UITypeEditor
  {
    //this is a container for strings, which can be picked-out
    ListBox Box1 = new ListBox();
    IWindowsFormsEditorService edSvc;
    //this is a string array for drop-down list
    public static List<Channel> ChannelList;

    public SelEditor()
    {
      Box1.BorderStyle = BorderStyle.None;
      
      //add event handler for drop-down box when item will be selected
      Box1.Click += new EventHandler(Box1_Click);
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.DropDown;
    }

    // Displays the UI for value selection.
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      Box1.ScrollAlwaysVisible = true;
      Box1.HorizontalScrollbar = true;
      Box1.Items.Clear();
      Box1.Items.AddRange(ChannelList.ToArray());
      Box1.Height = 200;
      //Box1.PreferredHeight;
      // Uses the IWindowsFormsEditorService to display a 
      // drop-down UI in the Properties window.
      edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
      if (edSvc != null)
      {
        edSvc.DropDownControl(Box1);
        
        if (Box1.SelectedItem != null)
          return Box1.SelectedItem.ToString();
        else
          return string.Empty;

      }
      return value;
    }

    private void Box1_Click(object sender, EventArgs e)
    {
      edSvc.CloseDropDown();
    }
  }
}
