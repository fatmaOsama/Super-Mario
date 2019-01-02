using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Super_Mario
{
    class FireFlower : Gifts
    {
        public FireFlower(Vector2 NewPosition)
        {
            Type = 1;
            points = 1000;
            Position = NewPosition;
        }
        public override void Load()
        {

            texture = Content.Load<Texture2D>("FireFlower");
            rectangle = new Rectangle((int)Position.X,(int)Position.Y, 40, 40);
        }
      
    }
}
