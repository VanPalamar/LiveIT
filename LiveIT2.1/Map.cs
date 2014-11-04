using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    class Map
    {

        Rectangle[] _map;
        Box[,] _boxes;
        Box[] _boxArray;

        

        int _size;
        int _boxwidth;

        public Map( int size )
        {
            _map = new Rectangle[size];
            _boxArray = new Box[size];
            _boxes = new Box[size, size];
            _size = size;
        }

        public Rectangle[] Grid
        {
            get { return _map; }
        }

        public Box[] Boxes
        {
            get { return _boxArray; }
        }

        public int BoxWidth
        {
            get { return _boxwidth; }
            set { _boxwidth = value; }
        }
        public int Size
        {
            get { return _size; }
        }
        public void Createmap( int boxWidth )
        {
            int _pos = 0;
            _boxwidth = boxWidth;
            for( int i = 0; i < _size * boxWidth; i += boxWidth )
            {
                for( int j = 0; j < _size ; j += boxWidth )
                {
                    if( _pos != _size )
                    {
                        //_map[_pos++] = new Rectangle( i, j, boxWidth, boxWidth );
                        //_boxes[i, j] = new Box( i, j, boxWidth );
                   
                        _boxArray[_pos++] = new Box( i, j, boxWidth );
                        
                    }

                }

            }
        }

        public void DrawMap( Graphics graphic )
        {
            graphic.DrawRectangles( Pens.Red, _map );
        }
    }
}
