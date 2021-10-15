using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingRomeo
{
    public partial class Form1 : Form
    {

        MyImage myImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                myImage = new MyImage(dialog.FileName);
                imageLabel.Visible = false;
                this.originalPic.Image = myImage.reset();
                this.newPic.Image = myImage.reset();
            }
        }

        private void brightnessBtn_Click(object sender, EventArgs e)
        {
            if (newPic.Image != null)
            {
                int brightness = Convert.ToInt32(brightnessText.Text);
                this.newPic.Image = null;
                this.newPic.Image = myImage.Brightness(brightness);
            } 
        }

        private void contrastBtn_Click(object sender, EventArgs e)
        {
            if (newPic.Image != null)
            {
                int contrast = Convert.ToInt32(contrastText.Text);
                this.newPic.Image = null;
                this.newPic.Image = myImage.Contrast(contrast);
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (newPic.Image != null)
            {
                this.newPic.Image = null;
                this.newPic.Image = myImage.reset();
            }
        }

        private void originalPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                myImage = new MyImage(dialog.FileName);
                imageLabel.Visible = false;
                this.originalPic.Image = myImage.reset();
                this.newPic.Image = myImage.reset();
            }
        }

        private void originalLable_Click(object sender, EventArgs e)
        {

        }

        private void grayscaleBtn_Click(object sender, EventArgs e)
        {
            if (newPic.Image != null)
            {
                this.newPic.Image = null;
                this.newPic.Image = myImage.toGrayscale();
            }
                
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void histEqBtn_Click(object sender, EventArgs e)
        {
            if (newPic.Image != null)
            {
                this.newPic.Image = null;
                this.newPic.Image = myImage.histEq();
            }
            
        }

        private void newPic_Click(object sender, EventArgs e)
        {
            if (newPic.Image != null)
            {
                FormImage form = new FormImage();
                form.Height = newPic.Image.Height + 39;
                form.Width = newPic.Image.Width + 16;
                form.BackgroundImage = newPic.Image;
                form.Show();
            }
            
        }

        private void imageLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                myImage = new MyImage(dialog.FileName);
                imageLabel.Visible = false;
                this.originalPic.Image = myImage.reset();
                this.newPic.Image = myImage.reset();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newPic.Image = myImage.compare(new Bitmap("C:\\Users\\Romeo\\Desktop\\Programming\\Test Images\\highContrast.jpg"), Convert.ToInt32(comparerTextBox.Text));
        }
    }
}



