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
        public PxColor(object obj)
        {
            color = Color.FromArgb(0, 0, 0, 0);
            isExist = false;
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
            get9Elems(78, 47);
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
            PxColor temp = new PxColor(null);
            int i, j,z;
            i = j = z = 0;
            foreach(var ix in Enumerable.Range(x-1,3))
            {   
                foreach(var iy in Enumerable.Range(y-1,3))
                {
                    try
                    {
                        temp = new PxColor(bitmap.GetPixel(ix, iy), true);

                    }  
                    catch (ArgumentOutOfRangeException)
                    {
                        temp = new PxColor(null);

                    }
                    curPixelList[i][j] = temp;
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
            foreach(var i in Enumerable.Range(0,curPixelList.Capacity))
            {
                curPixelList.Add(new List<PxColor>());
                foreach (var j in Enumerable.Range(0, curPixelList.Capacity))
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
