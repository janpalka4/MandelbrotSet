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
        public float Start = 0f;
        public float End = 10f;
        public float Zoom = 0.16f;
        public List<Keyframe> keyframes = new List<Keyframe>();
        public event EventHandler<Pohled> FramePassed;

        private HScrollBar scrollBar;
        private float vstart = 0f;
        private float vend = 10f;
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
            vend = 10f / Zoom;

            scrollBar = new HScrollBar() {Dock = DockStyle.Bottom, Minimum=0, Maximum=100};
            scrollBar.ValueChanged += ScrollBar_ValueChanged;
            Controls.Add(scrollBar);

            OnLoad();
        }

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            vstart = (scrollBar.Value / (float)scrollBar.Maximum) * (10f / Zoom);
            vend = vstart + 10f / Zoom;
            Prekreslit();
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
                Position = Start;
            }
            else
                previewTimer.Stop();

        }

        private void PreviewTimer_Tick(object sender, EventArgs e)
        {
            Pohled pohled = PreskocNaPohled(Position);
            Position += 16f / 1000f * 1.5f;
            if (FramePassed != null) FramePassed.Invoke(this,pohled);
            if (Position >= End) previewTimer.Stop();
            Prekreslit();
        }

        private Pohled PreskocNaPohled(float p)
        {
            Pohled pohled = new Pohled();
            Keyframe[] pred = keyframes.Where(x => x.t <= p).ToArray();
            Keyframe[] po = keyframes.Where(x => x.t >= p).ToArray();
            Keyframe st = pred.Length > 0 ? pred.Where(x => x.t == pred.Select(y => y.t).Max()).First() : new Keyframe() { value = PosledniPohled, t = p };
            Keyframe en = po.Length > 0 ? po.Where(x => x.t == po.Select(y => y.t).Min()).First() : new Keyframe() { value = PosledniPohled, t = p };
            float R = en.t - st.t;
            float t = (p - st.t) / R;
            pohled.p1 = Util.LerpP(st.value.p1, en.value.p1, t);
            pohled.p2 = Util.LerpP(st.value.p2, en.value.p2, t);
            PosledniPohled = pohled;
            return pohled;
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
            Position = (float)Math.Round(vstart + (Location.X / (float)Width) * Math.Abs(vstart - vend));
            if (FramePassed != null) FramePassed.Invoke(this, PreskocNaPohled(Position));
            Prekreslit();
        }

        private void Prekreslit()
        {
            
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            float mezera = Width / (vend-vstart);
            int pos = 0;
            for (int i = (int)vstart; i < vend; i++)
            {
                if (i % 10 == 0)
                {
                    g.DrawString(i.ToString(), new Font(FontFamily.GenericMonospace, Width / (vend - vstart) / 2), Brushes.Black, new PointF(pos * mezera, 0));
                }else if(i % 5 == 0)
                {
                    g.DrawLine(Pens.Gray, pos * mezera, 5, pos * mezera, 18);
                }else g.DrawLine(Pens.Gray, pos * mezera, 14, pos * mezera, 18);
                pos++;
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
        private float TimeToCood(float t) => (t - vstart) * Width / Math.Abs(vstart - vend);

    }
}
