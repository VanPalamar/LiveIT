using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    public class Texture
    {

        public Bitmap SetTexture(Box box)
        {
            return new Bitmap(@"..\..\..\assets\" + box.Ground.ToString()+".jpg");
        }
    }
}
