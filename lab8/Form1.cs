using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            drawSpace(e);
            drawStars(e);
            drawMoon(e);
            drawLawn(e);

            Pen pen = new Pen(Color.ForestGreen);
            DrawBranch(e.Graphics,pen, 7, 15, 250, 350, 50, 5, 0.75f, 1);
            DrawBranch(e.Graphics, pen, 7, 16, 150, 360, 50, 4, 0.6f, 1);

        }

        private static void drawStars(PaintEventArgs e)
        {
            string drawString = "*";
            Font drawFont = new Font("Arial", 5);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            StringFormat drawFormat = new StringFormat();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {

                float x = rnd.Next(0, 500);
                float y = rnd.Next(0, 500);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            }

            drawFont.Dispose();
            drawBrush.Dispose();
        }

        private static void drawSpace(PaintEventArgs e)
        {


            Rectangle rt = new Rectangle(0, 0, 500, 500);
            SolidBrush b = new SolidBrush(Color.Black);
            e.Graphics.FillRectangle(b, rt);

            b.Dispose();
        }

        private static void drawLawn(PaintEventArgs e)
        {
            Pen p = new Pen(Color.ForestGreen, 4.0F);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

            Rectangle rt = new Rectangle(0, 350, 500, 200);
            e.Graphics.DrawEllipse(p, rt);

            HatchBrush b = new HatchBrush(
                 HatchStyle.DottedGrid,
                 Color.YellowGreen,
                 Color.Indigo);

            e.Graphics.FillEllipse(b, rt);
            p.Dispose();
            b.Dispose();
        }

        private static void drawMoon(PaintEventArgs e)
        {
            HatchBrush b = new HatchBrush(
                 HatchStyle.Horizontal,
                 Color.Red,
                 Color.Gray);

            e.Graphics.FillEllipse(b, 0, 0, 100, 60);
            b.Dispose();
        }
        
        private void DrawBranch(Graphics gr, Pen pen,
            int depth, 
            int max_depth, 
            float x, float y,float length, 
            float theta,//rotation 
            float length_scale, //size
            float dtheta)//form
        {
            
            // See where this branch should end.
            float x1 = (float)(x + length * Math.Cos(theta));
            float y1 = (float)(y + length * Math.Sin(theta));

            // Set the pen's color depending on the depth.
            if (depth == 1) pen.Color = Color.Red;
            else
            {
                int g = 255 * (max_depth - depth) / max_depth;
                int r = 139 * (depth - 3) / max_depth;
                if (r < 0) r = 0;
                int b = 0;
                pen.Color = Color.FromArgb(r, g, b);
            }

            // Set the pen's thickness depending on the depth.
            int thickness = 10 * depth / max_depth;
            if (thickness < 0) thickness = 0;
            pen.Width = thickness;

            // Draw the branch.
            gr.DrawLine(pen, x, y, x1, y1);

            // If depth > 1, draw the attached branches.
            if (depth > 1)
            {
                DrawBranch(gr, pen, depth - 1, max_depth, x1, y1,
                    length * length_scale, theta + dtheta, length_scale,
                    dtheta);
                DrawBranch(gr, pen, depth - 1, max_depth, x1, y1,
                    length * length_scale, theta - dtheta, length_scale,
                    dtheta);
            }
        }

    }
}
