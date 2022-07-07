using System.Drawing;

namespace MapForms.Helpers
{
    public static class ImageHelper
    {
        public static Color DefaultColor = Color.Black;
        public static int DeffaultTolerance = 3;

        /// <summary>
        /// Rotate image on angle
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="angle"></param>
        /// <returns>Rotted image</returns>
        public static Bitmap RotateImage(Bitmap bitmap, float angle, Point point = new Point())
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(bitmap.Width , bitmap.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(bitmap, point.X, point.Y, 32, 32);
            }
            return returnBitmap;
        }

        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }

        public static Bitmap ColorReplace(Image inputImage, int tolerance, Color newColor)
        {
            return ColorReplace(inputImage, tolerance, DefaultColor, newColor);
        }

        public static Bitmap ColorReplace(Image inputImage, Color newColor)
        {
            return ColorReplace(inputImage, DefaultColor, newColor);
        }

        public static Bitmap ColorReplace(Image inputImage, Color oldColor, Color newColor)
        {
            return ColorReplace(inputImage, DeffaultTolerance, oldColor, newColor);
        }

        public static Bitmap ColorReplace(Image inputImage, int tolerance, Color oldColor, Color newColor)
        {
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);
            Graphics G = Graphics.FromImage(outputImage);
            G.DrawImage(inputImage, 0, 0);
            for (int y = 0; y < outputImage.Height; y++)
            {
                for (int x = 0; x < outputImage.Width; x++)
                {
                    Color PixelColor = outputImage.GetPixel(x, y);
                    if (PixelColor.R > oldColor.R - tolerance && PixelColor.R < oldColor.R + tolerance && 
                        PixelColor.G > oldColor.G - tolerance && PixelColor.G < oldColor.G + tolerance && 
                        PixelColor.B > oldColor.B - tolerance && PixelColor.B < oldColor.B + tolerance &&
                        PixelColor.A > oldColor.A - tolerance && PixelColor.A < oldColor.A + tolerance)
                    {
                        int RColorDiff = oldColor.R - PixelColor.R;
                        int GColorDiff = oldColor.G - PixelColor.G;
                        int BColorDiff = oldColor.B - PixelColor.B;
                        int AColorDiff = oldColor.A - PixelColor.A;

                        if (PixelColor.R > oldColor.R) RColorDiff = newColor.R + RColorDiff;
                        else RColorDiff = newColor.R - RColorDiff;
                        if (RColorDiff > 255) RColorDiff = 255;
                        if (RColorDiff < 0) RColorDiff = 0;

                        if (PixelColor.G > oldColor.G) GColorDiff = newColor.G + GColorDiff;
                        else GColorDiff = newColor.G - GColorDiff;
                        if (GColorDiff > 255) GColorDiff = 255;
                        if (GColorDiff < 0) GColorDiff = 0;

                        if (PixelColor.B > oldColor.B) BColorDiff = newColor.B + BColorDiff;
                        else BColorDiff = newColor.B - BColorDiff;
                        if (BColorDiff > 255) BColorDiff = 255;
                        if (BColorDiff < 0) BColorDiff = 0;

                        if (PixelColor.A > oldColor.A) AColorDiff = newColor.A + AColorDiff;
                        else AColorDiff = newColor.A - AColorDiff;
                        if (AColorDiff > 255) AColorDiff = 255;
                        if (AColorDiff < 0) AColorDiff = 0;

                        outputImage.SetPixel(x, y, Color.FromArgb(AColorDiff, RColorDiff, GColorDiff, BColorDiff));
                    }
                }
            }
            return outputImage;
        }

        public static Bitmap ReplaceColorMatrix(Bitmap image, Color newColor)
        {
            return ReplaceColorMatrix(image, DefaultColor, newColor);
        }

        public static Bitmap ReplaceColorMatrix(Bitmap image, Color oldColor, Color newColor)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color gotColor = image.GetPixel(x, y);
                    if(gotColor.ToArgb() == oldColor.ToArgb())
                    {
                        image.SetPixel(x, y, newColor);
                    }
                }
            }
            return image;
        }

        public static Bitmap DrawCircule()
        {
            using (Bitmap btm = new Bitmap(25, 25))
            {
                using (Graphics grf = Graphics.FromImage(btm))
                {
                    using (Brush brsh = new SolidBrush(ColorTranslator.FromHtml("#ff00ffff")))
                    {
                        grf.FillEllipse(brsh, 0, 0, 19, 19);
                    }
                }
                return btm;
            }
        }
    }
}
