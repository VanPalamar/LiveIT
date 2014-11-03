using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    class Park
    {
        public Park(Rectangle[] terrain, int terrainWidth)
        {
            int rectpos = 0;
            for( int x = 0; x < terrainWidth; x += 60 )
            {
                for( int y = 0; y < terrainWidth; y += 60 )
                {
                    terrain[rectpos++] = new Rectangle( x, y, 60, 60 );
                }
            }
        }


    }
}
