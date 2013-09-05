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
        PictureBox currentPb = new PictureBox();

        public MainForm()
        {
            InitializeComponent();
            brightLabel.Text = brightTrackBar.Value.ToString();
            currentPb = inputBox;
            core = new Core(inputBox, comboBox1, this.resetBightConrols);
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
                {
                    core.openFile(askLoad.FileName);
                    this.brightTrackBar.Value = 128;
                    brightLabel.Text = "128";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        void saveImage()
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

        void applyFilter()
        {
            if (core.isFast())
                return;
            this.UseWaitCursor = true;
            this.inputBox.UseWaitCursor = true;
            core.applyFilter();
            this.UseWaitCursor = false;
            this.inputBox.UseWaitCursor = false;
        }
        
        private void bOpen_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void bSafe_Click(object sender, EventArgs e)
        {
            saveImage();

        }

        private void brightTrackBar_Scroll(object sender, EventArgs e)
        {
            if (core.isFast())
            {
                brightTrackBar.Value = 128;
                return;
            }
            brightLabel.Text = brightTrackBar.Value.ToString();
            brightValue = brightTrackBar.Value;
            core.changeBright(brightTrackBar.Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (core.isFast())
                openImage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Equals(core,null))
                return;
            core.curFilter = comboBox1.SelectedItem.ToString();
        }
        public void resetBightConrols()
        {
            brightTrackBar.Value = 128;
            brightLabel.Text = "128";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();   
        }

        private void применитьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
