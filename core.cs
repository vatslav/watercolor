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
        List<int> waterColorMask = new  List<int>{0, -1, 0,
                                                        -1, 4, -1,
                                                        0, -1, 0};
        List<int> curFilterMx = new  List<int>();
        const int bluerOnWaterColor = 5;
        const int edgeMaxOnWaterCol = 3;
        List<List<PxColor>> curPixelList = new List<List<PxColor>>();
        public Core(PictureBox mainCanvas) 
        { 
            this.mainCanvas = mainCanvas;
            //curFilterMx = waterColorMask; //на случай большего кода
            clearCurMx(bluerOnWaterColor);



        
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
            curFilterMx = waterColorMask;
            
            waterColorFilter();
            return;
        }
        private void waterColorFilter()
        {
            clearCurMx(bluerOnWaterColor);
            int width = bitmap.Width;
            int height = bitmap.Height;            
            resultBitmap = new Bitmap(width, height);
            List<int> red = new List<int>(bluerOnWaterColor);
            List<int> grin = new List<int>(bluerOnWaterColor);
            List<int> blue = new List<int>(bluerOnWaterColor);
            int index=0;
            //сглаживание
            foreach(var x in Enumerable.Range(0, width))
            {
                foreach (var y in Enumerable.Range(0, height))
                {
                    getElems(x, y, bluerOnWaterColor);
                    foreach (var ListElem in curPixelList)
                    {
                        foreach (var elem in ListElem)
                        {
                            if (elem.isExist)
                            {
                                red.Add(elem.color.R);
                                grin.Add(elem.color.G);
                                blue.Add(elem.color.B);
                                index++;
                            }
                        }
                    }
                    red.Sort();                    
                    grin.Sort();
                    blue.Sort();
                    index = (int)((bluerOnWaterColor - (bluerOnWaterColor - index)) / 2);

                    resultBitmap.SetPixel(x, y, Color.FromArgb(255, red[index], grin[index], blue[index]));
                    index = 0;
                    red.Clear();
                    grin.Clear();
                    blue.Clear();
                }
            }
            //выделение краев
            List<int> Red = new List<int>(edgeMaxOnWaterCol);
            List<int> Grin = new List<int>(edgeMaxOnWaterCol);
            List<int> Blue = new List<int>(edgeMaxOnWaterCol);
            
            foreach (var x in Enumerable.Range(0, width))
            {
                foreach (var y in Enumerable.Range(0, height))
                {
                    getElems(x, y, edgeMaxOnWaterCol);
                    foreach (var listElem in curPixelList)
                    {
                        foreach (var elem in listElem)
                        {
                            
                            
                                Red.Add(elem.color.R);
                                Grin.Add(elem.color.G);
                                Blue.Add(elem.color.B);
                                
                        
                            
                            
                        }
                        

                    }
                    
                    foreach (var i in Enumerable.Range(0, edgeMaxOnWaterCol))
                    {
                        Red[i]  *= waterColorMask[i];
                        Grin[i] *= waterColorMask[i];
                        Blue[i] *= waterColorMask[i];
                        resultBitmap.SetPixel(x,y, Color.FromArgb(red.Sum(), grin.Sum(), blue.Sum()));
                    }
                    Red.Clear();
                    Grin.Clear();
                    Blue.Clear();
                    
                }

            }
                    

            mainCanvas.Image = (Image)resultBitmap;
            return;
        }
        /// <summary>
        /// возвращает список соседних элементов пикселя
        /// </summary>
        /// <param name="x">координата по Х</param>
        /// <param name="y">координата по У</param>
        /// <returns></returns>
        private void getElems(int x, int y, int sqrtOffNumberElem)
        {
            
            
            int i, j;
            i = j  = 0;
            foreach (var ix in Enumerable.Range(x - 1, sqrtOffNumberElem))
            {
                foreach (var iy in Enumerable.Range(y - 1, sqrtOffNumberElem))
                {
                    if (ix < 0 || iy < 0 || ix>=bitmap.Width ||iy>=bitmap.Height)
                    {
                        curPixelList[i][j] = new PxColor(null);
                        continue;
                    }
                    try
                    {
                        curPixelList[i][j] = new PxColor(bitmap.GetPixel(ix, iy), true);

                    }  
                    catch (ArgumentOutOfRangeException)
                    {
                        curPixelList[i][j] = new PxColor(null);

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
        private void clearCurMx(int size)
        {
            PxColor temp = new PxColor(Color.FromArgb(0, 0, 0, 0), false);
            curPixelList.Clear();
            curPixelList.Capacity = size;
            foreach (var i in Enumerable.Range(0, size))
            {
                curPixelList.Add(new List<PxColor>(size));
                foreach (var j in Enumerable.Range(0, size))
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
