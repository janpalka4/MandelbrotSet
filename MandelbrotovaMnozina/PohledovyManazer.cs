using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotovaMnozina
{
    public static class PohledovyManazer
    {
        public static Pohled AktualniPohled = new Pohled(new PointF(-2, -2), new PointF(2, 2));
        public static readonly Pohled Vychozi = new Pohled(new PointF(-2, -2), new PointF(2, 2));

        private static List<Pohled> _Pohledy = new List<Pohled>();
        private static int _Index = 0;

        public static void PridatPohled(Pohled pohled)
        {
            _Pohledy.Add(pohled);
            AktualniPohled = pohled;
            _Index++;
        }

        public static Pohled PredchoziPohled()
        {
            if (_Index == 1) return new Pohled(new PointF(-2,-2),new PointF(2,2));
            _Index--;
            AktualniPohled = _Pohledy[_Index - 1];
            return AktualniPohled;
        }
        public static Pohled NadchazejiciPohled()
        {
            if (_Index == _Pohledy.Count) return _Pohledy[_Index - 1];
            _Index++;
            AktualniPohled = _Pohledy[_Index - 1];
            return AktualniPohled;
        }

        public static Pohled RectToPohled(Rectangle vyber, int width,int height)
        {
            Pohled pohled = AktualniPohled;
            float Xs = vyber.Left / (float)width;
            float Ys = vyber.Top / (float)height;
            float Xs1 = vyber.Right / (float)width;
            float Ys1 = vyber.Bottom / (float)height;
            float R = pohled.p2.X - pohled.p1.X;
            PointF p1 = PointF.Empty;
            PointF p2 = PointF.Empty;
            p1.X = pohled.p1.X + (Xs * R);
            p1.Y = pohled.p1.Y + (Ys * R);
            p2.X = pohled.p1.X + (Xs1 * R);
            p2.Y = pohled.p1.Y + (Ys1 * R);

            return new Pohled(p1, p2);
        }
    }
}
