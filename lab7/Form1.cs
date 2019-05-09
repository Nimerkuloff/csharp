using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace lab7
{
    public partial class Form1 : Form
    {

        private double xMin = 0;
        private double xMax = 6 * Math.PI;
        private double step = (Math.PI * 2) / 10;

        private double[] x;
        private double[] y;
        private double[] z;
        private double[] v;
        public Form1()
        {
            InitializeComponent();
        }


        Chart chart;
        private void CalcFunction()
        {

            // Количество точек графика
            int count = (int)Math.Ceiling((xMax - xMin) / step) + 1;
            // Создаѐм массивы нужных размеров
            x = new double[count];
            y = new double[count];
            z = new double[count];
            v = new double[count];
            // Расчитываем точки для графиков функции
            for (int i = 0; i < count; i++)
            {
                x[i] = xMin + step * i;
                y[i] = (trackBarY.Value) ;
                z[i] = (trackBarZ.Value) ;

                v[i] = Math.Pow(Math.Abs(Math.Cos(x[i]) - Math.Cos(y[i])), 1 + 2 * Math.Pow(Math.Sin(y[i]), 2))
                       * (1 + z[i] + Math.Pow(z[i], 2) / 2 + Math.Pow(z[i], 3) / 3 + Math.Pow(z[i], 4) / 4);

            }

        }
        private void CreateChart()
        {
            chart = new Chart();
            chart.Parent = this;
            chart.SetBounds(10, 10, ClientSize.Width - 20, ClientSize.Height - 20);
            chart.Series.Clear();

            ChartArea area = new ChartArea();
            area.Name = "myGraph";
            area.AxisX.Minimum = xMin;
            area.AxisX.Maximum = xMax;
            area.AxisX.MajorGrid.Interval = step;
            
            chart.ChartAreas.Add(area);

            Series series = new Series();
            series.ChartArea = "myGraph";
            series.ChartType = SeriesChartType.Spline;
            series.BorderWidth = 3;
            series.LegendText = "V";
            
            chart.Series.Add(series);

            Legend legend = new Legend();
            chart.Legends.Add(legend);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateChart();
            CalcFunction();
            chart.Series[0].Points.DataBindXY(x, v);
        }

        private void TrackBarY_ValueChanged(object sender, EventArgs e)
        {
            
            CalcFunction();
            chart.Series[0].Points.DataBindXY(x, v);
        }

        private void TrackBarZ_ValueChanged(object sender, EventArgs e)
        {
            
            CalcFunction();
            chart.Series[0].Points.DataBindXY(x, v);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
