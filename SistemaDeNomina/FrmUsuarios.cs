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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
       SqlConnection con = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
        
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            cargarUsuarios();
        }
        
        public void GuardarUsuario() 
        {
            con.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SP_InsertarUsuario",con);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            adaptador.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar,(30)).Value=txtNombre.Text;
            adaptador.SelectCommand.Parameters.Add("@Apellido",SqlDbType.VarChar,(30)).Value=txtApellido.Text;
            adaptador.SelectCommand.Parameters.Add("@Usuario",SqlDbType.VarChar,(50)).Value=txtUsuario.Text;
            adaptador.SelectCommand.Parameters.Add("@Contraseña",SqlDbType.VarChar,(50)).Value=txtContraseña.Text;
            adaptador.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Usuario guardado exitosamente");
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
                limpiarCampos();
                txtNombre.Focus();
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
                limpiarCampos();
                txtNombre.Focus();
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
                limpiarCampos();
                txtNombre.Focus();
            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
                limpiarCampos();
                txtNombre.Focus();
            }
            else 
            {
                GuardarUsuario();
                limpiarCampos();
                txtNombre.Focus();
            }
           
            cargarUsuarios();
        }
        public void cargarUsuarios() 
        {
            con.Open();
            string query = "Select * from Usuarios";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public void limpiarCampos() 
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtNombre.Focus();
        }
        public void Validar() 
        { 
       
        }
        public void eliminarUsuario(int Id) 
        {
            con.Open();
            SqlCommand cm = new SqlCommand("SP_EliminarUsuario",con);
            cm.CommandText = "SP_EliminarUsuario";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@Id",Id);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtNombre.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtApellido.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txtUsuario.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txtContraseña.Text = dataGridView1.SelectedCells[4].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Eliminar Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eliminarUsuario(Convert.ToInt32(txtId.Text));
                }
                else
                {
                    MessageBox.Show("Usuario no eliminado");
                    limpiarCampos();
                }
            }
            else 
            {
                MessageBox.Show("Debe seleccionar usuario a eliminar");
            }
            
            cargarUsuarios();
        }
    }
}
