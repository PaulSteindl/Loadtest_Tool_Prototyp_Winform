namespace Loadtest_Tool_Prototyp_Winform
{
    partial class Results
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.requestsTxt = new System.Windows.Forms.TextBox();
            this.averageTimeTxt = new System.Windows.Forms.TextBox();
            this.minTimeTxt = new System.Windows.Forms.TextBox();
            this.maxTimeTxt = new System.Windows.Forms.TextBox();
            this.errorMarginTxt = new System.Windows.Forms.TextBox();
            this.resultListView = new System.Windows.Forms.ListView();
            this.timeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.successCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sendKbCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reciveKbCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sendBodyCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.responseBodyCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requests:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Average:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Error Margin:";
            // 
            // requestsTxt
            // 
            this.requestsTxt.Location = new System.Drawing.Point(85, 20);
            this.requestsTxt.Name = "requestsTxt";
            this.requestsTxt.ReadOnly = true;
            this.requestsTxt.Size = new System.Drawing.Size(100, 20);
            this.requestsTxt.TabIndex = 6;
            // 
            // averageTimeTxt
            // 
            this.averageTimeTxt.Location = new System.Drawing.Point(85, 46);
            this.averageTimeTxt.Name = "averageTimeTxt";
            this.averageTimeTxt.ReadOnly = true;
            this.averageTimeTxt.Size = new System.Drawing.Size(100, 20);
            this.averageTimeTxt.TabIndex = 7;
            // 
            // minTimeTxt
            // 
            this.minTimeTxt.Location = new System.Drawing.Point(85, 72);
            this.minTimeTxt.Name = "minTimeTxt";
            this.minTimeTxt.ReadOnly = true;
            this.minTimeTxt.Size = new System.Drawing.Size(100, 20);
            this.minTimeTxt.TabIndex = 8;
            // 
            // maxTimeTxt
            // 
            this.maxTimeTxt.Location = new System.Drawing.Point(85, 98);
            this.maxTimeTxt.Name = "maxTimeTxt";
            this.maxTimeTxt.ReadOnly = true;
            this.maxTimeTxt.Size = new System.Drawing.Size(100, 20);
            this.maxTimeTxt.TabIndex = 9;
            // 
            // errorMarginTxt
            // 
            this.errorMarginTxt.Location = new System.Drawing.Point(85, 124);
            this.errorMarginTxt.Name = "errorMarginTxt";
            this.errorMarginTxt.ReadOnly = true;
            this.errorMarginTxt.Size = new System.Drawing.Size(100, 20);
            this.errorMarginTxt.TabIndex = 10;
            // 
            // resultListView
            // 
            this.resultListView.AllowDrop = true;
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeCol,
            this.successCol,
            this.sendKbCol,
            this.reciveKbCol,
            this.sendBodyCol,
            this.responseBodyCol});
            this.resultListView.GridLines = true;
            this.resultListView.HideSelection = false;
            this.resultListView.Location = new System.Drawing.Point(191, 12);
            this.resultListView.MultiSelect = false;
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(597, 426);
            this.resultListView.TabIndex = 12;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            this.resultListView.SelectedIndexChanged += new System.EventHandler(this.resultListView_SelectedIndexChanged);
            // 
            // timeCol
            // 
            this.timeCol.Text = "Time";
            // 
            // successCol
            // 
            this.successCol.Text = "Success";
            // 
            // sendKbCol
            // 
            this.sendKbCol.Text = "Send Byte";
            this.sendKbCol.Width = 80;
            // 
            // reciveKbCol
            // 
            this.reciveKbCol.Text = "Recived Byte";
            this.reciveKbCol.Width = 80;
            // 
            // sendBodyCol
            // 
            this.sendBodyCol.Text = "Send Body";
            this.sendBodyCol.Width = 157;
            // 
            // responseBodyCol
            // 
            this.responseBodyCol.Text = "Response Body";
            this.responseBodyCol.Width = 156;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.errorMarginTxt);
            this.Controls.Add(this.maxTimeTxt);
            this.Controls.Add(this.minTimeTxt);
            this.Controls.Add(this.averageTimeTxt);
            this.Controls.Add(this.requestsTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox errorMarginTxt;
        public System.Windows.Forms.TextBox maxTimeTxt;
        public System.Windows.Forms.TextBox minTimeTxt;
        public System.Windows.Forms.TextBox averageTimeTxt;
        public System.Windows.Forms.TextBox requestsTxt;
        public System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader timeCol;
        private System.Windows.Forms.ColumnHeader successCol;
        private System.Windows.Forms.ColumnHeader sendKbCol;
        private System.Windows.Forms.ColumnHeader reciveKbCol;
        private System.Windows.Forms.ColumnHeader sendBodyCol;
        private System.Windows.Forms.ColumnHeader responseBodyCol;
    }
}