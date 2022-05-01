namespace BT03
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnC = new System.Windows.Forms.Button();
            this.btnLT = new System.Windows.Forms.Button();
            this.btnCC = new System.Windows.Forms.Button();
            this.btnKTC = new System.Windows.Forms.Button();
            this.btnCf = new System.Windows.Forms.Button();
            this.btn7U = new System.Windows.Forms.Button();
            this.btnP = new System.Windows.Forms.Button();
            this.btnCG = new System.Windows.Forms.Button();
            this.btnGR = new System.Windows.Forms.Button();
            this.btnGV = new System.Windows.Forms.Button();
            this.btnTV = new System.Windows.Forms.Button();
            this.btnBPC = new System.Windows.Forms.Button();
            this.btnBPT = new System.Windows.Forms.Button();
            this.btnBPG = new System.Windows.Forms.Button();
            this.btnBPB = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnOD = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fastfood Order";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnC);
            this.groupBox1.Controls.Add(this.btnLT);
            this.groupBox1.Controls.Add(this.btnCC);
            this.groupBox1.Controls.Add(this.btnKTC);
            this.groupBox1.Controls.Add(this.btnCf);
            this.groupBox1.Controls.Add(this.btn7U);
            this.groupBox1.Controls.Add(this.btnP);
            this.groupBox1.Controls.Add(this.btnCG);
            this.groupBox1.Controls.Add(this.btnGR);
            this.groupBox1.Controls.Add(this.btnGV);
            this.groupBox1.Controls.Add(this.btnTV);
            this.groupBox1.Controls.Add(this.btnBPC);
            this.groupBox1.Controls.Add(this.btnBPT);
            this.groupBox1.Controls.Add(this.btnBPG);
            this.groupBox1.Controls.Add(this.btnBPB);
            this.groupBox1.Location = new System.Drawing.Point(37, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 207);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh mục món ăn";
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(395, 106);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(75, 23);
            this.btnC.TabIndex = 14;
            this.btnC.Text = "Cam";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnLT
            // 
            this.btnLT.Location = new System.Drawing.Point(395, 58);
            this.btnLT.Name = "btnLT";
            this.btnLT.Size = new System.Drawing.Size(75, 23);
            this.btnLT.TabIndex = 13;
            this.btnLT.Text = "Lipton";
            this.btnLT.UseVisualStyleBackColor = true;
            this.btnLT.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCC
            // 
            this.btnCC.Location = new System.Drawing.Point(395, 19);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(75, 23);
            this.btnCC.TabIndex = 12;
            this.btnCC.Text = "Coca";
            this.btnCC.UseVisualStyleBackColor = true;
            this.btnCC.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnKTC
            // 
            this.btnKTC.Location = new System.Drawing.Point(294, 151);
            this.btnKTC.Name = "btnKTC";
            this.btnKTC.Size = new System.Drawing.Size(176, 23);
            this.btnKTC.TabIndex = 11;
            this.btnKTC.Text = "Khoai tây chiên";
            this.btnKTC.UseVisualStyleBackColor = true;
            this.btnKTC.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCf
            // 
            this.btnCf.Location = new System.Drawing.Point(294, 106);
            this.btnCf.Name = "btnCf";
            this.btnCf.Size = new System.Drawing.Size(75, 23);
            this.btnCf.TabIndex = 10;
            this.btnCf.Text = "Cafe";
            this.btnCf.UseVisualStyleBackColor = true;
            this.btnCf.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn7U
            // 
            this.btn7U.Location = new System.Drawing.Point(294, 58);
            this.btn7U.Name = "btn7U";
            this.btn7U.Size = new System.Drawing.Size(75, 23);
            this.btn7U.TabIndex = 9;
            this.btn7U.Text = "7 up";
            this.btn7U.UseVisualStyleBackColor = true;
            this.btn7U.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnP
            // 
            this.btnP.Location = new System.Drawing.Point(294, 19);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(75, 23);
            this.btnP.TabIndex = 8;
            this.btnP.Text = "Pepsi";
            this.btnP.UseVisualStyleBackColor = true;
            this.btnP.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCG
            // 
            this.btnCG.Location = new System.Drawing.Point(171, 151);
            this.btnCG.Name = "btnCG";
            this.btnCG.Size = new System.Drawing.Size(104, 23);
            this.btnCG.TabIndex = 7;
            this.btnCG.Text = "Cơm Gà Tender";
            this.btnCG.UseVisualStyleBackColor = true;
            this.btnCG.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnGR
            // 
            this.btnGR.Location = new System.Drawing.Point(171, 106);
            this.btnGR.Name = "btnGR";
            this.btnGR.Size = new System.Drawing.Size(104, 23);
            this.btnGR.TabIndex = 6;
            this.btnGR.Text = "Gà rán phần";
            this.btnGR.UseVisualStyleBackColor = true;
            this.btnGR.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnGV
            // 
            this.btnGV.Location = new System.Drawing.Point(171, 58);
            this.btnGV.Name = "btnGV";
            this.btnGV.Size = new System.Drawing.Size(104, 23);
            this.btnGV.TabIndex = 5;
            this.btnGV.Text = "Gà viên Cola";
            this.btnGV.UseVisualStyleBackColor = true;
            this.btnGV.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnTV
            // 
            this.btnTV.Location = new System.Drawing.Point(171, 19);
            this.btnTV.Name = "btnTV";
            this.btnTV.Size = new System.Drawing.Size(104, 23);
            this.btnTV.TabIndex = 4;
            this.btnTV.Text = "Tôm viên Cola";
            this.btnTV.UseVisualStyleBackColor = true;
            this.btnTV.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnBPC
            // 
            this.btnBPC.Location = new System.Drawing.Point(31, 151);
            this.btnBPC.Name = "btnBPC";
            this.btnBPC.Size = new System.Drawing.Size(115, 23);
            this.btnBPC.TabIndex = 3;
            this.btnBPC.Text = "Burger Phô mai Cá";
            this.btnBPC.UseVisualStyleBackColor = true;
            this.btnBPC.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnBPT
            // 
            this.btnBPT.Location = new System.Drawing.Point(31, 106);
            this.btnBPT.Name = "btnBPT";
            this.btnBPT.Size = new System.Drawing.Size(115, 23);
            this.btnBPT.TabIndex = 2;
            this.btnBPT.Text = "Burger Phô mai Tôm";
            this.btnBPT.UseVisualStyleBackColor = true;
            this.btnBPT.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnBPG
            // 
            this.btnBPG.Location = new System.Drawing.Point(31, 58);
            this.btnBPG.Name = "btnBPG";
            this.btnBPG.Size = new System.Drawing.Size(115, 23);
            this.btnBPG.TabIndex = 1;
            this.btnBPG.Text = "Burger Phô mai Gà";
            this.btnBPG.UseVisualStyleBackColor = true;
            this.btnBPG.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnBPB
            // 
            this.btnBPB.Location = new System.Drawing.Point(31, 19);
            this.btnBPB.Name = "btnBPB";
            this.btnBPB.Size = new System.Drawing.Size(115, 23);
            this.btnBPB.TabIndex = 0;
            this.btnBPB.Text = "Burger Phô mai Bò";
            this.btnBPB.UseVisualStyleBackColor = true;
            this.btnBPB.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(37, 286);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Xoá";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnOD
            // 
            this.btnOD.Location = new System.Drawing.Point(432, 286);
            this.btnOD.Name = "btnOD";
            this.btnOD.Size = new System.Drawing.Size(75, 23);
            this.btnOD.TabIndex = 3;
            this.btnOD.Text = "Order";
            this.btnOD.UseVisualStyleBackColor = true;
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(196, 291);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(47, 13);
            this.Name.TabIndex = 4;
            this.Name.Text = "Tên bàn";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(249, 286);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 334);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(470, 173);
            this.dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.btnOD);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            //this.Name = "Form1";
            this.Text = "E-Order Application";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnLT;
        private System.Windows.Forms.Button btnCC;
        private System.Windows.Forms.Button btnKTC;
        private System.Windows.Forms.Button btnCf;
        private System.Windows.Forms.Button btn7U;
        private System.Windows.Forms.Button btnP;
        private System.Windows.Forms.Button btnCG;
        private System.Windows.Forms.Button btnGR;
        private System.Windows.Forms.Button btnGV;
        private System.Windows.Forms.Button btnTV;
        private System.Windows.Forms.Button btnBPC;
        private System.Windows.Forms.Button btnBPT;
        private System.Windows.Forms.Button btnBPG;
        private System.Windows.Forms.Button btnBPB;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnOD;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

