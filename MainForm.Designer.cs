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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultBox = new System.Windows.Forms.PictureBox();
            this.bSafe = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.autoFilter = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.brightTrackBar = new System.Windows.Forms.TrackBar();
            this.brightLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.inputBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.применитьФильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поддержкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resultBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(449, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 360);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результирующие изображение";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(6, 21);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(419, 333);
            this.resultBox.TabIndex = 5;
            this.resultBox.TabStop = false;
            // 
            // bSafe
            // 
            this.bSafe.BackgroundImage = global::watercolor.Properties.Resources.Gift_Artdesigner;
            this.bSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSafe.Location = new System.Drawing.Point(892, 168);
            this.bSafe.Name = "bSafe";
            this.bSafe.Size = new System.Drawing.Size(19, 21);
            this.bSafe.TabIndex = 2;
            this.bSafe.Text = "сохранить изображение";
            this.bSafe.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bSafe.UseVisualStyleBackColor = true;
            this.bSafe.Click += new System.EventHandler(this.bSafe_Click);
            // 
            // bApply
            // 
            this.bApply.BackgroundImage = global::watercolor.Properties.Resources.Art_Artdesigner;
            this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bApply.Location = new System.Drawing.Point(892, 195);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(19, 21);
            this.bApply.TabIndex = 1;
            this.bApply.Text = "применить фильтр";
            this.bApply.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bOpen
            // 
            this.bOpen.BackgroundImage = global::watercolor.Properties.Resources.Open;
            this.bOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOpen.Location = new System.Drawing.Point(894, 222);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(19, 19);
            this.bOpen.TabIndex = 0;
            this.bOpen.Text = "выбрать изображение";
            this.bOpen.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.autoFilter);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.brightTrackBar);
            this.groupBox2.Controls.Add(this.brightLabel);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(918, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип фильтра";
            // 
            // autoFilter
            // 
            this.autoFilter.AutoSize = true;
            this.autoFilter.Location = new System.Drawing.Point(178, 74);
            this.autoFilter.Name = "autoFilter";
            this.autoFilter.Size = new System.Drawing.Size(253, 20);
            this.autoFilter.TabIndex = 12;
            this.autoFilter.Text = "автоматически применять фильтр";
            this.autoFilter.UseVisualStyleBackColor = true;
            this.autoFilter.CheckedChanged += new System.EventHandler(this.autoFilter_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 74);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(149, 20);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Масштабирование";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Применять к эскизу";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // brightTrackBar
            // 
            this.brightTrackBar.LargeChange = 1;
            this.brightTrackBar.Location = new System.Drawing.Point(314, 37);
            this.brightTrackBar.Maximum = 256;
            this.brightTrackBar.Name = "brightTrackBar";
            this.brightTrackBar.Size = new System.Drawing.Size(309, 42);
            this.brightTrackBar.SmallChange = 10;
            this.brightTrackBar.TabIndex = 6;
            this.brightTrackBar.TickFrequency = 10;
            this.brightTrackBar.Value = 128;
            this.brightTrackBar.Scroll += new System.EventHandler(this.brightTrackBar_Scroll);
            // 
            // brightLabel
            // 
            this.brightLabel.AutoSize = true;
            this.brightLabel.Location = new System.Drawing.Point(382, 18);
            this.brightLabel.Name = "brightLabel";
            this.brightLabel.Size = new System.Drawing.Size(29, 16);
            this.brightLabel.TabIndex = 8;
            this.brightLabel.Text = "128";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(278, 24);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Яркость:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.inputBox);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(12, 133);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(431, 360);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Исходное изображение";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(6, 21);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(419, 333);
            this.inputBox.TabIndex = 4;
            this.inputBox.TabStop = false;
            this.inputBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // фильтрToolStripMenuItem
            // 
            this.фильтрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.применитьФильтрToolStripMenuItem});
            this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.фильтрToolStripMenuItem.Text = "Изображение";
            this.фильтрToolStripMenuItem.Click += new System.EventHandler(this.фильтрToolStripMenuItem_Click);
            // 
            // применитьФильтрToolStripMenuItem
            // 
            this.применитьФильтрToolStripMenuItem.Name = "применитьФильтрToolStripMenuItem";
            this.применитьФильтрToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.применитьФильтрToolStripMenuItem.Text = "Применить фильтр";
            this.применитьФильтрToolStripMenuItem.Click += new System.EventHandler(this.применитьФильтрToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поддержкаToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // поддержкаToolStripMenuItem
            // 
            this.поддержкаToolStripMenuItem.Name = "поддержкаToolStripMenuItem";
            this.поддержкаToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.поддержкаToolStripMenuItem.Text = "Поддержка";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 505);
            this.Controls.Add(this.bSafe);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Сундучок с фильтрами v.1.5";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Button bSafe;
        private System.Windows.Forms.PictureBox inputBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem применитьФильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поддержкаToolStripMenuItem;
        private System.Windows.Forms.PictureBox resultBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TrackBar brightTrackBar;
        private System.Windows.Forms.Label brightLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoFilter;
    }
}

