using System;
using System.Collections.Generic;
using System.Drawing;
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
        Rectangle _rectangle;
        string _texture;
         Map _map;

        

        public Box( int x, int y, Map map )
        {
            _map = map;
            _x = x;
            _y = y;
            _width = _map.boxWidth;
            _texture = "grass";
            //_rectangle = new Rectangle( x, y, width, width );
        }

        public void SetTexture( string textureName )
        {
            _texture = textureName;
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public string Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public int X
        {
            get { return _x; }
          
        }
        public int Y
        {
            get { return _y; }
           
        }
        public Rectangle[] Area
        {
            get {return new Rectangle[] ; }
        }
        
    }
}
