using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecogPCA;

namespace Assignment_8
{
    public partial class Form1 : Form
    {
        
        Matrix I; // pixels x number of images
        Matrix average_face; // height x width
        Matrix eig_faces; // pixels x number of eig faces
        Matrix[] image_features; // number of eig faces x number of images

        int image_width = 92;
        int image_height = 112;
        int classes = 40;
        int images_per_class = 5;
        int num_eig_faces = 30;

        int size;
        int number_of_images;


        void loadImages()
        {
            string training_path = "C:/Users/Romeo/Desktop/Coding/Programming/Test Images/ATTFaceDataSet/Training/";

            size = image_width * image_height;
            number_of_images = classes * images_per_class;

            I = new Matrix(size, number_of_images);
            average_face = new Matrix(size, 1);
            Bitmap average_bitmap = new Bitmap(image_width, image_height);

            for(int current_class = 1, column_index = 0; current_class <= classes; current_class++)
            {
                
                for(int current_image = 1;current_image <= images_per_class; current_image++)
                {
                    string image_path = training_path + "S" + current_class + "_" + current_image + ".jpg";
                    Bitmap image = new Bitmap(image_path);

                    for (int column = 0, row_index = 0; column < image.Width; column++)
                    {
                        for(int row = 0; row < image.Height; row++)
                        {
                            Color pixel = image.GetPixel(column, row);
                            int value = pixel.R;
                            I[row_index, column_index] = value;
                            average_face[row_index, 0] += value;
                            row_index++;
                        }
                    }
                    column_index++;

                }
            }
            
            for(int i = 0, count = 0; i < image_width; i++)
            {
                for(int j = 0; j < image_height; j++)
                {
                    int pixel = (int)average_face[count, 0];
                    pixel /= number_of_images;
                    average_face[count++, 0] = pixel;
                    average_bitmap.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                }
            }
            pictureBox9.Image = average_bitmap; 
            
            for (int i = 0; i < number_of_images; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    I[j, i] -= (int)average_face[j, 0];  // dimentions: pixels x images
                }
            }

            Matrix cov = (Matrix)I.Transpose().Multiply(I); // dimentions: images x images
            IEigenvalueDecomposition eig = cov.GetEigenvalueDecomposition();
            Matrix eig_vectors = (Matrix)eig.EigenvectorMatrix; // dimentions: images x images
            eig_vectors = (Matrix)eig_vectors.Submatrix(0, number_of_images-1, number_of_images-num_eig_faces, number_of_images-1); // dimentions: images x num_eig_faces
            eig_faces = (Matrix)I.Multiply(eig_vectors); // dimentions: pixels x num_eig_faces
            image_features = new Matrix[number_of_images];

            for(int i = 0; i < number_of_images; i++)
            {
                Matrix curr_image = (Matrix)I.Submatrix(0, size-1, i, i);
                Matrix features = (Matrix)curr_image.Transpose().Multiply(eig_faces); // dimentions: 1 x num_eig_faces
                image_features[i] = features;
            }

            Bitmap img1 = new Bitmap(image_width, image_height);
            Bitmap img2 = new Bitmap(image_width, image_height);
            Bitmap img3 = new Bitmap(image_width, image_height);

            int min1 = int.MaxValue;
            int max1 = int.MinValue;
            int min2 = int.MaxValue;
            int max2 = int.MinValue;
            int min3 = int.MaxValue;
            int max3 = int.MinValue;
            for (int i = 0; i < size; i++)
            {
                int pixel1 = (int)(eig_faces[i, num_eig_faces - 1]);
                min1 = pixel1 < min1 ? pixel1 : min1;
                max1 = pixel1 > max1 ? pixel1 : max1;
                int pixel2 = (int)(eig_faces[i, num_eig_faces - 2]);
                min2 = pixel2 < min2 ? pixel2 : min2;
                max2 = pixel2 > max2 ? pixel2 : max2;
                int pixel3 = (int)(eig_faces[i, num_eig_faces - 3]);
                min3 = pixel3 < min3 ? pixel3 : min3;
                max3 = pixel3 > max3 ? pixel3 : max3;

            }


