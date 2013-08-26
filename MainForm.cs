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
            //List<int> mx = new List<int>();
            //try
            //{
            //    mx.Add(Convert.ToInt32(textBox11.Text));
            //    mx.Add(Convert.ToInt32(textBox12.Text));
            //    mx.Add(Convert.ToInt32(textBox13.Text));
            //    mx.Add(Convert.ToInt32(textBox21.Text));
            //    mx.Add(Convert.ToInt32(textBox22.Text));
            //    mx.Add(Convert.ToInt32(textBox23.Text));
            //    mx.Add(Convert.ToInt32(textBox31.Text));
            //    mx.Add(Convert.ToInt32(textBox32.Text));
            //    mx.Add(Convert.ToInt32(textBox33.Text));
            //}
            //catch (ArgumentException)
            //{
            //    MessageBox.Show("не верное значение элемента матрицы");
            //    return;
            //}
            core.applyFilter();
        }
    }
}
