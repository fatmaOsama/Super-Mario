using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Mario : Dynamic
    {
       
        protected int Type;

        public int type
        {
            set { Type = value; }
            get { return Type; }
        }
        protected bool jump, Fall, yalaTani;
        public bool Jump
        {
            set { jump = value; }
            get { return jump; }
        }
        public bool fall
        {
            set { Fall = value; }
            get { return Fall; }
        }
        public bool YalaTani
        {
            set { yalaTani = value; }
            get { return yalaTani; }
        }

        public float jumpHeight;
        public float JumpHeight
        {
            set { jumpHeight = value; }
            get { return jumpHeight; }
        }

        public Mario()
        {

            Jump = false;
            fall = false;
            YalaTani = true;
            JumpHeight = -14;     //-max
            Position = new Vector2(50, 440);
            FrameHeight = 50;
            FrameWidth = 55;
            interval = 50;
            type = 1;

        }

        public override void Load()
        {
            texture = Content.Load<Texture2D>("SmallMario");
            rectangle = new Rectangle(15, 30, 30, 70);
           

        }

        public override void Update(GameTime gameTime)
        {

            rectangleDynamic = new Rectangle(CurrentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
            Origin = new Vector2(rectangleDynamic.Width / 2, rectangleDynamic.Height / 2);
            Position += Velocity;
            rectangle.X = (int)Position.X-25;
            rectangle.Y = (int)Position.Y-40;
            


        }

        public void AnimateLeft(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                CurrentFrame++;
                timer = 0;
                if (CurrentFrame > 2)
                {
                    CurrentFrame = 0;
                }
            }

        }

        public void AnimateRight(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                CurrentFrame++;
                timer = 0;
                if (CurrentFrame < 3 || CurrentFrame > 5)
                {
                    CurrentFrame = 3;
                }
            }

        }



    }

}
