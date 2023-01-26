using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examen_TercerParical
{
    public partial class Form1 : Form
    {
        int auditivo;
        int kinestesico;
        int visual;
        int total;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = DateTime.Now.ToString("G");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strConnString = "Server=localhost;Port=5432;User Id=postgres;Password=Galletita163;Database=examen_visual";
            string retorno = "";
            try
            {
                visual = Int32.Parse(comboBox1.Text) + Int32.Parse(comboBox5.Text) + Int32.Parse(comboBox13.Text) + Int32.Parse(comboBox12.Text) + Int32.Parse(comboBox11.Text) + Int32.Parse(comboBox20.Text) + Int32.Parse(comboBox19.Text) + Int32.Parse(comboBox28.Text) + Int32.Parse(comboBox24.Text) + Int32.Parse(comboBox23.Text) + Int32.Parse(comboBox32.Text) + Int32.Parse(comboBox36.Text);
                auditivo = Int32.Parse(comboBox2.Text) + Int32.Parse(comboBox3.Text) + Int32.Parse(comboBox10.Text) + Int32.Parse(comboBox9.Text) + Int32.Parse(comboBox21.Text) + Int32.Parse(comboBox17.Text) + Int32.Parse(comboBox16.Text) + Int32.Parse(comboBox27.Text) + Int32.Parse(comboBox26.Text) + Int32.Parse(comboBox22.Text) + Int32.Parse(comboBox35.Text) + Int32.Parse(comboBox31.Text);
                kinestesico = Int32.Parse(comboBox4.Text) + Int32.Parse(comboBox6.Text) + Int32.Parse(comboBox7.Text) + Int32.Parse(comboBox14.Text) + Int32.Parse(comboBox8.Text) + Int32.Parse(comboBox18.Text) + Int32.Parse(comboBox15.Text) + Int32.Parse(comboBox25.Text) + Int32.Parse(comboBox34.Text) + Int32.Parse(comboBox33.Text) + Int32.Parse(comboBox30.Text) + Int32.Parse(comboBox29.Text);
                total = auditivo + visual + kinestesico;
                textBox11.Text = visual.ToString();
                textBox12.Text = auditivo.ToString();
                textBox13.Text = kinestesico.ToString();
                textBox14.Text = total.ToString();

                if(visual > auditivo && visual > kinestesico)
                {
                    MessageBox.Show("Tu canal de aprendizaje es visual");
                    textBox2.Text = "Visual con " + textBox11.Text + " puntos";
                }
                else
                {
                    if (auditivo > kinestesico && auditivo > visual)
                    {
                        MessageBox.Show("Tu canal de aprendizaje es auditivo");
                        textBox2.Text = "Auditivo con " + textBox12.Text + " puntos";
                    }
                    if (kinestesico > visual && kinestesico > auditivo)
                    {
                        MessageBox.Show("Tu canal de apendizaje es kinestesico");
                        textBox2.Text = "Kinestesico con " + textBox13.Text + " puntos";
                    }
                    if (kinestesico == visual)
                    {
                        MessageBox.Show("Tu canal de apendizaje es kinestesico y visual");
                        textBox2.Text = "Kinestesico con " + textBox13.Text + " puntos";
                    }
                    if (kinestesico == auditivo)
                    {
                        MessageBox.Show("Tu canal de apendizaje es kinestesico y auditivo");
                        textBox2.Text = "Kinestesico con " + textBox12.Text + " puntos";
                    }
                }
                

                NpgsqlConnection objConn = new NpgsqlConnection(strConnString);

                string query = "INSERT INTO inteligencia (nombres, apellidos, nacimiento, correo, celular, uno, dos ,tres, cuatro, cinco, seis, siete, ocho, nueve, diez, once, doce, trece, catorce, quince, dseis, docho, dnueve, veinte, d21, d22, d23, d24, d25, d26, d27, d28, d29, c30, c31, c32, c33, c34 , c35, c36, aplicacion, resultado, dsiete) VALUES (@nom,@ape,@naci, @correo, @celu, @uno, @dos, @tres, @cuatro, @cinco, @seis, @siete, @ocho, @nueve, @diez, @once, @doce, @trece, @catorce, @quince, @d6, @d8, @d9, @d20, @d21, @d22, @d23, @d24, @d25, @d26, @d27, @d28, @d29, @c30, @c31, @c32, @c33, @c34, @c35, @c36, @hora, @result, @d7)";
                objConn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(query, objConn);
                comando.Parameters.AddWithValue("@nom", nombres.Text);
                comando.Parameters.AddWithValue("@ape", ape.Text);
                comando.Parameters.AddWithValue("@naci", Convert.ToString(dateTimePicker1.Text));
                comando.Parameters.AddWithValue("@correo", correo.Text);
                comando.Parameters.AddWithValue("@celu", celu.Text);
                comando.Parameters.AddWithValue("@uno", Int32.Parse(comboBox1.Text));
                comando.Parameters.AddWithValue("@dos", Int32.Parse(comboBox2.Text));
                comando.Parameters.AddWithValue("@tres", Int32.Parse(comboBox3.Text));
                comando.Parameters.AddWithValue("@cuatro", Int32.Parse(comboBox4.Text));
                comando.Parameters.AddWithValue("@cinco", Int32.Parse(comboBox5.Text));
                comando.Parameters.AddWithValue("@seis", Int32.Parse(comboBox6.Text));
                comando.Parameters.AddWithValue("@siete", Int32.Parse(comboBox7.Text));
                comando.Parameters.AddWithValue("@ocho", Int32.Parse(comboBox14.Text));
                comando.Parameters.AddWithValue("@nueve", Int32.Parse(comboBox13.Text));
                comando.Parameters.AddWithValue("@diez", Int32.Parse(comboBox12.Text));
                comando.Parameters.AddWithValue("@once", Int32.Parse(comboBox11.Text));
                comando.Parameters.AddWithValue("@doce", Int32.Parse(comboBox10.Text));
                comando.Parameters.AddWithValue("@trece", Int32.Parse(comboBox9.Text));
                comando.Parameters.AddWithValue("@catorce", Int32.Parse(comboBox8.Text));
                comando.Parameters.AddWithValue("@quince", Int32.Parse(comboBox21.Text));
                comando.Parameters.AddWithValue("@d6", Int32.Parse(comboBox20.Text));
                comando.Parameters.AddWithValue("@d8", Int32.Parse(comboBox18.Text));
                comando.Parameters.AddWithValue("@d9", Int32.Parse(comboBox17.Text));
                comando.Parameters.AddWithValue("@d20", Int32.Parse(comboBox16.Text));
                comando.Parameters.AddWithValue("@d21", Int32.Parse(comboBox15.Text));
                comando.Parameters.AddWithValue("@d22", Int32.Parse(comboBox28.Text));
                comando.Parameters.AddWithValue("@d23", Int32.Parse(comboBox27.Text));
                comando.Parameters.AddWithValue("@d24", Int32.Parse(comboBox26.Text));
                comando.Parameters.AddWithValue("@d25", Int32.Parse(comboBox25.Text));
                comando.Parameters.AddWithValue("@d26", Int32.Parse(comboBox24.Text));
                comando.Parameters.AddWithValue("@d27", Int32.Parse(comboBox23.Text));
                comando.Parameters.AddWithValue("@d28", Int32.Parse(comboBox22.Text));
                comando.Parameters.AddWithValue("@d29", Int32.Parse(comboBox35.Text));
                comando.Parameters.AddWithValue("@c30", Int32.Parse(comboBox34.Text));
                comando.Parameters.AddWithValue("@c31", Int32.Parse(comboBox33.Text));
                comando.Parameters.AddWithValue("@c32", Int32.Parse(comboBox32.Text));
                comando.Parameters.AddWithValue("@c33", Int32.Parse(comboBox31.Text));
                comando.Parameters.AddWithValue("@c34", Int32.Parse(comboBox30.Text));
                comando.Parameters.AddWithValue("@c35", Int32.Parse(comboBox29.Text));
                comando.Parameters.AddWithValue("@c36", Int32.Parse(comboBox36.Text));
                comando.Parameters.AddWithValue("@hora", Convert.ToString(textBox1.Text));
                comando.Parameters.AddWithValue("@result", Convert.ToString(textBox2.Text));
                comando.Parameters.AddWithValue("@d7", Int32.Parse(comboBox19.Text));


                comando.ExecuteNonQuery();

                tabControl1.SelectedIndex = 6;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
      
        private void Valuar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
