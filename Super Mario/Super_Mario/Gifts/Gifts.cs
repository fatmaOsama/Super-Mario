using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
     class Gifts : Static
    {

        protected int Points;
        public int points
        {
            set { Points = value; }
            get { return Points;  }
        }

        protected int type;
        public int Type
        {
            set { type = value; }
            get { return type; }
        }
        public bool isGained = false;
        public bool IsGained
        {
            set { isGained = value; }
            get { return isGained; }
        }
       
        public Gifts() { }

        public virtual bool Action(Rectangle Mario)
        {
            if (rectangle.Intersects(Mario) && IsGained == false)
            {
                IsGained = true;
                return true;
            }
            return false;
        }
    }
}
