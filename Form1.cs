using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Metronome
{
    public partial class MainForm : Form
    {
        int BPM = 60;
        bool timer_on = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }

            label1.Text = "--";
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
            if (checkBox1.Checked || checkBox2.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
            if (checkBox1.Checked || checkBox2.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "BPM")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "BPM";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number))
            {
                if (timer_on)
                {
                    timer_on = !timer_on;
                    timer1.Stop();
                    button1.Text = "СТАРТ";
                    textBox1.Enabled = !textBox1.Enabled;
                    panel2.Enabled = !panel2.Enabled;
                }
                else
                {
                    timer_on = !timer_on;
                    timer1.Start();
                    button1.Text = "СТОП";
                    BPM = int.Parse(textBox1.Text);
                    textBox1.Enabled = !textBox1.Enabled;
                    panel2.Enabled = !panel2.Enabled;
                }
            }
            else
            {
                MessageBox.Show("Введите число", "Ошибка");
            }
        }

        private void ChangeBpm(int count)
        {
            if (BPM + count > 0)
            {
                BPM += count;
            } else {
                BPM = 0;
            }
        }
    }
}