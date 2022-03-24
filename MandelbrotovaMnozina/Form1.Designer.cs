
namespace MandelbrotovaMnozina
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPohledX = new System.Windows.Forms.TextBox();
            this.txtPohledY = new System.Windows.Forms.TextBox();
            this.txtIteraci = new System.Windows.Forms.TextBox();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.NumericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitTentoPohledJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upravitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krokZpětToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krokVpředToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glControl1 = new OpenTK.GLControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownR)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(805, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vykreslit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseUp);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtPohledX);
            this.flowLayoutPanel2.Controls.Add(this.txtPohledY);
            this.flowLayoutPanel2.Controls.Add(this.txtIteraci);
            this.flowLayoutPanel2.Controls.Add(this.StatusTextBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 835);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1007, 23);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // txtPohledX
            // 
            this.txtPohledX.Location = new System.Drawing.Point(3, 3);
            this.txtPohledX.Name = "txtPohledX";
            this.txtPohledX.ReadOnly = true;
            this.txtPohledX.Size = new System.Drawing.Size(200, 20);
            this.txtPohledX.TabIndex = 0;
            // 
            // txtPohledY
            // 
            this.txtPohledY.Location = new System.Drawing.Point(209, 3);
            this.txtPohledY.Name = "txtPohledY";
            this.txtPohledY.ReadOnly = true;
            this.txtPohledY.Size = new System.Drawing.Size(200, 20);
            this.txtPohledY.TabIndex = 1;
            // 
            // txtIteraci
            // 
            this.txtIteraci.Location = new System.Drawing.Point(415, 3);
            this.txtIteraci.Name = "txtIteraci";
            this.txtIteraci.ReadOnly = true;
            this.txtIteraci.Size = new System.Drawing.Size(100, 20);
            this.txtIteraci.TabIndex = 2;
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Location = new System.Drawing.Point(521, 3);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.Size = new System.Drawing.Size(278, 20);
            this.StatusTextBox.TabIndex = 3;
            this.StatusTextBox.Text = "Status: Připraven!";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(805, 441);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 388);
            this.flowLayoutPanel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(806, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Paleta barev:";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.NumericUpDownX);
            this.flowLayoutPanel4.Controls.Add(this.NumericUpDownY);
            this.flowLayoutPanel4.Controls.Add(this.NumericUpDownR);
            this.flowLayoutPanel4.Controls.Add(this.button2);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(805, 336);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(200, 83);
            this.flowLayoutPanel4.TabIndex = 8;
            // 
            // NumericUpDownX
            // 
            this.NumericUpDownX.DecimalPlaces = 5;
            this.NumericUpDownX.Location = new System.Drawing.Point(3, 3);
            this.NumericUpDownX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericUpDownX.Name = "NumericUpDownX";
            this.NumericUpDownX.Size = new System.Drawing.Size(92, 20);
            this.NumericUpDownX.TabIndex = 0;
            // 
            // NumericUpDownY
            // 
            this.NumericUpDownY.DecimalPlaces = 5;
            this.NumericUpDownY.Location = new System.Drawing.Point(101, 3);
            this.NumericUpDownY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericUpDownY.Name = "NumericUpDownY";
            this.NumericUpDownY.Size = new System.Drawing.Size(92, 20);
            this.NumericUpDownY.TabIndex = 1;
            // 
            // NumericUpDownR
            // 
            this.NumericUpDownR.DecimalPlaces = 5;
            this.NumericUpDownR.Location = new System.Drawing.Point(3, 29);
            this.NumericUpDownR.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericUpDownR.Name = "NumericUpDownR";
            this.NumericUpDownR.Size = new System.Drawing.Size(190, 20);
            this.NumericUpDownR.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Potvrdit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(805, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Manualni navigace";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.upravitToolStripMenuItem,
            this.oAplikaciToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1007, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uložitTentoPohledJakoToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // uložitTentoPohledJakoToolStripMenuItem
            // 
            this.uložitTentoPohledJakoToolStripMenuItem.Name = "uložitTentoPohledJakoToolStripMenuItem";
            this.uložitTentoPohledJakoToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.uložitTentoPohledJakoToolStripMenuItem.Text = "Uložit tento pohled jako";
            this.uložitTentoPohledJakoToolStripMenuItem.Click += new System.EventHandler(this.uložitTentoPohledJakoToolStripMenuItem_Click);
            // 
            // upravitToolStripMenuItem
            // 
            this.upravitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.krokZpětToolStripMenuItem,
            this.krokVpředToolStripMenuItem});
            this.upravitToolStripMenuItem.Name = "upravitToolStripMenuItem";
            this.upravitToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.upravitToolStripMenuItem.Text = "Upravit";
            // 
            // krokZpětToolStripMenuItem
            // 
            this.krokZpětToolStripMenuItem.Name = "krokZpětToolStripMenuItem";
            this.krokZpětToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.krokZpětToolStripMenuItem.Text = "Krok zpět";
            this.krokZpětToolStripMenuItem.Click += new System.EventHandler(this.krokZpětToolStripMenuItem_Click);
            // 
            // krokVpředToolStripMenuItem
            // 
            this.krokVpředToolStripMenuItem.Name = "krokVpředToolStripMenuItem";
            this.krokVpředToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.krokVpředToolStripMenuItem.Text = "Krok vpřed";
            this.krokVpředToolStripMenuItem.Click += new System.EventHandler(this.krokVpředToolStripMenuItem_Click);
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.oAplikaciToolStripMenuItem.Text = "O aplikaci";
            this.oAplikaciToolStripMenuItem.Click += new System.EventHandler(this.oAplikaciToolStripMenuItem_Click);
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(-1, 34);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(800, 798);
            this.glControl1.TabIndex = 11;
            this.glControl1.VSync = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "CPU",
            "GPU"});
            this.listBox1.Location = new System.Drawing.Point(809, 79);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(127, 17);
            this.listBox1.TabIndex = 12;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(806, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Metoda:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 858);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Mandelbrotova mnozina";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownR)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox txtPohledX;
        private System.Windows.Forms.TextBox txtPohledY;
        private System.Windows.Forms.TextBox txtIteraci;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.NumericUpDown NumericUpDownX;
        private System.Windows.Forms.NumericUpDown NumericUpDownY;
        private System.Windows.Forms.NumericUpDown NumericUpDownR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krokZpětToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krokVpředToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitTentoPohledJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
    }
}

