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
    public partial class OAplikaciForm : Form
    {
        public OAplikaciForm()
        {
            InitializeComponent();
        }

        private void OAplikaciForm_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = ManazerZdroju.NacistZdroj("About.html");
        }
    }
}
