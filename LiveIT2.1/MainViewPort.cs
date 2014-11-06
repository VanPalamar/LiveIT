using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        Box _selectedBox;
        public MainViewPort( Map map, int Width, int Height )
        {
            _viewPort = new Rectangle( 0, 0, Width, Height );
            _map = map;
            R = _viewPort;
        }

        public void Draw( Graphics g, Bitmap b )
        {
            _boxList = _map.GetOverlappedBoxes(R);
            foreach( Box boxs in _boxList )
            {
                g.DrawImage(b, new Rectangle(boxs.Area.X - _offsetX, boxs.Area.Y - _offsetY, boxs.Area.Width, boxs.Area.Height));
                g.DrawRectangle(Pens.Red, new Rectangle(boxs.Area.X - _offsetX, boxs.Area.Y - _offsetY, boxs.Area.Width, boxs.Area.Height));
                g.DrawRectangle( Pens.White, _viewPort );
            }
        }

        public void DrawMouseSelector(Graphics g, Rectangle mouseRect)
        {
            for (int i = 0; i < _boxList.Count; i++ )
            {
                if (mouseRect.IntersectsWith(new Rectangle(_boxList[i].Area.X - _offsetX, _boxList[i].Area.Y - _offsetY, _boxList[i].Area.Width, _boxList[i].Area.Height)))
                {
                    g.DrawRectangle(Pens.White, new Rectangle(_boxList[i].Area.X - _offsetX, _boxList[i].Area.Y - _offsetY, _boxList[i].Area.Width, _boxList[i].Area.Height));
                    _selectedBox = _map[_boxList[i].Area.X / _map.BoxSize, _boxList[i].Area.Y / _map.BoxSize];
                    g.DrawString((_boxList[i].Area.X).ToString() + "\n" + (_boxList[i].Area.Y).ToString(), new Font("Arial", 10f), Brushes.Aqua, _boxList[i].Area.X - _offsetX, _boxList[i].Area.Y - _offsetY);
                }
            }
        }
        public void MoveLeft(int speed) 
        {
            _offsetX -= speed;
            R.X -= speed;
        }
        public void MoveRight( int speed )
        {
            _offsetX += speed;
            R.X += speed;
        }
        public void MoveDown( int speed )
        {
            _offsetY += speed;
            R.Y += speed;
        }
        public void MoveUp( int speed )
        {
            _offsetY -= speed;
            R.Y -= speed;
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

        public Box SelectedBox
        {
            get { return _selectedBox; }
        }
       
    }
}
