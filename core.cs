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
        List<List<double>> waterColorMask2d = new List<List<double>>{new List<double>{-0.5,-0.5,-0.5},
                                                                new List<double>{-0.5, 5, -0.5},
                                                                new List<double>{-0.5, -0.5, -0.5}};
        //List<List<double>> waterColorMask2d = new List<List<double>>{new List<double>{0,05, 0,05, 0,05},
        //                                                        new List<double>{0,05,0,06,0,05},
        //                                                        new List<double>{0,05,0,05,0,05}};
        List<int> curFilterMx = new  List<int>();
        const int bluerOnWaterColor = 5;
        const int edgeMaxOnWaterCol = 3;
        const int edgeMaxOnWaterColLiniearly = edgeMaxOnWaterCol * edgeMaxOnWaterCol;
        const int divisionIndex = 1;
        List<List<PxColor>> curPixelList = new List<List<PxColor>>();
        List<int> red = new List<int>(edgeMaxOnWaterCol);
        List<int> grin = new List<int>(edgeMaxOnWaterCol);
        List<int> blue = new List<int>(edgeMaxOnWaterCol);
        Dictionary<String, payLoad> functionDB = new Dictionary<string, payLoad>();
        public String curFilter = "Акварелизация";
        public bool brightHold = false;
        
        public delegate void payLoad();
        double devisor=1;
        public List <String> filtersList = new List<string>(); /* = new [] {"Акварелизация", "Размытие методом усреднения", "Размытие", 
        "увелечение резкости", "сглаживание контуров", "выделение границ разноцветных областей"};*/
        Dictionary<String, List<List<double>>> filterDict = new Dictionary<string, List<List<double>>>();
        //private delegate void payLoad(int x, int y, int brightValue);
        List<int> t = new List<int>(){1,2,3};
        public Core(PictureBox mainCanvas, ComboBox cb, payLoad resetBright) 
        { 
            this.mainCanvas = mainCanvas;
            //curFilterMx = waterColorMask; //на случай большего кода
            clearCurMxs(bluerOnWaterColor);
            
            //filterDict = new Dictionary<string,List<List<int>>>() {ne
            filterDict.Add("Акварелизация", new List<List<double>>{new List<double>{-0.5,-0.5,-0.5},
                                                                new List<double>{-0.5, 5, -0.5},
                                                                new List<double>{-0.5, -0.5, -0.5}});
            filterDict.Add("Размытие методом усреднения", new List<List<double>>());
            filterDict.Add("Размытие", new List<List<double>>{new List<double>{1,1,1},
                                                                new List<double>{1,8,1},
                                                                new List<double>{1,1,1}});
            filterDict.Add("Размытие по цвету соседей", new List<List<double>>{new List<double>{0,05, 0,05, 0,05},
                                                                new List<double>{0,05,0,06,0,05},
                                                                new List<double>{0,05,0,05,0,05}});

            filterDict.Add("Увелечение резкости", new List<List<double>>{new List<double>{0,-1,0},
                                                                new List<double>{-1,5,-1},
                                                                new List<double>{0,-1,0}});

            filterDict.Add("Увелечение резкости2", new List<List<double>>{new List<double>{-0.1,-0.1,-0.1},
                                                                new List<double>{-0.1,1.8,-0.1},
                                                                new List<double>{-0.1,-0.1,-0.1}});
            filterDict.Add("Сглаживание контуров", new List<List<double>>{new List<double>{0,1,0},
                                                                new List<double>{1,1,1},
                                                                new List<double>{0,1,0}});

            filterDict.Add("Выделение границ разноцветных областей",  new List<List<double>>{new List<double>{0,-1,0},
                                                                new List<double>{-1, 4, -1},
                                                                new List<double>{0, -1, 0}});
            filterDict.Add("Тиснение0", new List<List<double>>{new List<double>{-1,0,1},
                                                                new List<double>{-2,0,2},
                                                                new List<double>{-1, 0,1}});
            filterDict.Add("Тиснение1", new List<List<double>>{new List<double>{-1,-1,-1},
                                                                new List<double>{-1,8,-1},
                                                                new List<double>{-1, -1,-1}});
            filterDict.Add("Тиснение2", new List<List<double>>{new List<double>{0,-1,0},
                                                                new List<double>{-1,4,-1},
                                                                new List<double>{0, -1,0}});
            functionDB.Add("Акварелизация", aquaColor);
            functionDB.Add("Размытие методом усреднения", bluerOnAvergeMedian);
            functionDB.Add("Размытие", simpleFilter);
            functionDB.Add("Увелечение резкости", simpleFilter);
            functionDB.Add("Сглаживание контуров", simpleFilter);
            functionDB.Add("Выделение границ разноцветных областей", simpleFilter);
            functionDB.Add("Размытие по цвету соседей", simpleFilter);
            functionDB.Add("Увелечение резкости2", simpleFilter);
            
            functionDB.Add("Тиснение", embossed);
            foreach (var filterEntry in functionDB)
            {
                filtersList.Add(filterEntry.Key);
            }
            cb.DataSource = filtersList;
            functionDB.Add("resetBright", resetBright);
           // initFinished = true;
        
        }
        /// <summary>
        /// применение фильра в случаях простых преобразований (отличие только в матрице)
        /// </summary>
        void simpleFilter()
        {
            mainLoppCicle(filterDict[curFilter]);
            
        }
        void embossed()
        {
            mainLoppCicle(filterDict["Тиснение0"]);
            mainLoppCicle(filterDict["Тиснение1"]);
            mainLoppCicle(filterDict["Тиснение2"]);
        }

        public void applyFilter()
        {
            bitmap = resultBitmap;
            functionDB[curFilter]();
            resetBrightConrol();
            
            return;
        }

        void aquaColor()
        {
            bluerOnAvergeMedian();
            mainLoppCicle(filterDict[curFilter]);
        }

        private void waterColorFilter()
        {
            bluerOnAvergeMedian();
            waterColor();
        }
        /// <summary>
        /// первый ли раз запущено приложение?
        /// </summary>
        public bool isFast()
        {
            if (bitmap == null)
                return true;
            return false;
        }

        /// <summary>
        /// сглаживание методом серединного усреденения
        /// </summary>
        private void bluerOnAvergeMedian()
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
            bitmap = resultBitmap;
            mainCanvas.Image = (Image)resultBitmap;

        }

        /// <summary>
        /// применение матрицы фильтра
        /// </summary>
        private void waterColor()
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
                                 red.Add(Convert.ToInt32(curPixelList[ix][iy].color.R * waterColorMask2d[ix][iy]));
                                grin.Add(Convert.ToInt32(curPixelList[ix][iy].color.G * waterColorMask2d[ix][iy]));
                                blue.Add(Convert.ToInt32(curPixelList[ix][iy].color.B * waterColorMask2d[ix][iy]));
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

            bitmap = resultBitmap;
            mainCanvas.Image = (Image)resultBitmap;
            return;
        }
        

        private void mainLoppCicle(List<List<double>> filterMask, int sizeMx=edgeMaxOnWaterCol)
        {
            clearCurMxs(sizeMx);


            foreach (var x in Enumerable.Range(0, bitmap.Width))
            {
                foreach (var y in Enumerable.Range(0, bitmap.Height))
                {
                    getElems(x, y, sizeMx);
                    foreach (var ix in Enumerable.Range(0, sizeMx))
                    {
                        foreach (var iy in Enumerable.Range(0, sizeMx))
                        {
                            if (curPixelList[ix][iy].isExist)
                            {
                                red.Add(Convert.ToInt32(curPixelList[ix][iy].color.R *  filterMask[ix][iy]));
                                grin.Add(Convert.ToInt32(curPixelList[ix][iy].color.G * filterMask[ix][iy]));
                                blue.Add(Convert.ToInt32(curPixelList[ix][iy].color.B * filterMask[ix][iy]));
                            }
                        }
                    }
                    devisor = findSumMatrixElem(filterMask);
                    resultBitmap.SetPixel(x, y, Color.FromArgb(repairColor(red.Sum()), repairColor(grin.Sum()), repairColor(blue.Sum())));

                    red.Clear();
                    grin.Clear();
                    blue.Clear();
                    clearCurMxs(sizeMx);

                }

            }

            bitmap = resultBitmap;
            mainCanvas.Image = (Image)resultBitmap;
            return;
        }
        double findSumMatrixElem(List<List<double>> filterMask)
        {
            double sum=0;
            foreach (var row in filterMask)
            {
                foreach (var cell in row)
                {
                    sum += cell;
                }

            }
            return sum;

        }


        private int repairColor(int color)
        {
            if (devisor != 0)
                color = Convert.ToInt32(color / devisor);
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
        private int getElems(int x, int y, int count, int offStart=-1)
        {
            
            
            int i, j,z;
            i = j  = z =0;
            foreach (var ix in Enumerable.Range(x + offStart, count))
            {
                foreach (var iy in Enumerable.Range(y + offStart, count))
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
                    z++;
                }
                j = 0;
                i++;
            }
            return z;
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

        public void changeBright(int brightValue)
        {
            if (brightHold)
                return;
            resultBitmap = new Bitmap(bitmap.Width, bitmap.Height); 
            clearCurMxs(1);
            brightValue -= 128;
            int red;
            int grin;
            int blue;
            //clearCurMxs(edgeMaxOnWaterCol);
            foreach (var x in Enumerable.Range(0, bitmap.Width))
            {
                foreach (var y in Enumerable.Range(0, bitmap.Height))
                {
                    getElems(x, y, 1, 0);
                    red = curPixelList[0][0].color.R + brightValue;
                    grin = curPixelList[0][0].color.G + brightValue;
                    blue = curPixelList[0][0].color.B + brightValue;
                    resultBitmap.SetPixel(x, y, Color.FromArgb(repairColor(red), repairColor(grin), repairColor(blue)));
                }
            }

            mainCanvas.Image = (Image)resultBitmap;
            
        }
        void resetBrightConrol()
        {
            brightHold = true;
            functionDB["resetBright"]();
            brightHold = false;
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
            resultBitmap = bitmap;
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