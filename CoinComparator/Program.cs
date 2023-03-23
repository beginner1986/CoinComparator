using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

internal class Program
{
    private static void Main(string[] args)
    {
        string window = "Coin Comparator";
        CvInvoke.NamedWindow(window);

        Mat img = CvInvoke.Imread("test_img.png");

        if (img is null)
            return;

        CvInvoke.Imshow(window, img);
        CvInvoke.WaitKey(0);
        CvInvoke.DestroyWindow(window);
    }
}