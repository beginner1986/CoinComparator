using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

internal class Program
{
    private static void Main(string[] args)
    {
        Mat img = CvInvoke.Imread("test_img.png");
        Mat img_gray = new Mat();
        CvInvoke.CvtColor(img, img_gray, ColorConversion.Bgr2Gray);

        if (img is null)
            return;

        CvInvoke.Imshow("Input image", img);
        CvInvoke.Imshow("Gray image", img_gray);
        CvInvoke.WaitKey(0);
        CvInvoke.DestroyAllWindows();
    }
}