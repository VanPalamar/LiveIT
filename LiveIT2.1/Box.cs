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
<<<<<<< HEAD
        Rectangle _source;
=======
         Rectangle _source;
>>>>>>> 81a3faee6c47a2a4a52bb7d6d8f73c4aa435cb07

        public Box( int line, int column, Map map )
        {
            _map = map;
            _line = line;
            _column = column;
            _ground = BoxGround.Forest;
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

        public Rectangle Source
        {
            get { return _source; }
            set { _source = value; }
<<<<<<< HEAD
=======
            
>>>>>>> 81a3faee6c47a2a4a52bb7d6d8f73c4aa435cb07
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="target">Rectangle in pixel in the Graphics.</param>
        /// <param name="textures">Texture object to apply the texture on the box </param>
        internal void Draw( Graphics g, Rectangle target, Texture textures )
        {
<<<<<<< HEAD
            g.DrawImage(textures.LoadTexture(this), new Rectangle( this.Area.X, this.Area.Y, this.Source.Width, this.Source.Height ) );
=======

            Graphics _gBox = g;
            Rectangle _source = source;
            Rectangle _target = target;

          
>>>>>>> 81a3faee6c47a2a4a52bb7d6d8f73c4aa435cb07
        }
        
    }
}
