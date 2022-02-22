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
                    //Bitmap bmp = new Bitmap("d:\\csharp2015\\images\\scenery1.jpg");
                    //double[][] kernel = new double[3][];
                    //for (int i = 0; i < 3; i++)
                    //    kernel[i] = new double[3];
                    //kernel[0][0] = 1 / 9.0;
                    //kernel[0][1] = 1 / 9.0;
                    //kernel[0][2] = 1 / 9.0;
                    //kernel[1][0] = 1 / 9.0;
                    //kernel[1][1] = 1 / 9.0;
                    //kernel[1][2] = 1 / 9.0;
                    //kernel[2][0] = 1 / 9.0;
                    //kernel[2][1] = 1 / 9.0;
                    //kernel[2][2] = 1 / 9.0;

                    //kernel[0][0] = 0;
                    //kernel[0][1] = -1;
                    //kernel[0][2] = 0;
                    //kernel[1][0] = -1;
                    //kernel[1][1] = 5;
                    //kernel[1][2] = -1;
                    //kernel[2][0] = 0;
                    //kernel[2][1] = -1;
                    //kernel[2][2] = 0;

                    //kernel[0][0] = -1;
                    //kernel[0][1] = -1;
                    //kernel[0][2] = -1;
                    //kernel[1][0] = 0;
                    //kernel[1][1] = 0;
                    //kernel[1][2] = 0;
                    //kernel[2][0] = 1;
                    //kernel[2][1] = 1;
                    //kernel[2][2] = 1;


                    Bitmap bmp = new Bitmap(pic1.Image);
                    string kText = filterText.Text;
                    string[] kTextln = kText.Split('\n');
                    int n = kTextln.Length;
                    double[][] kernel = new double[n][];

                    for (int i = 0; i < n; i++)
                    {
                        kernel[i] = new double[n];
                        string[] line = kTextln[i].Split(',');
                        for(int j = 0; j < line.Length; j++)
                        {
                            string c = line[j].Trim();
                            kernel[i][j] = Convert.ToInt32(c);
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
            filterText.Text = "1,1,1\n1,0,1\n1,1,1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterText.Text = "-1,-1,-1\n-1,1,-1\n-1,-1,-1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,0,0\n0,1,0\n0,0,0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,0,0\n0,1,0\n0,0,0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            filterText.Text = "-1,0,1\n-2,0,2\n-1,0,1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,0,0\n0,1,0\n0,0,0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            filterText.Text = "0,0,0\n0,1,0\n0,0,0";
        }
    }
}
