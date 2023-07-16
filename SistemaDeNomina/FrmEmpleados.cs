using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaDeNomina
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text)) 
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDepartamento.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                GuardarEmpleados();
                //btnCrearEmpleado.Enabled = false;
            }
        }
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
        
        public void mostrarEmpleados()
        {
            string query = "Select * from empleados";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            //Conexion con = new Conexion();
            btbNuevo.Visible = false;
            mostrarEmpleados();
            
            
        }

        public void GuardarEmpleados() 
        {
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
          //  cn.ConnectionString=("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SP_InsertarEmpleado",cn);
           SqlCommand cm = new SqlCommand();
            //cm.CommandType = CommandType.StoredProcedure;
            //cm.CommandText = "SP_InsertarEmpleado";
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar,(30)).Value = txtNombre.Text;
            adapter.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, (30)).Value = txtApellido.Text;
            adapter.SelectCommand.Parameters.Add("@Direccion", SqlDbType.VarChar, (100)).Value = txtDireccion.Text;
            adapter.SelectCommand.Parameters.Add("@Telefono", SqlDbType.VarChar,(20)).Value = txtTelefono.Text;
            adapter.SelectCommand.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = dtpIngreso.MaxDate;
            adapter.SelectCommand.Parameters.Add("@Cargo", SqlDbType.VarChar,(50)).Value = txtCargo.Text;
            adapter.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar, (50)).Value = txtDepartamento.Text;
            adapter.SelectCommand.Parameters.Add("@Salario", SqlDbType.VarChar, (50)).Value = txtSalario.Text;
            adapter.SelectCommand.Parameters.Add("@Cedula", SqlDbType.VarChar, (30)).Value = txtCedula.Text;
           // cm.Parameters.Add("@Id", SqlDbType.Int).Value=txtCargo.Text.ToString();
            /*
            cm.Parameters.AddWithValue("@Nombre",SqlDbType.VarChar).Value=txtNombre.Text;
            cm.Parameters.AddWithValue("@Apellido", SqlDbType.VarChar).Value = txtApellido.Text;
            cm.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = txtDireccion.Text;
            cm.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = txtTelefono.Text;
            cm.Parameters.AddWithValue("@FechaIngreso", SqlDbType.DateTime).Value = dtpIngreso.MaxDate;
            cm.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = txtCargo.Text;
            cm.Parameters.AddWithValue("@Departamento", SqlDbType.VarChar).Value = txtDepartamento.Text;
            cm.Parameters.AddWithValue("@Salario", SqlDbType.VarChar).Value = txtSalario.Text;
            cm.Parameters.AddWithValue("@Cedula", SqlDbType.VarChar).Value = txtCedula.Text;
             */
           // cm.Connection = cn;
           // cn.Open();
           // DataTable dt = new DataTable();
           // dt.Load(cm.ExecuteReader());
            adapter.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Datos Registrados exitosamente!!!");
            limpiarCampos();
            mostrarEmpleados();
        
            cn.Close();
        }

        public void ActualizarEmpleado()
        {
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
            //  cn.ConnectionString=("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SP_ActualizarEmpleado", cn);
            SqlCommand cm = new SqlCommand();
            //cm.CommandType = CommandType.StoredProcedure;
            //cm.CommandText = "SP_InsertarEmpleado";
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = txtCodigoEmpleado.Text;
            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, (30)).Value = txtNombre.Text;
            adapter.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, (30)).Value = txtApellido.Text;
            adapter.SelectCommand.Parameters.Add("@Direccion", SqlDbType.VarChar, (100)).Value = txtDireccion.Text;
            adapter.SelectCommand.Parameters.Add("@Telefono", SqlDbType.VarChar, (20)).Value = txtTelefono.Text;
            adapter.SelectCommand.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = dtpIngreso.MaxDate;
            adapter.SelectCommand.Parameters.Add("@Cargo", SqlDbType.VarChar, (50)).Value = txtCargo.Text;
            adapter.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar, (50)).Value = txtDepartamento.Text;
            adapter.SelectCommand.Parameters.Add("@Salario", SqlDbType.VarChar, (50)).Value = txtSalario.Text;
            adapter.SelectCommand.Parameters.Add("@Cedula", SqlDbType.VarChar, (30)).Value = txtCedula.Text;
            // cm.Parameters.Add("@Id", SqlDbType.Int).Value=txtCargo.Text.ToString();
            /*
            cm.Parameters.AddWithValue("@Nombre",SqlDbType.VarChar).Value=txtNombre.Text;
            cm.Parameters.AddWithValue("@Apellido", SqlDbType.VarChar).Value = txtApellido.Text;
            cm.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = txtDireccion.Text;
            cm.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = txtTelefono.Text;
            cm.Parameters.AddWithValue("@FechaIngreso", SqlDbType.DateTime).Value = dtpIngreso.MaxDate;
            cm.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = txtCargo.Text;
            cm.Parameters.AddWithValue("@Departamento", SqlDbType.VarChar).Value = txtDepartamento.Text;
            cm.Parameters.AddWithValue("@Salario", SqlDbType.VarChar).Value = txtSalario.Text;
            cm.Parameters.AddWithValue("@Cedula", SqlDbType.VarChar).Value = txtCedula.Text;
             */
            // cm.Connection = cn;
            // cn.Open();
            // DataTable dt = new DataTable();
            // dt.Load(cm.ExecuteReader());
            adapter.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Datos actualizados exitosamente!!!");
            limpiarCampos();
            mostrarEmpleados();

            cn.Close();
        }
        private void limpiarCampos() 
        {
            btnCrearEmpleado.Enabled = true;
            txtTelefono.Clear();
            txtSalario.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtDepartamento.Clear();
            txtCedula.Clear();
            txtCodigoEmpleado.Clear();
            txtCargo.Clear();
            txtApellido.Clear();
        }
        private void btbNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            btnCrearEmpleado.Enabled = true;
           
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoEmpleado.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtCedula.Text = dataGridView1.SelectedCells[9].Value.ToString();
            txtNombre.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtApellido.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txtDireccion.Text=dataGridView1.SelectedCells[3].Value.ToString();
            txtTelefono.Text = dataGridView1.SelectedCells[4].Value.ToString();
            //dtpIngreso.Text = dataGridView1.SelectedCells[5].Value(Mindat)
            txtCargo.Text = dataGridView1.SelectedCells[6].Value.ToString();
            txtDepartamento.Text = dataGridView1.SelectedCells[7].Value.ToString();
            txtSalario.Text = dataGridView1.SelectedCells[8].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Eliminar Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EliminarEmpleado(Convert.ToInt32(txtCodigoEmpleado.Text));
                    MessageBox.Show("Registro eliminado exitosamente!");
                }
                else { 
                    MessageBox.Show("Registro no eliminado");
                    limpiarCampos();
                }
            }
            else 
            {
                MessageBox.Show("Por favor seleccione el registro a eliminar");
            }
            mostrarEmpleados();

        }
        public void EliminarEmpleado(int Id)
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("SP_EliminarEmpleado",cn);
            cm.CommandText = "SP_EliminarEmpleado";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@Id", Id);
            cm.ExecuteNonQuery();
            //btnCrearEmpleado.Enabled = false;
            cn.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtDepartamento.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                ActualizarEmpleado();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
