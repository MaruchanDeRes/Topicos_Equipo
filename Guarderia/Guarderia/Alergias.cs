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
    public partial class Alergias : Form
    {
        public Alergias()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(640, 370); // Ancho y alto del formulario
            this.MaximizeBox = false; // Deshabilitar el botón de maximizar
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Fijar el borde del formulario
        }
        SqlConnection conx = new SqlConnection("Data Source=LavBal\\SQLEXPRESS01;Initial Catalog=Guarderia;Integrated Security=True");
        private void CargarDatos()
        {
            conx.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Nino", conx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; // Asegúrate de que el nombre del DataGridView es correcto
            conx.Close();
        }
        private void Alergias_Load(object sender, EventArgs e)
        {

            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand altas = new SqlCommand("INSERT INTO Alergia ( num_matricula,nombre_ingrediente ) VALUES (@num_matricula, @nombre_ingrediente )", conx);
            altas.Parameters.AddWithValue("num_matricula", textBox1.Text);
            altas.Parameters.AddWithValue("nombre_ingrediente", textBox2.Text);
           
            CargarDatos();
            conx.Open();



            altas.ExecuteNonQuery();


            MessageBox.Show("Se han subido sus datos ☺,Eres un genio ♥");
            conx.Close();
            textBox1.Clear();
            textBox2.Clear();
           
            CargarDatos();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string baja = " DELETE FROM Alergia WHERE num_matricula = @num_matricula";

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
        private void button2_Click(object sender, EventArgs e)
        {
           
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
            Comida Comida = new Comida();
            Comida.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Costo_Mensual Costo_Mensual = new Costo_Mensual();
            Costo_Mensual.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Alumno alumno = new Alumno();  // Crea una instancia de Alumno
            alumno.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Tutor tutor= new Tutor();
            tutor.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            PagoRealizado pagosr = new PagoRealizado();
            pagosr.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            PagoMatricula psgom = new PagoMatricula();
            psgom.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Comida comida = new Comida();
            comida.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();    
            Costo_Mensual costo = new Costo_Mensual();
            costo.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TutorAlumno alumno=new TutorAlumno();
            alumno.Show();
        }
    }
}
