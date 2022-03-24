using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotovaMnozina
{
    public static class Util
    {
        public static float LerpF(float a, float b, float t) => a + t * (b - a);
        public static Color LerpC(Color a, Color b, float t) => Color.FromArgb((int)LerpF(a.R, b.R, t), (int)LerpF(a.G, b.G, t), (int)LerpF(a.B, b.B, t));

    }
}
