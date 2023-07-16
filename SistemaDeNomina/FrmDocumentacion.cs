using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaDeNomina
{
    public partial class FrmDocumentacion : Form
    {
        public FrmDocumentacion()
        {
            InitializeComponent();
        }

        private void FrmDocumentacion_Load(object sender, EventArgs e)
        {
            txtBuscar.Text = "http://ahoraprograma.blogspot.com/";
            txtBuscar.Visible = false;
            webBrowser1.Navigate(txtBuscar.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
