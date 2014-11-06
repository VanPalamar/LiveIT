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
        int _offsetX = 0;
        int _offsetY = 0;
        Rectangle R;
        public MainViewPort( Map map, int Width, int Height )
        {
            _viewPort = new Rectangle( 0, 0, Width, Height );
            _map = map;
            R = _viewPort;
        }

        public void Draw( Graphics g, Bitmap b )
        {
            _boxList = _map.GetOverlappedBoxes( new Rectangle(_viewPort.X + _offsetX, _viewPort.Y + _offsetY, _viewPort.Width, _viewPort.Height ));
            foreach( Box boxs in _boxList )
            {
                g.DrawImage(b, new Rectangle(boxs.Area.X - _offsetX, boxs.Area.Y - _offsetY, boxs.Area.Width, boxs.Area.Height));
                g.DrawRectangle(Pens.Red, new Rectangle(boxs.Area.X - _offsetX, boxs.Area.Y - _offsetY, boxs.Area.Width, boxs.Area.Height));
                //g.DrawString( boxs.Area.X.ToString() + "\n" + boxs.Area.Y.ToString(), new Font( "Arial", 10f ), Brushes.Black, boxs.Area );
                g.DrawRectangle( Pens.White, _viewPort );
            }
        }

        public void MoveLeft(int speed) 
        {
            //_viewPort.X -= speed;
            _offsetX -= speed;
        }
        public void MoveRight( int speed )
        {
            //_viewPort.X += speed;
            _offsetX += speed;
        }
        public void MoveDown( int speed )
        {
            //_viewPort.Y += speed;
            _offsetY += speed;
        }
        public void MoveUp( int speed )
        {
            //_viewPort.Y -= speed;
            _offsetY -= speed;
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
