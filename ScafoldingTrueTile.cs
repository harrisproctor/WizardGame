using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class ScafoldingTrueTile : Truetile
    {
        
        TileManager tileManager;
        public int tileind;
        int cooldown = 0;
        int health = 4;




        public ScafoldingTrueTile( int ind, TileManager tileManager)
        {
           
            tileind = ind;
            this.tileManager = tileManager;
            croprect = new Microsoft.Xna.Framework.Rectangle(768, 0, 128, 128);
        }

        public override void Activate(int side, Entity e)
        {
            //Debug.WriteLine("yipyip");
            if (cooldown == 0)
            {
                health -= 1;
                croprect.Y += 128;
                cooldown = 60;
                if(health < 1)
                {
                    tileManager.map[tileind] = tileManager.backmap[tileind];
                    //tileManager.player.ledgegrab = false;
                }
            }
            



        }

        public override void Update()
        {
          if(cooldown > 0)
            {
                cooldown -= 1;
            }

        }

    }
}
