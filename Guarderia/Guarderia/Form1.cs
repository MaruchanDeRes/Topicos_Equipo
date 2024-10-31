using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guarderia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Alumno = new Alumno();
            Alumno.ShowDialog();
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

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
