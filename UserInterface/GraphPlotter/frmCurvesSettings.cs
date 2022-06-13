using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalFunctions;

namespace UserInterface.GraphPlotter
{
  public partial class frmCurvesSettings : Form
  {
    private List<Channel> _channelList;

    private RealTimeGraph _editedGraph;

    private Curve _selectedCurve;

    public RealTimeGraph EditedGraph
    {
      get { return _editedGraph; }
      set
      {
        _editedGraph = value;
        if (_editedGraph != null)
        {
          cmbCurveNo.Items.Clear();
          cmbCurveNo.Items.AddRange(EditedGraph.Curves.Select(crv => crv.CurveNo.ToString()).ToArray());
        }
      }
    }

    public List<Channel> ChannelList
    {
      get { return _channelList; }
      set
      {
        _channelList = value;
        cmbChannels.Items.Clear();
        cmbChannels.Items.AddRange(_channelList.ToArray());
      }
    }

    public frmCurvesSettings()
    {
      InitializeComponent();
      this.FormClosing += frmCurvesSettings_FormClosing;
      btnClose.Click += (object sender, EventArgs e) => { this.DialogResult = DialogResult.OK; this.Close(); };
      btnAdd.Click += btnAdd_Click;
      btnUpdate.Click += btnUpdate_Click;
      btnDelete.Click += btnDelete_Click;
      btnSelectColor.Click += btnSelectColor_Click;
      cmbCurveNo.SelectedIndexChanged += cmbCurveNo_SelectedIndexChanged;
      txtCurveWidth.KeyPress += txtFloat_KeyPress;
      txtMaxValue.KeyPress += txtFloat_KeyPress;
      txtMinValue.KeyPress += txtFloat_KeyPress;
      txtPrecision.KeyPress += txtPrecision_KeyPress;
      cmbChannels.SelectedIndexChanged += cmbChannels_SelectedIndexChanged;
    }

  
    private void cmbChannels_SelectedIndexChanged(object sender, EventArgs e)
    {
      Channel cnl = cmbChannels.SelectedItem as Channel;
      if (cnl != null && _selectedCurve == null)
      {
        txtMaxValue.Text = cnl.Max.ToString();
        txtMinValue.Text = cnl.Min.ToString();
        txtPrecision.Text = cnl.Precision.ToString();
        txtUnit.Text = cnl.Unit;
      }
    }

    private void txtPrecision_KeyPress(object sender, KeyPressEventArgs e)
    {
      Functions.NumericUnSignIntInput(ref e);
    }

    private void txtFloat_KeyPress(object sender, KeyPressEventArgs e)
    {
      Functions.NumericFloatInput(ref e, '.');
    }

    private void frmCurvesSettings_FormClosing(object sender, FormClosingEventArgs e)
    {
      List<string> chLst = new List<string>();
      chLst.AddRange(EditedGraph.Curves.Select(crv => crv.Name).ToArray());
      EditedGraph.ChannelName = chLst;
    }

    private void cmbCurveNo_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cmbCurveNo.Text != null && cmbCurveNo.Text != string.Empty)
      {
        Curve curve = _editedGraph.Curves.FindLast(crv => crv.CurveNo == int.Parse(cmbCurveNo.Text));
        if (curve != null)
        {
          _selectedCurve = curve;
          txtMaxValue.Text = curve.MaxValue.ToString();
          txtMinValue.Text = curve.MinValue.ToString();
          txtPrecision.Text = curve.Precision.ToString();
          txtCurveWidth.Text = curve.Width.ToString();
          picBoxBackColor.BackColor = curve.CurveColor;
          cmbChannels.SelectedItem = cmbChannels.Items.Cast<Channel>().FirstOrDefault(cn => cn.Name == curve.Name);
          txtUnit.Text = curve.Unit;
        }
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (cmbCurveNo.Text != null && cmbCurveNo.Text != string.Empty)
      {
        if (EditedGraph.CurveCount > 0)
        {
          int selectedIndex = cmbCurveNo.SelectedIndex;
          cmbCurveNo.Items.Remove(_selectedCurve.CurveNo.ToString());
          EditedGraph.RemoveCurve(_selectedCurve.Name);
          RefreshCmbCurve();
          if (cmbCurveNo.Items.Count != 0)
          {
            if (selectedIndex < cmbCurveNo.Items.Count)
              cmbCurveNo.SelectedIndex = selectedIndex;
            else
              cmbCurveNo.SelectedIndex = cmbCurveNo.Items.Count - 1;
          }
          if (cmbCurveNo.SelectedItem != null)
            _selectedCurve = cmbCurveNo.SelectedItem as Curve;
        }
      }
    }

    private void RefreshCmbCurve()
    {
      cmbCurveNo.Items.Clear();
      foreach (Curve crv in EditedGraph.Curves)
        cmbCurveNo.Items.Add(crv.CurveNo.ToString());
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (_selectedCurve != null)
      {
        if (EditedGraph.Curves.FindLast(crv => crv.Name == cmbChannels.Text) == null || _selectedCurve.Name == cmbChannels.Text)
        {
          _selectedCurve.MaxValue = float.Parse(txtMaxValue.Text);
          _selectedCurve.MinValue = float.Parse(txtMinValue.Text);
          _selectedCurve.Precision = int.Parse(txtPrecision.Text);
          _selectedCurve.CurveColor = picBoxBackColor.BackColor;
          _selectedCurve.Name = cmbChannels.Text;
          _selectedCurve.Unit = txtUnit.Text;
          _selectedCurve.Width = float.Parse(txtCurveWidth.Text);
        }
        else
          MessageBox.Show("This channel has already used!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
        MessageBox.Show("Please select a curve for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (cmbChannels.SelectedItem != null && !string.IsNullOrEmpty(cmbCurveNo.Text))
      {
        if (EditedGraph.CurveCount < 4)
        {
          if (EditedGraph.AddCurve(cmbChannels.Text, float.Parse(txtMaxValue.Text), float.Parse(txtMinValue.Text), int.Parse(txtPrecision.Text), picBoxBackColor.BackColor, txtUnit.Text))
          {
            Curve crv = EditedGraph.GetCurve(cmbChannels.Text);
            crv.Width = float.Parse(txtCurveWidth.Text);
            RefreshCmbCurve();
            cmbCurveNo.Text = crv.CurveNo.ToString();
          }
          else
            MessageBox.Show("This channel has already used!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
          MessageBox.Show("Max curve count limit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
        MessageBox.Show("Please select a channel and curve name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

    }

    private void btnSelectColor_Click(object sender, EventArgs e)
    {
      ColorDialog cldlg = new ColorDialog();
      cldlg.Color = picBoxBackColor.BackColor;
      cldlg.ShowDialog();
      picBoxBackColor.BackColor = cldlg.Color;

    }
  }
}
