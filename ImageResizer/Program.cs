using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            #region 原始版本
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw1.Stop();
            #endregion

            imageProcess.Clean(destinationPath);

            #region 非同步版本
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw2.Stop();
            #endregion

            Console.WriteLine($"原始版本_花費時間: {sw1.ElapsedMilliseconds} ms");
            Console.WriteLine($"非同步版本_花費時間: {sw2.ElapsedMilliseconds} ms");
            Console.WriteLine(string.Format("效能提升百分比:{0} %" , ((double)(sw1.ElapsedMilliseconds - sw2.ElapsedMilliseconds) / (double)sw1.ElapsedMilliseconds)).ToString());
        }
    }
}
