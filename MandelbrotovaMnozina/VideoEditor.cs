using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotovaMnozina
{
    public struct Keyframe
    {
        public Pohled value;
        public float t;
    }
    public partial class VideoEditor : Form
    {
        PlotBox plotBox;
        DateTime time = new DateTime();
        public VideoEditor()
        {
            InitializeComponent();
            plotBox = new PlotBox() { Width = panel1.Width, Height = panel1.Height, vykreslovaciMod = VykreslovaciMod.GPU };
            plotBox.VybranNovyPohled += PlotBox_VybranNovyPohled;
            timeLineControl1.FramePassed += TimeLineControl1_FramePassed;
            panel1.Controls.Add(plotBox);
        }

        private void TimeLineControl1_FramePassed(object sender, Pohled e)
        {
            PohledovyManazer.AktualniPohled = e;
            plotBox.Render();
            time = time.AddMilliseconds(16);
            label1.Text = $"{time.Minute}:{time.Second}";
        }

        private void PlotBox_VybranNovyPohled(object sender, Pohled e)
        {
            timeLineControl1.PridatKlic(new Keyframe() { value = e, t = timeLineControl1.Position });
        }

        private async void VideoEditor_Load(object sender, EventArgs e)
        { 
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void OnVideoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) timeLineControl1.Play();
        }
    }
}
