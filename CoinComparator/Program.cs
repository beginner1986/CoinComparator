using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

internal class Program
{
    private static void Main(string[] args)
    {
        Mat img = CvInvoke.Imread("test_img.png");

        if (img is null)
            return;

        Mat img_gray = new();
        CvInvoke.CvtColor(img, img_gray, ColorConversion.Bgr2Gray);

        Mat img_blur = new();
        CvInvoke.GaussianBlur(img_gray, img_blur, new System.Drawing.Size(3, 3), 0);

        CvInvoke.Imshow("Input image", img);
        CvInvoke.Imshow("Output image", img_blur);
        CvInvoke.WaitKey(0);
        CvInvoke.DestroyAllWindows();
    }
}