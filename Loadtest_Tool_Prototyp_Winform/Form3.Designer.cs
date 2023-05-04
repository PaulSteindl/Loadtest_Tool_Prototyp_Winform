namespace Loadtest_Tool_Prototyp_Winform
{
    partial class Form3
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
            this.requestTxtBx = new System.Windows.Forms.RichTextBox();
            this.responseTxtBx = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // requestTxtBx
            // 
            this.requestTxtBx.Location = new System.Drawing.Point(12, 25);
            this.requestTxtBx.Name = "requestTxtBx";
            this.requestTxtBx.ReadOnly = true;
            this.requestTxtBx.Size = new System.Drawing.Size(385, 413);
            this.requestTxtBx.TabIndex = 0;
            this.requestTxtBx.Text = "";
            // 
            // responseTxtBx
            // 
            this.responseTxtBx.Location = new System.Drawing.Point(403, 25);
            this.responseTxtBx.Name = "responseTxtBx";
            this.responseTxtBx.ReadOnly = true;
            this.responseTxtBx.Size = new System.Drawing.Size(385, 413);
            this.responseTxtBx.TabIndex = 1;
            this.responseTxtBx.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Response";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.responseTxtBx);
            this.Controls.Add(this.requestTxtBx);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox responseTxtBx;
        public System.Windows.Forms.RichTextBox requestTxtBx;
    }
}