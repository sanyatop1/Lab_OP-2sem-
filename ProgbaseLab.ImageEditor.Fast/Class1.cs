using System;
using ProgbaseLab.ImageEditor;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace ProgbaseLab.ImageEditor.Fast
{
    public class Class1: ProgbaseLab.ImageEditor.Common.IRunnable
    {
        public  void Crop(int height, int width, int top, int left,string filename,string fileout)
        {
             Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
            Mat bmp = new Mat(filename);
            
            Rect rectCrop = new Rect(height,width ,left, top);
            Mat result = new Mat(bmp, rectCrop);
             result.SaveImage(fileout);
             stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed)
            

            ;


        }
        public  void RotateLeft90(string filename,string fileout)
        {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
       Mat bmp = new Mat(filename);
       Mat result = new Mat();
       result.SaveImage(fileout);
 
       Point2f center = new Point2f(bmp.Width / 2, bmp.Height / 2);
       Mat matrix = Cv2.GetRotationMatrix2D(center, 270, 1);  // angle + scale
       Cv2.WarpAffine(bmp, result, matrix, bmp.Size());
       result.SaveImage(fileout);
       Console.WriteLine("True");
       stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);

        }
         public  void ExtractRed(string filename,string fileout)
         {Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
              Mat bmp = new Mat(filename);
       Mat[] channels = Cv2.Split(bmp);  // BGR
       channels[0].SetTo(0);
       channels[1].SetTo(0);
       Mat result = new Mat();
       Cv2.Merge(channels, result);
       result.SaveImage(fileout);
       Console.WriteLine("True");
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
         }
         public void Grayscale(string filename,string fileout)
         {Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
              Mat bmp = new Mat(filename);
       Mat[] channels = Cv2.Split(bmp);
       for(int i = 0; i < channels.Length; i++)
       {
           Mat channel = channels[i];
           channel.SaveImage(fileout);
       }
       Console.WriteLine("True");
stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
         }
          public void ChangeSaturation(string filename,string fileout,int saturation)
         {
             Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
              Mat bmp = new Mat(filename);
       Mat result = new Mat();
       Cv2.Filter2D(bmp, result,-1,saturation);
       result.SaveImage(fileout);
       stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
         }
    }
}
