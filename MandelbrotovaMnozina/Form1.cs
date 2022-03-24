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
        Bitmap bitmap = null;
        bool drag = false;
        Point start = new Point(0,0);
        Point end = new Point(800,800);
        Rectangle vyber = new Rectangle(0,0,800,800);
        string NazevAplikace;
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
            foreach(Color c in Mnozina.Paleta)
            {
                Panel Cprev = new Panel() { Width = flowLayoutPanel3.Width, Height = 10, BackColor = c };
                flowLayoutPanel3.Controls.Add(Cprev);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vykresli();
        }

        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            if (!drag)
                start = e.Location;
            drag = true;
            
        }
        public void Vykresli()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Text = "Pracuji...";
            bitmap = Mnozina.VykresliMnozinu(new Rectangle(0,0,800,800),PohledovyManazer.AktualniPohled);
            pictureBox1.Image = bitmap;
            stopwatch.Stop();
            StatusTextBox.Text = $"Status: Doba vykreslení {stopwatch.ElapsedMilliseconds / 1000f}s";
            AktualizujUI();
        }
        public void DokonciVyber()
        {
            Pohled pohled = PohledovyManazer.AktualniPohled;
            float Xs = vyber.Left / 800f;
            float Ys = vyber.Top / 800f;
            float Xs1 = vyber.Right / 800f;
            float Ys1 = vyber.Bottom / 800f;
            float R = pohled.p2.X - pohled.p1.X;
            PointF p1 = PointF.Empty;
            PointF p2 = PointF.Empty;
            p1.X = pohled.p1.X + (Xs * R);
            p1.Y = pohled.p1.Y + (Ys * R);
            p2.X = pohled.p1.X + (Xs1 * R);
            p2.Y = pohled.p1.Y + (Ys1 * R);

            pohled = new Pohled(p1, p2);
            PohledovyManazer.PridatPohled(pohled);

            VypocitejPocetIteraci();
        }
        private void VypocitejPocetIteraci(float sirka = 800f)
        {
            double scale = sirka / (PohledovyManazer.AktualniPohled.p2.X - PohledovyManazer.AktualniPohled.p1.X);
            Mnozina.MaxIteraci = (int)(Math.Sqrt(2 * Math.Sqrt(Math.Abs(1 - Math.Sqrt(5 * scale)))) * 16.5);
        }
        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (drag && bitmap != null)
            {
                end = e.Location;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawImage(bitmap, 0, 0);
                vyber = new Rectangle(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(start.X - end.X), Math.Abs(start.X - end.X));
                g.DrawRectangle(Pens.Red, vyber);
            }
            
        }
        public void AktualizujUI()
        {
            txtPohledX.Text = $"X: {PohledovyManazer.AktualniPohled.p1.X}   -   {PohledovyManazer.AktualniPohled.p2.X}";
            txtPohledY.Text = $"Y: {PohledovyManazer.AktualniPohled.p1.Y}   -   {PohledovyManazer.AktualniPohled.p2.Y}";
            txtIteraci.Text = $"Iterací: {Mnozina.MaxIteraci}";
            Text = NazevAplikace;
        }
        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            DokonciVyber();
            Vykresli();
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
            VypocitejPocetIteraci();
            Vykresli();
        }

        private void uložitTentoPohledJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderForm renderForm = new RenderForm();
            renderForm.Show();
        }

        private void krokZpětToolStripMenuItem_Click(object sender, EventArgs e) => zpet();

        private void krokVpředToolStripMenuItem_Click(object sender, EventArgs e) => vpred();
    }
}
