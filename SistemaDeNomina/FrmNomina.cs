using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SistemaDeNomina
{
    public partial class FrmNomina : Form
    {
        public FrmNomina()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
            SqlCommand cm = new SqlCommand("Select * From Empleados where Id=@Id",cn);
            cm.Parameters.AddWithValue("@Id",txtId.Text);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["Nombre"].ToString();
                txtApellido.Text = reader["Apellido"].ToString();
                txtCargo.Text = reader["Cargo"].ToString();
                txtSueldoB.Text = reader["Salario"].ToString();
            }
            else 
            {
                MessageBox.Show("No Existe empleado para realizar Nomina");
            }
            btnBuscar.Enabled = false;
            txtId.Enabled = false;
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtAdelantoSueldo.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtBonoTransp.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtMontoHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtPrecioHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtSeguroMed.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtSueldoB.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtSueldoNeto.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtTotalAsignaciones.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtTotalDeducciones.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else
            {
                GuardarNomina();
                button1.Enabled = false;
            }
         

        }

        public void GuardarNomina() 
        {
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SP_InsertarNomina", cn);
            SqlCommand cm = new SqlCommand();
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, (30)).Value = txtNombre.Text;
            adapter.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, (30)).Value = txtApellido.Text;
            adapter.SelectCommand.Parameters.Add("@Cargo", SqlDbType.VarChar, (50)).Value = txtCargo.Text;
            adapter.SelectCommand.Parameters.Add("@SueldoBruto", SqlDbType.VarChar, (50)).Value = txtSueldoB.Text;
            adapter.SelectCommand.Parameters.Add("@HorasExt", SqlDbType.Int).Value = txtHorasEx.Text;
            adapter.SelectCommand.Parameters.Add("@PrecioHorasExt", SqlDbType.Int).Value = txtPrecioHorasEx.Text;
            adapter.SelectCommand.Parameters.Add("@PagoHorasExt", SqlDbType.Int).Value = txtMontoHorasEx.Text;
            adapter.SelectCommand.Parameters.Add("@BonoTransporte", SqlDbType.Int).Value = txtBonoTransp.Text;
            adapter.SelectCommand.Parameters.Add("@SeguroMedico", SqlDbType.Float).Value = txtSeguroMed.Text;
            adapter.SelectCommand.Parameters.Add("@AdelantoSueldo", SqlDbType.Int).Value = txtAdelantoSueldo.Text;
            adapter.SelectCommand.Parameters.Add("@SueldoNeto", SqlDbType.Float).Value = txtSueldoNeto.Text;

            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Nomina guardada exitosamente!!!");
            MostrarNominas();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtAdelantoSueldo.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtBonoTransp.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            
            else if (string.IsNullOrEmpty(txtPrecioHorasEx.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            
            else if (string.IsNullOrEmpty(txtSueldoB.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
            else if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe completar todos los campos!!!");
            }
           
            else { 
            float totalAsignaciones, SeguroMed, TotalDesucciones, SueldoBruto, SueldoNeto;
            int HorasExt, PrecioHorasExt, PagoHorasExt, BonoTransp, AdelantoSueldo;
            HorasExt = Convert.ToInt32(txtHorasEx.Text);
            PrecioHorasExt = Convert.ToInt32(txtPrecioHorasEx.Text);
            PagoHorasExt = HorasExt * PrecioHorasExt;
            BonoTransp = Convert.ToInt32(txtBonoTransp.Text);
            totalAsignaciones = PagoHorasExt + BonoTransp;
            SueldoBruto = float.Parse(txtSueldoB.Text);
            SeguroMed = SueldoBruto * 0.0591F;
            AdelantoSueldo = Convert.ToInt32(txtAdelantoSueldo.Text);
            TotalDesucciones = SeguroMed - AdelantoSueldo;
            SueldoNeto = SueldoBruto + totalAsignaciones - TotalDesucciones;
            txtMontoHorasEx.Text = PagoHorasExt.ToString();
            txtTotalAsignaciones.Text = totalAsignaciones.ToString();
            txtSeguroMed.Text = SeguroMed.ToString();
            txtTotalDeducciones.Text = TotalDesucciones.ToString();
            txtSueldoNeto.Text = SueldoNeto.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            button1.Enabled = true;
            txtId.Enabled = true;
            txtCargo.Clear();
            txtAdelantoSueldo.Clear();
            txtApellido.Clear();
            txtBonoTransp.Clear();
            txtHorasEx.Clear();
            txtId.Clear();
            txtMontoHorasEx.Clear();
            txtNombre.Clear();
            txtPrecioHorasEx.Clear();
            txtSeguroMed.Clear();
            txtSueldoB.Clear();
            txtSueldoNeto.Clear();
            txtTotalAsignaciones.Clear();
            txtTotalDeducciones.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void FrmNomina_Load(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtCargo.Enabled = false;
            txtSueldoB.Enabled = false;

            MostrarNominas();
        }
        public void MostrarNominas() 
        {
            string query = "Select * from Nominas";
            SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
