using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvolFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvolve_Click(object sender, EventArgs e)
        {
            if (pic1.Image != null)
            {
                try
                {
                    
                    Bitmap bmp = new Bitmap(pic1.Image);
                    string kText = filterText.Text;
                    string[] kTextln = kText.Split('\n');
                    int n = kTextln.Length;
                    double[][] kernel = new double[n][];
                    double sum = 0;

                    for (int i = 0; i < n; i++)
                    {
                        kernel[i] = new double[n];
                        string[] line = kTextln[i].Split(',');
                        for(int j = 0; j < line.Length; j++)
                        {
                            string c = line[j].Trim();
                            kernel[i][j] = Convert.ToDouble(c);
                            sum += kernel[i][j];
                        }
                    
                    }

                    sum = sum > 0 ? sum : 1;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            kernel[i][j] /= sum;
                            
                        }

                    }

                    MyImageProc.CovertToGray(bmp);
                    MyImageProc.Convolve(bmp, kernel);
                    pic2.Image = null;
                    pic2.Image = bmp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                this.pic1.Image = new Bitmap(dialog.FileName);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pic2_Click(object sender, EventArgs e)
        {
            if (pic2.Image != null)
            {
                FormImage form = new FormImage();
                form.Height = pic2.Image.Height + 39;
                form.Width = pic2.Image.Width + 16;
                form.BackgroundImage = pic2.Image;
                form.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,0,0\n0,1,0\n0,0,0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filterText.Text = "1,1,1\n1,1,1\n1,1,1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterText.Text = "-1,-1,-1\n-1,0,-1\n-1,-1,-1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,-0.5,0\n-0.5,3,-0.5\n0,-0.5,0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterText.Text = "0.499,0.707,0.499\n0.707,1,0.707\n0.499,0.707,0.499"; //gaussean
        }

        private void button6_Click(object sender, EventArgs e)
        {
            filterText.Text = "-1,0,1\n-2,0,2\n-1,0,1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,1,0\n1,-4,1\n0,1,0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            filterText.Text = "-0.461,0.085,-0.461\n0.085,1.504,0.085\n-0.461,0.085,-0.461";
        }

        private void sobelXbtn_Click(object sender, EventArgs e)
        {
            filterText.Text = "-1,0,1\n-2,0,2\n-1,0,1";
        }

        private void sobelYbtn_Click(object sender, EventArgs e)
        {
            filterText.Text = "-1,-2,-1\n0,0,0\n1,2,1";
        }

        private void edgeBtn_Click(object sender, EventArgs e)
        {
            //string sobelX = "-1,0,1\n-2,0,2\n-1,0,1";
            double[][] sobelX1 = new double[][]
            {
                new double[] { -1, 0, 1 },
                new double[] { -2, 0, 2 },
                new double[] { -1, 0, 1 },
            };

            //string sobelY = "-1,-2,-1\n0,0,0\n1,2,1";

            double[][] sobelY1 = new double[][]
            {
                new double[] { -1, -2, -1 },
                new double[] { 0, 0, 0 },
                new double[] { 1, 2, 1 },
            };

            //string sobelX = "-1,0,1\n-2,0,2\n-1,0,1";
            double[][] sobelX2 = new double[][]
            {
                new double[] { 1, 0, -1 },
                new double[] { 2, 0, -2 },
                new double[] { 1, 0, -1 },
            };

            //string sobelY = "-1,-2,-1\n0,0,0\n1,2,1";

            double[][] sobelY2 = new double[][]
            {
                new double[] { 1, 2, 1 },
                new double[] { 0, 0, 0 },
                new double[] { -1, -2, -1 },
            };

            Bitmap X1 = new Bitmap(pic1.Image);
            Bitmap Y1 = new Bitmap(pic1.Image);
            Bitmap X2 = new Bitmap(pic1.Image);
            Bitmap Y2 = new Bitmap(pic1.Image);
            MyImageProc.CovertToGray(X1);
            MyImageProc.CovertToGray(Y1);
            MyImageProc.CovertToGray(X2);
            MyImageProc.CovertToGray(Y2);
            MyImageProc.Convolve(X1, sobelX1);
            MyImageProc.Convolve(Y1, sobelY1);
            MyImageProc.Convolve(X2, sobelX2);
            MyImageProc.Convolve(Y2, sobelY2);

            Bitmap imgEdges = new Bitmap(X1.Width, X1.Height);

            for (int i = 0, pixel; i < X1.Width; i++)
            {
                for (int j = 0; j < X1.Height; j++)
                {
                    int xp1 = X1.GetPixel(i, j).R;
                    int yp1 = Y1.GetPixel(i, j).R;
                    int xp2 = X2.GetPixel(i, j).R;
                    int yp2 = Y2.GetPixel(i, j).R;

                    int max = 0;
                    max = xp1 > max ? xp1 : max;
                    max = yp1 > max ? yp1 : max;
                    max = xp2 > max ? xp2 : max;
                    max = yp2 > max ? yp2 : max;
                    pixel = max;
                    if (pixel < 50) pixel = 0;

                    imgEdges.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                }
            }

            pic2.Image = null;
            pic2.Image = imgEdges;
        }
    }
}
