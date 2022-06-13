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

  public class ExtentedFileNameEditor : UITypeEditor
  {
    private OpenFileDialog ofd;
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.Modal;
    }
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if ((context != null) && (provider != null))
      {
        IWindowsFormsEditorService editorService =
        (IWindowsFormsEditorService)
        provider.GetService(typeof(IWindowsFormsEditorService));
        if (editorService != null)
        {
          ofd = new OpenFileDialog();
          ofd.Filter = "Picture|*.jpg;*.bmp;*.jpeg;*.png|All|*.*";
          ofd.FileName = "";
          if (ofd.ShowDialog() == DialogResult.OK)
          {
            return ofd.FileName.ToString();
          }
        }
      }
      return base.EditValue(context, provider, value);
    }
  }

}
