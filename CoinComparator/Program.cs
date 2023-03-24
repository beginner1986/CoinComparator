using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

internal class Program
{
    private static void Main(string[] args)
    {
        string fileName = "test_img.png";
        Mat img = CvInvoke.Imread(fileName);

        if (img is null)
        {
            Console.WriteLine($"Failed to open file {fileName}");
            return;
        }

        Mat imgGray = new();
        CvInvoke.CvtColor(img, imgGray, ColorConversion.Bgr2Gray);

        Mat imgBlur = new();
        CvInvoke.GaussianBlur(imgGray, imgBlur, new System.Drawing.Size(7, 7), 0);

        Mat imgSobel= new();
        CvInvoke.Sobel(imgBlur, imgSobel, DepthType.Cv64F, 0, 1, 3);
        
        Mat imgCanny = new();
        CvInvoke.Canny(imgBlur, imgCanny, 50, 100, 3, true);

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