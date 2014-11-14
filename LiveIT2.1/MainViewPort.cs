using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveIT2._1
{
    public class MainViewPort
    {
        const int _minimalWidthInCentimeter = 200;
        List<Box> _boxList;
        Rectangle _viewPort, _screen;
        Map _map;
        int _offsetX = 0;
        int _offsetY = 0;
        List<Box> _selectedBoxes;
        Texture _texture;
        public MainViewPort( Map map)
        {
            _map = map;
            _viewPort = new Rectangle( 0, 0, 800, 800 );           
            _texture = new Texture();
            _selectedBoxes = new List<Box>();
            _screen = new Rectangle( 0, 0, 600,600 );
        }

        public void Draw( Graphics g )
        {
            _boxList = _map.GetOverlappedBoxes(_viewPort);
            foreach( Box boxs in _boxList )
            {
                boxs.Draw( g, _screen, _texture, _viewPort );
                g.DrawRectangle(Pens.Red, new Rectangle(boxs.Area.X, boxs.Area.Y, boxs.Area.Width, boxs.Area.Height));
                g.DrawRectangle( Pens.White, _viewPort );
            }
        }


        public double ZoomFactor
        {
            get { return 1.0 - ((double)_viewPort.Width / (double)_map.MapSize); }
            set
            {
                if( value < 0.0 || value > 1.0 ) throw new ArgumentException();
                int newWidth = (int)Math.Round( _map.MapSize * (value - 1) );
                Debug.Assert( newWidth <= _map.MapSize );
                if( newWidth < _minimalWidthInCentimeter ) newWidth = _minimalWidthInCentimeter;
                int deltaW = newWidth - _viewPort.Width;
                if( deltaW != 0 )
                {
                    int newHeight = (int)Math.Round( (double)_viewPort.Height * (double)newWidth / (double)_viewPort.Width );
                    int deltaH = newHeight - _viewPort.Height;
                    _viewPort.X -= deltaW / 2;
                    _viewPort.Y -= deltaH / 2;
                    _viewPort.Height = newHeight;
                    _viewPort.Width = newWidth;
                }
            }
        }

        public void Zoom( int meters )
        {
            _viewPort.Width += meters;
            _viewPort.Height += meters;
            if( _viewPort.Width < _minimalWidthInCentimeter && _viewPort.Height < _minimalWidthInCentimeter )
            {
                _viewPort.Width = _minimalWidthInCentimeter;
                _viewPort.Height = _minimalWidthInCentimeter;
            }

            if( _viewPort.Width > _map.MapSize )
            {
                _viewPort.Height = _map.MapSize;
                _viewPort.Width = _map.MapSize;
            }
            
            
            
        }

        public void Offset( Point delta )
        {
            _viewPort.Offset( delta );
            if( _viewPort.X < 0 ) _viewPort.X = 0;
            if( _viewPort.Y < 0 ) _viewPort.Y = 0;
            if( _viewPort.Right > _map.MapSize ) _viewPort.X = _map.MapSize - _viewPort.Width;
            if( _viewPort.Bottom > _map.MapSize ) _viewPort.Y = _map.MapSize - _viewPort.Height;
        }

        public void DrawMouseSelector(Graphics g, Rectangle mouseRect)
        {
            _selectedBoxes.Clear();
            for (int i = 0; i < _boxList.Count; i++ )
            {
                
                if (mouseRect.IntersectsWith(new Rectangle(_boxList[i].Area.X - _offsetX, _boxList[i].Area.Y - _offsetY, _boxList[i].Area.Width, _boxList[i].Area.Height)))
                {
                    _selectedBoxes.Add( _map[_boxList[i].Area.X / _map.BoxSize, _boxList[i].Area.Y / _map.BoxSize] );
                    g.DrawRectangle(Pens.White, new Rectangle(_boxList[i].Area.X - _offsetX, _boxList[i].Area.Y - _offsetY, _boxList[i].Area.Width, _boxList[i].Area.Height));
                    g.DrawString((_boxList[i].Area.X).ToString() + "\n" + (_boxList[i].Area.Y).ToString(), new Font("Arial", 10f), Brushes.Aqua, _boxList[i].Area.X - _offsetX, _boxList[i].Area.Y - _offsetY);
                }
            }
        }


        public void MoveX(int centimeters) 
        {
            Offset( new Point( centimeters, 0 ) );
        }
        public void MoveY( int centimeters )
        {
            Offset( new Point( 0, centimeters ) );
        }


        public List<Box> SelectedBox
        {
            get { return _selectedBoxes; }
        }
       
    }
}
