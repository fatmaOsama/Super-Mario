using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class FireMario : Mario
    {
        public FireMario(Vector2 newPosition, Rectangle newRectangle)
        {
            FrameHeight = 59;
            FrameWidth = 46;
            interval = 40;
            type = 3;
            Position = newPosition;
            rectangle = newRectangle;
            rectangle.Width += 15;
            
        }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("FireMario");

        }
    }
}
