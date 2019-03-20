using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        string a;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = (string)listBox1.Items[0];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string output = string.Empty;
            
            foreach (char c in a)
            {
                if (c <= '9' && c >= '0')
                {
                    output += c;
                }
            }
            label1.Text = output;
        }
    }
}
