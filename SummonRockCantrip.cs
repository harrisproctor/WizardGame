using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class SummonRockCantrip : Cantrip
    {
        Player player;
        int cooldown;
        public SummonRockCantrip(Player player)
        {
            this.player = player;
            cooldown = 0;
            id = 2;
            pushonhit = 4;
            manacost = 1;
            symbcroprect = new Rectangle(256, 0, 128, 128);

        }






        public override void cast()
        {
            if(cooldown == 0) 
            {
                if(player.facing == 0)
                {
                    player.itemManager.addCrystalRock(player.hitbox.X+60,player.hitbox.Y+40);
                }
                else
                {
                    player.itemManager.addCrystalRock(player.hitbox.X-20, player.hitbox.Y + 40);
                }
                if (player.itemManager.items.Last().hitbox.Y + player.itemManager.items.Last().hitbox.Height > player.hitbox.Y + player.hitbox.Height)
                {
                    player.itemManager.items.Last().hitbox.Y = player.hitbox.Y;

                }
                if (player.facing == 0)
                {
                    player.itemManager.items.Last().xvel = 2;

                }
                else
                {

                    player.itemManager.items.Last().xvel = -2;

                }
                //make sure its not in wall
                player.colcheck.checkTile(player.itemManager.items.Last());
                if (player.itemManager.items.Last().colliding)
                {
                    player.itemManager.items.Last().hitbox.X = player.hitbox.X + player.itemManager.items.Last().xmidoffset;


                }
                player.framesincethrow++;
                player.prevheldItem = player.itemManager.items.Last();


            }
          
            
        }


    

        public override void update()
        {
            if (cooldown > 0) {
            cooldown -= 1;
            
            }


           
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
          

        }

    }
}
