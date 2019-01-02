using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
        class NormalBricks : Bricks
        {
            public NormalBricks(Vector2 NewPosition)
            {
                Position = NewPosition;
            }
            public override void Load() //3lshan katbdd klam w 3ayzaha ttkrar b ashkal mo5tlfa
            {

                texture = Content.Load<Texture2D>("Normal");
                rectangle = new Rectangle((int)Position.X,(int) Position.Y, 40, 40);
               // rectangle = new Rectangle(300, 382, 40, 40);
            }
            public void Update(Mario mario)
            {
               
            }
        }
    }

