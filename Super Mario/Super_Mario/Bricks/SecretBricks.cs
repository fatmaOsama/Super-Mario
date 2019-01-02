using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class SecretBricks : Bricks
    {
        private Random ran = new Random();
        private Random r = new Random();
        public List<Gifts> gift = new List<Gifts>();
        public SecretBricks(Vector2 NewPosition)
        {
            Position = NewPosition;
            int type = ran.Next(1, 4);
            int coinType = r.Next(1, 6);
            if (type == 1)
            {
                gift.Add(new SuperStar(new Vector2(0,0)));
            }
            else if (type == 2)
            {
                gift.Add(new FireFlower(new Vector2(0, 0)));
            }
            else if (type == 3)
            {
                for (int i = 0; i < coinType; i++)
                {//postion yaa fatmaaa yaa osamaa
                    gift.Add(new Coins(new Vector2(0, 0)));
                }
            }
        }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("Normal");
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
        }

    }

}

