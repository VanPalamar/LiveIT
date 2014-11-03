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
        Bitmap _creature;
        Bitmap _textureGrass;
        Graphics g;
        Rectangle _area;
        Box[,] _boxes;

        bool right;
        bool left;
        bool up;
        bool down;

        Timer t;
        Bitmap _background;
        Graphics _screenGraphic;
        Map _map;

        Rectangle[] rects;
        Rectangle[] terrainRects;

        Size _selectionCursorWidth;
        Rectangle _screen;

        private void Form1_Load( object sender, EventArgs e )
        {
            this.DoubleBuffered = true;

            _background = new Bitmap( this.Width, this.Height );
            _area = new Rectangle( this.Width / 2, this.Height / 2, 100, 100 );
            _map = new Map( 15000 );
            _textureGrass = new Bitmap(@"..\..\..\assets\Grass.jpg");

            _screen = new Rectangle(0, 0, this.Width, this.Height);

            _boxes = _map.Boxes;
            terrainRects = new Rectangle[1000];
            _map.Createmap( 200 );
            g = this.CreateGraphics();
            _screenGraphic = Graphics.FromImage( _background );

            _selectionCursorWidth = new Size(50, 50);
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
                if (_selectionCursorWidth.Height <= 1000)
                {
                    _selectionCursorWidth.Height += 200;
                    _selectionCursorWidth.Width += 200;
                }

            }
            else
            {
                if (_selectionCursorWidth.Height >= 60)
                {
                    _selectionCursorWidth.Height -= 200;
                    _selectionCursorWidth.Width -= 200;
                }
            }
        }


        private void t_Tick( object sender, EventArgs e )
        {
            Rectangle _rMouse = new Rectangle(new Point(Cursor.Position.X, Cursor.Position.Y), _selectionCursorWidth);
            if( up ) { MoveRectangle( Direction.Up ); }
            if( left ) { MoveRectangle( Direction.Left ); }
            if( down ) { MoveRectangle( Direction.Down ); }
            if( right ) { MoveRectangle( Direction.Right ); }
            g.DrawImage( Draw(), new Point( 0, 0 ) );
            

        }

        public enum Direction { Up, Down, Right, Left };
        public void MoveRectangle( Direction d )
        {
            int _speed = 30;
            for( int i = 0; i <  _map.Grid.Length; i++ )
            {
                if (d == Direction.Down) { _map.Grid[i].Y -= _speed; }
                if (d == Direction.Up) { _map.Grid[i].Y += _speed; }
                if (d == Direction.Right) { _map.Grid[i].X -= _speed; }
                if (d == Direction.Left) { _map.Grid[i].X += _speed; }
            }
        }
        public Bitmap Draw()
        {

            _screenGraphic.Clear( Color.FromArgb( 255, Color.Blue ) );
            for( int i = 0; i < _map.Grid.Length; i++ )
            {
                    _screenGraphic.DrawImage(_textureGrass, _map.Grid[i]);
                    //_screenGraphic.DrawString(_map.Grid[i].X.ToString() + "\n" + _map.Grid[i].Y.ToString(), new Font("Arial", 10f), Brushes.Black, new Point(_map.Grid[i].X, _map.Grid[i].Y));
                
            }   
            return _background;
        }

        private void Form1_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Z ) { up = true; }
            if( e.KeyCode == Keys.Q ) { left = true; }
            if( e.KeyCode == Keys.S ) { down = true; }
            if( e.KeyCode == Keys.D ) { right = true; }
        }

        private void Form1_KeyUp( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Z ) { up = false; }
            if( e.KeyCode == Keys.Q ) { left = false; }
            if( e.KeyCode == Keys.S ) { down = false; }
            if( e.KeyCode == Keys.D ) { right = false; }
        }

    }
}
