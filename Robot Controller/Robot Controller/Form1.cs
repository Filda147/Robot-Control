using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Robot_Controller
{
    
    public partial class Form1 : Form
    {
        string Line = "";
        int activeIndex=0;
        string activeCode=" ";
        bool running = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void motor4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Robot_M4;
        }

        private void motor4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Robot_M0;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Robot_M3;
        }

        private void motor2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Robot_M2;
        }

        private void motor2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Robot_M0;
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Robot_M1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedText != null)
                try
                {
                    serialPort1.PortName = comboBox1.SelectedText;
                }
                catch
                {
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
             serialPort1.Open();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value * 100;
            label5.Text = "Interval: "+(float)trackBar1.Value / 10 + " s";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            StreamReader sr = new StreamReader(myStream);
                            Line = sr.ReadToEnd().ToUpper()+" ";
                            richTextBox1.Text = Line;
                            activeCode = Line;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("A");
                
            }
            

        }

        private void panel9_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("B");

            }
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("C");

            }
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("D");

            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("E");

            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("F");

            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("G");

            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("H");

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && activeCode != null && running)
            {
                while (activeCode[activeIndex] != ' ')
                {
                    serialPort1.Write(activeCode[activeIndex].ToString());
                    activeIndex++;
                }
                if (activeIndex != activeCode.Length-1)
                {
                    activeIndex++;
                }
                else
                    activeIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            button1.BackColor = Color.FromArgb(56, 56, 56);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel11_Click(object sender, EventArgs e)
        {
            if (running)
            {
                running = false;
                panel11.BackgroundImage= Properties.Resources.flatDark15;
            }
            else
            {
                running = true;
                panel11.BackgroundImage = Properties.Resources.flatDark13;
            }
        }
    }
}
