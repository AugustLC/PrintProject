using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Rasterizer;

using RawPrint;
using System.Diagnostics;
using System.Threading;


namespace PrintProject
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Info.columns = 2;
            Info.width = 220;
            Info.height = 220;
            //Info.columns = (int)numericUpDown1.Value;
            string[] hhh = { };
            Info.allfiles = hhh;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int num1 = e.Location.Y / Info.height;

                int num2 = e.Location.X / Info.width;

                string Filepath = Info.pdfs[num1*Info.columns + num2];
                

                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = Filepath;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(2500);
                if (false == p.CloseMainWindow())
                    p.Kill();
                    
            }
            catch { }
        }


        /*private void update()
        {
            Info.columns = (int)numericUpDown1.Value;

            Info.pics = new List<Bitmap>();

            GC.Collect();

            Thread.Sleep(100);

            DirectoryInfo dir = new DirectoryInfo("Temp");
            foreach (FileInfo f in dir.GetFiles())
            {
                f.Delete();
            }

            string[] allPdf = Directory.GetFiles("PDFs");
            Info.pdfs = new List<string>();
            Info.pics = new List<Bitmap>();
            Info.picPaths = new List<string>();
            pictureBox1.Height = 0;


            foreach (string filename in allPdf)
            {
                PdfRasterizer rasterizer = new PdfRasterizer(filename);
                rasterizer.Draw("Temp\\" + Path.GetFileNameWithoutExtension(filename) + ".png", ImageFormat.Png, ImageSize.Dpi300);
                Info.pdfs.Add(filename);
            }

            pictureBox1.Image = new Bitmap(2500, 10000);
            Graphics graph = Graphics.FromImage(pictureBox1.Image);

            int i = 0, j = 0;

            string[] allfiles = Directory.GetFiles("Temp");

            foreach (string filename in allfiles)
            {
                Info.pics.Add(new Bitmap(filename));
                float tempScale = Info.pics[Info.pics.Count - 1].Height / 100;
                tempScale = Info.pics[Info.pics.Count - 1].Width / tempScale;
                Info.width = (int)tempScale + 20;
                Info.pics[Info.pics.Count - 1] = new Bitmap(Info.pics[Info.pics.Count - 1], new Size((int)tempScale, 100));
                Info.picPaths.Add(filename);

                //if (Info.pics[Info.pics.Count - 1].Width > width) width = Info.pics[Info.pics.Count - 1].Width;

                //Info.height = Info.pics[Info.pics.Count - 1].Height;


                //Info.height = Info.pics[Info.pics.Count - 1].Height;

                if (i >= Info.columns) { i = 0; j++; pictureBox1.Height = pictureBox1.Height + Info.height; }

                graph.DrawImage(Info.pics[Info.pics.Count - 1], new Point(i * Info.width, j * Info.height));

                i++;



            }

            if (i < Info.columns) pictureBox1.Height = pictureBox1.Height + Info.height;

            int width = Info.width * Info.columns;
            pictureBox1.Width = width;

            //panel1.Width = width + 20;
            //this.Width = width + 50;
        }*/


        private void update()
        {
            

            Info.pics = new List<Bitmap>();

            GC.Collect();

            Thread.Sleep(500);

            DirectoryInfo dir = new DirectoryInfo("Temp");
            foreach (FileInfo f in dir.GetFiles())
            {
                f.Delete();
            }

            string[] allPdf = Directory.GetFiles("PDFs");
            Info.pdfs = new List<string>();
            Info.pics = new List<Bitmap>();
            Info.picPaths = new List<string>();
            pictureBox1.Height = 0;


            foreach (string filename in allPdf)
            {
                PdfRasterizer rasterizer = new PdfRasterizer(filename);
                rasterizer.Draw("Temp\\" + Path.GetFileNameWithoutExtension(filename) + ".png", ImageFormat.Png, ImageSize.Dpi300);
                Info.pdfs.Add(filename);
            }

            pictureBox1.Image = new Bitmap(2500, 10000);
            Graphics graph = Graphics.FromImage(pictureBox1.Image);

            int i = 0, j = 0, k=0;

            string[] allfiles = Directory.GetFiles("Temp");
            Info.allfiles = allfiles;

            foreach (string filename in allfiles)
            {
                Info.pics.Add(new Bitmap(filename));
                float tempScale = Info.pics[Info.pics.Count - 1].Height / 200;
                tempScale = Info.pics[Info.pics.Count - 1].Width / tempScale;
                if(k==0) Info.width = (int)tempScale + 20;
                Info.pics[Info.pics.Count - 1] = new Bitmap(Info.pics[Info.pics.Count - 1], new Size((int)tempScale, 200));
                Info.picPaths.Add(filename);

                //if (Info.pics[Info.pics.Count - 1].Width > width) width = Info.pics[Info.pics.Count - 1].Width;

                //Info.height = Info.pics[Info.pics.Count - 1].Height;


                //Info.height = Info.pics[Info.pics.Count - 1].Height;

                if (i >= Info.columns) { i = 0; j++; pictureBox1.Height = pictureBox1.Height + Info.height; }

                graph.DrawImage(Info.pics[Info.pics.Count - 1], new Point(i * Info.width, j * Info.height));

                i++;

                k++;

            }

            if (i <= Info.columns) pictureBox1.Height = pictureBox1.Height + Info.height;

            int width = Info.width * Info.columns;
            pictureBox1.Width = width;

            

            //panel1.Width = width + 20;
            //this.Width = width + 50;
        }



        private void update_pics()
        {
            //Info.columns = (int)numericUpDown1.Value;

            pictureBox1.Image = new Bitmap(2500, 10000);
            Graphics graph = Graphics.FromImage(pictureBox1.Image);

            int i = 0, j = 0, k = 0;

            pictureBox1.Height = 150;

            string[] allfiles = Info.allfiles;

            if (allfiles.Length != 0)
            foreach (string filename in allfiles)
            {
                //Info.pics.Add(new Bitmap(filename));
                //float tempScale = Info.pics[Info.pics.Count - 1].Height / 100;
                //tempScale = Info.pics[Info.pics.Count - 1].Width / tempScale;
                //Info.width = (int)tempScale + 20;
                //Info.pics[Info.pics.Count - 1] = new Bitmap(Info.pics[Info.pics.Count - 1], new Size((int)tempScale, 100));
                //Info.picPaths.Add(filename);

                //if (Info.pics[Info.pics.Count - 1].Width > width) width = Info.pics[Info.pics.Count - 1].Width;

                //Info.height = Info.pics[Info.pics.Count - 1].Height;


                //Info.height = Info.pics[Info.pics.Count - 1].Height;

                if (i >= Info.columns) { i = 0; j++; pictureBox1.Height = pictureBox1.Height + Info.height; }

                graph.DrawImage(Info.pics[k], new Point(i * Info.width, j * Info.height));

                i++;
                k++;
            }

            if (i <= Info.columns) pictureBox1.Height = pictureBox1.Height + Info.height;

            int width = Info.width * Info.columns;
            pictureBox1.Width = width;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            update();
            Info.columns = (int)panel1.Size.Width / Info.width;
            update_pics();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Info.pics = new List<Bitmap>();

            GC.Collect();

            Thread.Sleep(500);

            DirectoryInfo dir = new DirectoryInfo("Temp");
            foreach (FileInfo f in dir.GetFiles())
            {
                f.Delete();
            }
        }


        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //numericUpDown1.Value = (int)panel1.Size.Width / Info.width;
            Info.columns = (int)panel1.Size.Width / Info.width;
            update_pics();
        }
    }

    public class Info
    {
        public static List<string> pdfs;
        public static List<Bitmap> pics;
        public static List<string> picPaths;
        public static int width;
        public static int height;
        public static int columns;
        public static string[] allfiles;
    }
}
