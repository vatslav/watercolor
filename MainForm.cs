using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace watercolor
{
    public partial class MainForm : Form
    {
        Core core;
        public int brightValue;

        public MainForm()
        {
            InitializeComponent();
            brightLabel.Text = brightTrackBar.Value.ToString();
            core = new Core(pictureBox1, comboBox1, this);
            //core.openFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum3.jpg");
            //core.applyFilter();
            
        }
        private void openImage()
        {
            try
            {
                OpenFileDialog askLoad = new OpenFileDialog();
                askLoad.Filter = "jpeg|*.jpg|сырое изображение|*.bmp";
                askLoad.Title = "Выберети изображение";
                askLoad.ShowDialog();
                Console.WriteLine(askLoad.FileName);
                if (askLoad.FileName != "")
                    core.openFile(askLoad.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        
        private void bOpen_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (core.isFast())
                return;
            //this.UseWaitCursor = true;
            //this.pictureBox1.UseWaitCursor = true;
            core.applyFilter();
            //this.UseWaitCursor = false;
            //this.pictureBox1.UseWaitCursor = false;
        }

        private void bSafe_Click(object sender, EventArgs e)
        {
            if (core.isFast())
                return;
            SaveFileDialog saveDial = new SaveFileDialog();
            saveDial.Filter = "изображения .jpg|*.jpg";
            saveDial.Title = "Сохранение изображения";
            saveDial.ShowDialog();
            if (saveDial.FileName != "")
                core.safeFile(saveDial.FileName);

        }

        private void brightTrackBar_Scroll(object sender, EventArgs e)
        {
            brightLabel.Text = brightTrackBar.Value.ToString();
            brightValue = brightTrackBar.Value;
            core.changeBright(brightTrackBar.Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (core.isFast())
                openImage();
        }
    }
}
