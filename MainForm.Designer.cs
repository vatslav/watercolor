namespace watercolor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bOpen = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.bSafe = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(12, 12);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(91, 61);
            this.bOpen.TabIndex = 0;
            this.bOpen.Text = "выбрать изображение";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bApply
            // 
            this.bApply.Location = new System.Drawing.Point(109, 12);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(91, 61);
            this.bApply.TabIndex = 1;
            this.bApply.Text = "применить фильтр";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bSafe
            // 
            this.bSafe.Location = new System.Drawing.Point(206, 12);
            this.bSafe.Name = "bSafe";
            this.bSafe.Size = new System.Drawing.Size(91, 61);
            this.bSafe.TabIndex = 2;
            this.bSafe.Text = "сохранить изображение";
            this.bSafe.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(303, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(46, 51);
            this.dataGridView1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 164);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(6, 22);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(36, 20);
            this.textBox11.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox33);
            this.groupBox1.Controls.Add(this.textBox23);
            this.groupBox1.Controls.Add(this.textBox32);
            this.groupBox1.Controls.Add(this.textBox31);
            this.groupBox1.Controls.Add(this.textBox21);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.textBox22);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Location = new System.Drawing.Point(303, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 105);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Матрица коэффициентов";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(48, 22);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(36, 20);
            this.textBox12.TabIndex = 6;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(90, 22);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(36, 20);
            this.textBox13.TabIndex = 7;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(6, 48);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(36, 20);
            this.textBox21.TabIndex = 8;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(48, 48);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(36, 20);
            this.textBox22.TabIndex = 9;
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(90, 48);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(36, 20);
            this.textBox23.TabIndex = 10;
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(6, 74);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(36, 20);
            this.textBox31.TabIndex = 11;
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(48, 74);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(36, 20);
            this.textBox32.TabIndex = 12;
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(90, 74);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(36, 20);
            this.textBox33.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 277);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bSafe);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.bOpen);
            this.Name = "MainForm";
            this.Text = "Акварелизация";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Button bSafe;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox12;
    }
}

