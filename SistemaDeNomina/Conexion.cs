using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaDeNomina
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader rd;

        public Conexion()
        {
            cn = new SqlConnection("Data Source=DESKTOP-DEIS0VR\\SQLEXPRESS;Initial Catalog=Nomina;Integrated Security=True");
            try
            {
                cn.Open();
                //MessageBox.Show("conectado");
            }
            catch(Exception e)
            {
                MessageBox.Show("No se conecto: "+e.ToString());
            }
        }
    }
}
