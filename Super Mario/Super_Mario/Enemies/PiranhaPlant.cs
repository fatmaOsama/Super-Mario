using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class PiranhaPlant : DynamicEnemies
    {
        public PiranhaPlant(Vector2 newposition) {
            Position = newposition; 
        }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("piranha sprite");
            rectangle = new Rectangle((int)Position.X,(int)Position.Y, 30, 126);
            //Position = new Vector2(50, 200);   nour 
            FrameHeight = 126;
            FrameWidth = 55;
            interval = 100f;
            timer = 0;
        }
        public override void Update(GameTime gametime)
        {
            rectangle.X = (int)Position.X-15;
            rectangle.Y = (int)Position.Y-55;
            rectangleDynamic = new Rectangle(CurrentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
            Origin = new Vector2(rectangleDynamic.Width / 2, rectangleDynamic.Height / 2);
            Position.Y += (int)Velocity.Y;
            bool direction = true;
            if (Position.Y >= 300) { Velocity.Y = -Velocity.Y; direction = true; }
            if (Position.Y <= 150) { Velocity.Y = -Velocity.Y; direction = false; }
            Position += Velocity;
            if (direction == true)
            {
                Velocity.Y += 0.05f;
                AnimateRight(gametime);
            }
            else if (direction == false)
            {
                Velocity.Y += -0.05f;
                AnimateLeft(gametime);
            }
            else
            {
                Velocity = Vector2.Zero;
            }
          //  base.Update();
        }
        public override void AnimateRight(GameTime gametime)
        {
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                CurrentFrame++;
                timer = 0;
                if (CurrentFrame > 3)
                {
                    CurrentFrame = 0;
                }
            }
        }
        public override void AnimateLeft(GameTime gametime)
        {
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                CurrentFrame++;
                timer = 0;
                if (CurrentFrame > 7 || CurrentFrame < 4)
                {
                    CurrentFrame = 4;
                }
            }
        }
    }
}
