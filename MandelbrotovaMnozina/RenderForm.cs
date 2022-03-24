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
                Text = "Pracuji...";
                Bitmap bmp = Mnozina.VykresliMnozinu(new Rectangle(0, 0, (int)NumericResX.Value, (int)NumericResY.Value),PohledovyManazer.AktualniPohled);
                bmp.Save(PathTextBox.Text);
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
    }
}
