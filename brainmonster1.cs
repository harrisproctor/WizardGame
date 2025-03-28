﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class brainmonster1 : Entity
    {

        //public Texture2D battexture;
        public Player player;
        //Rectangle hitbox = new Rectangle(1200, 500, 80, 80);
        Rectangle drawbox = new Rectangle(0, 0, 128, 128);
        Rectangle cropbox = new Rectangle(0, 0, 128, 128);
        Rectangle tophitbox = new Rectangle(0, 0, 90, 5);
        int aniframe = 0;
        public bool flapdown;
        public bool leftward = false;
        public SpriteEffects facingeffect = SpriteEffects.None;
        CollisionCheck check;
        int playerdirx;
        int playerdiry;
        Rectangle playerfeet;
        MonsterManager mm;
        public bool consious = true;
        public int unconsioustime = 0;
        public int maxVel = 20;
        public bool attacking = false;
        public int health = 3;
        public int iframes = 0;
        public bool prevattacking = false;






        public brainmonster1(Player player, MonsterManager mm)
        {
            this.player = player;
            id = 34;
            hitrank = 6;
            hitbox = new Rectangle(1700, 600, 100, 100);
            check = player.colcheck;
            bounce = 100;
            this.mm = mm;



        }

        public override void update()
        {
            prevattacking = attacking;
            if (iframes > 0)
            {
                iframes--;
            }
            if (consious)
            {
                yvel = 0;
                xvel = 0;

                playerdirx = hitbox.X - player.hitbox.X;
                playerdiry = hitbox.Y - player.hitbox.Y;
                if (playerdirx < -5)
                {
                    xvel++;
                    if (facingeffect == SpriteEffects.FlipHorizontally)
                    {
                        facingeffect = SpriteEffects.None;
                    }
                }
                else if (playerdirx > 5)
                {
                    xvel--;
                    if (facingeffect == SpriteEffects.None)
                    {
                        facingeffect = SpriteEffects.FlipHorizontally;
                    }
                }

                if (playerdiry < -60)
                {
                    yvel++;
                }
                else
                {
                    yvel--;
                }


                colliding = false;
                grounded = false;
                check.checkTile(this);


                hitbox.X += xvel;
                hitbox.Y += yvel;

                hitCheck();


                aniframe++;


                

                if (attacking)
                {
                    if(prevattacking == false)
                    {
                        aniframe = 1;
                    }
                    if(aniframe == 1)
                    {
                        cropbox.X = 128;
                        cropbox.Y = 128;
                    }
                    if (aniframe % 10 == 9)
                    {
                        cropbox.X += 128;
                        
                    }
                  
                    if (cropbox.X > 400)
                    {

                        cropbox.X = 0;
                        cropbox.Y = 0;
                        aniframe = 0;
                        attacking = false;

                    }



                }
                else
                {

                   
                    if (aniframe % 10 == 1)
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

                    if (aniframe == 100)
                    {
                        aniframe = 0;
                        // cropbox.X = 0;
                    }
                }
            }
            else
            {
                //unconsious

             

               

                //start collsion check
                grounded = false;
                colliding = false;

                check.checkTile(this);


               
                


                //limit physics
                if (xvel > maxVel)
                {
                    xvel = maxVel;
                }
                else if (xvel < -maxVel)
                {
                    xvel = -maxVel;
                }

                if (yvel > maxVel)
                {
                    yvel = maxVel;
                }
                else if (yvel < -maxVel)
                {
                    yvel = -maxVel;
                }

                //applie sphysiocs
                hitbox.X += xvel;
                hitbox.Y += yvel;

                //
                unconsioustime++;

                

                if (unconsioustime > 200)
                {
                    cropbox.X = 0;
                    cropbox.Y = 0;
                    consious = true;
                    unconsioustime = 0;
                    

                }




            }


        }

        public override void hit(Entity entity)
        {

            if (iframes == 0)
            {
                switch (entity.hitrank)
                {
                    case 1:
                        // Code to execute if variable == value1
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        entity.xvel = -entity.xvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health--;
                        iframes = 20;
                        break;
                    case 2:
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        //consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health--;
                        iframes = 20;
                        break;
                    case 3:
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health -= 2;
                        iframes = 20;
                        break;
                    case 4:
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health -= 2;
                        iframes = 20;
                        break;
                    case 5:
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health -= 2;
                        iframes = 20;
                        break;
                    // Add more cases as needed
                    case 6:
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health -= 2;
                        iframes = 20;
                        break;
                    case 7:
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health -= 2;
                        iframes = 20;
                        break;
                    default:
                        // Code to execute if none of the cases match

                        break;
                }
                
            }


                if (health < 1)
            {
                player.mm.particleManager.addBrainChunk(hitbox.X+20,hitbox.Y,5,-5);
                player.mm.particleManager.addBrainChunk(hitbox.X+ 30, hitbox.Y+ 40,-5,-5);
                player.mm.particleManager.addBrainChunk(hitbox.X+60, hitbox.Y+40,0,-8);

                player.mm.particleManager.addManaSmall(hitbox.X + 20, hitbox.Y, 1, -5,40,0.5f);
                player.mm.particleManager.addManaSmall(hitbox.X + 30, hitbox.Y + 40, -1, -5,40, 0.5f);
                player.mm.particleManager.addManaSmall(hitbox.X + 60, hitbox.Y + 40, 0, -8,25, 0.2f);


                player.mm.monsters.Remove(this);
                
            }
            


        }

        public void hitCheck()
        {
            if (hitbox.Intersects(player.hitbox) )
            {
                tophitbox.X = hitbox.X + 5;
                tophitbox.Y = hitbox.Y;
                playerfeet = new Rectangle(player.hitbox.X+10, player.hitbox.Y + player.hitbox.Height - 10, player.hitbox.Width-10, 10);
                if(player.yvel < 0)
                {
                    tophitbox.Height = -player.yvel;
                }
                else
                {
                    tophitbox.Height = 5;
                }
                tophitbox.Height = player.yvel;
                if (tophitbox.Intersects(playerfeet))
                {
                    consious = false;
                    cropbox.X = 0;
                    cropbox.Y = 128;
                    player.yvel = -9;
                    yvel += 5;
                    health--;
                    hit(player);
                    player.iframes = 7;
                    player.elevation = player.hitbox.Y;


                }
                else
                {
                   // aniframe = 0;
                    attacking = true;
                    player.hit(this);
                }
            }
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
            drawbox.X = (int)(hitbox.X-10) - player.centerWorldX + player.centerX;
            drawbox.Y = (int)(hitbox.Y-10) - player.centerWorldY + player.centerY;
            // _spriteBatch.Draw(battexture, drawbox, cropbox, Color.White);
            _spriteBatch.Draw(texture, drawbox, cropbox, Color.White, 0, Vector2.Zero, facingeffect, 1);
        }


    }
}
