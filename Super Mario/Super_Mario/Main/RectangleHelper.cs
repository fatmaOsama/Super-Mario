using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Super_Mario
{
    static class RectangleHelper
    {

        public static bool TOP(this Rectangle Obj, Rectangle Mario)
        {
            //Console.WriteLine("Intersects in  top :" + Mario.Intersects(Obj));
            return (Mario.Intersects(Obj) && Mario.Bottom >= Obj.Top);
        }
        public static bool BOTTOM(this Rectangle Mario, Rectangle Obj)
        {

            return (Mario.Intersects(Obj) && Mario.Top>=Obj.Bottom-1 &&
                Mario.Right>=Obj.Left+(Obj.Width/4) && Mario.Left<=Obj.Right-(Obj.Width/4) );
        }

        public static bool LEFT(this Rectangle Mario, Rectangle Obj)
        {

            return (Mario.Intersects(Obj) && Mario.Right <= Obj.Right && Mario.Right >= Obj.Left - 2
                && Mario.Top<=Obj.Bottom-(Obj.Width/4) && Mario.Bottom>=Obj.Top+(Obj.Width/4));
        }
        public static bool RIGHT(this Rectangle Mario, Rectangle Obj)
        {

            return (Mario.Intersects(Obj) && Mario.Left >= Obj.Left && Mario.Left <= Obj.Right - 2
                && Mario.Top <= Obj.Bottom - (Obj.Width / 4) && Mario.Bottom >= Obj.Top + (Obj.Width / 4));
        }

    }
}
