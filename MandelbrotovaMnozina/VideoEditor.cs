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
            time = new DateTime(1, 1, 1, 1, 0, 0);
            time = time.AddSeconds(timeLineControl1.Position);
            label1.Text = $"{time.Minute}:{time.Second}";
        }

        private void PlotBox_VybranNovyPohled(object sender, Pohled e)
        {
            timeLineControl1.PridatKlic(new Keyframe() { value = e, t = timeLineControl1.Position });
            AktualizujListKlicu();
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

        private void kliceTab_Focus(object sender, EventArgs e) => AktualizujListKlicu();

        private void AktualizujListKlicu()
        {
            listView2.Items.Clear();
            listView2.View = View.Details;
            foreach (Keyframe keyframe in timeLineControl1.keyframes.OrderBy(x => x.t))
            {
                ListViewItem item = new ListViewItem(new[] { $"{keyframe.t}", "Klíč" });
                listView2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeLineControl1.Play();
            time = new DateTime();
        }

        private void numericStart_ValueChanged(object sender, EventArgs e) => timeLineControl1.Start = (float)numericStart.Value;

        private void numericEnd_ValueChanged(object sender, EventArgs e) => timeLineControl1.End = (float)numericEnd.Value;
    }
}
