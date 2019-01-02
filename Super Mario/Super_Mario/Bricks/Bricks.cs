using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super_Mario
{
  
    class Bricks:Static
    {
        static int size;
        public Bricks(){
            size = 40;
        }
        public static int Size{
            get { return size; }
            set { size = value; }
    }
       
    }
}
