namespace BaiTap01
{
    partial class Form1
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckCV = new System.Windows.Forms.CheckBox();
            this.ckTR = new System.Windows.Forms.CheckBox();
            this.ckCHR = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTR = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butT = new System.Windows.Forms.Button();
            this.butTT = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(179, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ten Khach Hang";
            // 
            // ckCV
            // 
            this.ckCV.AutoSize = true;
            this.ckCV.Location = new System.Drawing.Point(64, 110);
            this.ckCV.Name = "ckCV";
            this.ckCV.Size = new System.Drawing.Size(62, 17);
            this.ckCV.TabIndex = 3;
            this.ckCV.Text = "Cạo vôi";
            this.ckCV.UseVisualStyleBackColor = true;
            // 
            // ckTR
            // 
            this.ckTR.AutoSize = true;
            this.ckTR.Location = new System.Drawing.Point(64, 147);
            this.ckTR.Name = "ckTR";
            this.ckTR.Size = new System.Drawing.Size(68, 17);
            this.ckTR.TabIndex = 4;
            this.ckTR.Text = "Tẩy răng";
            this.ckTR.UseVisualStyleBackColor = true;
            // 
            // ckCHR
            // 
            this.ckCHR.AutoSize = true;
            this.ckCHR.Location = new System.Drawing.Point(64, 181);
            this.ckCHR.Name = "ckCHR";
            this.ckCHR.Size = new System.Drawing.Size(98, 17);
            this.ckCHR.TabIndex = 5;
            this.ckCHR.Text = "Chụp hình răng";
            this.ckCHR.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "$100.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "$1.200.000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "$200.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Trám răng";
            // 
            // cbTR
            // 
            this.cbTR.FormattingEnabled = true;
            this.cbTR.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbTR.Location = new System.Drawing.Point(158, 261);
            this.cbTR.Name = "cbTR";
            this.cbTR.Size = new System.Drawing.Size(121, 21);
            this.cbTR.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "$80.00/cái";
            // 
            // butT
            // 
            this.butT.Location = new System.Drawing.Point(64, 325);
            this.butT.Name = "butT";
            this.butT.Size = new System.Drawing.Size(75, 23);
            this.butT.TabIndex = 12;
            this.butT.Text = "Thoát";
            this.butT.UseVisualStyleBackColor = true;
            this.butT.Click += new System.EventHandler(this.butT_Click);
            // 
            // butTT
            // 
            this.butTT.Location = new System.Drawing.Point(484, 325);
            this.butTT.Name = "butTT";
            this.butTT.Size = new System.Drawing.Size(75, 23);
            this.butTT.TabIndex = 13;
            this.butTT.Text = "Tính tiền";
            this.butTT.UseVisualStyleBackColor = true;
            this.butTT.Click += new System.EventHandler(this.butTT_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Dental Payment";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(484, 375);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butTT);
            this.Controls.Add(this.butT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckCHR);
            this.Controls.Add(this.ckTR);
            this.Controls.Add(this.ckCV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckCV;
        private System.Windows.Forms.CheckBox ckTR;
        private System.Windows.Forms.CheckBox ckCHR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butT;
        private System.Windows.Forms.Button butTT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
    }
}

