using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
//using 

namespace watercolor
{   
    


    class Core
    {
        public Bitmap bitmap;
        private Bitmap resultBitmap;
        PictureBox mainCanvas;
        //матрица выделения краев
        List<int> mxEdgesEnhancement = new  List<int>{0, -1, 0,
                                                        -1, 4, -1,
                                                        0, -1, 0};
        List<int> curFilterMx = new  List<int>();
        List<List<Color>> curPixelList = new List<List<Color>>(9);

        public Core(PictureBox mainCanvas) 
        { 
            this.mainCanvas = mainCanvas;
            curFilterMx = mxEdgesEnhancement; //на случай большего кода
        
        }
        /// <summary>
        /// загрузка картинки
        /// </summary>
        /// <param name="path"></param>
        public void openFile(String path)
        {
               if (bitmap != null)
               {
                  bitmap.Dispose();
               }
            mainCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            bitmap = new Bitmap(path);
            mainCanvas.Image = (Image)bitmap;

        }

        public void applyFilter()
        {
            curFilterMx = mxEdgesEnhancement; 
            waterColorFilter();
            return;
        }
        private void waterColorFilter()
        {

            int width = bitmap.Width;
            int height = bitmap.Height;
            resultBitmap = new Bitmap(width, height);



            return;
        }
        /// <summary>
        /// возвращает список соседних элементов пикселя
        /// </summary>
        /// <param name="x">координата по Х</param>
        /// <param name="y">координата по У</param>
        /// <returns></returns>
        private void get9Elems(int x, int y)
        {
            
            for (int ix = x - 1; ix < x + 1; ix++)
            {
                for (int iy = y - 1; iy < x + 1; iy++)
                {
                    try
                    {
                        curPixelList[x][y] = bitmap.GetPixel(ix, iy);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        curPixelList[x][y] = Color.FromArgb(-1, -1, -1, -1);
                    }

                }

            }
            return;
        }
        /// <summary>
        /// определяет существуют ли такой пиксель
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool virifyPixelAdress(int x, int y)
        {
            if (x < 0 || y < 0)
                return false;
            else
            {
                try
                {
                    bitmap.GetPixel(x, y);
                    return true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return false;
                }
            }
        }


    }
}
