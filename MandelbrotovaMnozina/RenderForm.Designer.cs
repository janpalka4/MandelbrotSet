
namespace MandelbrotovaMnozina
{
    partial class RenderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenderForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumericResX = new System.Windows.Forms.NumericUpDown();
            this.NumericResY = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.SearchTextBox = new System.Windows.Forms.Button();
            this.MethodSelect = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.StornoButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericResX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericResY)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.NumericResX);
            this.flowLayoutPanel1.Controls.Add(this.NumericResY);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 72);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rozlišení:";
            // 
            // NumericResX
            // 
            this.NumericResX.Location = new System.Drawing.Point(3, 16);
            this.NumericResX.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NumericResX.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericResX.Name = "NumericResX";
            this.NumericResX.Size = new System.Drawing.Size(357, 20);
            this.NumericResX.TabIndex = 0;
            this.NumericResX.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // NumericResY
            // 
            this.NumericResY.Location = new System.Drawing.Point(3, 42);
            this.NumericResY.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NumericResY.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericResY.Name = "NumericResY";
            this.NumericResY.Size = new System.Drawing.Size(357, 20);
            this.NumericResY.TabIndex = 1;
            this.NumericResY.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.PathTextBox);
            this.flowLayoutPanel2.Controls.Add(this.SearchTextBox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 120);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(360, 50);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cesta k souboru:";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(3, 16);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(264, 20);
            this.PathTextBox.TabIndex = 1;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(273, 16);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(75, 23);
            this.SearchTextBox.TabIndex = 2;
            this.SearchTextBox.Text = "...";
            this.SearchTextBox.UseVisualStyleBackColor = true;
            this.SearchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            // 
            // MethodSelect
            // 
            this.MethodSelect.FormattingEnabled = true;
            this.MethodSelect.Items.AddRange(new object[] {
            "CPU",
            "GPU"});
            this.MethodSelect.Location = new System.Drawing.Point(12, 29);
            this.MethodSelect.Name = "MethodSelect";
            this.MethodSelect.Size = new System.Drawing.Size(90, 17);
            this.MethodSelect.TabIndex = 3;
            this.MethodSelect.SelectedIndexChanged += new System.EventHandler(this.MethodSelect_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Způsob vykreslení:";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(296, 186);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Uložit";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StornoButton
            // 
            this.StornoButton.Location = new System.Drawing.Point(215, 186);
            this.StornoButton.Name = "StornoButton";
            this.StornoButton.Size = new System.Drawing.Size(75, 23);
            this.StornoButton.TabIndex = 6;
            this.StornoButton.Text = "Storno";
            this.StornoButton.UseVisualStyleBackColor = true;
            this.StornoButton.Click += new System.EventHandler(this.StornoButton_Click);
            // 
            // RenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.StornoButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MethodSelect);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenderForm";
            this.Text = "Vyrenderovat";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericResX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericResY)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumericResX;
        private System.Windows.Forms.NumericUpDown NumericResY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button SearchTextBox;
        private System.Windows.Forms.ListBox MethodSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button StornoButton;
    }
}