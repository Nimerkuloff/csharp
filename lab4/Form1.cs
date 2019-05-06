using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace lab4
{
    public partial class Form1 : Form
    {
        int rows, cols;
        int rows2, cols2;
       
    
        public Form1()
        {
            InitializeComponent();
        }

        private double[][] toJaggedArray(double[,] arrFinal)
        {
            double[][] jarray = new double[rows][];
            var buffer = new List<double>(); 
           
            for (int k = 0; k < rows; k++)
            {
                for (int i = 0; i < cols2; i++)
                {
                    if (arrFinal[k,i] >= 0)
                    {
                        buffer.Add(arrFinal[k, i]);
                    }
                }
                jarray[k] = new double[buffer.Count] ;
                buffer.CopyTo(jarray[k]);
                buffer.Clear();
            }
            return jarray;
        }
        private void printJaggedArray(double[][] jarray)
        {
            for (int k = 0; k < rows; k++)
            {
                string rowToString ="";
                for (int i = 0; i < jarray[k].Length; i++)
                {
                    rowToString += Math.Round(jarray[k][i], 1).ToString()+"  ";
                    
                }
                    label5.Text += "jarray[" + k + "] = { " + rowToString+"}" + "\n";
            }
        }
        private void processMatrices()
        {
            bool notSquareMatrix = rows != cols && rows2 != cols2;
            if (notSquareMatrix)
            {
                initLabel();
                setRowsAndCols();

                double[,] arr1 = randomInit(rows, cols);
                arrToGrid(1, arr1);

                double[,] arr2 = randomInit(rows2, cols2);
                arrToGrid(2, arr2);

                double[,] arrFinal = multiplyMatrices(arr1, arr2);
                double[][] jarray = toJaggedArray(arrFinal);

                printJaggedArray(jarray);
            }
            else
            {
                errorLabel.Text = "перезапустите программу и\nвведите прямоугольные матрицы";
            }
        }
       

        private double[,] multiplyMatrices(double[,] arrA, double[,] arrB)
        {
            if (cols == rows2)
            {
                double[,] arrC = new double[rows, cols2];
                for (int iA = 0; iA < rows; iA++)
                {
                    for (int iB = 0; iB < cols2; iB++)
                    {
                        arrC[iA, iB] = 0;
                        for (int iC = 0; iC < cols; iC++)
                        {
                            arrC[iA, iB] += arrA[iA, iC] * arrB[iC, iB];
                        }
                    }
                }
                return arrC;
            }
            else
            {
                double[,] nullArr = new double[1, 1];
                return nullArr;
            }
        }

        private void setRowsAndCols()
        {
            dataGridView1.RowCount = rows;
            dataGridView1.ColumnCount = cols;
            dataGridView2.RowCount = rows2;
            dataGridView2.ColumnCount = cols2;
        }



        private double[,] randomInit(int rows, int cols)
        {
            //Заполняем матрицу случайными числами
            double[,] arr = new double[rows, cols];
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rand.NextDouble()*15-5;
                }
            }
            return arr;
        }
        private void arrToGrid(int numOfMatrix, double[,] arr1or2)
        {
            if (numOfMatrix == 1)
            {
                //Выводим матрицу в dataGridView1
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(arr1or2[i, j]);
                    }
                }
            }
            else if (numOfMatrix == 2)
            {
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = Convert.ToString(arr1or2[i, j]);
                    }
                }
            }
           
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void initLabel()
        {
            errorLabel.Text = "";
        }




        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && IsDigitsOnly(textBox1.Text))
            {
                rows = Convert.ToInt32(textBox1.Text);
            }
            else
            {
                textBox1.ResetText();
            }
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && IsDigitsOnly(textBox2.Text))
            {
                cols = Convert.ToInt32(textBox2.Text);
            }
            else
            {
                textBox2.ResetText();
            }
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && IsDigitsOnly(textBox3.Text))
            {
                rows2 = Convert.ToInt32(textBox3.Text);
            }
            else
            {
                textBox3.ResetText();
            }
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && IsDigitsOnly(textBox4.Text))
            {
                cols2 = Convert.ToInt32(textBox4.Text);
            }
            else
            {
                textBox4.ResetText();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            processMatrices();
        }
        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (rows == cols || rows2 == cols2)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
    }
}
