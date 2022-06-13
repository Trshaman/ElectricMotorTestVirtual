using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalFunctions;
using System.Net;

namespace UserInterface
{
  public partial class IP4TextBox : UserControl
  {
    List<TextBox> _ipBoxes = new List<TextBox>();
    private IPAddress _ipAddress = new IPAddress(new byte[] {0,0,0,0});
    public IPAddress IpAddress
    {
      get{
        string ipString = string.Empty;
        ipString += _ipBoxes[0].Text.Trim() + "." + _ipBoxes[1].Text.Trim() + "." + _ipBoxes[2].Text.Trim() + "." + _ipBoxes[3].Text.Trim();
        IPAddress.TryParse(ipString, out _ipAddress);
        return _ipAddress;
      }
      set 
      {
        if(value != null)
        {
          _ipAddress = value;
          string[] ipS = value.ToString().Split('.');
          for (int i = 0; i < 4; i++)
            _ipBoxes[i].Text = ipS[i];
          
        }
      }
    }
    public IP4TextBox()
    {
      InitializeComponent();
      _ipBoxes = new List<TextBox>();
      _ipBoxes.AddRange(new TextBox[] { textBox1, textBox2, textBox3, textBox4 });
      foreach (TextBox txbx in _ipBoxes)
      {
        txbx.MaxLength = 3;
        txbx.KeyPress += textBox_KeyPress;
        txbx.TextChanged += txbx_TextChanged;
      }
    }

    void txbx_TextChanged(object sender, EventArgs e)
    {
      TextBox txbx = (TextBox)sender;
      if(txbx.Text != "")
        txbx.Text = Functions.MaxMinControl(float.Parse(txbx.Text), 255, 0).ToString();
    }


    void txbx_LostFocus(object sender, EventArgs e)
    {
      TextBox txbx = (TextBox) sender;
      txbx.Text = Functions.MaxMinControl(float.Parse(txbx.Text), 255, 0).ToString();
    }

    void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      TextBox txbx = (TextBox)sender;
      int index = _ipBoxes.IndexOf(txbx);
      if (e.KeyChar == '.' && txbx.Text != string.Empty)
      {
        if (index == 3) index = -1;
        e.Handled = true;
        _ipBoxes[++index].Focus();
        _ipBoxes[index].SelectAll();
      }
      else
      {
        Functions.NumericIntInput(ref e);
        if (!e.Handled && txbx.Text.Length == 2 && txbx.SelectedText != txbx.Text && e.KeyChar != '\b')
        {
          if (index == 3) index = -1;
          _ipBoxes[++index].Focus();
          _ipBoxes[index].SelectAll();
        }

      }
    }

    
  }
}
