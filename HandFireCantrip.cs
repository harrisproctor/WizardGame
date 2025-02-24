using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HandFireCantrip : Cantrip
    {

        Texture2D fireballTexture;
        int spellframe;
        Player player;
        Rectangle hitbox = new Rectangle(0,0,60,60);
        Rectangle drawbox = new Rectangle(0,0,80,80);
        Rectangle cropbox = new Rectangle(0,0,128,128);
        public bool isfiring;
        public int casts = 0;

        public HandFireCantrip(Player player)
        {
            this.player = player;
            id = 1;
            pushonhit = 4;
            manacost = 1;
            symbcroprect = new Rectangle(0, 0, 128, 128);
            cantripnum = 1;

        }

        




        public override void cast()
        {
            if (casts == 0)
            {
                fireballTexture = player.fireballtexture;
            }
            casts++;
           isfiring = true;
        }


        public void hitCheck()
        {
            for (int i = 0; i < player.mm.monsters.Count; i++)
            {


                if (hitbox.Intersects(player.mm.monsters[i].hitbox))
                {


                    player.mm.monsters[i].hit(player);



                }


            }
        }

        public override void update() 
        {

            if (isfiring)
            {
                hitCheck();
                spellframe++;
                if (player.facing == 0)
                {
                    hitbox.X = player.hitbox.X + 75;
                }
                else {
                    hitbox.X = player.hitbox.X - 50;
                }
                
                hitbox.Y = player.hitbox.Y ;

                if(spellframe % 5 == 1)
                {
                    cropbox.X += 128;
                    if (cropbox.X > 400) {
                        cropbox.X = 0;
                    }
                }
                else if (spellframe == 50)
                {
                    isfiring = false;
                    spellframe = 0;
                    cropbox.X = 0;
                }
            }
        }

        public override void draw(SpriteBatch _spriteBatch) 
        {
            if (isfiring)
            {
                drawbox.X = (int)hitbox.X-10 - player.centerWorldX + player.centerX;
                drawbox.Y = (int)hitbox.Y-10 - player.centerWorldY + player.centerY;
                _spriteBatch.Draw(fireballTexture, drawbox,cropbox, Color.White);
            }

        }






    }
}
