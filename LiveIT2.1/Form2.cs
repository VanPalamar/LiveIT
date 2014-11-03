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
        Bitmap creature;
        Bitmap textureGrass;
        Graphics g;
        Rectangle area;
        bool right;
        bool left;
        bool up;
        bool down;
        int collectedNumber = 0;
        Timer t;
        Bitmap background;
        Graphics scG;
        Map _map;

        Rectangle[] rects;
        Rectangle[] terrainRects;
         

        private void Form1_Load( object sender, EventArgs e )
        {
            creature = new Bitmap( @"..\..\..\assets\ico.png" );
            creature.MakeTransparent( Color.White );
            background = new Bitmap( this.Width, this.Height );
            area = new Rectangle( this.Width / 2, this.Height / 2, 100, 100 );
            _map = new Map( 15000 );
            textureGrass = new Bitmap(@"..\..\..\assets\Grass.jpg");

            Box[,]_boxes = _map.Boxes;
            rects = new Rectangle[10];
            terrainRects = new Rectangle[1000];
            //makerect();
            _map.Createmap( 200 );
            //MakeTerrain();

            g = this.CreateGraphics();
            scG = Graphics.FromImage( background );

            t = new Timer();
            t.Interval = 10;
            t.Tick += new EventHandler( t_Tick );
            t.Start();
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
            for( int i = 0; i <  _map.Grid.Length; i++ )
            {
                if( d == Direction.Down ) { _map.Grid[i].Y -= 15; }
                if( d == Direction.Up ) { _map.Grid[i].Y += 15; }
                if( d == Direction.Right ) { _map.Grid[i].X -= 15; }
                if( d == Direction.Left ) { _map.Grid[i].X += 15; }
            }
        }
        public Bitmap Draw()
        {

            scG.Clear( Color.FromArgb( 255, Color.Blue ) );
            for( int i = 0; i < terrainRects.Length; i++ )
            {
                scG.DrawImage( textureGrass, _map.Grid[i] );
            }
            scG.FillRectangles( Brushes.Gold, rects );
          
            return background;
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
