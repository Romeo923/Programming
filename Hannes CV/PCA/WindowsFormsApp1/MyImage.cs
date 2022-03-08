using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace FaceRecogPCA
{
    /// <summary>
    /// Summary description for MyImage.
    /// </summary>
    public class MyImage : IComparable, ICloneable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap BmpImg { get; set; }
        public string Id { get; set; } // id of image
        public string FileName { get; set; } // full path name
        public string FileNameShort { get; set; } // short file name for image
        public double ImgMean { get; set; }
        public double[] ImgVector;// linearized pixel values
        public double[] ImgVectorAdjM;// linearized pixel values minus mean image
        public double[] FSV;// Face space vector, projection onto reduced Dimension
        ImgComparison imgCompareMode;
        public ImgComparison ImgCompareMode { get; set; }
        public double CorrError { get; set; }
        public double EuclideanError { get; set; } // L2 Norm
        public MyImage()
        {
        }
        public MyImage(int width, int height, string id)
        {
            this.Id = id;
            this.ImgVector = new double[width * height];
        }
        public MyImage(string fname, string id, int width, int height, ImgFormat imf, ImgComparison imc)
        {
            FileInfo finfo = new FileInfo(fname);
            string dirName = finfo.Directory.Name;
            this.FileNameShort = finfo.Name;
            this.Id = id;
            this.FileName = fname;
            imgCompareMode = imc;
            ReadPic(imf, width, height); // read the picture into an 1-D array
            FindImageMean();
            this.ImgVectorAdjM = new double[width * height];
            this.FSV = new double[width * height];
        }
        private void ReadPic(ImgFormat imf, int width, int height)
        {
            try
            {
                Bitmap b = new Bitmap(this.FileName);
                this.BmpImg = new Bitmap(b, new Size(width, height));
                ImgVector = new double[width * height];
                int k = 0; int r1a, g1a, b1a, gray;
                Color c1;
                for (int i = 0; i < height; i++)

            for (int j = 0; j < width; j++)
                {
                    c1 = b.GetPixel(j, i);
                    r1a = c1.R;
                    g1a = c1.G;
                    b1a = c1.B;
                    if (r1a != b1a)
                        gray = (int)(.299 * r1a
                        + .587 * g1a
                        + .114 * b1a);
                    else
                        gray = b1a;
                    ImgVector[k++] = gray;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "ImageArray Creation Error");
            }
        }
        //-------------------FindImageMean---------------------------
        void FindImageMean()
        {
            double imgSum = 0;
            for (int i = 0; i < this.ImgVector.Length; i++)
                imgSum = imgSum + this.ImgVector[i];
            this.ImgMean = imgSum / this.ImgVector.Length;
        }
        //------------------------------------------------------------------
        public int CompareTo(Object rhs) // for sorting
        {
            MyImage im = (MyImage)rhs;
            if (imgCompareMode == ImgComparison.CORRELATION)
                return im.CorrError.CompareTo(this.CorrError); // index 0 is best
            else
                return im.EuclideanError.CompareTo(this.EuclideanError);
        }
        public object Clone() // for in memory copy
        {
            MyImage clone = (MyImage)this.MemberwiseClone();
            if (this.FSV != null)
                clone.FSV = (double[])(this.FSV.Clone());
            if (this.ImgVector != null)
                clone.ImgVector = (double[])(this.ImgVector.Clone());
            if (this.ImgVectorAdjM != null)
                clone.ImgVectorAdjM = (double[])(this.ImgVectorAdjM.Clone());
            return clone;
        }
    }
}