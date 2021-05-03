using System;
using ProgbaseLab.ImageEditor;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace ProgbaseLab.ImageEditor.Common
{
    public interface IRunnable

    {
        
        void Crop(int height, int width, int top, int left,string filename,string fileout);
          void RotateLeft90(string filename,string fileout);
          void ExtractRed(string filename,string fileout);
          void Grayscale(string filename,string fileout);
          void ChangeSaturation(string filename,string fileout,int saturation);
        
    }
    
}
