using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class weakHealCantrip : Cantrip
    {



        Texture2D fireballTexture;
        int spellframe;
        Player player;
        
        public bool isfiring;
        public int casts = 0;

        int manasucktime = 0;
        bool sucking = true;
        int spawnoffsety = 0;
        int spawnoffsetx = 0;
        int partsize = 32;

        public weakHealCantrip(Player player)
        {
            this.player = player;
            id = 7;
            pushonhit = 4;
            manacost = 0.025f;
            symbcroprect = new Rectangle(256, 256, 128, 128);
            cantripnum = 7;

        }






        public override void cast()
        {
            // player.throwitem();'
           // if (player.mana > 0.025)
           // {
                sucking = true;
               // player.changeMana(-0.025f);
                manasucktime += 1;
                spawnoffsetx = player.mm.particleManager.rnd.Next(10, 60);
                spawnoffsetx = player.mm.particleManager.rnd.Next(10, 60);
                partsize = player.mm.particleManager.rnd.Next(16, 48);
                player.mm.particleManager.addHealSmall(player.hitbox.X + spawnoffsetx, player.hitbox.Y + spawnoffsety, 0, -8, partsize, 0.1f);
                // Debug.WriteLine("heal");
                if (manasucktime == 200)
                {
                    player.changeHealth(1);
                    manasucktime = 0;
                   
                }

           // }

        }


       
        public override void update()
        {
            if (sucking)//sucking
            {
                //Debug.WriteLine(manasucktime);
                //Console.WriteLine(manasucktime);
                //Debug.WriteLine(manasucktime);
                if (player.mana > 0.025)
                {
                    if (player.frameCounter.frame % 5 == 0)
                    {
                        spawnoffsetx = player.mm.particleManager.rnd.Next(10, 60);
                        spawnoffsetx = player.mm.particleManager.rnd.Next(10, 60);
                        partsize = player.mm.particleManager.rnd.Next(16, 48);
                        player.mm.particleManager.addHealSmall(player.hitbox.X + spawnoffsetx, player.hitbox.Y + spawnoffsety, 0, -8, partsize, 0.1f);

                    }

                    //sucking = true;
                    player.changeMana(-0.025f);
                    manasucktime += 1;
                    
                    if (manasucktime == 200)
                    {

                        player.changeHealth(1);
                        manasucktime=0;
                        
                    }

                    if(keyrelease == true)
                    {
                        keyrelease = false;
                        sucking = false;
                    }
                   

                }
            }

        }
    }
}
