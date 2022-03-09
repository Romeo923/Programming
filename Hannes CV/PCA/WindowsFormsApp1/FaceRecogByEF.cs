//----------------FaceRecogByEF.cs-----------------
//--- contains important functions for recognizing face by the
//--- Eigen Face technique.
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace FaceRecogPCA
{
    public class FaceRecogByEF
    {
        public List<MyImage> ImageList; // list of stored images
        public MyImage AvgImage = new MyImage();
        public Matrix Cov = null; // Covariance Matrix
        public Matrix I = null; // matrix of mean adjusted images
        public double[] Evals; // Eigen Values
        public double[,] Evecs; // Eigen Vectors
        public List<EvEvec> EVList; // Eigen values and vectors
        public List<EigenFace> EigenFaceList = new List<EigenFace>();
        // list of Eigen faces
        public Matrix EigenFaceMatrix;
        public MyImage unkIm;
        private int imageWidth;
        private int imageHeight;
        public int imageNumPixels;
        private int NumEigenFaces; // significant number of EigenFaces
                                   //--------------------------------------------------
        public FaceRecogByEF(int imWidth, int imHeight, int imPixels, int M)
        {
            imageWidth = imWidth;
            imageHeight = imHeight;
            imageNumPixels = imPixels;
            this.NumEigenFaces = M;
        }
        //----------------------ComputeEFs()----------------
        public void ComputeEFs(ImgComparison imgComparison, string imagesFolder) // Euclidean or Corr
        {
            ImageList = new List<MyImage>();
            //EigenFaceList = new List<EigenFace>();
            EVList = new List<EvEvec>();
            // Scan Stored Image directory and add every jpg to
            // ImageList
            try
            {
                //DirectoryInfo dirInfo = new DirectoryInfo(currDir + "\\" + Sto_ImDir);
                DirectoryInfo dirInfo = new DirectoryInfo(imagesFolder);
                if (!dirInfo.Exists)
                    throw new DirectoryNotFoundException(imagesFolder +
                    "folder does not exist,");
                foreach (FileInfo nextFile in dirInfo.GetFiles())
                {
                    if (nextFile.Extension.ToUpper() == ".JPG")
                        this.ImageList.Add(new MyImage(nextFile.FullName, "II", imageWidth, imageHeight, ImgFormat.TwentyFourBit, imgComparison)); // Euclidean or Corr
                    else
                    if (nextFile.Extension.ToUpper() == ".GIF")

                this.ImageList.Add(new MyImage(nextFile.FullName, "II", imageWidth, imageHeight, ImgFormat.EightBit, imgComparison));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Error creating the ImageList..");
            }
            AdjustAllImages(); // subtract mean image from each image
            ComputeCovMatrix();
            ComputeEigenValuesEigenVectors();
            ComputeEigenFaces();
            ComputeKnownFaceSpace(); // projection of images onto reduced dim
        }
        //-------------------------------------------------
        //--------------------FindAvgImageAndAdjustImages()------------
        void AdjustAllImages()
        { // finds average image, then subtracts average image from
          // each image to obtain zero mean images
            try
            {
                // find average image
                double[] sum = new double[imageWidth * imageHeight];
                for (int i = 0; i < sum.Length; i++)
                    sum[i] = 0;
                for (int i = 0; i < sum.Length; i++)
                {
                    foreach (MyImage img in ImageList)
                    {
                        sum[i] += img.ImgVector[i];
                    }
                }
                this.AvgImage.ImgVector = new double[sum.Length];
                for (int i = 0; i < sum.Length; i++)
                    this.AvgImage.ImgVector[i] = sum[i] / ImageList.Count;
                // subtract average image from each image
                foreach (MyImage mimg in ImageList)
                {
                    SubtractAvgImage(mimg);
                }
                int numImages = ImageList.Count;
                I = new Matrix(imageWidth * imageHeight, numImages);
                int count = 0;
                // copy mean adjusted images into I matrix
                foreach (MyImage mimg in ImageList)
                {
                    for (int j = 0; j < mimg.ImgVectorAdjM.Length; j++)
                        I[j, count] = mimg.ImgVectorAdjM[j];
                    count++;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-------------------------------------------------------------
        //----------------SubtractAvgImage()---------------------
        public void SubtractAvgImage(MyImage img1)
        {
            // subtract average image from given image
            for (int i = 0; i < img1.ImgVector.Length; i++)
            {
                img1.ImgVectorAdjM[i] = img1.ImgVector[i] -
                this.AvgImage.ImgVector[i];
            }
        }
        //-------------------------------------------------
        //---------------------ComputeCovMatrix--------------------
        private void ComputeCovMatrix() // covariance matrix
        {
            Cov = (Matrix)((I.Transpose().Multiply(I)));
        }
        //-------------------------------------------------
        private void ComputeEigenValuesEigenVectors()
        {
            int i, j;
            int n = ImageList.Count;
            Evals = new double[n];
            IMatrix Evecs = new Matrix(n, n);
            IEigenvalueDecomposition eigen = Cov.GetEigenvalueDecomposition();
            Evecs = eigen.EigenvectorMatrix;
            Evals = eigen.RealEigenvalues;
            //---Copy the Eigen values and vectors in EvEvec objects
            //---for easier sorting by Eigen values.
            double[] evcTemp = new double[n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                    evcTemp[j] = Evecs[j, i];
                EVList.Add(new EvEvec(Evals[i], evcTemp, n));
            }
            EVList.Sort(); // sorts, highest Eigen value in pos. 0
        }
        //----------------------------------------------------------
        //-----------ComputeEigenFaces()-------------------------
        private void ComputeEigenFaces()
        {
            int numEFs = 0;
            if (ImageList.Count < NumEigenFaces)
                numEFs = ImageList.Count;
            else
                numEFs = NumEigenFaces;
            EigenFaceMatrix = new Matrix(imageWidth * imageHeight, numEFs);
            // copy EigenVectors into a Matrix

        Matrix EV = new Matrix(ImageList.Count, NumEigenFaces);
            for (int i = 0; i < NumEigenFaces; i++)
            {
                for (int j = 0; j < ImageList.Count; j++)
                    EV[j, i] = EVList[i].EigenVec[j];
            }
            EigenFaceMatrix = (Matrix)(I.Multiply(EV));
            //normalize EigenFace(it is an eigen vector of orig.covar matrix)
            for (int j = 0; j < NumEigenFaces; j++)
            {
                double rsum = 0;
                for (int i = 0; i < imageNumPixels; i++)
                {
                    rsum += EigenFaceMatrix[i, j] * EigenFaceMatrix[i, j];
                }
                for (int i = 0; i < imageNumPixels; i++)
                    EigenFaceMatrix[i, j] = EigenFaceMatrix[i, j] / Math.Sqrt(rsum);
            }
            // Copy Eigen Faces to a List for easier display later
            for (int i = 0; i < NumEigenFaces; i++)
            {
                EigenFace ef = new EigenFace(imageWidth * imageHeight);
                for (int j = 0; j < imageWidth * imageHeight; j++)
                    ef.EF[j] = EigenFaceMatrix[j, i];
                EigenFaceList.Add(ef);
            }
        }
        //---------------------------------------------------------
        //----------ComputeKnownFaceSpace()----------------
        private void ComputeKnownFaceSpace()
        {
            Matrix projection = (Matrix)(I.Transpose().Multiply(EigenFaceMatrix));
            for (int i = 0; i < ImageList.Count; i++)
            {
                for (int j = 0; j < NumEigenFaces; j++)
                    ImageList[i].FSV[j] = projection[i, j];
            }
        }
        //-------------------------------------------------
        //----------ComputeFaceSpace()---------------------
        public void ComputeFaceSpace(MyImage im)
        {
            int i, j;
            double rsum;
            for (i = 0; i < EigenFaceList.Count; i++)
            {
                rsum = 0.0;
                for (j = 0; j < imageNumPixels; j++)
                {
                    EigenFace ef = (EigenFace)EigenFaceList[i];
                    rsum = rsum + im.ImgVectorAdjM[j] * ef.EF[j];
                }
                im.FSV[i] = rsum;
            }
        }

        //-------------------------------------------------
        //-------------------NormalizeEigenFaces()-----------
        void NormalizeEigenFaces()
        {
            // normalize the EigenFace to 0-255 range
            foreach (EigenFace ef in EigenFaceList)
            {
                double max1 = (from n in ef.EF select n).Max();
                double min = (from n in ef.EF select n).Min();
                double diff = max1 - min;
                for (int i = 0; i < ef.EF.Length; i++)
                {
                    ef.EF[i] = ef.EF[i] - min;
                    ef.EF[i] = ef.EF[i] / diff * 255;
                    if (ef.EF[i] < 0)
                        ef.EF[i] = 0;
                    if (ef.EF[i] > 255)
                        ef.EF[i] = 255;
                }
            }
        }
        //---------------------------------------------------
        //--------------GetReconstructedFaceSpaceImage(MyImage img)------------
        public MyImage GetMatchedAndReconstructedImages(MyImage inputImg,
        ref double selfReconstError, ref MatchResult[] bestMatches)
        {
            // assumes data is in Imagevector
            MyImage recImage = new MyImage();
            recImage.ImgVectorAdjM = new double[inputImg.ImgVectorAdjM.Length];
            // subtract mean image from input image
            SubtractAvgImage(inputImg);
            //-------FSV for input image-----------------
            ComputeFaceSpace(inputImg);
            double[] fsvData = inputImg.FSV;
            // Reconstruct the input image
            double[] recData = new double[inputImg.ImgVectorAdjM.Length];
            for (int j = 0; j < inputImg.ImgVectorAdjM.Length; j++)
            {
                recData[j] = 0;
                for (int i = 0; i < NumEigenFaces; i++)
                {
                    recData[j] += fsvData[i] * ((EigenFace)EigenFaceList[i]).EF[j];
                }
            }
            // normalize the reconstructed image to 255 range
            double max1 = (from n in recData select n).Max();
            double min = (from n in recData select n).Min();
            double diff = max1 - min;
            for (int i = 0; i < inputImg.ImgVectorAdjM.Length; i++)
            {
                recData[i] = recData[i] - min;

            recData[i] = (recData[i] / diff) * 255;
                recData[i] = recData[i];
                if (recData[i] < 0)
                    recData[i] = 0;
                if (recData[i] > 255)
                    recData[i] = 255;
            }
            // add mean image
            for (int i = 0; i < recData.Length; i++)
                recImage.ImgVectorAdjM[i] = recData[i] + this.AvgImage.ImgVector[i];
            // readjust the reconstructed image to 0-255 range
            max1 = (from n in recImage.ImgVectorAdjM select n).Max();
            min = (from n in recImage.ImgVectorAdjM select n).Min();
            diff = max1 - min;
            for (int i = 0; i < recImage.ImgVectorAdjM.Length; i++)
            {
                recImage.ImgVectorAdjM[i] = recImage.ImgVectorAdjM[i] - min;
                recImage.ImgVectorAdjM[i] = (recImage.ImgVectorAdjM[i] / diff) * 255;
                if (recImage.ImgVectorAdjM[i] < 0)
                    recImage.ImgVectorAdjM[i] = 0;
                if (recImage.ImgVectorAdjM[i] > 255)
                    recImage.ImgVectorAdjM[i] = 255;
            }
            selfReconstError = 0;
            for (int i = 0; i < inputImg.ImgVectorAdjM.Length; i++)
                selfReconstError = selfReconstError + (inputImg.ImgVector[i] -
                recImage.ImgVectorAdjM[i]) * (inputImg.ImgVector[i] -
                recImage.ImgVectorAdjM[i]);
            selfReconstError = Math.Sqrt(selfReconstError);
            //-----------find best match----------------------------
            MatchResult[] MR = new MatchResult[ImageList.Count];
            for (int i = 0; i < ImageList.Count; i++)
            {
                MR[i] = new MatchResult(i, 0, (MyImage)((MyImage)ImageList[i]).Clone());
                double dist = 0;
                for (int j = 0; j < NumEigenFaces; j++)
                    dist += ((MR[i].mImage.FSV[j] - inputImg.FSV[j]) *
                    (MR[i].mImage.FSV[j] - inputImg.FSV[j]));
                MR[i].EucledianDist = Math.Sqrt(dist);
            }
            //--------------find correlation--------------------
            double[] corr = FindCorrelation(inputImg);
            for (int i = 0; i < ImageList.Count; i++)
                MR[i].Correlation = corr[i];
            Array.Sort(MR);
            bestMatches = MR;
            return recImage;
        }

        public double[] FindCorrelation(MyImage unkIm)
        {
            //----------------correlation ---------------
            // m |
            // S(Xi-X')*(Yi-Y') |--> rtop
            // i=0 |
            // Correlation = --------------------
            // m m |
            // S(Xi-X')² * S(Yi-Y')² |--> rbot1 ^ rbot2
            // i=0 i=0 |
            //-------------------------------------------
            int i, j, k;
            double rsum = 0; double avgunk;
            double[] avgi = new double[ImageList.Count];
            //---------Calculates the unknown face space average---------//
            //------------------ Y' ---------------------------------//
            for (k = 0; k < EigenFaceList.Count; k++)
            {
                rsum = rsum + unkIm.FSV[k];
            }
            avgunk = rsum / EigenFaceList.Count;
            //---------Calculates the known face space average---------//
            //------------------ X' ---------------------------------//
            for (i = 0; i < ImageList.Count; i++)
            {
                rsum = 0.0;
                MyImage im = (MyImage)ImageList[i];
                for (k = 0; k < EigenFaceList.Count; k++)//review
                {
                    rsum = rsum + im.FSV[k];
                }
                avgi[i] = rsum / EigenFaceList.Count;
            }
            //----Calculate the Numerator of the Correlation Equation----//
            double[] rtop = new double[ImageList.Count];
            for (i = 0; i < ImageList.Count; i++)
            {
                rtop[i] = 0.0;
                for (j = 0; j < EigenFaceList.Count; j++)
                {
                    MyImage im = (MyImage)ImageList[i];
                    rtop[i] = rtop[i] + (im.FSV[j] - avgi[i]) *
                    (unkIm.FSV[j] - avgunk);
                }
            }
            //---Calculate the Denominator of the Correlation Equation----//
            double[] rbot1 = new Double[ImageList.Count];
            double[] rbot2 = new Double[ImageList.Count];

        for (i = 0; i < ImageList.Count; i++)
            {
                rbot1[i] = 0.0; rbot2[i] = 0.0;
                for (j = 0; j < EigenFaceList.Count; j++)
                {
                    MyImage im = (MyImage)ImageList[i];
                    rbot1[i] = rbot1[i] + (im.FSV[j] - avgi[i]) * (im.FSV[j] - avgi[i]);
                    rbot2[i] = rbot2[i] + (unkIm.FSV[j] - avgunk) * (unkIm.FSV[j] - avgunk);
                }
            }
            //----Calculate the final Correlation Equation----//
            double[] corr = new double[ImageList.Count];
            for (i = 0; i < ImageList.Count; i++)
                corr[i] = rtop[i] / Math.Sqrt(rbot1[i] * rbot2[i]);
            return corr;
        }
        //-------------------------------------------------
        //-----------Finds the LSE ------------------------
        public void FindLSE()
        {
            // ResultVec = new Double[ImageList.Count];
            for (int i = 0; i < ImageList.Count; i++)
            {
                double rsum = 0.0;
                MyImage im = (MyImage)ImageList[i];
                for (int k = 0; k < EigenFaceList.Count; k++)//review
                {
                    rsum = rsum + (im.FSV[k] - unkIm.FSV[k]) * (im.FSV[k] - unkIm.FSV[k]);
                }
            }
        }
    }
}
