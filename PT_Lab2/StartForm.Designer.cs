namespace PT_Lab2
{
    partial class StartForm
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
            this.SquareEq_Button = new System.Windows.Forms.Button();
            this.CubicEq_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SquareEq_Button
            // 
            this.SquareEq_Button.Location = new System.Drawing.Point(12, 75);
            this.SquareEq_Button.Name = "SquareEq_Button";
            this.SquareEq_Button.Size = new System.Drawing.Size(136, 23);
            this.SquareEq_Button.TabIndex = 0;
            this.SquareEq_Button.Text = "Square Equation";
            this.SquareEq_Button.UseVisualStyleBackColor = true;
            this.SquareEq_Button.Click += new System.EventHandler(this.SquareEq_Button_Click);
            // 
            // CubicEq_Button
            // 
            this.CubicEq_Button.Location = new System.Drawing.Point(167, 75);
            this.CubicEq_Button.Name = "CubicEq_Button";
            this.CubicEq_Button.Size = new System.Drawing.Size(136, 23);
            this.CubicEq_Button.TabIndex = 1;
            this.CubicEq_Button.Text = "Cubic Equation";
            this.CubicEq_Button.UseVisualStyleBackColor = true;
            this.CubicEq_Button.Click += new System.EventHandler(this.CubicEq_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose the type of equation";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 110);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CubicEq_Button);
            this.Controls.Add(this.SquareEq_Button);
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SquareEq_Button;
        private Button CubicEq_Button;
        private Label label1;
    }
}