using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveIT2._1
{
    public class Texture
    {
        Bitmap _textureGrass, _textureWater, _textureDesert, _textureForest, _textureSnow;

        public Bitmap LoadTexture(Box box)
        {
            switch( box.Ground.ToString() )
            {
                case "Grass" :
                    return _textureGrass;
                case "Water" :
                    return _textureWater;
                case "Forest" :
                    return _textureForest;
                case "Snow" :
                    return _textureSnow;
                case "Desert" :
                    return _textureDesert;
                default :
                    return _textureGrass;
            }
        }

        public Texture()
        {
            _textureGrass = new Bitmap( @"..\..\..\assets\Grass.jpg" );
            _textureWater = new Bitmap( @"..\..\..\assets\Water.jpg" );
            _textureForest = new Bitmap( @"..\..\..\assets\Dirt.jpg" );
            _textureSnow = new Bitmap( @"..\..\..\assets\Snow.jpg" );
            _textureDesert = new Bitmap( @"..\..\..\assets\Desert.jpg" );
        }

    }
}
