using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class jumpboostCantrip : Cantrip
    {
        Player player;
        public int boostStr = 25;
        public int boostPow = -8;
        public bool boosted = false;


        public jumpboostCantrip(Player player)
        {
            this.player = player;
            id = 10;
            pushonhit = 4;
            manacost = 0;
            symbcroprect = new Rectangle(128, 384, 128, 128);
            cantripnum = 10;
        }


        public override void update()
        {
            if (!boosted)
            {
                boosted = true;
                player.jumpPow = boostPow;
                player.jumpStr = boostStr;


            }
        }

        public override void drop()
        {
            boosted = false;
            player.jumpStr = player.startJumpStr;
            player.jumpPow = player.startjumpPow;
        }




    }
}
