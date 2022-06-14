using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using OpenTK;
using System.Reflection;

namespace MandelbrotovaMnozina
{
    [System.ComponentModel.Browsable(true)]
    public class PlotBox : PictureBox
    {
        bool drag = false;
        Point start = new Point(0, 0);
        Point end = new Point(800, 800);
        Rectangle vyber = new Rectangle(0, 0, 800, 800);
        Bitmap bitmap;
        ShaderContext context;
        GLControl gLControl;

        public VykreslovaciMod vykreslovaciMod = VykreslovaciMod.CPU;
        public event EventHandler<Pohled> VybranNovyPohled;
        public PlotBox()
        {
            MouseDown += DragStart;
            MouseUp += delegate { drag = false; DokoncitVyber(); };
            MouseMove += OnMouseDrag;
            ControlRemoved += OnRemoved;
            bitmap = new Bitmap(Width, Height);
            OnLoad();
        }

        private void DragStart(object sender, MouseEventArgs e)
        {
            drag = true;
            start = e.Location;
        }

        private void OnRemoved(object sender, ControlEventArgs e)
        {
            context.Dispose();
            gLControl.Dispose();
            Parent.Controls.Remove(gLControl);
        }

        private async void OnLoad()
        {
            await Task.Delay(100);
            gLControl = new GLControl() { Width = Width, Height = Height };
            Parent.Controls.Add(gLControl);
            context = new ShaderContext(gLControl);
            Render();
        }

        private void OnMouseDrag(object sender, MouseEventArgs e)
        {
            if (drag && bitmap != null)
            {
                end = e.Location;
                Graphics g = CreateGraphics();
                g.DrawImage(bitmap, 0, 0);
                vyber = new Rectangle(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(start.X - end.X), Math.Abs(start.X - end.X));
                g.DrawRectangle(Pens.Red, vyber);
            }
        }

        private void DokoncitVyber()
        {
            Pohled pohled = PohledovyManazer.RectToPohled(vyber,Width,Height);
            PohledovyManazer.PridatPohled(pohled);
            if(VybranNovyPohled != null)VybranNovyPohled.Invoke(this, pohled);
        }

        public Bitmap Render()
        {
            if(vykreslovaciMod == VykreslovaciMod.CPU)
            {
                bitmap = Mnozina.VykresliMnozinu(new Rectangle(0, 0, Width, Height), PohledovyManazer.AktualniPohled);
                Image = bitmap;
            }
            else
            {
                bitmap = context.Render(Width, Height, PohledovyManazer.AktualniPohled);
                Image = bitmap;
            }
            return bitmap;
        }
    }
}
