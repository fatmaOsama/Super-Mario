using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Coins : Gifts
    {
        public int size;
        public static int CoinsNumber;
        public Coins(Vector2 NewPosition)
        {
            Position = NewPosition;
            CoinsNumber = 0;
            points = 200;
            size=20;
        }

      

        public override void Load() {
            texture = Content.Load<Texture2D>("COIN");

            rectangle = new Rectangle((int)Position.X,(int) Position.Y, size, size);
        }

        public override bool Action(Rectangle Mario)
        {
            if (rectangle.Intersects(Mario) && IsGained==false)
            {
                IsGained = true;
                CoinsNumber++;
                return true;
            }
            return false;
        }

    }
}

