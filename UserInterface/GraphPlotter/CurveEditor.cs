using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace UserInterface.GraphPlotter
{
  internal class CurveEditor : UITypeEditor
  {
    //this is a string array for drop-down list
    public static List<Channel> ChannelList { get; set; }
    public static RealTimeGraph EditedGraph { get; set; }
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.Modal;
    }
    public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
    {
      IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
      List<string> chList = value as List<string>;
      if (svc != null && EditedGraph != null)
      {
        using (frmCurvesSettings form = new frmCurvesSettings())
        {
          form.EditedGraph = EditedGraph;
          form.EditedGraph.ChannelName = chList;
          form.ChannelList = ChannelList;
          if (svc.ShowDialog(form) == DialogResult.OK)
          {
            EditedGraph = form.EditedGraph; // update object
            value = form.EditedGraph.ChannelName;
          }
        }
      }
      return value; // can also replace the wrapper object here
    }
  }
}
