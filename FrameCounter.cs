using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class FrameCounter
    {
        public int frame = 0;


        public void update() 
        {
        frame++;
            if (frame == 100) {
                frame = 0;
            }
        }
    }
}
