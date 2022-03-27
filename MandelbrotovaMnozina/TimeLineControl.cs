using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MandelbrotovaMnozina
{
    public class TimeLineControl : Panel
    {
        public float Position = 0f;
        public float start = 0f;
        public float end = 10f;
        public float Zoom = 0.16f;

        public List<Keyframe> keyframes = new List<Keyframe>();

        public event EventHandler<Pohled> FramePassed;

        bool drag = false;

        Pohled PosledniPohled = PohledovyManazer.Vychozi;

        Timer previewTimer;

        Bitmap bmp;

        public TimeLineControl()
        {
            bmp = new Bitmap(Width, Height);

            MouseDown += TimeLineControl_MouseDown;
            MouseMove += TimeLineControl_MouseMove;
            MouseUp += TimeLineControl_MouseUp;
            Resize += TimeLineControl_Resize;

            previewTimer = new Timer() { Interval = 16 };
            previewTimer.Tick += PreviewTimer_Tick;

            keyframes.Add(new Keyframe() { t = 0, value = PohledovyManazer.Vychozi });
            end = 10f / Zoom;

            OnLoad();
        }

        private void TimeLineControl_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void TimeLineControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) AktualizujPoziciKurzoru(e.Location);
        }

        private async void OnLoad()
        {
            await Task.Delay(100);
            Prekreslit();
        }
        private void TimeLineControl_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(Width, Height);
            Prekreslit();
        }

        public void Play()
        {

            if (!previewTimer.Enabled)
            {
                previewTimer.Start();
                Position = 0;
            }
            else
                previewTimer.Stop();

        }

        private void PreviewTimer_Tick(object sender, EventArgs e)
        {
            Pohled pohled = new Pohled();
            Keyframe[] pred = keyframes.Where(x => x.t <= Position).ToArray();
            Keyframe[] po = keyframes.Where(x => x.t >= Position).ToArray();
            Keyframe st = pred.Length > 0 ? pred.Where(x => x.t == pred.Select(y => y.t).Max()).First() : new Keyframe() { value = PosledniPohled, t = Position };
            Keyframe en = po.Length > 0 ? po.Where(x => x.t == po.Select(y => y.t).Min()).First() : new Keyframe() { value = PosledniPohled, t = Position };
            float R = en.t - st.t;
            float t = (Position - st.t) / R;
            pohled.p1 = Util.LerpP(st.value.p1, en.value.p1, t);
            pohled.p2 = Util.LerpP(st.value.p2, en.value.p2, t);
            Position += 16f / 1000f;
            if (FramePassed != null) FramePassed.Invoke(this,pohled);
            if (Position >= end) previewTimer.Stop();
            PosledniPohled = pohled;
            Prekreslit();
        }

        public void PridatKlic(Keyframe keyframe)
        {
            if(keyframes.Where(x => x.t == keyframe.t).Count() == 0)
            {
                keyframes.Add(keyframe);
            }
            else
            {
                keyframes.RemoveAll(x => x.t == keyframe.t);
                keyframes.Add(keyframe);
            }
        }

        private void TimeLineControl_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            AktualizujPoziciKurzoru(e.Location);
        }
        private void AktualizujPoziciKurzoru(Point Location)
        {
            Position = (float)Math.Round(start + (Location.X / (float)Width) * Math.Abs(start - end));
            Prekreslit();
        }

        private void Prekreslit()
        {
            
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            float T = 10f / Zoom;
            float mezera = Width / T;
            for (int i = (int)Math.Min(0, Position - T / 2f); i < T; i++)
            {
                g.DrawString(i.ToString(), new Font(FontFamily.GenericMonospace, Width / T / 2), Brushes.Black, new PointF(i * mezera, 0));
            }
            foreach (Keyframe keyframe in keyframes)
            {
                g.FillEllipse(Brushes.Blue, TimeToCood(keyframe.t) - 6, 12, 12, 12);
                g.DrawLine(Pens.Blue, TimeToCood(keyframe.t), 0, TimeToCood(keyframe.t), Height);
            }
            g.DrawLine(Pens.Black, 0, 18, Width, 18);
            g.DrawLine(Pens.Red, TimeToCood(Position), 0, TimeToCood(Position), Height);
            CreateGraphics().DrawImage(bmp,new Point(0,0));
        }
        private float TimeToCood(float t) => (t - start) * Width / Math.Abs(start - end);

    }
}
