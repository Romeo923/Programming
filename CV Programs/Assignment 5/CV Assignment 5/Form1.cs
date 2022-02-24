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

namespace CV_Assignment_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static List<Point> Shape1 = new List<Point>();
        static List<Point> Shape2 = new List<Point>();

        private void btnInitializeShapes_Click(object sender, EventArgs e)
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
            Shape1.Add(p1a);
            Shape1.Add(p2a);
            Shape1.Add(p3a);
            Shape1.Add(p4a);
            Shape1.Add(p5a);
            Shape1.Add(p6a);
            Shape1.Add(p7a);
            Transformation T2 = new Transformation();
            T2.A = 1.05; T2.B = 0.05; T2.T1 = 15; T2.T2 = 22;
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
    }
}