            for (int column = 0, index = 0; column < image_width; column++)
            {

                for (int row = 0; row < image_height; row++)
                {
                    double p1 = (int)(eig_faces[index, num_eig_faces - 1]);
                    p1 -= min1;
                    p1 /= (max1 - min1);
                    p1 *= 255;
                    int pixel1 = (int)p1;
                    double p2 = (int)(eig_faces[index, num_eig_faces - 2]);
                    p2 -= min2;
                    p2 /= (max2 - min2);
                    p2 *= 255;
                    int pixel2 = (int)p2;
                    double p3 = (int)(eig_faces[index, num_eig_faces - 3]);
                    p3 -= min3;
                    p3 /= (max3 - min3);
                    p3 *= 255;
                    int pixel3 = (int)p3;

                    index++;

                    img1.SetPixel(column, row, Color.FromArgb(pixel1, pixel1, pixel1));
                    img2.SetPixel(column, row, Color.FromArgb(pixel2, pixel2, pixel2));
                    img3.SetPixel(column, row, Color.FromArgb(pixel3, pixel3, pixel3));
                    
                }
            }
            
            pictureBox5.Image = img1;    
            pictureBox6.Image = img2;
            pictureBox7.Image = img3;
                  
            

        }
        
        void recognize(Bitmap img)
        {
            Matrix image = new Matrix(size, 1);
            for (int i = 0, index = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    int value = pixel.R;
                    image[index, 0] = value - average_face[index, 0];
                    index++;

                }
            }
            Matrix features = (Matrix)image.Transpose().Multiply(eig_faces);
            Matrix reconstruct = (Matrix)features.Multiply(eig_faces.Transpose());
            reconstruct = (Matrix)reconstruct.Transpose();
            Bitmap reconstructed_image = new Bitmap(image_width, image_height);

            int best1 = 0;
            double error1 = int.MaxValue;
            int best2 = 0;
            double error2 = int.MaxValue;
            int best3 = 0;
            double error3 = int.MaxValue;

            for (int k = 0; k < number_of_images; k++)
            {
                Matrix result = (Matrix)features.Subtraction(image_features[k]);
                double error = 0;
                for (int i = 0; i < num_eig_faces; i++)
                {
                    error += result[0, i] * result[0, i];
                }
                error = Math.Sqrt(error);
                if (error < error1)
                {
                    best3 = best2;
                    error3 = error2;

                    best2 = best1;
                    error2 = error1;

                    best1 = k;
                    error1 = error;

                }
                else if (error < error2)
                {
                    best3 = best2;
                    error3 = error2;

                    best2 = k;
                    error2 = error;

                }
                else if (error < error3)
                {
                    best3 = k;
                    error3 = error;
                }

            }


            Bitmap image1 = new Bitmap(image_width, image_height);
            Bitmap image2 = new Bitmap(image_width, image_height);
            Bitmap image3 = new Bitmap(image_width, image_height);

            long min = int.MaxValue;
            long max = int.MinValue;

            for(int i = 0; i< size; i++)
            {
                long p = (long)reconstruct[i, 0];
                min = p < min ? p : min;
                max = p > max ? p : max;
            }

            for (int i = 0, index = 0; i < image_width; i++)
            {
                for (int j = 0; j < image_height; j++)
                {
                    int pixel1 = (int)(I[index, best1] + average_face[index, 0]);
                    int pixel2 = (int)(I[index, best2] + average_face[index, 0]);
                    int pixel3 = (int)(I[index, best3] + average_face[index, 0]);
                    double pR = (int)reconstruct[index, 0];
                    pR -= min;
                    pR /= (max - min);
                    pR *= 255;
                    int pixelR = (int)pR;
                    index++;

                    image1.SetPixel(i, j, Color.FromArgb(pixel1, pixel1, pixel1));
                    image2.SetPixel(i, j, Color.FromArgb(pixel2, pixel2, pixel2));
                    image3.SetPixel(i, j, Color.FromArgb(pixel3, pixel3, pixel3));
                    reconstructed_image.SetPixel(i, j, Color.FromArgb(pixelR, pixelR, pixelR));

                }
            }
            pictureBox2.Image = image1;
            textBox5.Text = "Error: " + error1;
            pictureBox3.Image = image2;
            textBox6.Text = "Error: " + error2;
            pictureBox4.Image = image3;
            textBox7.Text = "Error: " + error3;
            pictureBox8.Image = reconstructed_image;
        }

        public Form1()
        {
            InitializeComponent();
            loadImages();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";

            if (DialogResult.OK == dialog.ShowDialog())
            {
                Bitmap img = new Bitmap(dialog.FileName);
                pictureBox1.Image = img;
                recognize(img);
            }

        }
    }
}
