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
        List<List<int>> waterColorMask2d = new List<List<int>>{new List<int>{0,-1,0},
                                                                new List<int>{-1, 4, -1},
                                                                new List<int>{0, -1, 0}};
        List<int> curFilterMx = new  List<int>();
        const int bluerOnWaterColor = 5;
        const int edgeMaxOnWaterCol = 3;
        const int edgeMaxOnWaterColLiniearly = edgeMaxOnWaterCol * edgeMaxOnWaterCol;
        List<List<PxColor>> curPixelList = new List<List<PxColor>>();
        List<int> red = new List<int>(edgeMaxOnWaterCol);
        List<int> grin = new List<int>(edgeMaxOnWaterCol);
        List<int> blue = new List<int>(edgeMaxOnWaterCol);
        Dictionary<String, payLoad> functionDB = new Dictionary<string, payLoad>();
        public Core(PictureBox mainCanvas, Form MainForm) 
        { 
            this.mainCanvas = mainCanvas;
            //curFilterMx = waterColorMask; //на случай большего кода
            clearCurMxs(bluerOnWaterColor);



        
        }

        public void applyFilter()
        {
            resultBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            bluerWaterColor();
            waterColorFilter();
            return;
        }
        private void bluerWaterColor()
        {
            clearCurMxs(bluerOnWaterColor);
            int index = 0;
            //сглаживание
            foreach (var x in Enumerable.Range(0, bitmap.Width))
            {
                foreach (var y in Enumerable.Range(0, bitmap.Height))
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

        }
        private void waterColorFilter()
        {
            //выделение краев
            clearCurMxs(edgeMaxOnWaterCol);


            foreach (var x in Enumerable.Range(0, bitmap.Width))
            {
                foreach (var y in Enumerable.Range(0, bitmap.Height))
                {
                    getElems(x, y, edgeMaxOnWaterCol);
                    foreach (var ix in Enumerable.Range(0,edgeMaxOnWaterCol))
                    {
                        foreach (var iy in Enumerable.Range(0,edgeMaxOnWaterCol))
                        {
                            if (curPixelList[ix][iy].isExist)
                            {
                                 red.Add(curPixelList[ix][iy].color.R * waterColorMask2d[ix][iy]);
                                grin.Add(curPixelList[ix][iy].color.G * waterColorMask2d[ix][iy]);
                                blue.Add(curPixelList[ix][iy].color.B * waterColorMask2d[ix][iy]);
                            } 
                        }
                    }

                    resultBitmap.SetPixel(x, y, Color.FromArgb(repairColor(red.Sum()), repairColor(grin.Sum()), repairColor(blue.Sum())));
                    
                    red.Clear();
                    grin.Clear();
                    blue.Clear();
                    clearCurMxs(edgeMaxOnWaterCol);
                    
                }

            }
                    

            mainCanvas.Image = (Image)resultBitmap;
            return;
        }
        private delegate void payLoad(int x, int y);

        private void mainLoppCicle(String nameFunc)
        {
            clearCurMxs(edgeMaxOnWaterCol);
            foreach (var x in Enumerable.Range(0, bitmap.Width))
            {
                foreach (var y in Enumerable.Range(0, bitmap.Height))
                {
                    if (functionDB.ContainsKey(nameFunc))
                        throw new ArgumentException(string.Format("Operation {0} is invalid", nameFunc), "NameFunc");
                    functionDB[nameFunc](x,y);
                }
            }
        }

        private int repairColor(int color)
        {
            color = color / 9;
            if (color < 0)
                return 0;
            if (color > 255)
                return 255;
            return color;
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
        private void clearCurMxs(int size)
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
            red.Clear();
            grin.Clear();
            blue.Clear();

        }

        public void changeBright()
        {
            clearCurMxs(3);

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

        public void safeFile(String path)
        {
            resultBitmap.Save(path);
        }



    }
}


        //List<int> waterColorMask = new  List<int>{0, -1, 0,
        //                                                -1, 4, -1,
        //                                                0, -1, 0};