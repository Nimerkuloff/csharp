using System;
using System.Text.RegularExpressions;
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
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            a = (string)listBox1.Items[0];

            Match match = Regex.Match(a, "\\d");
           
            for(int i = 0; i < a.Length; i++)
            {
               
                if (match.Success)
                {
                    label1.Text += match.Value;
                }
                match = match.NextMatch();
            }
            
        }
    }
}
