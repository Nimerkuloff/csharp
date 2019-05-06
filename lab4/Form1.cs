using System;
using System.Windows.Forms;


namespace lab4
{
    public partial class Form1 : Form
    {
        int rows, cols;
        int rows2, cols2;
        private int arrFinalSize = 0;

        public Form1()
        {
            InitializeComponent();
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
                arrToGrid(3, arrFinal);

                //getNumOfNonNegativeElems(arrFinal);

            }
            else
            {
                errorLabel.Text = "перезапустите программу и\nвведите прямоугольные матрицы";
            }
        }

        private void getNumOfNonNegativeElems(double[,] arrFinal)
        {
            foreach (double elem in arrFinal)
            {
                if (elem >= 0)
                {
                    arrFinalSize++;
                }
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

        private void initLabel()
        {
            errorLabel.Text = "";
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
                    arr[i, j] = rand.NextDouble() * 10;
                }
            }
            
            return arr;
        }
        private void arrToGrid(int numOfMatrix, double[,] arr1or2or3)
        {
            if (numOfMatrix == 1)
            {
                //Выводим матрицу в dataGridView1
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(arr1or2or3[i, j]);
                    }
                }
            }
            else if (numOfMatrix == 2)
            {
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = Convert.ToString(arr1or2or3[i, j]);
                    }
                }
            }
            else if (numOfMatrix == 3)
            {
                if (!arr1or2or3.Equals(0))
                {
                    dataGridView3.RowCount = rows;
                    dataGridView3.ColumnCount = cols2;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols2; j++)
                        {
                            if (arr1or2or3[i, j] >= 0)
                            {
                                dataGridView3.Rows[i].Cells[j].Value = Convert.ToString(arr1or2or3[i, j]);
                            }
                            else
                            {
                                dataGridView3.Rows[i].Cells[j].Value = "*";
                            }
                        }

                    }
                }
                else
                {
                    errorLabel.Text = "эти матрицы нельзя перемножить";
                }
            }
        }





        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") rows = Convert.ToInt32(textBox1.Text);
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "") cols = Convert.ToInt32(textBox2.Text);
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "") rows2 = Convert.ToInt32(textBox3.Text);
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "") cols2 = Convert.ToInt32(textBox4.Text);
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
