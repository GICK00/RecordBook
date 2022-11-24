namespace RecordBook
{
    partial class FormRecordBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecordBook));
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonRecordBookAdd = new System.Windows.Forms.Button();
            this.buttonRecordBookRemov = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonRecordBookEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView3.Location = new System.Drawing.Point(5, 174);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 20;
            this.dataGridView3.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.Size = new System.Drawing.Size(882, 422);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.TabStop = false;
            this.dataGridView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView3_SelectionChanged);
            this.dataGridView3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView3_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Количество долгов:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Количество сданных предметов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Ф.И.О. Студента:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(13, 24);
            this.toolStripLabel2.Text = "  ";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem});
            this.toolStripDropDownButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(86, 24);
            this.toolStripDropDownButton2.Text = "Документы";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.справкаToolStripMenuItem.Text = "Справка о пересдачи";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem
            // 
            this.экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem.Name = "экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem";
            this.экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem.Text = "Экспортировать зачетную книжку в Excel";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(22, 24);
            this.toolStripLabel4.Text = "     ";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(0, 24);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripDropDownButton2,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.toolStripLabel3,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(-4, 55);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(901, 27);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonRecordBookAdd
            // 
            this.buttonRecordBookAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookAdd.FlatAppearance.BorderSize = 0;
            this.buttonRecordBookAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonRecordBookAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonRecordBookAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecordBookAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecordBookAdd.Location = new System.Drawing.Point(5, 145);
            this.buttonRecordBookAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRecordBookAdd.Name = "buttonRecordBookAdd";
            this.buttonRecordBookAdd.Size = new System.Drawing.Size(95, 23);
            this.buttonRecordBookAdd.TabIndex = 63;
            this.buttonRecordBookAdd.Text = "Добавить";
            this.buttonRecordBookAdd.UseVisualStyleBackColor = false;
            this.buttonRecordBookAdd.Click += new System.EventHandler(this.buttonRecordBookAdd_Click);
            // 
            // buttonRecordBookRemov
            // 
            this.buttonRecordBookRemov.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookRemov.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookRemov.FlatAppearance.BorderSize = 0;
            this.buttonRecordBookRemov.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonRecordBookRemov.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonRecordBookRemov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecordBookRemov.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecordBookRemov.Location = new System.Drawing.Point(214, 145);
            this.buttonRecordBookRemov.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRecordBookRemov.Name = "buttonRecordBookRemov";
            this.buttonRecordBookRemov.Size = new System.Drawing.Size(95, 23);
            this.buttonRecordBookRemov.TabIndex = 64;
            this.buttonRecordBookRemov.Text = "Удалить";
            this.buttonRecordBookRemov.UseVisualStyleBackColor = false;
            this.buttonRecordBookRemov.Click += new System.EventHandler(this.buttonRecordBookRemov_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(897, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 65;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 19);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 19);
            // 
            // buttonRecordBookEdit
            // 
            this.buttonRecordBookEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRecordBookEdit.FlatAppearance.BorderSize = 0;
            this.buttonRecordBookEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonRecordBookEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonRecordBookEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecordBookEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecordBookEdit.Location = new System.Drawing.Point(110, 145);
            this.buttonRecordBookEdit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRecordBookEdit.Name = "buttonRecordBookEdit";
            this.buttonRecordBookEdit.Size = new System.Drawing.Size(95, 23);
            this.buttonRecordBookEdit.TabIndex = 66;
            this.buttonRecordBookEdit.Text = "Изменить";
            this.buttonRecordBookEdit.UseVisualStyleBackColor = false;
            this.buttonRecordBookEdit.Click += new System.EventHandler(this.buttonRecordBookEdit_Click);
            // 
            // FormRecordBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 627);
            this.Controls.Add(this.buttonRecordBookEdit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonRecordBookRemov);
            this.Controls.Add(this.buttonRecordBookAdd);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(894, 489);
            this.Name = "FormRecordBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Зачетная книжка студента";
            this.Load += new System.EventHandler(this.FormRecordBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button buttonRecordBookAdd;
        private System.Windows.Forms.ToolStripMenuItem экспортироватьЗачетнуюКнижкуВExcelToolStripMenuItem;
        private System.Windows.Forms.Button buttonRecordBookRemov;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button buttonRecordBookEdit;
    }
}