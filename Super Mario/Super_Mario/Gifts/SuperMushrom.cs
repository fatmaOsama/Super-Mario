using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{


    class SuperMushrom : Gifts
    {
        public SuperMushrom(Vector2 NewPosition)
        {
            Type = 4;
            Position = NewPosition;
            points = 1000;
        }

        public override void Load()
        {
            //NA2S EL SORA!!

            texture = Content.Load<Texture2D>("superm");
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
        }

  

    }
}

