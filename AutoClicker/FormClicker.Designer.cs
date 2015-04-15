namespace AutoClicker
{
    partial class FormClicker
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
            this.labelAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstate = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.rightBox = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ignoreColorBox = new System.Windows.Forms.TextBox();
            this.BoxBright = new System.Windows.Forms.CheckBox();
            this.numSecToClick = new System.Windows.Forms.NumericUpDown();
            this.numSecToColor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecToClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecToColor)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(61, 53);
            this.labelAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(43, 13);
            this.labelAmount.TabIndex = 4;
            this.labelAmount.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Press F1 to Start/Stop AutoClicking";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "AutoClicker State";
            // 
            // lstate
            // 
            this.lstate.AutoSize = true;
            this.lstate.ForeColor = System.Drawing.Color.Red;
            this.lstate.Location = new System.Drawing.Point(148, 58);
            this.lstate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lstate.Name = "lstate";
            this.lstate.Size = new System.Drawing.Size(64, 13);
            this.lstate.TabIndex = 7;
            this.lstate.Text = "Not Clicking";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(79, 99);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(37, 13);
            this.labelC.TabIndex = 8;
            this.labelC.Text = "Colour";
            this.labelC.Click += new System.EventHandler(this.labelC_Click);
            // 
            // rightBox
            // 
            this.rightBox.AutoSize = true;
            this.rightBox.Location = new System.Drawing.Point(13, 79);
            this.rightBox.Name = "rightBox";
            this.rightBox.Size = new System.Drawing.Size(79, 17);
            this.rightBox.TabIndex = 9;
            this.rightBox.Text = "right button";
            this.rightBox.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(13, 51);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ignoreColorBox
            // 
            this.ignoreColorBox.Location = new System.Drawing.Point(13, 31);
            this.ignoreColorBox.Name = "ignoreColorBox";
            this.ignoreColorBox.Size = new System.Drawing.Size(100, 20);
            this.ignoreColorBox.TabIndex = 11;
            this.ignoreColorBox.Text = "DarkRed";
            // 
            // BoxBright
            // 
            this.BoxBright.AutoSize = true;
            this.BoxBright.Location = new System.Drawing.Point(13, 103);
            this.BoxBright.Name = "BoxBright";
            this.BoxBright.Size = new System.Drawing.Size(69, 17);
            this.BoxBright.TabIndex = 12;
            this.BoxBright.Text = "Яркость";
            this.BoxBright.UseVisualStyleBackColor = true;
            // 
            // numSecToClick
            // 
            this.numSecToClick.Location = new System.Drawing.Point(151, 79);
            this.numSecToClick.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSecToClick.Name = "numSecToClick";
            this.numSecToClick.Size = new System.Drawing.Size(120, 20);
            this.numSecToClick.TabIndex = 13;
            this.numSecToClick.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // numSecToColor
            // 
            this.numSecToColor.Location = new System.Drawing.Point(151, 106);
            this.numSecToColor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSecToColor.Name = "numSecToColor";
            this.numSecToColor.Size = new System.Drawing.Size(120, 20);
            this.numSecToColor.TabIndex = 14;
            // 
            // FormClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 136);
            this.Controls.Add(this.numSecToColor);
            this.Controls.Add(this.numSecToClick);
            this.Controls.Add(this.BoxBright);
            this.Controls.Add(this.ignoreColorBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.rightBox);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.lstate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAmount);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormClicker";
            this.Text = "AutoClicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecToClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecToColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lstate;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.CheckBox rightBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox ignoreColorBox;
        private System.Windows.Forms.CheckBox BoxBright;
        private System.Windows.Forms.NumericUpDown numSecToClick;
        private System.Windows.Forms.NumericUpDown numSecToColor;

    }
}

