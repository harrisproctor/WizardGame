using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class MagicWaveCantrip : Cantrip
    {

        Player player;


        public MagicWaveCantrip(Player player)
        {
            this.player = player;
            id = 1;
            pushonhit = 4;
            manacost = 1;
            symbcroprect = new Rectangle(256, 128, 128, 128);

        }






        public override void cast()
        {


            if (player.facing == 1)
            {
                // hitbox.X = player.hitbox.X + 75;
                //player.colcheck.tileManager.magicmanager.addMagicArrow1(player.hitbox.X - 40 + player.xvel, player.hitbox.Y + 10, -1, 0);
                player.colcheck.tileManager.magicmanager.addMagicWave1(player.hitbox.X + 80 , player.hitbox.Y + 20, 2, 3);
                player.colcheck.tileManager.magicmanager.addMagicWave1(player.hitbox.X - 70 + player.xvel, player.hitbox.Y + 25, 4, 3);
            }
            else
            {
                //hitbox.X = player.hitbox.X - 50;
                player.colcheck.tileManager.magicmanager.addMagicWave1(player.hitbox.X + 80 + player.xvel, player.hitbox.Y + 25, 2, 3);
                player.colcheck.tileManager.magicmanager.addMagicWave1(player.hitbox.X - 70 , player.hitbox.Y + 20, 4, 3);
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
