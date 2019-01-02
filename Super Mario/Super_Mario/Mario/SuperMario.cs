using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class SuperMario : Mario
    {
        public SuperMario(Vector2 newPosition, Rectangle newRectangle)
        {
            FrameHeight = 45;
            FrameWidth = 55;
            interval = 40;
            type = 2;
            Position = newPosition;
            rectangle = newRectangle;
            rectangle.Width += 15;
        }


        public override void Load()
        {
            texture = Content.Load<Texture2D>("SuperMario");

        }
    }

}
