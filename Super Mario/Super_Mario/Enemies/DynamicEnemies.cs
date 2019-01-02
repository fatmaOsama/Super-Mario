using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
    class DynamicEnemies : Dynamic
    {
        protected bool IsKilled = false;
        public bool iskilled
        {
            set { IsKilled = value; }
            get { return IsKilled; }
        }
        public DynamicEnemies() { }
        public virtual void AnimateRight(GameTime gametime) { }
        public virtual void AnimateLeft(GameTime gametime) { }
        public  int Collide(Rectangle mario)
        {
            if (IsKilled == false)
            {
                if (rectangle.TOP(mario) )
                 {

                     IsKilled = true;
                     return 0;
                 }
                if (rectangle.RIGHT(mario) || rectangle.LEFT(mario))
                {
                    return -1;
                }
            }
            return 1;
        }
    }
}
