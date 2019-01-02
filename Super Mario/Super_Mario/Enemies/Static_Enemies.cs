using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class StaticEnemies : Static
    {
        protected bool IsOn = false;
        public int Collide(Rectangle mario)
        {
           
             
                if (rectangle.RIGHT(mario) || rectangle.LEFT(mario) || rectangle.TOP(mario) && IsOn==false)
                {
                    IsOn = true;
                    return -1;
                }
                if (!rectangle.Intersects(mario))
                {
                    IsOn = false;
                }
           
            return 1;
        
        }
    }

}
