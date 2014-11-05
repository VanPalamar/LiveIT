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

        Box[] _boxes;

        bool right;
        bool left;
        bool up;
        bool down;
        bool _changeTexture = false;

        string _selectedTexture;

        Timer t;

        Bitmap _background;
        Bitmap _textureGrass, _textureWater, _textureDirt, _textureSnow, _textureDesert;

        Map _map;
  
        Size _selectionCursorWidth;
        Rectangle _screen;
        Rectangle _mouseRect;

        Dictionary<string, Bitmap> _texturesDictionnary;

        int _boxWidth;

        private void Form1_Load( object sender, EventArgs e )
        {
            this.DoubleBuffered = true;
            _selectedTexture = "grass";
            _background = new Bitmap( this.Width, this.Height );
            _map = new Map( 1500, 100 );
            Rectangle r = new Rectangle( 0, 0, 250000, 250000 );
            List<Box> _boxList = (List<Box>)_map.GetOverlappedBoxes( r );
            _textureGrass = new Bitmap(@"..\..\..\assets\Grass.jpg");
            _textureWater = new Bitmap( @"..\..\..\assets\Water.jpg" );
            _textureDirt = new Bitmap( @"..\..\..\assets\Dirt.jpg" );
            _textureSnow = new Bitmap( @"..\..\..\assets\Snow.jpg" );
            _textureDesert = new Bitmap( @"..\..\..\assets\Desert.jpg" );

            _boxWidth = 100;

            _screen = new Rectangle( 0, 0, this.Width, this.Height );
            _mouseRect = new Rectangle( 0, 0, 100, 100 );

            g = this.CreateGraphics();
            _screenGraphic = Graphics.FromImage( _background );

            _selectionCursorWidth = new Size(50, 50);
            this.MouseWheel += new MouseEventHandler(T_mouseWheel);

            _texturesDictionnary = new Dictionary<string, Bitmap>()
	            {
	                {"grass", _textureGrass},
	                {"water", _textureWater},
	                {"dirt", _textureDirt},
	                {"snow", _textureSnow},
                    {"desert", _textureDesert}         
	            };


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
            //if( up ) { MoveRectangle( Direction.Up ); }
            //if( left ) { MoveRectangle( Direction.Left ); }
            //if( down ) { MoveRectangle( Direction.Down ); }
            //if( right ) { MoveRectangle( Direction.Right ); }
            
            g.DrawImage( Draw(), new Point( 0, 0 ) );
                      
        }

        public enum Direction { Up, Down, Right, Left };
        //public void MoveRectangle( Direction d )
        //{
        //    int _speed = 40;
        //    for( int i = 0; i < _boxes.Length; i++ )
        //    {
        //        if( d == Direction.Down ) { _boxes[i].Y -= _speed;  }
        //        if( d == Direction.Up ) { _boxes[i].Y += _speed;  }
        //        if( d == Direction.Right ) { _boxes[i].X -= _speed;  }
        //        if( d == Direction.Left ) { _boxes[i].X += _speed; }
        //    }
        //}
        public Bitmap Draw()
        {
            Rectangle _rMouse = new Rectangle( new Point( Cursor.Position.X, Cursor.Position.Y ), _selectionCursorWidth );
            _screenGraphic.Clear( Color.FromArgb( 255, Color.Black ) );
            
            //for( int i = 0; i < _boxes.Length; i++ )
            //{
                
            //    if( _boxes[i].Rectangle.IntersectsWith( _screen ) )
            //    {
            //        if( _boxes[i].Rectangle.IntersectsWith( _rMouse ) && _boxes[i].Rectangle.IntersectsWith( _screen ) )
            //        {
            //            _screenGraphic.DrawRectangle( new Pen( Brushes.Red, 10f ), new Rectangle(new Point(_boxes[i].Rectangle.X,_boxes[i].Rectangle.Y ), new Size(_boxes[i].Rectangle.Width,_boxes[i].Rectangle.Width)  ));
                        
            //            if( _changeTexture )
            //            {
            //                _screenGraphic.FillRectangle( Brushes.DimGray, _boxes[i].Rectangle );
            //                _boxes[i].Texture = _selectedTexture;
            //            }
            //        }
                    
            //        _screenGraphic.DrawImage( _texturesDaictionnary[_boxes[i].Texture], _boxes[i].Rectangle );
            //    }
                                    
            //}

            _changeTexture = false;
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

        private void Form1_MouseClick( object sender, MouseEventArgs e )
        {
            _changeTexture = true;
        }

        private void _waterButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = "water";
        }

        private void _dirtButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = "dirt";
        }

        private void _snowButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = "snow";
        }

        private void _desertButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = "desert";
        }

        private void _grassButton_Click( object sender, EventArgs e )
        {
            _selectedTexture = "grass";
        }

    }
}
