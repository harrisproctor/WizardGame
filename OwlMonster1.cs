﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class OwlMonster1 : Entity
    {

        public Player player;
        //Rectangle hitbox = new Rectangle(1200, 500, 80, 80);
        Rectangle drawbox = new Rectangle(0, 0, 100, 100);
        Rectangle cropbox = new Rectangle(0, 0, 128, 128);
        Rectangle tophitbox = new Rectangle(0, 0, 70, 5);
        int aniframe = 0;
        public bool flapdown;
        public bool leftward = false;
        public SpriteEffects facingeffect = SpriteEffects.None;
        CollisionCheck check;
        int playerdirx;
        int playerdiry;
        Rectangle playerfeet;
        MonsterManager mm;
        bool following = false;
        bool flying = false;
        int waitframes = 0;
        int roamframes = 0;
        int roamdirx = 0;
        int roamdiry = 0;


        public OwlMonster1(Player player, MonsterManager mm)
        {
            this.player = player;
            id = 33;
            hitbox = new Rectangle(1200, 500, 80, 50);
            check = player.colcheck;
            bounce = 100;
            this.mm = mm;
            hitrank = 7;



        }

        public override void hit(Entity entity)
        {


  

                die();










        }

        public void die()
        {
            player.mm.monsters.Remove(this);
            player.mm.particleManager.addManaSmall(hitbox.X + 20, hitbox.Y, 1, -5, 32, 0.2f);
            player.mm.particleManager.addManaSmall(hitbox.X + 30, hitbox.Y + 40, -1, -5, 32, 0.2f);
            player.mm.particleManager.addManaSmall(hitbox.X + 60, hitbox.Y + 40, 0, -8, 32, 0.1f);

            player.mm.particleManager.addOwlFeather(hitbox.X + 20, hitbox.Y, 5, -5);
            player.mm.particleManager.addOwlFeather(hitbox.X + 30, hitbox.Y + 40, -5, -5);
            player.mm.particleManager.addOwlFeather(hitbox.X + 60, hitbox.Y + 40, 0, -8);
        }

        public override void update()
        {
            
             yvel = 0;
            xvel = 0;

            playerdirx = hitbox.X - player.hitbox.X;
            playerdiry = hitbox.Y - player.hitbox.Y;
            if (playerdiry < 200 && playerdiry > -200 && playerdirx < 500 && playerdirx > -500)
            {
                following = true;
                flying = true;
            }
            if (following)
            {
                if (playerdirx < -5)
                {
                    xvel += 2;
                    if (facingeffect == SpriteEffects.FlipHorizontally)
                    {
                        facingeffect = SpriteEffects.None;
                    }
                }
                else if (playerdirx > 5)
                {
                    xvel -= 2;
                    if (facingeffect == SpriteEffects.None)
                    {
                        facingeffect = SpriteEffects.FlipHorizontally;
                    }
                }

                if (playerdiry < 0)
                {
                    yvel += 2;
                }
                else
                {
                    yvel -= 2;
                }
            }
            else
            {
                if(waitframes > 0)
                {
                    waitframes--;
                    if(waitframes == 1)
                    {
                        roamdiry = player.rnd.Next(-2, 3);
                        roamdirx = player.rnd.Next(-2, 3);
                        roamframes = player.rnd.Next(50, 300);
                        flying = true;
                        if(roamdirx > 0)
                        {
                            facingeffect = SpriteEffects.None;
                        }
                        else
                        {
                            facingeffect = SpriteEffects.FlipHorizontally;
                        }
                    }
                    
                }
                else
                {

                    if (roamframes > 0) 
                    {

                        xvel = roamdirx;
                        yvel = roamdiry;
                        roamframes -= 1;
                        
                    }
                    else
                    {
                        waitframes = player.rnd.Next(100, 700);
                        flying = false;
                    }
                }
            }

            if (!flying)
            {
                yvel += 4;
            }


            colliding = false;
            grounded = false;
            check.checkTile(this);


            hitbox.X += xvel;
            hitbox.Y += yvel;

            hitCheck();






            aniframe++;
            if (flying)
            {
                if (aniframe % 4 == 1)//4
                {
                    if (flapdown)
                    {
                        cropbox.X += 128;
                        if (cropbox.X > 600)
                        {
                            cropbox.X -= 128;
                            flapdown = false;

                        }
                    }
                    else
                    {
                        cropbox.X -= 128;
                        if (cropbox.X < 0)
                        {
                            cropbox.X += 128;
                            flapdown = true;

                        }

                    }

                }
                if (aniframe == 60)
                {
                    aniframe = 0;
                    // cropbox.X = 0;
                }
            }
            else
            {
                if (aniframe == 60)
                {
                    aniframe = 0;
                    cropbox.X = 512;
                }
            }

            


        }

        public void hitCheck()
        {
            if (hitbox.Intersects(player.hitbox))
            {
                tophitbox.X = hitbox.X + 5;
                tophitbox.Y = hitbox.Y;
                playerfeet = new Rectangle(player.hitbox.X + 10, player.hitbox.Y + player.hitbox.Height - 10, player.hitbox.Width - 10, 10); //10
                tophitbox.Height = player.yvel;
                if (tophitbox.Intersects(playerfeet))
                {
                    die();
                    player.yvel = -9;
                    player.iframes = 7;
                    player.elevation = player.hitbox.Y;
                }
                else
                {
                    player.hit(this);
                   

                }
            }
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
            drawbox.X = (int)(hitbox.X - 10) - player.centerWorldX + player.centerX;
            drawbox.Y = (int)(hitbox.Y - 30) - player.centerWorldY + player.centerY;
            // _spriteBatch.Draw(battexture, drawbox, cropbox, Color.White);
            _spriteBatch.Draw(texture, drawbox, cropbox, Color.White, 0, Vector2.Zero, facingeffect, 1);
        }




    }
}
