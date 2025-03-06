using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class SpikesTrueTile : Truetile
    {

        TileManager tileManager;
        public int tileind;
        int aniframe = 0;
        //int health = 4;




        public SpikesTrueTile(int ind, TileManager tileManager)
        {

            tileind = ind;
            this.tileManager = tileManager;
            croprect = new Microsoft.Xna.Framework.Rectangle(0, 384, 128, 128);
        }

        public override void Activate(int side, Entity e)
        {

            if(side == 1)
            {
                Debug.WriteLine("spiked");
            }




        }


    }
}
