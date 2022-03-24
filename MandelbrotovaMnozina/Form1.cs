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
    public partial class Form1 : Form
    {
        Bitmap bitmap = null;
        bool drag = false;
        Point start = new Point(0,0);
        Point end = new Point(800,800);
        Rectangle vyber = new Rectangle(0,0,800,800);
        Pohled Pohled = new Pohled(new PointF(-2, -2), new PointF(2, 2));
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PohledovyManazer.PridatPohled(Pohled);
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
            bitmap = Mnozina.VykresliMnozinu(new Rectangle(0,0,800,800),Pohled);
            pictureBox1.Image = bitmap;
            AktualizujUI();
        }
        public void DokonciVyber()
        {
            float Xs = vyber.Left / 800f;
            float Ys = vyber.Top / 800f;
            float Xs1 = vyber.Right / 800f;
            float Ys1 = vyber.Bottom / 800f;
            float R = Pohled.p2.X - Pohled.p1.X;
            PointF p1 = PointF.Empty;
            PointF p2 = PointF.Empty;
            p1.X = Pohled.p1.X + (Xs * R);
            p1.Y = Pohled.p1.Y + (Ys * R);
            p2.X = Pohled.p1.X + (Xs1 * R);
            p2.Y = Pohled.p1.Y + (Ys1 * R);
            Pohled = new Pohled(p1, p2);
            PohledovyManazer.PridatPohled(Pohled);

            double scale = 800.0/(Pohled.p2.X - Pohled.p1.X);
            Mnozina.MaxIteraci = (int)(Math.Sqrt(2*Math.Sqrt(Math.Abs(1-Math.Sqrt(5*scale))))*16.5);
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
            txtPohledX.Text = $"X: {Pohled.p1.X}   -   {Pohled.p2.X}";
            txtPohledY.Text = $"Y: {Pohled.p1.Y}   -   {Pohled.p2.Y}";
            txtIteraci.Text = $"Iterací: {Mnozina.MaxIteraci}";
        }
        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            DokonciVyber();
            Vykresli();
        }

        private void zpetButton_Click(object sender, EventArgs e)
        {
            Pohled = PohledovyManazer.PredchoziPohled();
            Vykresli();
        }

        private void vpredButton_Click(object sender, EventArgs e)
        {
            Pohled = PohledovyManazer.NadchazejiciPohled();
            Vykresli();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pohled pohled = new Pohled();
            pohled.p1 = new PointF(NumericUpDownX.Value-1f,NumericUpDownY.Value-1f)
        }
    }
}
