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
        private static List<Pohled> _Pohledy = new List<Pohled>();
        private static int _Index = 0;

        public static void PridatPohled(Pohled pohled)
        {
            _Pohledy.Add(pohled);
            _Index++;
        }

        public static Pohled PredchoziPohled()
        {
            if (_Index == 1) return new Pohled(new PointF(-2,-2),new PointF(2,2));
            _Index--;
            return _Pohledy[_Index-1];
        }
        public static Pohled NadchazejiciPohled()
        {
            if (_Index == _Pohledy.Count) return _Pohledy[_Index - 1];
            _Index++;
            return _Pohledy[_Index-1];
        }
    }
}
