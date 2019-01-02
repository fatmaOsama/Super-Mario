using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Static 
    {
        
        protected Texture2D Texture;
        public Texture2D texture
        {
            set { Texture = value; }
            get { return Texture; }
        }

        public Rectangle rectangle;
      
        public Vector2 Position;
        //public Vector2 Position
        //{
        //    set { position = value; }
        //    get { return position; }
        //}
        public Static( ){}

        private static ContentManager content;
        public static ContentManager Content
        {
            set { content = value; }
            get { return content; }

        } 

        public virtual void Load(){}
        //public abstract void Update();
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }
}
