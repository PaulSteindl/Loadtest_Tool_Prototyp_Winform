namespace Loadtest_Tool_Prototyp_Winform
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.selectXsdBtn = new System.Windows.Forms.Button();
            this.loadXsdBtn = new System.Windows.Forms.Button();
            this.selectXsdTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.urlTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.pathTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.xmlPropertView = new System.Windows.Forms.PropertyGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.threadsNumberNr = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.rampupPeriodeNr = new System.Windows.Forms.NumericUpDown();
            this.loopCountNr = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.durationNr = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.createPathTxt = new System.Windows.Forms.TextBox();
            this.xmlCreateCountNr = new System.Windows.Forms.NumericUpDown();
            this.createXmlsBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.sendRequestsBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumberNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rampupPeriodeNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopCountNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmlCreateCountNr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "XSD File:";
            // 
            // selectXsdBtn
            // 
            this.selectXsdBtn.Location = new System.Drawing.Point(16, 88);
            this.selectXsdBtn.Name = "selectXsdBtn";
            this.selectXsdBtn.Size = new System.Drawing.Size(75, 23);
            this.selectXsdBtn.TabIndex = 1;
            this.selectXsdBtn.Text = "Select XSD";
            this.selectXsdBtn.UseVisualStyleBackColor = true;
            this.selectXsdBtn.Click += new System.EventHandler(this.selectXsdBtn_Click);
            // 
            // loadXsdBtn
            // 
            this.loadXsdBtn.Location = new System.Drawing.Point(97, 88);
            this.loadXsdBtn.Name = "loadXsdBtn";
            this.loadXsdBtn.Size = new System.Drawing.Size(75, 23);
            this.loadXsdBtn.TabIndex = 2;
            this.loadXsdBtn.Text = "Load XSD";
            this.loadXsdBtn.UseVisualStyleBackColor = true;
            this.loadXsdBtn.Click += new System.EventHandler(this.loadXsdBtn_Click);
            // 
            // selectXsdTxt
            // 
            this.selectXsdTxt.Location = new System.Drawing.Point(85, 10);
            this.selectXsdTxt.Name = "selectXsdTxt";
            this.selectXsdTxt.ReadOnly = true;
            this.selectXsdTxt.Size = new System.Drawing.Size(177, 20);
            this.selectXsdTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Url/IP:";
            // 
            // urlTxt
            // 
            this.urlTxt.Location = new System.Drawing.Point(57, 278);
            this.urlTxt.Name = "urlTxt";
            this.urlTxt.Size = new System.Drawing.Size(196, 20);
            this.urlTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port:";
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(57, 305);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(78, 20);
            this.portTxt.TabIndex = 7;
            // 
            // pathTxt
            // 
            this.pathTxt.Location = new System.Drawing.Point(57, 332);
            this.pathTxt.Name = "pathTxt";
            this.pathTxt.Size = new System.Drawing.Size(196, 20);
            this.pathTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "XML Example";
            // 
            // xmlPropertView
            // 
            this.xmlPropertView.Location = new System.Drawing.Point(377, 29);
            this.xmlPropertView.Name = "xmlPropertView";
            this.xmlPropertView.Size = new System.Drawing.Size(411, 409);
            this.xmlPropertView.TabIndex = 12;
            this.xmlPropertView.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Threads:";
            // 
            // threadsNumberNr
            // 
            this.threadsNumberNr.Location = new System.Drawing.Point(120, 150);
            this.threadsNumberNr.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.threadsNumberNr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadsNumberNr.Name = "threadsNumberNr";
            this.threadsNumberNr.Size = new System.Drawing.Size(120, 20);
            this.threadsNumberNr.TabIndex = 15;
            this.threadsNumberNr.ThousandsSeparator = true;
            this.threadsNumberNr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Rampup Periode:";
            // 
            // rampupPeriodeNr
            // 
            this.rampupPeriodeNr.Location = new System.Drawing.Point(120, 176);
            this.rampupPeriodeNr.Name = "rampupPeriodeNr";
            this.rampupPeriodeNr.Size = new System.Drawing.Size(120, 20);
            this.rampupPeriodeNr.TabIndex = 17;
            // 
            // loopCountNr
            // 
            this.loopCountNr.Location = new System.Drawing.Point(120, 202);
            this.loopCountNr.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.loopCountNr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.loopCountNr.Name = "loopCountNr";
            this.loopCountNr.Size = new System.Drawing.Size(120, 20);
            this.loopCountNr.TabIndex = 18;
            this.loopCountNr.ThousandsSeparator = true;
            this.loopCountNr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Loop Count:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Duration (Seconds):";
            // 
            // durationNr
            // 
            this.durationNr.Location = new System.Drawing.Point(120, 231);
            this.durationNr.Maximum = new decimal(new int[] {
            10800,
            0,
            0,
            0});
            this.durationNr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.durationNr.Name = "durationNr";
            this.durationNr.Size = new System.Drawing.Size(120, 20);
            this.durationNr.TabIndex = 22;
            this.durationNr.ThousandsSeparator = true;
            this.durationNr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Create Path:";
            // 
            // createPathTxt
            // 
            this.createPathTxt.Location = new System.Drawing.Point(85, 36);
            this.createPathTxt.Name = "createPathTxt";
            this.createPathTxt.ReadOnly = true;
            this.createPathTxt.Size = new System.Drawing.Size(177, 20);
            this.createPathTxt.TabIndex = 24;
            // 
            // xmlCreateCountNr
            // 
            this.xmlCreateCountNr.Location = new System.Drawing.Point(85, 62);
            this.xmlCreateCountNr.Name = "xmlCreateCountNr";
            this.xmlCreateCountNr.Size = new System.Drawing.Size(177, 20);
            this.xmlCreateCountNr.TabIndex = 25;
            // 
            // createXmlsBtn
            // 
            this.createXmlsBtn.Location = new System.Drawing.Point(178, 88);
            this.createXmlsBtn.Name = "createXmlsBtn";
            this.createXmlsBtn.Size = new System.Drawing.Size(84, 23);
            this.createXmlsBtn.TabIndex = 26;
            this.createXmlsBtn.Text = "Create XMLs";
            this.createXmlsBtn.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "XML Count:";
            // 
            // sendRequestsBtn
            // 
            this.sendRequestsBtn.Location = new System.Drawing.Point(16, 368);
            this.sendRequestsBtn.Name = "sendRequestsBtn";
            this.sendRequestsBtn.Size = new System.Drawing.Size(98, 23);
            this.sendRequestsBtn.TabIndex = 28;
            this.sendRequestsBtn.Text = "Send Requests";
            this.sendRequestsBtn.UseVisualStyleBackColor = true;
            this.sendRequestsBtn.Click += new System.EventHandler(this.sendRequestsBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(120, 368);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 29;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.sendRequestsBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.createXmlsBtn);
            this.Controls.Add(this.xmlCreateCountNr);
            this.Controls.Add(this.createPathTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.durationNr);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.loopCountNr);
            this.Controls.Add(this.rampupPeriodeNr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.threadsNumberNr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.xmlPropertView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pathTxt);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.urlTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectXsdTxt);
            this.Controls.Add(this.loadXsdBtn);
            this.Controls.Add(this.selectXsdBtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumberNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rampupPeriodeNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopCountNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmlCreateCountNr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectXsdBtn;
        private System.Windows.Forms.Button loadXsdBtn;
        private System.Windows.Forms.TextBox selectXsdTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox urlTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.TextBox pathTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PropertyGrid xmlPropertView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown threadsNumberNr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown rampupPeriodeNr;
        private System.Windows.Forms.NumericUpDown loopCountNr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown durationNr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox createPathTxt;
        private System.Windows.Forms.NumericUpDown xmlCreateCountNr;
        private System.Windows.Forms.Button createXmlsBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button sendRequestsBtn;
        private System.Windows.Forms.Button stopBtn;
    }
}

