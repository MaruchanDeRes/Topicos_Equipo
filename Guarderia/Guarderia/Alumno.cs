using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace Guarderia
{
    public partial class Alumno : Form
    {
        SqlConnection conx = new SqlConnection("Data Source=LavBal\\SQLEXPRESS01;Initial Catalog=Guarderia;Integrated Security=True");
        public Alumno()
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
        private void Alumno_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand altas = new SqlCommand("INSERT INTO Nino (num_matricula, nombre,fecha_nacimiento,fecha_ingreso,fecha_baja ) VALUES (@num_matricula, @nombre,@fecha_nacimiento,@fecha_ingreso,@fecha_baja)", conx);
            altas.Parameters.AddWithValue("num_matricula", textBox1.Text);
            altas.Parameters.AddWithValue("nombre", textBox2.Text);
            altas.Parameters.AddWithValue("fecha_nacimiento", textBox3.Text);
            altas.Parameters.AddWithValue("fecha_ingreso", textBox4.Text);
            altas.Parameters.AddWithValue("fecha_baja", textBox5.Text);
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


        private void button9_Click(object sender, EventArgs e)
        {
            string baja = " DELETE FROM Nino WHERE num_matricula = @num_matricula";
           
            conx.Open();


            SqlCommand cmIns = new SqlCommand(baja, conx);
            cmIns.Parameters.AddWithValue("num_matricula", textBox1.Text);
            cmIns.BeginExecuteNonQuery();

            cmIns.Dispose();
            cmIns = null;
            MessageBox.Show("num_matricula eliminado");
            conx.Close();
            textBox1.Clear();
            CargarDatos();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM Nino WHERE num_matricula =@num_matricula", conx);
            conx.Open();

            consulta.Parameters.AddWithValue("@num_matricula", textBox1.Text);


            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                consulta.Parameters.AddWithValue("num_matricula", textBox1.Text);
                consulta.Parameters.AddWithValue("nombre", textBox2.Text);
                consulta.Parameters.AddWithValue("fecha_nacimiento", textBox3.Text);
                consulta.Parameters.AddWithValue("fecha_ingreso", textBox4.Text);
                consulta.Parameters.AddWithValue("fecha_baja", textBox5.Text);

            }
            MessageBox.Show("CONSULTA COMPLETA");
            conx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Tutor = new Tutor();
            Tutor.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form TutorAlumno = new TutorAlumno();
            TutorAlumno.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form PagoMatricula = new PagoMatricula();
            PagoMatricula.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form PagoRealizado = new PagoRealizado();
            PagoRealizado.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Alergias = new Alergias();
            Alergias.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Comida = new Comida();
            Comida.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Costo_Mensual = new Costo_Mensual();
            Costo_Mensual.ShowDialog();
        }
    }
}
