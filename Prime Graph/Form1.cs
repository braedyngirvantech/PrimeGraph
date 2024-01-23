using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prime_Graph
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            Width = 1100;
            Height = 1100;

            List<int> primes = new List<int> { 2, 3 };
            bool isPrime = true;

            for (int p = 5; p < 1000; p += 2)
            {
                isPrime = true;
                for (int c = 0; c < primes.Count; c++)
                {
                    if (!(c < Math.Sqrt(p)))
                        break;
                    if (p % primes[c] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    primes.Add(p);
            }


            for (int i = 0; i < primes.Count; i+= 2)
            {
                points.Add(new Point(primes[i], primes[i+1]));
            }


            Shown += OnShown;
        }

        void OnShown(object sender, EventArgs e)
        {
            Graphics graph = CreateGraphics();
            graph.Clear(Color.Black);
            foreach (Point p in points)
            {
                graph.FillRectangle(Brushes.Yellow, p.X-1, p.Y-1, 3, 3);
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                int xDif = points[i + 1].X - points[i].X,
                    yDif = points[i + 1].Y - points[i].Y;

                if (xDif == yDif)
                {
                    graph.DrawLine(Pens.White, points[i], points[i + 1]);
                }
                else if (xDif < yDif)
                {
                    graph.DrawLine(Pens.Red, points[i], points[i + 1]);
                }
                else if (xDif > yDif)
                {
                    graph.DrawLine(Pens.Green, points[i], points[i + 1]);
                }

            }
        }
    }
}
