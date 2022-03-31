using System;
using System.IO;
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
    public partial class RenderForm : Form
    {
        VykreslovaciMod vykreslovaciMod = VykreslovaciMod.CPU;
        ShaderContext context;
        OpenTK.GLControl gLControl;
        public RenderForm()
        {
            InitializeComponent();
            PathTextBox.Text = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\Snimek.jpg";
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Obrázky (*.jpg,*.png,*.bmp) | *.jpg;*.png;*.bmp";
            dialog.Title = "Umístění snímku";
            dialog.ShowDialog();
            string path = dialog.FileName;
            PathTextBox.Text = path;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (vykreslovaciMod == VykreslovaciMod.CPU)
                {
                    Text = "Pracuji...";
                    Bitmap bmp = Mnozina.VykresliMnozinu(new Rectangle(0, 0, (int)NumericResX.Value, (int)NumericResY.Value), PohledovyManazer.AktualniPohled);
                    bmp.Save(PathTextBox.Text);
                }
                else
                {
                    gLControl.Show();
                    Text = "Pracuji...";
                    Bitmap bmp = context.Render((int)NumericResX.Value, (int)NumericResY.Value, PohledovyManazer.AktualniPohled);
                    bmp.Save(PathTextBox.Text);
                    gLControl.Hide();
                }
                Close();
            }catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Text = "Vyrenderovat";
            }
        }

        private void StornoButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => vykreslovaciMod = (VykreslovaciMod)comboBox1.SelectedIndex;

        private void RenderForm_Load(object sender, EventArgs e)
        {
            gLControl = new OpenTK.GLControl();
            Controls.Add(gLControl);
            gLControl.Hide();
            context = new ShaderContext(gLControl);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }
    }
}
