namespace RecordBook
{
    partial class FormRecordBookAddUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecordBookAddUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonRecordBookAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel36.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Дисцеплина";
            // 
            // panel36
            // 
            this.panel36.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel36.Controls.Add(this.textBox18);
            this.panel36.Location = new System.Drawing.Point(170, 175);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(80, 24);
            this.panel36.TabIndex = 61;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox18.Location = new System.Drawing.Point(4, 5);
            this.textBox18.MaxLength = 1;
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(73, 13);
            this.textBox18.TabIndex = 50;
            this.textBox18.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Преподаватель";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Симестр";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Оценка";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Незачет",
            "Зачет",
            "3",
            "4",
            "5"});
            this.comboBox2.Location = new System.Drawing.Point(266, 175);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(81, 23);
            this.comboBox2.TabIndex = 69;
            // 
            // buttonRecordBookAdd
            // 
            this.buttonRecordBookAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonRecordBookAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookAdd.FlatAppearance.BorderSize = 0;
            this.buttonRecordBookAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonRecordBookAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonRecordBookAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecordBookAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecordBookAdd.Location = new System.Drawing.Point(9, 212);
            this.buttonRecordBookAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRecordBookAdd.Name = "buttonRecordBookAdd";
            this.buttonRecordBookAdd.Size = new System.Drawing.Size(95, 23);
            this.buttonRecordBookAdd.TabIndex = 70;
            this.buttonRecordBookAdd.Text = "Добавить";
            this.buttonRecordBookAdd.UseVisualStyleBackColor = false;
            this.buttonRecordBookAdd.Click += new System.EventHandler(this.buttonRecordBookAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(9, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 24);
            this.panel1.TabIndex = 62;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(4, 5);
            this.textBox1.MaxLength = 99;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(530, 13);
            this.textBox1.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(9, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 24);
            this.panel2.TabIndex = 63;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(4, 5);
            this.textBox2.MaxLength = 99;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(530, 13);
            this.textBox2.TabIndex = 50;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Location = new System.Drawing.Point(9, 175);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 24);
            this.panel3.TabIndex = 62;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(4, 5);
            this.textBox3.MaxLength = 90;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 13);
            this.textBox3.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "Дата провидения";
            // 
            // FormRecordBookAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 245);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRecordBookAdd);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel36);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 245);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(557, 245);
            this.Name = "FormRecordBookAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование зачетной книжки ";
            this.Load += new System.EventHandler(this.FormRecordBookAdd_Load);
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel36;
        public System.Windows.Forms.TextBox textBox18;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonRecordBookAdd;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Label label5;
    }
}