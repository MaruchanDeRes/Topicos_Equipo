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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Guarderia
{
    public partial class Comida : Form
    {
        SqlConnection conx = new SqlConnection("Data Source=LavBal\\SQLEXPRESS01;Initial Catalog=Guarderia;Integrated Security=True");
        public Comida()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(640, 370); // Ancho y alto del formulario
            this.MaximizeBox = false; // Deshabilitar el botón de maximizar
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Fijar el borde del formulario
        }
        private void CargarDatos()
        {
            conx.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AsistenciaComida", conx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; // Asegúrate de que el nombre del DataGridView es correcto
            conx.Close();
        }

        private void Comida_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand altas = new SqlCommand("INSERT INTO AsistenciaComida (num_matricula, fecha,num_menu) VALUES (@num_matricula, @fecha,@num_menu)", conx);
            altas.Parameters.AddWithValue("num_matricula", textBox1.Text);
            altas.Parameters.AddWithValue("fecha", textBox2.Text);
            altas.Parameters.AddWithValue("num_menu", textBox3.Text);
           
            CargarDatos();
            conx.Open();



            altas.ExecuteNonQuery();


            MessageBox.Show("Se han subido sus datos ☺,Eres un genio ♥");
            conx.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
            CargarDatos();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string baja = " DELETE FROM AsistenciaComida WHERE num_matricula = @num_matricula";

            conx.Open();


            SqlCommand cmIns = new SqlCommand(baja, conx);
            cmIns.Parameters.AddWithValue("num_matricula", textBox1.Text);
            cmIns.BeginExecuteNonQuery();

            cmIns.Dispose();
            cmIns = null;
            textBox1.Clear();
            conx.Close();
            CargarDatos();
            MessageBox.Show("num_matricula eliminado");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM AsistenciaComida WHERE num_matricula =@num_matricula", conx);
            conx.Open();

            consulta.Parameters.AddWithValue("@num_matricula", textBox1.Text);


            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                consulta.Parameters.AddWithValue("num_menu", textBox3.Text);
                consulta.Parameters.AddWithValue("num_matricula", textBox1.Text);
                consulta.Parameters.AddWithValue("fecha", textBox2.Text);
               

            }
            MessageBox.Show("CONSULTA COMPLETA");
            conx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tutor tutor = new Tutor();
            tutor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TutorAlumno tutor = new TutorAlumno();
            tutor.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PagoMatricula pagoMatricula = new PagoMatricula();
            pagoMatricula.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            PagoRealizado pagoRealizado = new PagoRealizado();
            pagoRealizado.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Alumno alumno = new Alumno();
            alumno.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Alergias alergias = new Alergias();
            alergias.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Costo_Mensual costo_Mensual = new Costo_Mensual();
            costo_Mensual.Show();
        }
    }
}
