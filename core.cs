using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
//using 

namespace watercolor
{
    public struct PxColor
    {
        public Color color;
        public bool isExist;
        public PxColor(Color color, bool isExist)
        {
            this.color = color;
            this.isExist = isExist;

        }
        public string ColorToString()
        {
            return color.A.ToString() + " " + color.B.ToString() + " " + color.G.ToString() + " " + color.R.ToString();
        }
    }


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
        List<List<PxColor>> curPixelList = new List<List<PxColor>>(3);
        public Core(PictureBox mainCanvas) 
        { 
            this.mainCanvas = mainCanvas;
            curFilterMx = mxEdgesEnhancement; //на случай большего кода
            clearCurMx();



        
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
            printCurPicturLsit();
            resultBitmap = new Bitmap(width, height);
            get9Elems(25, 25);
            printCurPicturLsit();

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
            clearCurMx();
            int i, j;
            i = j = 0;
            for (int ix = x - 1; ix < x + 1; ix++)
            {   
                for (int iy = y - 1; iy < x + 1; iy++)
                {
                    try
                    {
                        curPixelList[i][j] = new PxColor(bitmap.GetPixel(ix, iy), true);

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        curPixelList[i][j] = new PxColor(Color.FromArgb(0,0,0,0), false);

                    }
                    j++;
                }
                j = 0;
                i++;

            }
            return;
        }
        private void printCurPicturLsit()
        {
            int i = 0;
            int j = 0;
            foreach (var l in curPixelList)
            {
                foreach (var px in l)
                {
                    Console.WriteLine(String.Format("({0},{1} - {2},{3})", px.ColorToString(), px.isExist.ToString(), i, j));
                    j++;
                }
                j = 0;
                i++;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// обнуляет список текущих элементов
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void clearCurMx()
        {
            PxColor temp = new PxColor(Color.FromArgb(0, 0, 0, 0), false);
            curPixelList.Clear();
            for (int i = 0; i < curPixelList.Capacity; i++)
            {
                curPixelList.Add(new List<PxColor>());
                for (int j = 0; j < curPixelList.Capacity; j++)
                    curPixelList[i].Add(temp);
            }

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
