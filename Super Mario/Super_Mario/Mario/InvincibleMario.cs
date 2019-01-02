using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class InvincibleMario : Mario
    {
        public InvincibleMario(Vector2 newPosition,Rectangle newRectangle)
        {
            FrameHeight = 61;
            FrameWidth = 50;
            interval = 40;
            type = 4;
            Position = newPosition;
            rectangle = newRectangle;
            rectangle.Width += 15;

        }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("InvincibleMario");

        }


    }

}
