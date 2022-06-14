
using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;





//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

namespace ElectricMotorTestVirtual.Forms.WinForm
{
    public partial class MainScreen : Form
    {
        private ComSettingsPage _settingsPage;
        private MainOperatorUI _mainOperatorUI;
        private frmLog _frmLog;
        private RecipeSelectionPage _recipeSelectionPage;


        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void testSayfasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_mainOperatorUI == null)
            {
                _mainOperatorUI = new MainOperatorUI();
                _mainOperatorUI.HandleDestroyed += (object send, EventArgs e2) => { _mainOperatorUI = null; };
                _mainOperatorUI.Show();
            }
            else
            {
                _mainOperatorUI.Focus();
            }
        }

        private void receteAyarlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_recipeSelectionPage == null)
            {
                _recipeSelectionPage = new RecipeSelectionPage();
                _recipeSelectionPage.HandleDestroyed += (object send, EventArgs e2) => { _recipeSelectionPage = null; };
                _recipeSelectionPage.Show();
            }
            else
            {
                _mainOperatorUI.Focus();
            }
        }

        private void haberlesmeAyarlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_settingsPage == null)
            {
                _settingsPage = new ComSettingsPage();
                _settingsPage.HandleDestroyed += (object send, EventArgs e2) => { _settingsPage = null; };
                _settingsPage.Show();
            }
            else
            {
                _settingsPage.Focus();
            }
        }

        private void programiKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_mainOperatorUI == null)
            {
                _mainOperatorUI = new MainOperatorUI();
                _mainOperatorUI.HandleDestroyed += (object send, EventArgs e2) => { _mainOperatorUI = null; };
                _mainOperatorUI.Show();
            }
            else
            {
                _mainOperatorUI.Focus();
            }
        }
    }
}
