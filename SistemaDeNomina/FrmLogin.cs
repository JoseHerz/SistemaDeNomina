using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SistemaDeNomina
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                txtUsuario.Focus();
            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                txtUsuario.Focus();
            }
            else
            {

                cn.Open();
                string query = string.Format("Select Usuario,Contraseña from Usuarios where Usuario='{0}' AND Contraseña='{1}'", txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                SqlCommand cm = new SqlCommand(query, cn);
                SqlDataReader reader = null;
                reader = cm.ExecuteReader();
                if (reader.Read())
                {
                    FrmMenu menu = new FrmMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("DATOS ERRONEOS");
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    txtUsuario.Focus();
                }
                cn.Close();
                /*string usuario = txtUsuario.Text;
                string pass = txtContraseña.Text;
                if (usuario == "admin" && pass == "123")
                {
                    FrmMenu menu = new FrmMenu();
                    menu.Show();
                    this.Hide();
                }
                else 
                {
                    MessageBox.Show("USUARIO O CLAVE INCORRECTOS");
                }*/
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
