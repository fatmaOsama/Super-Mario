using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class SpecialBricks : Bricks
    {
        public SpecialBricks(Vector2 NewPosition)
        {
            Position = NewPosition;
        }

        public override void Load()
        {
            texture = Content.Load<Texture2D>("special");
            rectangle = new Rectangle((int)Position.X,(int)Position.Y, 40, 40);
        }
    }
}
