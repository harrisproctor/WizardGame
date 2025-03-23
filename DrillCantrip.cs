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
    internal class DrillCantrip : Cantrip
    {

        Texture2D fireballTexture;
        int spellframe;
        Player player;
        Rectangle hitbox = new Rectangle(0, 0, 60, 60);
        Entity drill = new Entity();
        Rectangle drawbox = new Rectangle(0, 0, 80, 80);
        Rectangle cropbox = new Rectangle(640, 0, 128, 128);
        public bool isfiring;
        public int casts = 0;
        private SpriteEffects spriteEffects;
        public int destind;
        public int setup = 0;

        public DrillCantrip(Player player)
        {
            this.player = player;
            id = 8;
            pushonhit = 4;
            manacost = 1;
            symbcroprect = new Rectangle(384, 512, 128, 128);
            cantripnum = 8;
           fireballTexture = player.colcheck.tileManager.magicmanager.effectstext1;
            drill.hitbox = new Rectangle(0,0, 60, 60);
            drill.bounce = 1;

        }






        public override void cast()
        {
           
            
            isfiring = true;
        }


        public void hitCheck()
        {
            drill.colliding = false;
            drill.grounded = false;

            destind = player.colcheck.checkTileRet(drill);
           // Debug.WriteLine(destind);


            if (drill.colliding || drill.grounded)
            {
               // Debug.WriteLine("help");
                
                if (destind != -1)
                {

                    player.colcheck.tileManager.breaktile(destind);
                    isfiring = false;
                    spellframe = 0;
                }


            }
        }

        public override void update()
        {

            if (isfiring)
            {
                if (isupordown == 0)
                {
                    if(setup != 0)
                    {
                        setup = 0;
                        cropbox.X = 640;
                        cropbox.Y = 0;
                    }

                    spellframe++;
                    if (player.facing == 0)
                    {
                        spriteEffects = SpriteEffects.None;
                        hitbox.X = player.hitbox.X + 75;
                        drill.xvel = 1;
                    }
                    else
                    {
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        hitbox.X = player.hitbox.X - 50;
                        drill.xvel = -1;
                    }

                    hitbox.Y = player.hitbox.Y;

                    drill.hitbox.X = hitbox.X;
                    drill.hitbox.Y = hitbox.Y;

                    drill.yvel = player.yvel;
                    hitCheck();
                    if (spellframe % 5 == 1)
                    {
                        cropbox.Y += 128;
                        if (cropbox.Y > 400)
                        {
                            cropbox.Y = 0;
                        }
                    }
                    else if (spellframe == 50)
                    {
                        isfiring = false;
                        spellframe = 0;
                        cropbox.Y = 0;
                    }
                }
                else 
                {
                    if (setup != 1)
                    {
                        setup = 1;
                        cropbox.X = 0;
                        cropbox.Y = 384;
                    }

                    spellframe++;
                    if (isupordown == -1)
                    {
                        spriteEffects = SpriteEffects.None;
                        hitbox.Y = player.hitbox.Y + 70;
                        drill.yvel = 1;
                    }
                    else
                    {
                        spriteEffects = SpriteEffects.FlipVertically;
                        hitbox.Y = player.hitbox.Y - 50;
                        drill.yvel = -1;
                    }

                    hitbox.X = player.hitbox.X + 20;

                    drill.hitbox.X = hitbox.X;
                    drill.hitbox.Y = hitbox.Y;

                    drill.xvel = player.xvel;
                    hitCheck();
                    if (spellframe % 5 == 1)
                    {
                        cropbox.X += 128;
                        if (cropbox.X > 400)
                        {
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
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
            if (isfiring)
            {
                drawbox.X = (int)hitbox.X - 10 - player.centerWorldX + player.centerX;
                drawbox.Y = (int)hitbox.Y - 10 - player.centerWorldY + player.centerY;
                _spriteBatch.Draw(fireballTexture, drawbox, cropbox, Color.White, 0, Vector2.Zero, spriteEffects, 1);
            }

        }
    }
}
