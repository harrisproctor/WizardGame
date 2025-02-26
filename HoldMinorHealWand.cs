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
    internal class HoldMinorHealWand : HoldItem
    {
        int manasucktime = 0;
        bool sucking = true;
        int spawnoffsety = 0;
        int spawnoffsetx = 0;
        int partsize = 32;

        public HoldMinorHealWand(CollisionCheck check, Player player) : base(check, player)
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
           // Debug.WriteLine(sucking);
            if (sucking)
            {
               //Debug.WriteLine(manasucktime);
                if (player.mana > 0.025)
                {
                    if(player.frameCounter.frame % 5 == 0)
                    {
                        spawnoffsetx = player.mm.particleManager.rnd.Next(10, 60);
                        spawnoffsetx = player.mm.particleManager.rnd.Next(10, 60);
                        partsize = player.mm.particleManager.rnd.Next(16, 48);
                        player.mm.particleManager.addHealSmall(player.hitbox.X + spawnoffsetx, player.hitbox.Y + spawnoffsety, 0, -8, partsize, 0.1f);

                    }

                    //sucking = true;
                    player.changeMana(-0.025f);
                    manasucktime += 1;
                    //Debug.WriteLine("zucc");
                    if (manasucktime == 200)
                    {
                        
                        player.changeHealth(1);
                        player.heldItem = null;
                        player.itemManager.items.Remove(this);
                        player.itemManager.fixMKeyind();
                    }
                    if(player.heldItem != this || player.leftact == true)
                    {
                        sucking = false;
                        //manasucktime = 0;
                    }

                }
            }
            
        }

        public override void use()
        {
            // player.throwitem();'
            if (player.mana > 0.025)
            {
                sucking = true;
                player.changeMana(-0.025f);
                manasucktime += 1;
               // Debug.WriteLine("heal");
                if (manasucktime == 200)
                {
                    player.changeHealth(1);
                    player.heldItem = null;
                    player.itemManager.items.Remove(this);
                    player.itemManager.fixMKeyind();
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
            croprect.Y = 256;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 64, 64);
            bounce = 10;



        }
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - xoffset  - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - yoffset -player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
