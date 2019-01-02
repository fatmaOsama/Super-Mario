using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
     class Dynamic : Static
    {

         public Vector2 Velocity;
      
        protected Rectangle RectangleDynamic;
        public Rectangle rectangleDynamic
        {
            set { RectangleDynamic = value; }
            get { return RectangleDynamic; }
        }
        protected Vector2 Origin;
        protected int CurrentFrame;
        protected int FrameHeight;
        protected int FrameWidth;
        protected float timer;
        protected float interval;

        public Dynamic()
        { }

        public virtual void Update(GameTime gametime) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, rectangleDynamic, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
          // spriteBatch.Draw(texture, rectangle, Color.Blue);
           // base.Draw(spriteBatch);
        }

    }
}
