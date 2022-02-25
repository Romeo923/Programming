using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mapack;

namespace Assignment_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static List<Point> Shape1 = new List<Point>();
        static List<Point> Shape2 = new List<Point>();

        private void initializeShapes(object sender, EventArgs e)
        {
            Shape1.Clear();
            Shape2.Clear();
            Point p1a = new Point(20, 30);
            Point p2a = new Point(120, 50);
            Point p3a = new Point(160, 80);
            Point p4a = new Point(180, 300);
            Point p5a = new Point(100, 220);
            Point p6a = new Point(50, 280);
            Point p7a = new Point(20, 140);
            Shape1.Add(p1a); Shape1.Add(p2a);
            Shape1.Add(p3a); Shape1.Add(p4a);
            Shape1.Add(p5a); Shape1.Add(p6a);
            Shape1.Add(p7a);
            Transformation T2 = new Transformation
            { A = 1.05, B = 0.05, T1 = 15, T2 = 22 };
            Shape2 = ApplyTransformation(T2, Shape1);
            Shape2[2] = new Point(Shape2[2].X + 10, Shape2[2].Y + 3);// change one point
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape1.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2, pRed, g);
        }

        void DisplayShape(List<Point> Shp, Pen pen, Graphics g)
        {
            Point? prevPoint = null; // nullable
            foreach (Point pt in Shp)
            {
                g.DrawEllipse(pen, new Rectangle(pt.X - 2, pt.Y - 2, 4, 4));
                if (prevPoint != null)
                    g.DrawLine(pen, (Point)prevPoint, pt);
                prevPoint = pt;
            }
            g.DrawLine(pen, Shp[0], Shp[Shp.Count - 1]);
        }

        public class Transformation
        {
            public double A { get; set; }
            public double B { get; set; }
            public double T1 { get; set; }
            public double T2 { get; set; }
        }

        List<Point> ApplyTransformation(Transformation T, List<Point> shpList)
        {
            List<Point> TList = new List<Point>();
            foreach (Point pt in shpList)
            {
                double xprime = T.A * pt.X + T.B * pt.Y + T.T1;
                double yprime = T.B * pt.X * -1 + T.A * pt.Y + T.T2;
                Point pTrans = new Point((int)xprime, (int)yprime);
                TList.Add(pTrans);
            }
            return TList;
        }

        private void register(object sender, EventArgs e)
        {
            Matrix A = new Matrix(4, 4);
            Matrix B = new Matrix(4, 1);

            for (int i = 0; i < 7; i++)
            {
                Point p1 = Shape1[i];
                int x1 = p1.X;
                int y1 = p1.Y;

                Point p2 = Shape2[i];
                int x2 = p2.X;
                int y2 = p2.Y;

                A[0, 0] += 2 * x2 * x2 + 2 * y2 * y2;

                A[0, 2] += 2 * x2;
                A[0, 3] += 2 * y2;

                A[1, 1] += 2 * x2 * x2 + 2 * y2 * y2;
                A[1, 2] += 2 * y2;
                A[1, 3] -= 2 * x2;

                A[2, 0] -= 2 * x2;
                A[2, 1] -= 2 * y2;
                A[2, 2] -= 2;

                A[3, 0] -= 2 * y2;
                A[3, 1] += 2 * x2;
                A[3, 3] -= 2;

                B[0, 0] += 2 * x1 * x2 + 2 * y1 * y2;
                B[1, 0] += 2 * x1 * y2 - 2 * x2 * y1;
                B[2, 0] -= 2 * x1;
                B[3, 0] -= 2 * y1;

            }

            Matrix result = A.Inverse * B;

            Transformation t = new Transformation
            { A = result[0, 0], B = result[1, 0], T1 = result[2, 0], T2 = result[3, 0] };

            Shape2 = ApplyTransformation(t, Shape2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape2.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2, pRed, g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initializeShapes(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register(sender, e);
        }
    }
}
