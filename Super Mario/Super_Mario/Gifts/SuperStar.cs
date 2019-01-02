using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Super_Mario
{
    class SuperStar : Gifts
    {
        public SuperStar(Vector2 NewPosition)
        {
            Type = 2;
            Position = NewPosition;
            points = 1000;
        }
        public override void Load()
        {
            //NA2S EL SORA!!
            texture = Content.Load<Texture2D>("Super-star");
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
        }
 
    }
}
