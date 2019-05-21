using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {

        PointF[] points;
        int tick=0;
        SolidBrush b = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(b, points[tick].X, points[tick].Y, 10, 10);
        }



        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (tick < points.Length-3)
            {
                tick +=3;
                Invalidate();
            }
            else { tick = 0; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int iter = 0;
            float angle = 0;

            //points init 
            points = Enumerable.Range(0, 101)
           .Select(x => new PointF { X = 0, Y = 0 })
           .ToArray(); ;

            do
            {
                iter++;

                points[iter].X = (float)Math.Round(100 * angle);
                points[iter].Y = (float)Math.Round(100 * Math.Sin(angle)) + 250;

                angle += (float)(0.02 * Math.PI);

            } while (angle < 2 * Math.PI);
        }
    }
}
