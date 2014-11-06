using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    public class Box
    {
        readonly Map _map;
        int _line;
        int _column;
        BoxGround _ground;

        public Box( int line, int column, Map map )
        {
            _map = map;
            _line = line;
            _column = column;
            _ground = BoxGround.Grass;
        }

        public Point Location
        {
            get { return new Point(_line*_map.BoxSize, _column*_map.BoxSize); }
        }

        public Rectangle Area
        {
            get { return new Rectangle( Location, new Size( _map.BoxSize, _map.BoxSize )); }
        }

        public BoxGround Ground
        {
            get { return _ground; }
            set { _ground = value; }
        }
        public Box Top
        {
            get { return _map[_line, _column - 1]; }
        }

        public Box Bottom
        {
            get { return _map[_line, _column + 1]; }
        }

        public Box Left
        {
            get { return _map[_line - 1, _column]; }
        }

        public Box Right
        {
            get { return _map[_line + 1, _column]; }
        }


        public int Line
        {
            get { return _line; }
          
        }
        public int Column
        {
            get { return _column; }
           
        }
        
    }
}
