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
        CvInvoke.GaussianBlur(img_gray, img_blur, new System.Drawing.Size(7, 7), 0);

        Mat img_sobel= new();
        CvInvoke.Sobel(img_blur, img_sobel, DepthType.Cv64F, 1, 1, 3);

        CvInvoke.Imshow("Input image", img);
        CvInvoke.Imshow("Output image", img_sobel);
        CvInvoke.WaitKey(0);
        CvInvoke.DestroyAllWindows();
    }
}