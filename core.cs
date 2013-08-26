using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace watercolor
{   
    class core
    {
        public Bitmap bitmap;
        public Graphics g;
        Image img;
        PictureBox mainCanvas;
        core(PictureBox mainCanvas) 
        { 
            this.mainCanvas = mainCanvas;
        
        }
        public void opemFile(String path)
        {
               if (bitmap != null)
               {
                  bitmap.Dispose();
               }
            img = Image.FromFile(path);
            bitmap = new Bitmap(mainCanvas.Height, mainCanvas.Width);
            g = Graphics.FromImage(img);
            g.
        }

    }
}
