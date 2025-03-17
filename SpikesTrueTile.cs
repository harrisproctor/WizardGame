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
        int killside = 1;
        Entity spikeent = new Entity();




        public SpikesTrueTile(int ind, TileManager tileManager,int kill)
        {

            tileind = ind;
            this.tileManager = tileManager;
            if(kill == 3)
            {
                croprect = new Microsoft.Xna.Framework.Rectangle(128, 384, 128, 128);
            }else if(kill == 4)
            {
                croprect = new Microsoft.Xna.Framework.Rectangle(384, 384, 128, 128);
            }
            else if (kill == 2)
            {
                croprect = new Microsoft.Xna.Framework.Rectangle(256, 384, 128, 128);
            }
            else
            {
                croprect = new Microsoft.Xna.Framework.Rectangle(0, 384, 128, 128);
            }
            
            spikeent.id = 144;
            killside = kill;
        }

        public override void Activate(int side, Entity e)
        {

            if(side == killside)
            {
                // Debug.WriteLine("spiked");
                e.hit(spikeent);

            }




        }


    }
}
