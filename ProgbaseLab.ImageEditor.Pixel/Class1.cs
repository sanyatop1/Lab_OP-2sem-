using System;
using ProgbaseLab.ImageEditor;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
using System.Diagnostics;
namespace ProgbaseLab.ImageEditor.Pixel


{
    public class Class1:  ProgbaseLab.ImageEditor.Common.IRunnable
    {
         public  void Crop(int height, int width, int top, int left,string filename,string fileout)
        {
            Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
            Bitmap bitmap = new Bitmap(filename);
            if (left>bitmap.Width||width>bitmap.Width||top>bitmap.Height||height>bitmap.Height||left>width||top>height)
            {
                Console.WriteLine("Error");

            }
            else
            {
Console.WriteLine("True");
Bitmap bitmapCopy = new Bitmap(bitmap.Width, bitmap.Height);

for (int i = height; i >top ; i--)
{
   for (int j = width; j >left; j--)
   {
       Color color = bitmap.GetPixel(j, i);
       bitmapCopy.SetPixel(j, i, color);
   }
}
bitmapCopy.Save(fileout);
            }
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);

        }
        public  void RotateLeft90(string filename,string fileout)
        {Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
            Bitmap bitmap = new Bitmap(filename);
Console.WriteLine("True");
bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
bitmap.Save(fileout);
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
        }
         public  void ExtractRed(string filename,string fileout)
         {Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
             Bitmap bitmap = new Bitmap(filename);
             Console.WriteLine("True");

             for (int i = 0; i < bitmap.Height; i++)
{
   for (int j = 0; j < bitmap.Width; j++)
   {
       Color color = bitmap.GetPixel(j, i);
       Color newColor = Color.FromArgb(255, color.R, 0, 0);
       bitmap.SetPixel(j, i, newColor);
   }
}
bitmap.Save(fileout);
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
         }
         public void Grayscale(string filename,string fileout)
         {Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
            Bitmap bitmap = new Bitmap(filename);
             Console.WriteLine("True");

             for (int i = 0; i < bitmap.Height; i++)
{
   for (int j = 0; j < bitmap.Width; j++)
   {
      Color color = bitmap.GetPixel(j, i);
int yLinear = (int)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);
Color newColor = Color.FromArgb(255, yLinear, yLinear, yLinear);
bitmap.SetPixel(j, i, newColor);
   }
}
bitmap.Save(fileout); 
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
         }
         public void ChangeSaturation(string filename,string fileout,int saturation)
         { Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
             Bitmap original = new Bitmap(filename);
             Bitmap newBitmap = new Bitmap(original.Width, original.Height);
             const float lumR = 0.3086f;
   const float lumG = 0.6094f;
   const float lumB = 0.0820f;
   float satCompl = 1.0f - saturation;  // complement
   float satComplR = lumR * satCompl;
   float satComplG = lumG * satCompl;
   float satComplB = lumB * satCompl;
   Graphics g = Graphics.FromImage(newBitmap);
   ColorMatrix colorMatrix = new ColorMatrix(
     new float[][]
   {
       new float[]{satComplR + saturation, satComplR,  satComplR,  0.0f, 0.0f,},
       new float[]{satComplG,  satComplG + saturation, satComplG,  0.0f, 0.0f,},
       new float[]{satComplB,  satComplB,  satComplB + saturation, 0.0f, 0.0f,},
       new float[]{0.0f,   0.0f,   0.0f,   1.0f,   0.0f,},
       new float[]{0.0f,   0.0f,   0.0f,   0.0f,   1.0f,},
   });
   ImageAttributes attributes = new ImageAttributes();
 
   
   attributes.SetColorMatrix(colorMatrix);
   g.DrawImage(
       original,
       new Rectangle(0, 0, original.Width, original.Height),
       0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
 
   attributes.Dispose();
   g.Dispose();
newBitmap.Save(fileout);
Console.WriteLine("True");
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
         }

    }
}
