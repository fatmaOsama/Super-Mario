using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Camera : Kingdom
    {
        protected Matrix Transform;
        public Matrix transform
        {
            set { Transform = value; }
            get { return Transform; }
        }

        protected Viewport view;
        public Viewport View
        {
            set { view = value; }
            get { return view; }
        }
        protected Vector2 center;
        public Vector2 Center
        {
            set { center = value; }
            get { return center; }
        }
        public Camera(Viewport NewView)
        { view = NewView; }

        public void Update(GameTime gameTime, Mario mario)
        {
            center = new Vector2((mario.rectangleDynamic.Width / 2) + mario.Position.X - 100, 0);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));



        }
    }
}
