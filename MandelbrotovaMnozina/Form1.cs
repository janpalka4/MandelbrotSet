using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotovaMnozina
{
    public partial class Form1 : Form
    {
        string NazevAplikace;
        PlotBox plotBox;

        VykreslovaciMod vykreslovaciMod = VykreslovaciMod.CPU;
        public Form1()
        {
            InitializeComponent();
            NazevAplikace = Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PohledovyManazer.PridatPohled(PohledovyManazer.AktualniPohled);
            plotBox = new PlotBox() { Width = panel1.Width, Height = panel1.Height, vykreslovaciMod = VykreslovaciMod.GPU };
            plotBox.VybranNovyPohled += PlotBox_VybranNovyPohled;
            panel1.Controls.Add(plotBox);
            panel1.Resize += delegate { plotBox.Width = panel1.Width; plotBox.Height = panel1.Height; Vykresli(); };

            aktualizovatPaletu();
            
        }

        private void PlotBox_VybranNovyPohled(object sender, Pohled e)
        {
            Vykresli();
        }

        private void aktualizovatPaletu()
        {
            int index = 0;
            flowLayoutPanel3.Controls.Clear();
            foreach (Color c in Mnozina.Paleta)
            {
                Panel Cprev = new Panel() { Width = flowLayoutPanel3.Width, Height = 10, BackColor = c, Name = $"{index}" };
                Cprev.Click += delegate {
                    int id = int.Parse(Cprev.Name);
                    ColorDialog dialog = new ColorDialog();
                    dialog.Color = Mnozina.Paleta[id];
                    dialog.ShowDialog();
                    Color barva = dialog.Color;
                    Mnozina.Paleta[id] = barva;
                    aktualizovatPaletu();
                };
                flowLayoutPanel3.Controls.Add(Cprev);
                index++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vykresli();
        }


        public void Vykresli()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Text = "Pracuji...";
            plotBox.Render();
            stopwatch.Stop();
            StatusTextBox.Text = $"Status: Doba vykreslení {stopwatch.ElapsedMilliseconds / 1000f}s";
            AktualizujUI();
        }
        
        public void AktualizujUI()
        {
            txtPohledX.Text = $"X: {PohledovyManazer.AktualniPohled.p1.X}   -   {PohledovyManazer.AktualniPohled.p2.X}";
            txtPohledY.Text = $"Y: {PohledovyManazer.AktualniPohled.p1.Y}   -   {PohledovyManazer.AktualniPohled.p2.Y}";
            txtIteraci.Text = $"Iterací: {Mnozina.MaxIteraci}";
            Text = NazevAplikace;
        }


        private void zpet()
        {
            PohledovyManazer.PredchoziPohled();
            Vykresli();
        }
        private void vpred()
        {
            PohledovyManazer.NadchazejiciPohled();
            Vykresli();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Pohled pohled = new Pohled();
            float R = (float)NumericUpDownR.Value;
            pohled.p1 = new PointF((float)NumericUpDownX.Value - 1f * R, (float)NumericUpDownY.Value - 1f * R);
            pohled.p2 = new PointF((float)NumericUpDownX.Value + 1f * R, (float)NumericUpDownY.Value + 1f * R);
            PohledovyManazer.PridatPohled(pohled);
            Vykresli();
        }

        private void uložitTentoPohledJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderForm renderForm = new RenderForm();
            renderForm.Show();
        }

        private void krokZpětToolStripMenuItem_Click(object sender, EventArgs e) => zpet();

        private void krokVpředToolStripMenuItem_Click(object sender, EventArgs e) => vpred();

        private void oAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OAplikaciForm form = new OAplikaciForm();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            plotBox.vykreslovaciMod = (VykreslovaciMod)comboBox1.SelectedIndex;
            vykreslovaciMod = plotBox.vykreslovaciMod;
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void editorVideaToolStripMenuItem_Click(object sender, EventArgs e) => new VideoEditor().Show();

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
