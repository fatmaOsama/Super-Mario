using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Spiny : StaticEnemies
    {
        public Spiny(Vector2 newposition) { Position = newposition; }

        public override void Load()
        {
            texture = Content.Load<Texture2D>("spiny");
            rectangle = new Rectangle((int)Position.X,(int)Position.Y, 50, 50);
            //Position = new Vector2(50, 200);
        }
    }
}
