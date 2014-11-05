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
        readonly Box[] _boxes;


         readonly int _meter;
         readonly int _sizeInMeter;
         readonly int _column;
         int _boxWidth;
        public int boxWidth
        {
            get { return _boxWidth; }
        }
        public Map( int size, int meter, int boxWidth )
        {
            
            _boxes = new Box[size*size];
            _sizeInMeter = meter;
            _column = size;
            _boxWidth = boxWidth;
        }

        

        public Box[] Boxes
        {
            get { return _boxes; }
        }

       
        public int Size
        {
            get { return _sizeInMeter; }
        }
        public void Createmap(  )
        {
            int _count = 0;

            for( int i = 0; i < _column; i++ )
            {
                for( int j = 0; j < _column; j++ )
                {

                    _boxes[_count++] = new Box( i, j, this);
                }

            }
        }
    }
}
