using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class RedWitch : Entity
    {
        //public Texture2D battexture;
        public Player player;
        //Rectangle hitbox = new Rectangle(1200, 500, 80, 80);
        Rectangle drawbox = new Rectangle(0, 0, 128, 128);
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
        public bool consious = true;
        public int unconsioustime = 0;
        public int maxVel = 20;
        public bool attacking = false;
        public int health = 3;
        public int iframes = 0;
        public bool prevattacking = false;
        public bool walking = false;
        public bool potright = false;
        int timesinceturn = 0;
        int shoottimer = 0;
        float dx;
        float dy;
        float sumAbs;
        bool casting = false;




        public RedWitch(Player player, MonsterManager mm)
        {
            this.player = player;
            id = 34;
            hitbox = new Rectangle(1700, 600, 80, 90);
            check = player.colcheck;
            bounce = 100;
            this.mm = mm;



        }

        public override void update()
        {
            prevattacking = attacking;
            shoottimer += 1;
            if (iframes > 0)
            {
                iframes--;
            }
            if (consious)
            {

                yvel += (player.frameCounter.frame % 2);
                playerdirx = hitbox.X - player.hitbox.X;
                playerdiry = hitbox.Y - player.hitbox.Y;
                if (playerdiry < 200 && playerdiry > -200 && playerdirx < 500 && playerdirx > -500)
                {
                    timesinceturn = 0;
                    walking = true;
                    if (playerdirx < -5)
                    {
                        xvel = 2;
                        facingeffect = SpriteEffects.FlipHorizontally;

                    }
                    else if (playerdirx > 5)
                    {
                        xvel = -2;
                        facingeffect = SpriteEffects.None;
                    }
                    onLedge = false;
                    colliding = false;
                    grounded = false;
                    check.checkTile(this);
                    check.onTheLedge(this);
                    if (colliding || onLedge)
                    {

                        if (xvel == 2)
                        {
                            xvel = -2;
                            walking = false;
                        }
                        else if (xvel == -2)
                        {
                            xvel = 2;
                            walking = false;
                        }



                    }
                    if (shoottimer > 300)
                    {
                        shoottimer = 0;
                        //here bitch
                        attacking = true;
                        casting = true;
                        //fireball();


                    }
                }
                else
                {
                    timesinceturn++;
                    walking = true;
                    if (potright)
                    {
                        xvel = 1;
                        facingeffect = SpriteEffects.FlipHorizontally;
                    }
                    else
                    {
                        xvel = -1;
                        facingeffect = SpriteEffects.None;
                    }
                    onLedge = false;
                    colliding = false;
                    grounded = false;
                    check.checkTile(this);
                    check.onTheLedge(this);
                    if (colliding || onLedge)
                    {

                        if (potright)
                        {
                            potright = false;
                        }
                        else
                        {
                            potright = true;
                        }



                    }


                }



                onLedge = false;
                colliding = false;
                grounded = false;
                check.checkTile(this);
                check.eitemCheck(this);


                hitbox.X += xvel;
                hitbox.Y += yvel;

                hitCheck();


                aniframe++;




                if (attacking)
                {
                    if (prevattacking == false)
                    {
                        aniframe = 1;
                    }
                    if (aniframe == 1)
                    {
                        cropbox.X = 0;
                        cropbox.Y = 128;
                    }
                    if (aniframe % 10 == 9)
                    {
                        cropbox.X += 128;

                    }

                    if (cropbox.X > 600)
                    {

                        cropbox.X = 0;
                        cropbox.Y = 0;
                        aniframe = 0;
                        attacking = false;
                        if (casting)
                        {
                            casting = false;
                            fireball();
                        }

                    }



                }
                else if (walking)
                {

                    if (xvel > 1 || xvel < -1)
                    {
                        if (aniframe % 12 == 1)
                        {

                            cropbox.X += 128;
                            if (cropbox.X > 700)
                            {
                                cropbox.X = 0;

                            }
                        }


                    }
                    else
                    {
                        if (aniframe % 18 == 1)
                        {

                            cropbox.X += 128;
                            if (cropbox.X > 700)
                            {
                                cropbox.X = 128;

                            }
                        }
                    }


                    if (aniframe == 288)
                    {
                        aniframe = 0;
                        // cropbox.X = 0;
                    }
                }
                else
                {

                    cropbox.X = 0;


                }
            }
            else
            {
                //unconsious

                yvel += (player.frameCounter.frame % 2);



                //start collsion check
                grounded = false;
                colliding = false;

                check.checkTile(this);
                check.eitemCheck(this);






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

                if (xvel > 0)
                {
                    xvel -= (player.frameCounter.frame % 2);
                }
                else if (xvel < 0)
                {
                    xvel += (player.frameCounter.frame % 2);
                }

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

        public void fireball()
        {
            dx = player.hitbox.X - hitbox.X;
            dy = player.hitbox.Y - hitbox.Y;
            sumAbs = Math.Abs(dx) + Math.Abs(dy);
            player.colcheck.tileManager.magicmanager.addMagicFire1(hitbox.X, hitbox.Y, dx / sumAbs, dy / sumAbs);
        }

        public override void hit(Entity entity)
        {

            if (iframes == 0)
            {
                if (entity.id == 101 || entity.id == 102 || entity.id == 103 || entity.id == 104 || entity.id == 105)
                {

                    xvel += entity.xvel / 2;
                    entity.xvel = -entity.xvel / 2;
                    consious = false;
                    cropbox.X = 0;
                    cropbox.Y = 128;
                    health--;
                    iframes = 20;


                }
                else if (entity.id == 1)
                {

                    consious = false;
                    cropbox.X = 0;
                    cropbox.Y = 128;
                    health--;
                    iframes = 50;



                }
                else if (entity.id == 1001 || entity.id == 1055)
                {
                    if (entity.bounce != 85)
                    {
                        xvel += entity.xvel / 2;
                        yvel += entity.yvel / 2;
                        consious = false;
                        cropbox.X = 0;
                        cropbox.Y = 128;
                        health--;
                        iframes = 20;
                    }


                }
                else if (entity.id == 1002)
                {
                    xvel += entity.xvel / 2;
                    yvel += entity.yvel / 2;
                    consious = false;
                    cropbox.X = 0;
                    cropbox.Y = 128;
                    health--;
                    iframes = 20;


                }
            }


            if (health < 1)
            {
                player.mm.particleManager.addBrainChunk(hitbox.X + 20, hitbox.Y, 5, -5);
                player.mm.particleManager.addBrainChunk(hitbox.X + 30, hitbox.Y + 40, -5, -5);
                player.mm.particleManager.addBrainChunk(hitbox.X + 60, hitbox.Y + 40, 0, -8);

                player.mm.particleManager.addManaSmall(hitbox.X + 20, hitbox.Y, 1, -5, 32, 0.3f);
                player.mm.particleManager.addManaSmall(hitbox.X + 30, hitbox.Y + 40, -1, -5, 32, 0.3f);
                player.mm.particleManager.addManaSmall(hitbox.X + 60, hitbox.Y + 40, 0, -8, 32, 0.3f);


                player.mm.monsters.Remove(this);

            }



        }

        public void hitCheck()
        {
            if (hitbox.Intersects(player.hitbox))
            {
                tophitbox.X = hitbox.X + 5;
                tophitbox.Y = hitbox.Y;
                playerfeet = new Rectangle(player.hitbox.X + 10, player.hitbox.Y + player.hitbox.Height - 10, player.hitbox.Width - 10, 10);
                if (player.yvel < 0)
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
            drawbox.X = (int)(hitbox.X - 20) - player.centerWorldX + player.centerX;
            drawbox.Y = (int)(hitbox.Y - 10) - player.centerWorldY + player.centerY;
            // _spriteBatch.Draw(battexture, drawbox, cropbox, Color.White);
            _spriteBatch.Draw(texture, drawbox, cropbox, Color.Crimson, 0, Vector2.Zero, facingeffect, 1);
        }
    }
}
