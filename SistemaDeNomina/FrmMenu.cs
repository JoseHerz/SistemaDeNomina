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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
        private void listarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void crearNominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNomina nomina = new FrmNomina();
            nomina.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 calendario = new Form1();
            calendario.Show();


        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteEmpleados reporte = new FrmReporteEmpleados();
            reporte.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
           // Conexion c = new Conexion();
        }

        private void mantenimientoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.Show();
            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaUsuarios consultaUsuario = new FrmConsultaUsuarios();
            consultaUsuario.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaEmpleados consultarEmpleados = new FrmConsultaEmpleados();
            consultarEmpleados.Show();
        }

        private void nominasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultarNominas consultarNominas = new FrmConsultarNominas();
            consultarNominas.Show();
        }

        private void documentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDocumentacion documentacion = new FrmDocumentacion();
            documentacion.Show();
            this.Hide();
        }

        private void nominasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteDeNominas nomina = new FrmReporteDeNominas();
            nomina.Show();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteDeUsuarios usuarios = new FrmReporteDeUsuarios();
            usuarios.Show();
        }
    }
}
