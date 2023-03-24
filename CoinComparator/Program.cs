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

        Mat imgGray = new();
        CvInvoke.CvtColor(img, imgGray, ColorConversion.Bgr2Gray);

        Mat imgBlur = new();
        CvInvoke.GaussianBlur(imgGray, imgBlur, new System.Drawing.Size(7, 7), 0);

        Mat imgSobel= new();
        CvInvoke.Sobel(imgBlur, imgSobel, DepthType.Cv64F, 0, 1, 3);
        
        Mat imgCanny = new();
        CvInvoke.Canny(imgBlur, imgCanny, 50, 100);

        Mat imgThreshold = new();
        CvInvoke.Threshold(imgCanny, imgThreshold, 100, 200, ThresholdType.BinaryInv);

        CvInvoke.Imshow("Input image", img);
        CvInvoke.Imshow("Output image - Sobel edges", imgSobel);
        CvInvoke.Imshow("Output image - Canny edges", imgCanny);
        CvInvoke.Imshow("Output image - Canny Threshold", imgThreshold);
        CvInvoke.WaitKey(0);
        CvInvoke.DestroyAllWindows();
    }
}