using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMan.Lights
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "\\";
            if(args.Count() > 0)
            {
                path = args[0];                
            }

            if (!path.EndsWith("\\"))
                path += "\\";

            if (path == "\\")
                path = "";

            CaptureCurrentScreen(path);
        }

        private static void CaptureCurrentScreen(string path)
        {
            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    bitmap.Save(path + GetFileName(), ImageFormat.Jpeg);
                }
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }
        }

        private static string GetFileName()
        {
            string currentTimeString = DateTime.Now.ToString("yyyyMMddhhmmss");
            return currentTimeString + ".jpg";
        }
    }
}
