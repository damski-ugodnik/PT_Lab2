﻿namespace PT_Lab2
{
    partial class SquareEq
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBox = new System.Windows.Forms.TextBox();
            this.bBox = new System.Windows.Forms.TextBox();
            this.aBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.mode3 = new System.Windows.Forms.RadioButton();
            this.mode2 = new System.Windows.Forms.RadioButton();
            this.mode1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.x2Box = new System.Windows.Forms.TextBox();
            this.x1Box = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gotoCubicEq = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBox);
            this.groupBox1.Controls.Add(this.bBox);
            this.groupBox1.Controls.Add(this.aBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(178, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "c  = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "b  = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "a  =";
            // 
            // cBox
            // 
            this.cBox.Location = new System.Drawing.Point(57, 116);
            this.cBox.Margin = new System.Windows.Forms.Padding(4);
            this.cBox.Name = "cBox";
            this.cBox.ShortcutsEnabled = false;
            this.cBox.Size = new System.Drawing.Size(99, 25);
            this.cBox.TabIndex = 0;
            this.cBox.TextChanged += new System.EventHandler(this.aBox_TextChanged);
            this.cBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aBox_KeyPress);
            // 
            // bBox
            // 
            this.bBox.Location = new System.Drawing.Point(57, 79);
            this.bBox.Margin = new System.Windows.Forms.Padding(4);
            this.bBox.Name = "bBox";
            this.bBox.ShortcutsEnabled = false;
            this.bBox.Size = new System.Drawing.Size(99, 25);
            this.bBox.TabIndex = 1;
            this.bBox.TextChanged += new System.EventHandler(this.aBox_TextChanged);
            this.bBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aBox_KeyPress);
            // 
            // aBox
            // 
            this.aBox.Location = new System.Drawing.Point(57, 40);
            this.aBox.Margin = new System.Windows.Forms.Padding(4);
            this.aBox.Name = "aBox";
            this.aBox.ShortcutsEnabled = false;
            this.aBox.Size = new System.Drawing.Size(99, 25);
            this.aBox.TabIndex = 2;
            this.aBox.TextChanged += new System.EventHandler(this.aBox_TextChanged);
            this.aBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aBox_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.descriptionBox);
            this.groupBox2.Controls.Add(this.clearButton);
            this.groupBox2.Controls.Add(this.processButton);
            this.groupBox2.Controls.Add(this.mode3);
            this.groupBox2.Controls.Add(this.mode2);
            this.groupBox2.Controls.Add(this.mode1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(11, 199);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(500, 158);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(278, 25);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.Size = new System.Drawing.Size(173, 114);
            this.descriptionBox.TabIndex = 3;
            this.descriptionBox.Text = "";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(134, 64);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(87, 32);
            this.clearButton.TabIndex = 0;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(134, 26);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(87, 32);
            this.processButton.TabIndex = 2;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // mode3
            // 
            this.mode3.AutoSize = true;
            this.mode3.Location = new System.Drawing.Point(10, 101);
            this.mode3.Margin = new System.Windows.Forms.Padding(4);
            this.mode3.Name = "mode3";
            this.mode3.Size = new System.Drawing.Size(72, 21);
            this.mode3.TabIndex = 2;
            this.mode3.TabStop = true;
            this.mode3.Text = "Mode 3";
            this.mode3.UseVisualStyleBackColor = true;
            this.mode3.CheckedChanged += new System.EventHandler(this.mode3_CheckedChanged);
            // 
            // mode2
            // 
            this.mode2.AutoSize = true;
            this.mode2.Location = new System.Drawing.Point(10, 67);
            this.mode2.Margin = new System.Windows.Forms.Padding(4);
            this.mode2.Name = "mode2";
            this.mode2.Size = new System.Drawing.Size(72, 21);
            this.mode2.TabIndex = 1;
            this.mode2.TabStop = true;
            this.mode2.Text = "Mode 2";
            this.mode2.UseVisualStyleBackColor = true;
            this.mode2.CheckedChanged += new System.EventHandler(this.mode2_CheckedChanged);
            // 
            // mode1
            // 
            this.mode1.AutoSize = true;
            this.mode1.Location = new System.Drawing.Point(10, 32);
            this.mode1.Margin = new System.Windows.Forms.Padding(4);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(72, 21);
            this.mode1.TabIndex = 0;
            this.mode1.TabStop = true;
            this.mode1.Text = "Mode 1";
            this.mode1.UseVisualStyleBackColor = true;
            this.mode1.CheckedChanged += new System.EventHandler(this.mode1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.x2Box);
            this.groupBox3.Controls.Add(this.x1Box);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(218, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(293, 167);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "x2 = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "x1 = ";
            // 
            // x2Box
            // 
            this.x2Box.Location = new System.Drawing.Point(56, 78);
            this.x2Box.Name = "x2Box";
            this.x2Box.ShortcutsEnabled = false;
            this.x2Box.Size = new System.Drawing.Size(188, 25);
            this.x2Box.TabIndex = 1;
            this.x2Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.x1Box_KeyPress);
            // 
            // x1Box
            // 
            this.x1Box.Location = new System.Drawing.Point(56, 40);
            this.x1Box.Name = "x1Box";
            this.x1Box.ShortcutsEnabled = false;
            this.x1Box.Size = new System.Drawing.Size(188, 25);
            this.x1Box.TabIndex = 2;
            this.x1Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.x1Box_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gotoCubicEq
            // 
            this.gotoCubicEq.Location = new System.Drawing.Point(611, 12);
            this.gotoCubicEq.Name = "gotoCubicEq";
            this.gotoCubicEq.Size = new System.Drawing.Size(178, 23);
            this.gotoCubicEq.TabIndex = 4;
            this.gotoCubicEq.Text = "Switch to Cubic Equation";
            this.gotoCubicEq.UseVisualStyleBackColor = true;
            this.gotoCubicEq.Click += new System.EventHandler(this.gotoCubicEq_Click);
            // 
            // SquareEq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 449);
            this.Controls.Add(this.gotoCubicEq);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SquareEq";
            this.Text = "Square Equation Solution";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SquareEq_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox cBox;
        private TextBox bBox;
        private TextBox aBox;
        private GroupBox groupBox2;
        private Button clearButton;
        private Button processButton;
        private RadioButton mode3;
        private RadioButton mode2;
        private RadioButton mode1;
        private GroupBox groupBox3;
        private Label label5;
        private Label label4;
        private TextBox x2Box;
        private TextBox x1Box;
        private ErrorProvider errorProvider1;
        private RichTextBox descriptionBox;
        private Button gotoCubicEq;
    }
}