using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveIT2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Graphics _screenGraphic;

        bool right;
        bool left;
        bool up;
        bool down;

        BoxGround _selectedTexture;

        Timer t;

        Bitmap _background;
        Map _map;
  
        Size _selectionCursorWidth;
        Rectangle _mouseRect;

        MainViewPort _viewPort;

        int _boxWidth;

        private void Form1_Load( object sender, EventArgs e )
        {
            this.DoubleBuffered = true;
            _selectedTexture = BoxGround.Grass;
            _background = new Bitmap( this.Width, this.Height );
            _map = new Map( 50, 2 );
            
            _boxWidth = _map.BoxSize;

             _viewPort = new MainViewPort( _map);
            _mouseRect = new Rectangle( 0, 0, 100, 100 );

            g = this.CreateGraphics();
            _screenGraphic = Graphics.FromImage( _background );

            _selectionCursorWidth = new Size(_boxWidth, _boxWidth);
            this.MouseWheel += new MouseEventHandler(T_mouseWheel);
            t = new Timer();
            
            t.Interval = 10;
            t.Tick += new EventHandler( t_Tick );
            t.Start();
        }

        private void T_mouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 1)
            {
                if( _selectionCursorWidth.Height <= _boxWidth * 5)
                {
                    _selectionCursorWidth.Height += _boxWidth;
                    _selectionCursorWidth.Width += _boxWidth;
                }

            }
            else
            {
                if( _selectionCursorWidth.Height >= _boxWidth / 2)
                {
                    _selectionCursorWidth.Height -= _boxWidth;
                    _selectionCursorWidth.Width -= _boxWidth;
                }
            }
        }


        private void t_Tick( object sender, EventArgs e )
        {
            if( up ) { MoveRectangle( Direction.Up ); }
            if( left ) { MoveRectangle( Direction.Left ); }
            if( down ) { MoveRectangle( Direction.Down ); }
            if( right ) { MoveRectangle( Direction.Right ); }
            
            g.DrawImage( Draw(), new Point( 0, 0 ) );
                      
        }

        public enum Direction { Up, Down, Right, Left };
        public void MoveRectangle( Direction d )
        {
            int speed = 45;
            if( d == Direction.Down ) { _viewPort.MoveY(speed); }
            if (d == Direction.Up) { _viewPort.MoveY(-speed); }
            if (d == Direction.Right) { _viewPort.MoveX(speed); }
            if (d == Direction.Left) { _viewPort.MoveX(-speed); }
        }
        public Bitmap Draw()
        {
            Rectangle _rMouse = new Rectangle( new Point( Cursor.Position.X, Cursor.Position.Y ), _selectionCursorWidth );
            _screenGraphic.Clear( Color.FromArgb( 255, Color.Black ) );

            _viewPort.Draw( _screenGraphic );
            _viewPort.DrawMouseSelector(_screenGraphic, _rMouse);
            return _background;
        }

        private void Form1_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Z ) { up = true; }
            if( e.KeyCode == Keys.Q ) { left = true; }
            if( e.KeyCode == Keys.S ) { down = true; }
            if( e.KeyCode == Keys.D ) { right = true; }
            if( e.KeyCode == Keys.Add ) { _viewPort.ZoomFactor = 0; }
        }

        private void Form1_KeyUp( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Z ) { up = false; }
            if( e.KeyCode == Keys.Q ) { left = false; }
            if( e.KeyCode == Keys.S ) { down = false; }
            if( e.KeyCode == Keys.D ) { right = false; }
        }

        private void Form1_MouseClick( object sender, MouseEventArgs e )
        {
            foreach( Box box in _viewPort.SelectedBox )
            {
                box.Ground = _selectedTexture;
            }
        }

        private void _waterButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = BoxGround.Water;
        }

        private void _dirtButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = BoxGround.Forest;
        }

        private void _snowButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = BoxGround.Snow;
        }

        private void _desertButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = BoxGround.Desert;
        }

        private void _grassButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = BoxGround.Grass;
        }

        private void _buttonZoomPlus_Click( object sender, EventArgs e )
        {

        }

        private void _buttonZoomMinus_Click( object sender, EventArgs e )
        {

        }

    }
}
