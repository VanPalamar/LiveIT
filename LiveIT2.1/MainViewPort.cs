using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    public class MainViewPort
    {
        List<Box> _boxList;
        Rectangle _viewPort;
        Map _map;
        public MainViewPort( Map map, int Height, int Width )
        {
            _viewPort = new Rectangle( 0, 0, Height, Width );
            _map = map;
        }

        public void Draw( Graphics g, Bitmap b )
        {
            _boxList = _map.GetOverlappedBoxes( _viewPort );
            foreach( Box boxs in _boxList )
            {
                g.DrawImage( b, boxs.Area );
                g.DrawString( boxs.Area.X.ToString() + "\n" + boxs.Area.Y.ToString(), new Font( "Arial", 10f ), Brushes.Black, boxs.Area );
                g.DrawRectangle( Pens.White, _viewPort );
            }
        }

        public void MoveLeft(int speed)
        {
            _viewPort.X += speed;
        }
        public void MoveRight( int speed )
        {
            _viewPort.X -= speed;
        }
        public void MoveDown( int speed )
        {
            _viewPort.Y -= speed;
        }
        public void MoveUp( int speed )
        {
            _viewPort.Y += speed;
        }

        public void ZoomIn( int zoomSize )
        {
            _viewPort.Width += zoomSize;
            _viewPort.Height += zoomSize;
        }

        public void ZoomOut( int zoomSize )
        {
            _viewPort.Width -= zoomSize;
            _viewPort.Height -= zoomSize;
        }
       
    }
}
