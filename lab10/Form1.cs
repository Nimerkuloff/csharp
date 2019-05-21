/*4. Разработайте функцию, оставляющую на изображении только один из
каналов (R,G,B). Канал выбирается пользователем.*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {

        private Bitmap bmp;
        bool clicked;

        Image imageGlobal;

        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            clicked = true;



            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF,*.WMF)| *.bmp; *.jpg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем выбран лифайл
            {
                Image image = Image.FromFile(dialog.FileName); //Загружаем в image изображение из выбранного файла

                imageGlobal = image;
                int width = image.Width;
                int height = image.Height;
                // pictureBox1.Width = width;
                // pictureBox1.Height = height;
                bmp = new Bitmap(image, width, height); //создаем и загружаем из image изображение в формате bmp
                pictureBox1.Image = bmp; //записываем изображение в формате bmp в pictureBox1
            }



        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (clicked)
            {

                Bitmap copy = new Bitmap(imageGlobal);

                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {

                        int G = copy.GetPixel(i, j).G; //извлекаем в G значение зеленого цвета в текущей точке
                        int B = copy.GetPixel(i, j).B; //извлекаем в B значение синего цвета в текущей точке

                        Color p = Color.FromArgb(255, 0, G, B);
                        copy.SetPixel(i, j, p); //записываем полученный цвет в текущую точку
                    }
                }
                pictureBox1.Image = copy;
                Refresh(); //вызываем функцию перерисовки окна
            }

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (clicked)
            {
                Bitmap copy = new Bitmap(imageGlobal);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        int R = copy.GetPixel(i, j).R; //извлекаем в R значение красного цвета в текущей точке
                        int B = copy.GetPixel(i, j).B; //извлекаем в B значение синего цвета в текущей точке

                        Color p = Color.FromArgb(255, R, 0, B);
                        copy.SetPixel(i, j, p); //записываем полученный цвет в текущую точку
                    }
                }
                pictureBox1.Image = copy;
                Refresh(); //вызываем функцию перерисовки окна
            }
        }


        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (clicked)
            {
                Bitmap copy = new Bitmap(imageGlobal);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        int R = copy.GetPixel(i, j).R; //извлекаем в R значение красного цвета в текущей точке
                        int G = copy.GetPixel(i, j).G; //извлекаем в G значение зеленого цвета в текущей точке

                        Color p = Color.FromArgb(255, R, G, 0);
                        copy.SetPixel(i, j, p); //записываем полученный цвет в текущую точку
                    }
                }
                pictureBox1.Image = copy;
                Refresh(); //вызываем функцию перерисовки окна
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bmp;
            Refresh();
        }
    }
}


