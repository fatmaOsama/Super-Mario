using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Super_Mario
{
    class UpMushrom : Gifts
    {
        public UpMushrom(Vector2 NewPosition )
        {
            Type = 3;
            Position = NewPosition;
            points = 0;
        }

        public override void Load()
        {
            //NA2S EL SORA
            texture = Content.Load<Texture2D>("UpMushrom");
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
        }

    }
}
