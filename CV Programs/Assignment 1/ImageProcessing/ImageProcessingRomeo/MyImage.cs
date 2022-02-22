using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingRomeo
{
    class MyImage
    {
        private Bitmap original;
        private Bitmap bitmap;
		private Bitmap grayscale;
		
		private SortedDictionary<int,int> hist;

        public MyImage(string path)
        {
            original = new Bitmap(path);
            bitmap = new Bitmap(path);
			grayscale = null;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public Bitmap reset()
        {
            return original;
        }

        public Bitmap Brightness(int brightness)
        {
			if (brightness == 0) return original;

            for(int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {

					Color color = original.GetPixel(i, j);

					int r = Convert.ToInt32(color.R) + brightness;
                    r = r <= 255 ? r : 255;
                    r = r >= 0 ? r : 0;
                    int g = Convert.ToInt32(color.G) + brightness;
                    g = g <= 255 ? g : 255;
                    g = g >= 0 ? g : 0;
                    int b = Convert.ToInt32(color.B) + brightness;
                    b = b <= 255 ? b : 255;
                    b = b >= 0 ? b : 0;

                    bitmap.SetPixel(i,j,Color.FromArgb(r,g,b));
                }
            }

            return bitmap;
        }

		public Bitmap Contrast(int nContrast)
		{
			if (nContrast == 0) return original;

			nContrast = nContrast <= 100 ? nContrast : 100;
			nContrast = nContrast >= -100 ? nContrast : -100;

			double pixel, contrast = (100.0 + nContrast) / 100.0;

			contrast *= contrast;

			int r, g, b;

			for (int y = 0; y < bitmap.Height; ++y)
			{
				for (int x = 0; x < bitmap.Width; ++x)
				{
					Color color = original.GetPixel(x, y);

					r = Convert.ToInt32(color.R);
					g = Convert.ToInt32(color.G);
					b = Convert.ToInt32(color.B);

					pixel = r / 255.0;
					pixel -= 0.5;
					pixel *= contrast;
					pixel += 0.5;
					pixel *= 255;

					pixel = pixel >= 0 ? pixel : 0;
					pixel = pixel <= 255 ? pixel : 255;
					
					r = (int)pixel;

					pixel = g / 255.0;
					pixel -= 0.5;
					pixel *= contrast;
					pixel += 0.5;
					pixel *= 255;

					pixel = pixel >= 0 ? pixel : 0;
					pixel = pixel <= 255 ? pixel : 255;

					g = (int)pixel;

					pixel = b / 255.0;
					pixel -= 0.5;
					pixel *= contrast;
					pixel += 0.5;
					pixel *= 255;

					pixel = pixel >= 0 ? pixel : 0;
					pixel = pixel <= 255 ? pixel : 255;
					
					b = (int)pixel;

					bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
				}

			}

			return bitmap;
		}

		public Bitmap toGrayscale()
        {
			//red: 0.299
			//green: 0.587 
			//blue: 0.114

			if(grayscale != null) return grayscale;
            
			grayscale = new Bitmap(original.Width, original.Height);
			hist = new SortedDictionary<int, int>();

			for (int i = 0; i < original.Width; i++)
            {
				for (int j = 0; j < original.Height; j++)
                {
					Color pixel = original.GetPixel(i, j);

					double gray = (Convert.ToInt32(pixel.R) * 0.299);
					gray += (Convert.ToInt32(pixel.G) * 0.587);
					gray += (Convert.ToInt32(pixel.B) * 0.114);
					int g = (int)gray;
					//int g = Convert.ToInt32(pixel.R);

                    if (!hist.ContainsKey(g)) hist.Add(g, 0);
					hist[g]++;

					grayscale.SetPixel(i, j, Color.FromArgb(g, g, g));
				}
            }
			
			return grayscale;
        }

		public Bitmap histEq()
        {
			toGrayscale();
			
			int MxN = grayscale.Width * grayscale.Height;
			int cdfMin = 999;
			int L = 256;
			Dictionary<int,int> cdf = new Dictionary<int, int>();

			int last = 0;
			foreach(int key in hist.Keys)
            {
				cdf.Add(key, hist[key] + last);
				last = cdf[key];
				cdfMin = cdf[key] < cdfMin ? cdf[key] : cdfMin;
            }

			for(int i = 0; i < bitmap.Width; i++)
            {
				for(int j = 0; j < bitmap.Height; j++)
                {
					Color color = grayscale.GetPixel(i, j);
					int pixel = Convert.ToInt32(color.R);

					double v = cdf[pixel] - cdfMin;
					v /= MxN - cdfMin;
					v *= L - 1;

					int hv = (int)Math.Round(v);

					bitmap.SetPixel(i, j,Color.FromArgb(hv,hv,hv));
                }
            }


			return bitmap;
        }

		public Bitmap compare(Bitmap compare, int percision)
        {
			Bitmap compMap = new Bitmap(compare.Width,compare.Height);
			//int count = 0;
			for (int i = 0; i < compare.Width; i++)
            {
				for(int j = 0; j < compare.Height; j++)
                {
					int pixel = Math.Abs(compare.GetPixel(i, j).R - bitmap.GetPixel(i, j).R) ;

					//if (pixel == 0) count++;

					if (Math.Abs(pixel) <= percision && Math.Abs(pixel) > 0)
                    {
						//Console.WriteLine("My image: " + histeq.GetPixel(i, j).R + "\nWiki Image: " + compare.GetPixel(i, j).R);
						pixel = 0;
						
                    }

					

					compMap.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                }
				
            }
			//Console.WriteLine("\n0 error: " + count);
			//string x = "Wiki image " + compare.Height + ", " + compare.Width + "\nMy Image " + histeq.Height + ", " + histeq.Width;
			//Console.WriteLine(x);
			return compMap;
        }

	}
}