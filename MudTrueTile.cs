using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class MudTrueTile : Truetile
    {

        TileManager tileManager;
        public int tileind;
        int aniframe = 0;
        //int health = 4;




        public MudTrueTile(int ind, TileManager tileManager)
        {

            tileind = ind;
            this.tileManager = tileManager;
            croprect = new Microsoft.Xna.Framework.Rectangle(0, 256, 128, 128);
        }

        public override void Activate(int side, Entity e)
        {

            e.xvel = e.xvel / 2;
            e.yvel = e.yvel / 2;
            if (e is Player)
            {
                ((Player)e).muddy = true;
            }
            



        }

        public override void Update()
        {
            aniframe++;
            if(aniframe == 80)
            {
                aniframe = 0;
                croprect.X = 0;
            }else if(aniframe % 20 == 0)
            {
                croprect.X += 128;
            }

        }


    }
}
