using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    class Box
    {

        int _x;
        int _y;
        int _width;

        string _texture;

        public Box( int x, int y, int width )
        {
            _x = x;
            _y = y;
            _width = width;
            _texture = "grass";
        }

        public void SetTexture( string textureName )
        {

            _texture = textureName;
        }

        public string Texture
        {
            get { return _texture; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
    }
}
