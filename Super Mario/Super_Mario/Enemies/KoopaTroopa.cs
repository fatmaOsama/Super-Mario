using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class KoopaTroopa : DynamicEnemies
    {
        private float initialb;
        private float initiale;

        public KoopaTroopa(Vector2 newposition) {
            Position = newposition;
            initialb = Position.X - 80;
            initiale = Position.X + 80;

        }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("Koopa troopa");
            rectangle = new Rectangle((int)Position.X,(int)Position.Y, 31, 71);
           // Position = new Vector2(150, 200);   nour
            FrameHeight = 70;
            FrameWidth = 31 ;
            interval = 100f;
            timer = 0;
        }
        public override void Update(GameTime gametime)
        {
            rectangle.X = (int)Position.X + (int)Velocity.X;
            rectangle.Y = (int)Position.Y - 31;
            rectangleDynamic = new Rectangle(CurrentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
            Origin = new Vector2(rectangleDynamic.Width / 2, rectangleDynamic.Height / 2);
            Position += Velocity;
            bool direction = true;
            if (Position.X >= initiale) { direction = false; }
            else if (Position.X <= initialb) { direction = true; }
            if (direction == true)
            {
                AnimateRight(gametime);
                Velocity.X += 0.055f;
            }
            else if (direction == false)
            {
                AnimateLeft(gametime);
                Velocity.X += -0.055f;
            }
            else
            {
                Velocity = Vector2.Zero;
            }
            //base.Update();
        }
        public override void AnimateRight(GameTime gametime)
        {
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                CurrentFrame++;
                timer = 0;
                if (CurrentFrame < 4 || CurrentFrame > 7)
                {
                    CurrentFrame = 4;
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
                if (CurrentFrame > 3)
                {
                    CurrentFrame = 0;
                }
            }
        }

    }
}
