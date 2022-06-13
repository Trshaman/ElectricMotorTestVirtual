﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace UserInterface
{
  public partial class Messages : Form
  {
    public Messages()
    {
      InitializeComponent();
      this.FormClosing += Messages_FormClosing;
      this.Activated += Messages_Activated;
      btnOk.Click += (object sender, EventArgs e) => { Visible = false; };

    }


    private void Messages_Activated(object sender, EventArgs e)
    {
      Rectangle rec = Screen.PrimaryScreen.WorkingArea;
      rec.Inflate((-rec.Width + this.Width) / 2, (-rec.Height + this.Height) / 2);
      this.Location = rec.Location;
      this.TopMost = true;
    }

    private void Messages_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Visible = false;
    }


    ///// <summary>
    ///// Displays a message box with specified text
    ///// </summary>
    ///// <param name="text">The text to display in the message box.</param>
    ///// <returns></returns>
    //public Messages Show(string text)
    //{
    //  lblMessage.Text = text;
    //  btnOk.Click += (object sender, EventArgs e) => { Visible = false; };
    //  Show();
    //  return this;
    //}

    ///// <summary>
    ///// Displays a message box with specified text and caption.
    ///// </summary>
    ///// <param name="text">The text to display in the message box.</param>
    ///// <param name="caption">The text to display in the title bar of the message box.</param>
    ///// <returns></returns>
    //public Messages Show(string text, string caption)
    //{
    //  this.Text = caption;
    //  return this;
    //}


    ////// Summary:
    //////     Displays a message box with specified text, caption, buttons, and icon.
    //////
    ////// Parameters:
    //////   text:
    //////     The text to display in the message box.
    //////
    //////   caption:
    //////     The text to display in the title bar of the message box.
    //////
    //////   buttons:
    //////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    //////     buttons to display in the message box.
    //////
    //////   icon:
    //////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    //////     icon to display in the message box.
    //////
    ////// Returns:
    //////     One of the System.Windows.Forms.DialogResult values.
    //////
    ////// Exceptions:
    //////   System.ComponentModel.InvalidEnumArgumentException:
    //////     The buttons parameter specified is not a member of System.Windows.Forms.MessageBoxButtons.-or-
    //////     The icon parameter specified is not a member of System.Windows.Forms.MessageBoxIcon.
    //////
    //////   System.InvalidOperationException:
    //////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    //////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    //////     property.
    //public Messages Show(string text, string caption, Icon icon)
    //{
    //  lblMessage.Text = text;
    //  Text = caption;
    //  pictureBox1.Image = icon.ToBitmap();
    //  pictureBox1.Size = pictureBox1.Image.Size;
    //  pictureBox1.Left = (Width - pictureBox1.Width) / 2;
    //  pictureBox1.Top = (lblMessage.Top - pictureBox1.Height) / 2;
    //  btnOk.Click += (object sender, EventArgs e) => { Visible = false; };
    //  Show();
    //  return this;
    //}

    ////
    //// Summary:
    ////     Displays a message box in front of the specified object and with the specified
    ////     text and caption.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    //public static DialogResult Show(IWin32Window owner, string text, string caption);
    ////
    //// Summary:
    ////     Displays a message box with specified text, caption, and buttons.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     The buttons parameter specified is not a member of System.Windows.Forms.MessageBoxButtons.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons);
    ////
    //// Summary:
    ////     Displays a message box in front of the specified object and with the specified
    ////     text, caption, and buttons.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons);
    ////

    ////
    //// Summary:
    ////     Displays a message box in front of the specified object and with the specified
    ////     text, caption, buttons, and icon.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, and
    ////     default button.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- defaultButton
    ////     is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
    ////
    //// Summary:
    ////     Displays a message box in front of the specified object and with the specified
    ////     text, caption, buttons, icon, and default button.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- defaultButton
    ////     is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, and options.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options);
    ////
    //// Summary:
    ////     Displays a message box in front of the specified object and with the specified
    ////     text, caption, buttons, icon, default button, and options.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values the specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- defaultButton
    ////     is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- options
    ////     specified System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly or System.Windows.Forms.MessageBoxOptions.ServiceNotification
    ////     and specified a value in the owner parameter. These two options should be
    ////     used only if you invoke the version of this method that does not take an
    ////     owner parameter.-or- buttons specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   displayHelpButton:
    ////     true to show the Help button; otherwise, false. The default is false.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool displayHelpButton);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file and HelpNavigator.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    ////   navigator:
    ////     One of the System.Windows.Forms.HelpNavigator values.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file and Help
    ////     keyword.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    ////   keyword:
    ////     The Help keyword to display when the user clicks the Help button.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file and HelpNavigator.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    ////   navigator:
    ////     One of the System.Windows.Forms.HelpNavigator values.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file and Help
    ////     keyword.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    ////   keyword:
    ////     The Help keyword to display when the user clicks the Help button.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file, HelpNavigator,
    ////     and Help topic.
    ////
    //// Parameters:
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    ////   navigator:
    ////     One of the System.Windows.Forms.HelpNavigator values.
    ////
    ////   param:
    ////     The numeric ID of the Help topic to display when the user clicks the Help
    ////     button.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param);
    ////
    //// Summary:
    ////     Displays a message box with the specified text, caption, buttons, icon, default
    ////     button, options, and Help button, using the specified Help file, HelpNavigator,
    ////     and Help topic.
    ////
    //// Parameters:
    ////   owner:
    ////     An implementation of System.Windows.Forms.IWin32Window that will own the
    ////     modal dialog box.
    ////
    ////   text:
    ////     The text to display in the message box.
    ////
    ////   caption:
    ////     The text to display in the title bar of the message box.
    ////
    ////   buttons:
    ////     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
    ////     buttons to display in the message box.
    ////
    ////   icon:
    ////     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
    ////     icon to display in the message box.
    ////
    ////   defaultButton:
    ////     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
    ////     the default button for the message box.
    ////
    ////   options:
    ////     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
    ////     display and association options will be used for the message box. You may
    ////     pass in 0 if you wish to use the defaults.
    ////
    ////   helpFilePath:
    ////     The path and name of the Help file to display when the user clicks the Help
    ////     button.
    ////
    ////   navigator:
    ////     One of the System.Windows.Forms.HelpNavigator values.
    ////
    ////   param:
    ////     The numeric ID of the Help topic to display when the user clicks the Help
    ////     button.
    ////
    //// Returns:
    ////     One of the System.Windows.Forms.DialogResult values.
    ////
    //// Exceptions:
    ////   System.ComponentModel.InvalidEnumArgumentException:
    ////     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
    ////     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
    ////     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
    ////
    ////   System.InvalidOperationException:
    ////     An attempt was made to display the System.Windows.Forms.MessageBox in a process
    ////     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
    ////     property.
    ////
    ////   System.ArgumentException:
    ////     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
    ////     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
    ////     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
    //public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param);

    public void ShowMessage(string text, string caption, Icon icon, bool close)
    {
      CrossThreadHelper.SetControlOfText(string.IsNullOrEmpty(caption) ? "User Message" : caption, this);
      CrossThreadHelper.SetControlOfText(text, lblMessage);
      CrossThreadHelper.SetPictureBoxOfImage(icon, pictureBox1);
    }
  }
}
