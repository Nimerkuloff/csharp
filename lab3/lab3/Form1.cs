using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab4
{
    public partial class Form1 : Form
    {
        M Mas = new M();
        
        double minEl;
        int minElIndex;
        double firstEl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            textBox1.Text = "";
            for (int i = 0; i < 25; i++)
            {
                Mas[i] = rand.NextDouble();
                textBox1.Text += "Mas[" + Convert.ToString(i) + "] = "
                + Convert.ToString(Mas[i]) + Environment.NewLine;
            }
            firstEl = Mas[0];
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            minEl = Mas[0];
            for (int i = 0; i < 25; i++)
            {
                if (Mas[i] <= minEl)
                {
                    minEl = Mas[i];
                    minElIndex = i;
                }

            }

            label3.Text = "MasMinElement[" + minElIndex + "] = " + Convert.ToString(Mas[minElIndex]) + Environment.NewLine;

            Mas[0] = Mas[minElIndex];
            Mas[minElIndex] = firstEl;
           
            for (int i = 0; i < 25; i++)
            {
                textBox2.Text += "Mas[" + Convert.ToString(i) + "] = " + Convert.ToString(Mas[i]) + Environment.NewLine;
            }
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Enabled = false;
        }

        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
