using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class FloatCantrip : Cantrip
    {


        Texture2D cloudTexture;
        int spellframe;
        Player player;
        Rectangle hitbox = new Rectangle(0, 0, 60, 60);
        Rectangle drawbox = new Rectangle(0, 0, 100, 100);
        Rectangle cropbox = new Rectangle(0, 0, 128, 128);
        public bool isfiring;
        public int casts = 0;

        public FloatCantrip(Player player)
        {
            this.player = player;
            id = 1;
            pushonhit = 4;
            manacost = 0;
            symbcroprect = new Rectangle(0, 128, 128, 128);
            cantripnum = 3;

        }






        public override void cast()
        {
            if (casts == 0)
            {
                cloudTexture = player.cloudtexture;
            }
            casts++;
            if (isfiring)
            {
                isfiring = false;
            }
            else
            {
                isfiring = true;
            }
           
        }


    

        public override void update()
        {

            if (isfiring )
            {
                if(player.mana > 0){
                    player.changeMana(-0.01f);
                    player.elevation = player.yvel;
                    player.yvel = 0;

                    spellframe++;


                    hitbox.Y = player.hitbox.Y + 30;
                    hitbox.X = player.hitbox.X - 5;

                    if (spellframe % 10 == 1)
                    {
                        cropbox.X += 128;
                        if (cropbox.X > 300)
                        {
                            cropbox.X = 0;
                        }
                    }
                    else if (spellframe == 600)
                    {

                        spellframe = 0;
                        cropbox.X = 0;
                    }
                }
                else
                {
                    isfiring = false;
                }
            }
        }

        public override void predraw(SpriteBatch _spriteBatch)
        {
            if (isfiring)
            {
                drawbox.X = (int)hitbox.X  - player.centerWorldX + player.centerX;
                drawbox.Y = (int)hitbox.Y  - player.centerWorldY + player.centerY;
                _spriteBatch.Draw(cloudTexture, drawbox, cropbox, Color.White);
            }

        }






    }
}
