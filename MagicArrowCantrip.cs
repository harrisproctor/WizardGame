using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class MagicArrowCantrip : Cantrip
    {
        
        Player player;
        

        public MagicArrowCantrip(Player player)
        {
            this.player = player;
            id = 1;
            pushonhit = 4;
            manacost = 1;
            symbcroprect = new Rectangle(128, 0, 128, 128);
            cantripnum = 5;

        }






        public override void cast()
        {

            
            if (player.facing == 1)
            {
               // hitbox.X = player.hitbox.X + 75;
                player.colcheck.tileManager.magicmanager.addMagicArrow1(player.hitbox.X-40+player.xvel, player.hitbox.Y+10, -1, 0);
            }
            else
            {
                //hitbox.X = player.hitbox.X - 50;
                player.colcheck.tileManager.magicmanager.addMagicArrow1(player.hitbox.X+80 + player.xvel, player.hitbox.Y+10,1,0);
            }
        }


       

        public override void update()
        {

            
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
            

        }





    }
}
