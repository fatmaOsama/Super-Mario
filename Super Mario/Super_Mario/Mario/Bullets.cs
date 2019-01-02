using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Bullets : Dynamic
    {
        public bool IsVisible;
        public Bullets(Vector2 newposition)
        {
            IsVisible = false;
            Position.X = newposition.X;
            Position.Y = newposition.Y + 100;

        }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("fire bullet");   //noour
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
        }
    }
}
