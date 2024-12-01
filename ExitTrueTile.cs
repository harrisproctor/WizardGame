using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class ExitTrueTile : Truetile
    {

        TileManager tileManager;
        public int tileind;
        int cooldown = 0;
        int health = 4;




        public ExitTrueTile(int ind, TileManager tileManager)
        {

            tileind = ind;
            this.tileManager = tileManager;
            croprect = new Microsoft.Xna.Framework.Rectangle(512, 0, 128, 128);
        }

        public override void Activate(int side,Entity e)
        {
           
            e.onExit = true;



        }

        public override void Update()
        {
            

        }


    }
}
