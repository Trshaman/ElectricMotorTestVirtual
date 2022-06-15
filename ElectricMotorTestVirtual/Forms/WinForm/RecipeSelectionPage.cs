using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricMotorTestVirtual.Forms.WinForm
{
    public partial class RecipeSelectionPage : Form
    {
        private TestRecipeSettings _testRecipeSettings;
        public RecipeSelectionPage()
        {
            InitializeComponent();
        }

        private void AddRecipe_Click(object sender, EventArgs e)
        {
            if (_testRecipeSettings == null)
            {
                _testRecipeSettings = new TestRecipeSettings();
                _testRecipeSettings.HandleDestroyed += (object send, EventArgs e2) => { _testRecipeSettings = null; };
               // _testRecipeSettings.MdiParent = this;
                _testRecipeSettings.Show();
            }
            else
            {
                _testRecipeSettings.Focus();
            }
        }
    }
}
