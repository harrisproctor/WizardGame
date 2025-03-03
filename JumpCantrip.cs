﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class JumpCantrip : Cantrip
    {
        Texture2D cloudTexture;
        int spellframe;
        Player player;
       
        public bool isfiring;
        public bool canjump = true;
        public int realmanacost = 1;

        public JumpCantrip(Player player)
        {
            this.player = player;
            id = 1;
            pushonhit = 4;
            manacost = 1;
            symbcroprect = new Rectangle(128, 128, 128, 128);
            cantripnum = 4;

        }



        public override void cast()
        {
            player.changeMana(manacost);

            if (canjump && realmanacost < player.mana)
            {
                player.ledgegrab = false;
                player.changeMana(-realmanacost);
                player.elevation = player.hitbox.Y;
                player.yvel = -10;
                player.mm.particleManager.addWindParticle(player.hitbox.X,player.hitbox.Y+80,0,0,0);
                player.mm.particleManager.addWindParticle(player.hitbox.X+80, player.hitbox.Y + 80, 0, 0,1);
            }

            canjump = false;   

        }

        public override void update()
        { 
        if(player.framesicneground < 3)
            {
                canjump = true;
            }
        
        
        
        }



        }
}
