using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class speedboostCantrip : Cantrip
    {
        Player player;
        public int boost = 15;
        public bool boosted = false;
        

        public speedboostCantrip(Player player)
        { 
        this.player = player;
            id = 9;
            pushonhit = 4;
            manacost = 0;
            symbcroprect = new Rectangle(0, 256, 128, 128);
            cantripnum = 9;
        }


        public override void update() 
        {
            if (!boosted) 
            {
                boosted = true;
                player.maxRunSpeed = boost;


            }
        }

        public override void drop()
        {
            boosted = false;
            player.maxRunSpeed = player.defmaxRunSpeed;
        }

    }
}
