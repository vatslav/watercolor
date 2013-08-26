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
        public IListSource matrix;
        public List<int> mx = new List<int>();
        public MainForm()
        {
            InitializeComponent();
            brightLabel.Text = brightTrackBar.Value.ToString();
            core = new Core(pictureBox1);
            //core.openFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum3.jpg");
            //core.applyFilter();
            
        }
        
        
        private void bOpen_Click(object sender, EventArgs e)
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

        private void bApply_Click(object sender, EventArgs e)
        {
            core.applyFilter();
        }

        private void bSafe_Click(object sender, EventArgs e)
        {
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
            core.changeBright(brightTrackBar.Value);
        }
    }
}
