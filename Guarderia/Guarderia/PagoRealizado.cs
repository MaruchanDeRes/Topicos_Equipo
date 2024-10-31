using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guarderia
{
    public partial class PagoRealizado : Form
    {
        SqlConnection conx = new SqlConnection("Data Source=LavBal\\SQLEXPRESS01;Initial Catalog=Guarderia;Integrated Security=True");

        public PagoRealizado()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(640, 370); // Ancho y alto del formulario
            this.MaximizeBox = false; // Deshabilitar el botón de maximizar
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Fijar el borde del formulario
        }
        private void CargarDatos()
        {
            conx.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Nino", conx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; // Asegúrate de que el nombre del DataGridView es correcto
            conx.Close();
        }
        private void PagoRealizado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand altas = new SqlCommand("INSERT INTO Pagador (DNI, nombre,direccion,telefono,cuenta_corriente ) VALUES (@DNI, @nombre,@direccion,@telefono,@cuenta_corriente)", conx);
            altas.Parameters.AddWithValue("DNI", textBox1.Text);
            altas.Parameters.AddWithValue("nombre", textBox2.Text);
            altas.Parameters.AddWithValue("direccion", textBox3.Text);
            altas.Parameters.AddWithValue("telefono", textBox4.Text);
            altas.Parameters.AddWithValue("cuenta_corriente", textBox5.Text);
            CargarDatos();
            conx.Open();



            altas.ExecuteNonQuery();


            MessageBox.Show("Se han subido sus datos ☺,Eres un genio ♥");
            conx.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            CargarDatos();
        }
    }
}
