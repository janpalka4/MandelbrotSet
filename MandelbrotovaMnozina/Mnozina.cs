using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotovaMnozina
{
    public struct Pohled
    {
        public PointF p1;
        public PointF p2;

        public Pohled(PointF P1, PointF P2)
        {
            p1 = new PointF(Math.Min(P1.X, P2.X), Math.Min(P1.Y, P2.Y));
            p2 = new PointF(Math.Max(P1.X, P2.X), Math.Max(P1.Y, P2.Y));
        }
    }
    public static class Mnozina
    {
        public static int MaxIteraci = 60;
        public static Color[] Paleta = {Color.FromArgb(106,52,3),
        Color.FromArgb(66,30,15),
        Color.FromArgb(25,7,26),
        Color.FromArgb(9,1,47),
        Color.FromArgb(4,4,73),
        Color.FromArgb(0,7,100),
        Color.FromArgb(12,44,138),
        Color.FromArgb(24,82,147),
        Color.FromArgb(57,125,209),
        Color.FromArgb(134,181,229),
        Color.FromArgb(211,236,248),
        Color.FromArgb(241,233,191),
        Color.FromArgb(248,201,95),
        Color.FromArgb(255,128,0),
        Color.FromArgb(204,128,0),
        Color.FromArgb(153,87,0),
        Color.FromArgb(106,52,3),
        Color.FromArgb(66,30,15),
        Color.FromArgb(25,7,26)};
        private static void VypocitejPocetIteraci(float sirka = 800f)
        {
            double scale = sirka / (PohledovyManazer.AktualniPohled.p2.X - PohledovyManazer.AktualniPohled.p1.X);
            MaxIteraci = (int)(Math.Sqrt(2 * Math.Sqrt(Math.Abs(1 - Math.Sqrt(5 * scale)))) * 16.5);
        }
        public static Bitmap VykresliMnozinu(Rectangle region,Pohled pohled)
        {
            VypocitejPocetIteraci(region.Width);
            Bitmap bmp = new Bitmap(region.Width, region.Height);
            float velikostPixeluX =  Math.Abs(pohled.p1.X - pohled.p2.X)/(float)region.Width;
            float velikostPixeluY = Math.Abs(pohled.p1.Y - pohled.p2.Y) / (float)region.Height;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    /*double cx = (x-bmp.Width/2)/(double)bmp.Width*4.0;
                    double cy = (y-bmp.Height/2)/(double)bmp.Height*4.0;*/
                    double cx = x * velikostPixeluX + pohled.p1.X;
                    double cy = y * velikostPixeluY + pohled.p1.Y;
                    double tmpX = cx;
                    double tmpY = cy;
                    double absZn = 0;
                    int i = 0;
                    do
                    {
                        double pomX = Math.Pow(cx,2)-Math.Pow(cy,2)+tmpX;
                        double pomY = 2 * cx * cy+tmpY;
                        cx = pomX;
                        cy = pomY;
                        absZn = Math.Abs(Math.Sqrt(Math.Pow(cx, 2) + Math.Pow(cy, 2)));
                        i++;
                    } while (!(absZn > 2 || i >= MaxIteraci));
                    //int barva = i==MaxIteraci ? 0 : (int)(i % 255 * (255.0/MaxIteraci));
                    Color barva = Color.Black;
                    if (i < MaxIteraci)
                    {
                        double logZn = Math.Log(absZn) / 2f;
                        double nu = Math.Log(logZn / Math.Log(2));
                        double index = i + 1 - nu;
                        double t = index % 1.0;
                        index = index - 17 * (int)(i / 17);
                        barva = Util.LerpC(Paleta[(int)index], Paleta[(int)index + 1], (float)t);
                    }

                    //bmp.SetPixel(x, y, Color.FromArgb(Math.Min(_barva*42,255), Math.Min(_barva * 42, 255), Math.Min(_barva * 42, 255)));
                    bmp.SetPixel(x, y, barva);
                }
                
            }
            return bmp;
        }
    }
}
