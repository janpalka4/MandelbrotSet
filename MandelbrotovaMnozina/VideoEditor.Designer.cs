
namespace MandelbrotovaMnozina
{
    partial class VideoEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.kliceTab = new System.Windows.Forms.TabPage();
            this.klicTab = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.casColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.popisColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeLineControl1 = new MandelbrotovaMnozina.TimeLineControl();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.kliceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(406, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "00:00";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.kliceTab);
            this.tabControl1.Controls.Add(this.klicTab);
            this.tabControl1.Location = new System.Drawing.Point(407, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 360);
            this.tabControl1.TabIndex = 4;
            // 
            // kliceTab
            // 
            this.kliceTab.Controls.Add(this.listView2);
            this.kliceTab.Location = new System.Drawing.Point(4, 22);
            this.kliceTab.Name = "kliceTab";
            this.kliceTab.Padding = new System.Windows.Forms.Padding(3);
            this.kliceTab.Size = new System.Drawing.Size(604, 334);
            this.kliceTab.TabIndex = 0;
            this.kliceTab.Text = "Klíče";
            this.kliceTab.UseVisualStyleBackColor = true;
            this.kliceTab.Enter += new System.EventHandler(this.kliceTab_Focus);
            // 
            // klicTab
            // 
            this.klicTab.Location = new System.Drawing.Point(4, 22);
            this.klicTab.Name = "klicTab";
            this.klicTab.Padding = new System.Windows.Forms.Padding(3);
            this.klicTab.Size = new System.Drawing.Size(604, 334);
            this.klicTab.TabIndex = 1;
            this.klicTab.Text = "Klíč";
            this.klicTab.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.casColumn,
            this.popisColumn});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(601, 334);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // casColumn
            // 
            this.casColumn.Text = "Čas";
            this.casColumn.Width = 50;
            // 
            // popisColumn
            // 
            this.popisColumn.Text = "Popis";
            this.popisColumn.Width = 250;
            // 
            // timeLineControl1
            // 
            this.timeLineControl1.Location = new System.Drawing.Point(0, 433);
            this.timeLineControl1.Name = "timeLineControl1";
            this.timeLineControl1.Size = new System.Drawing.Size(1019, 171);
            this.timeLineControl1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Přehrát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VideoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 603);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeLineControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VideoEditor";
            this.Text = "VideoEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.VideoEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnVideoKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.kliceTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private TimeLineControl timeLineControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage kliceTab;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TabPage klicTab;
        private System.Windows.Forms.ColumnHeader casColumn;
        private System.Windows.Forms.ColumnHeader popisColumn;
        private System.Windows.Forms.Button button1;
    }
}