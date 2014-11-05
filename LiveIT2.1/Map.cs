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
        readonly Box[] _boxes;
        readonly int _mapSize;
        // Box size in centimeter.
        readonly int _boxSize;

        public Map( int mapSize, int boxSizeInMeter )
        {
            _mapSize = mapSize;
            _boxes = new Box[mapSize * mapSize];
            _boxSize = boxSizeInMeter * 100;
            int count = 0;
            for( int i = 0; i < _mapSize; i++ )
            {
                for( int j = 0; j < _mapSize; j++ )
                {

                    _boxes[count++] = new Box( i, j, this );
                }
            }
        }


        /// <summary>
        /// Gets the box size in centimeter.
        /// </summary>
        public int BoxSize
        {
            get { return _boxSize; }
        }

        /// <summary>
        /// Gets the map size (the number of lines and number of columns).
        /// </summary>
        public int MapSize
        {
            get { return _mapSize; }
        }

        /// <summary>
        /// Gets the box at (line,column). line and column must be in [0,<see cref="MapSize"/>[
        /// otherwise null is returned.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <returns>The box or null.</returns>
        public Box this[ int line, int column ]
        {
            get
            {
                if (line < 0 || line >= _mapSize
                    || column < 0 || column > _mapSize) return null;
                return _boxes[line*_mapSize + column];
            }
        }

        public IEnumerable<Box> GetOverlappedBoxes(Rectangle r)
        {
            return new Box[0];
        }
    }
}
