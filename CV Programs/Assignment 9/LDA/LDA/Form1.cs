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

namespace LDA
{
    public partial class Form1 : Form
    {

        Matrix Projection;
        Matrix[] Projection_Features;

        int image_width = 92;
        int image_height = 112;
        int classes = 40;
        int images_per_class = 5;
        int num_eig_vectors;

        int size;
        int number_of_images;

        Matrix getImage(int c, int x)
        {

            Matrix image_out = new Matrix(size, 1);
            string training_path = "C:/Users/Romeo/Desktop/Coding/Programming/Test Images/ATTFaceDataSet/Training/";
            string image_path = training_path + "S" + c + "_" + x + ".jpg";
            Bitmap image = new Bitmap(image_path);

            for (int column = 0, row_index = 0; column < image.Width; column++)
            {
                for (int row = 0; row < image.Height; row++)
                {
                    Color pixel = image.GetPixel(column, row);
                    int value = pixel.R;
                    image_out[row_index++, 0] = value;
                }
            }

            return image_out;
        }

        Matrix[] getClassImages(int c)
        {
            return new Matrix[]
            {
                getImage(c,1),
                getImage(c,2),
                getImage(c,3),
                getImage(c,4),
                getImage(c,5),
            };
        }
        
        Matrix getClassMean(int c)
        {
            Matrix mean = new Matrix(size, 1);
            Matrix[] class_images = getClassImages(c);

            foreach(Matrix img in class_images)
            {
                mean = (Matrix)mean.Addition(img);
            }
            mean = (Matrix)mean.Multiply(1.0 / images_per_class);
            return mean;
        }

        Matrix getGlobalMean()
        {
            Matrix mean = new Matrix(size,1);
            for(int i = 1; i <= classes; i++)
            {
                Matrix[] class_images = getClassImages(i);
                foreach(Matrix img in class_images)
                {
                    mean = (Matrix)mean.Addition(img);
                }
            }

            mean = (Matrix)mean.Multiply(1.0 / number_of_images);
            return mean;
        }

        Matrix generateSw()
        {
            Matrix Sw = new Matrix(size, size);
            for(int i = 1; i <= classes; i++)
            {
                Matrix[] class_images = getClassImages(i);
                Matrix class_mean = getClassMean(i);
                foreach(Matrix img in class_images)
                {

                    Matrix mean_adjusted_img = (Matrix)img.Subtraction(class_mean);
                    Matrix Si = (Matrix)mean_adjusted_img.Multiply(mean_adjusted_img.Transpose());
                    Sw = (Matrix)Sw.Addition(Si);
                }
            }

            return Sw;
        }

        Matrix generateSb()
        {
            Matrix Sb = new Matrix(size, size);
            Matrix global_mean = getGlobalMean();

            for (int i = 1; i <= classes; i++)
            {
                Matrix class_mean = getClassMean(i);
                Matrix diff_of_means = (Matrix)class_mean.Subtraction(global_mean);
                Sb = (Matrix)Sb.Addition(diff_of_means.Multiply(diff_of_means.Transpose()));
                Sb = (Matrix)Sb.Multiply(images_per_class);

            }

            return Sb;
        }

        Matrix generateSx()
        {

            Matrix Sw = generateSw();
            Matrix Sb = generateSb();
            return (Matrix)Sw.Inverse.Multiply(Sb);
        }

        void learnProjections()
        {

            size = image_width * image_height;
            number_of_images = classes * images_per_class;
            num_eig_vectors = classes - 1;

            Matrix Sx = generateSx();

            IEigenvalueDecomposition eig = Sx.GetEigenvalueDecomposition();
            Matrix eig_vectors = (Matrix)eig.EigenvectorMatrix;
            eig_vectors = (Matrix)eig_vectors.Submatrix(0, size-1, size - num_eig_vectors, size - 1);

            Sx = null;
            GC.Collect();

            Matrix X = new Matrix(size, number_of_images);
            for(int col = 0; col < number_of_images; col++)
            {
                for (int i = 1; i <= classes; i++)
                {
                    for (int j = 1; j <= images_per_class; j++)
                    {
                        Matrix img = getImage(i, j);
                        for(int x = 0; x < size; x++)
                        {
                            X[x, col] = img[x, 0];
                        }
                    }
                }
            }
            
            Projection = (Matrix)X.Multiply(eig_vectors); // size x num_eig_vectors
            Projection_Features = new Matrix[number_of_images];

            for (int i = 0; i < number_of_images; i++)
            {
                Matrix curr_image = (Matrix)X.Submatrix(0, size - 1, i, i);
                Matrix features = (Matrix)curr_image.Transpose().Multiply(Projection); // dimentions: 1 x num_eig_vectors
                Projection_Features[i] = features;
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
                int pixel1 = (int)(Projection[i, num_eig_vectors - 1]);
                min1 = pixel1 < min1 ? pixel1 : min1;
                max1 = pixel1 > max1 ? pixel1 : max1;
                int pixel2 = (int)(Projection[i, num_eig_vectors - 2]);
                min2 = pixel2 < min2 ? pixel2 : min2;
                max2 = pixel2 > max2 ? pixel2 : max2;
                int pixel3 = (int)(Projection[i, num_eig_vectors - 3]);
                min3 = pixel3 < min3 ? pixel3 : min3;
                max3 = pixel3 > max3 ? pixel3 : max3;

            }


            for (int column = 0, index = 0; column < image_width; column++)
            {

                for (int row = 0; row < image_height; row++)
                {
                    double p1 = (int)(Projection[index, num_eig_vectors - 1]);
                    p1 -= min1;
                    p1 /= (max1 - min1);
                    p1 *= 255;
                    int pixel1 = (int)p1;
                    double p2 = (int)(Projection[index, num_eig_vectors - 2]);
                    p2 -= min2;
                    p2 /= (max2 - min2);
                    p2 *= 255;
                    int pixel2 = (int)p2;
                    double p3 = (int)(Projection[index, num_eig_vectors - 3]);
                    p3 -= min3;
                    p3 /= (max3 - min3);
                    p3 *= 255;
                    int pixel3 = (int)p3;

                    index++;

                    img1.SetPixel(column, row, Color.FromArgb(pixel1, pixel1, pixel1));
                    img2.SetPixel(column, row, Color.FromArgb(pixel2, pixel2, pixel2));
                    img3.SetPixel(column, row, Color.FromArgb(pixel3, pixel3, pixel3));

                    proj1.Image = img1;
                    proj2.Image = img2;
                    proj3.Image = img3;


                }
            }
        }



       

        public Form1()
        {
            InitializeComponent();
            learnProjections();
        }
    }
}
