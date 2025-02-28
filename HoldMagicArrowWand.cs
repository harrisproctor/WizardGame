using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldMagicArrowWand : HoldItem
    {

        int manasucktime = 0;
        bool sucking = true;
        int spawnoffsety = 0;
        int spawnoffsetx = 0;
        int partsize = 32;

        public HoldMagicArrowWand(CollisionCheck check, Player player) : base(check, player)
        {
            this.id = 102;
            this.player = player;
            this.check = check;
            holdoffset = 10;
            xmidoffset = 25;
            xleftholdoffset = -10;
            xrightholdoffset = 70;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;
            xoffset = 20;


            setDefaultValues();


        }

        public override void playeritemupdate()
        {

            base.update();
            

        }

        public override void use()
        {
            // player.throwitem();'
            if (player.mana > 1)
            {
                player.changeMana(-1);
                if (player.facing == 1)
                {
                    // hitbox.X = player.hitbox.X + 75;
                    player.colcheck.tileManager.magicmanager.addMagicArrow1(player.hitbox.X - 50 + player.xvel, player.hitbox.Y + 10, -1, 0);
                }
                else
                {
                    //hitbox.X = player.hitbox.X - 50;
                    player.colcheck.tileManager.magicmanager.addMagicArrow1(player.hitbox.X + 90 + player.xvel, player.hitbox.Y + 10, 1, 0);
                }

            }

        }
        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 20;
            hitbox.Height = 60;

            croprect.X = 0;
            croprect.Y = 384;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 64, 64);
            bounce = 10;



        }
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - xoffset - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - yoffset - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
