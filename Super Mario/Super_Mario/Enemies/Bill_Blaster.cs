using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class Bill_Blaster : StaticEnemies
    {
        public Bill_Blaster(Vector2 newposition) { Position = newposition; }
        public override void Load()
        {
            texture = Content.Load<Texture2D>("bill blaster");
            rectangle = new Rectangle((int)Position.X,(int)Position.Y, 75, 75);
            //Position = new Vector2(50, 200);
        }
    }
}
