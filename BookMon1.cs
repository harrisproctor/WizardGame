using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class BookMon1 : Entity
    {
        public Player player;
        //Rectangle hitbox = new Rectangle(1200, 500, 80, 80);
        Rectangle drawbox = new Rectangle(0, 0, 100, 100);
        Rectangle cropbox = new Rectangle(0, 0, 128, 128);
        Rectangle tophitbox = new Rectangle(0, 0, 70, 5);
        int aniframe = 0;
        public bool flapdown;
        public bool leftward = false;
        public SpriteEffects facingeffect = SpriteEffects.FlipHorizontally;
        CollisionCheck check;
        int playerdirx;
        int playerdiry;
        Rectangle playerfeet;
        MonsterManager mm;
        int maxVel = 20;
        bool following = false;
        int roamframes = 0;
        Random rand = new Random();
        int waitingframes = 100;



        public BookMon1(Player player, MonsterManager mm)
        {
            this.player = player;
            id = 35;
            hitrank = 7;
            hitbox = new Rectangle(1200, 500, 80, 80);
            check = player.colcheck;
            bounce = 100;
            this.mm = mm;



        }

        public void die()
        {
            player.mm.monsters.Remove(this);
            player.mm.particleManager.addManaSmall(hitbox.X + 20, hitbox.Y, 1, -5, 32, 0.2f);
            player.mm.particleManager.addManaSmall(hitbox.X + 30, hitbox.Y + 40, -1, -5, 32, 0.2f);
            player.mm.particleManager.addManaSmall(hitbox.X + 60, hitbox.Y + 40, 0, -8, 32, 0.1f);
        }

        public override void hit(Entity entity)
        {




                die();
;









        }

        public override void update()
        {
            following = false;
            yvel += 1;
            xvel = 0;

            playerdirx = hitbox.X - player.hitbox.X;
            playerdiry = hitbox.Y - player.hitbox.Y;
            if (playerdiry < 200 && playerdiry > -200 && playerdirx < 500 && playerdirx > -500)
            {
                following = true;
                if (playerdirx < -5)
                {
                    xvel += 2;
                    if (facingeffect == SpriteEffects.None)
                    {
                        facingeffect = SpriteEffects.FlipHorizontally;
                    }
                }
                else if (playerdirx > 5)
                {
                    xvel -= 2;
                    if (facingeffect == SpriteEffects.FlipHorizontally)
                    {
                        facingeffect = SpriteEffects.None;
                    }
                }
            }
            else
            {
                if(roamframes == 0)
                {
                    if(waitingframes == 0)
                    {
                        if(rand.Next(0,2) == 0)
                        {
                            roamframes = rand.Next(60, 100);
                        }
                        else
                        {
                            roamframes = rand.Next(-100, -60);
                        }
                        
                        waitingframes = rand.Next(100,500);
                    }
                    else
                    {
                        waitingframes--;
                    }
                }
                else
                {
                    following = true;
                    
                    if (roamframes > 0)
                    {
                        roamframes--;

                        xvel += 2;
                        facingeffect = SpriteEffects.FlipHorizontally;

                    }
                    else
                    {
                        roamframes++;
                        xvel -= 2;

                        facingeffect = SpriteEffects.None;
                    }
                        
                }


            }

           

            colliding = false;
            grounded = false;
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

            hitbox.X += xvel;
            hitbox.Y += yvel;

            hitCheck();






            aniframe++;
            if (following)
            {
                if (aniframe % 12 == 1)
                {

                    cropbox.X += 128;
                    if (cropbox.X > 700)
                    {
                        cropbox.X = 0;
                        flapdown = false;

                    }



                }
            }
            else
            {
                cropbox.X = 0;
            }

            if (aniframe == 84)
            {
                aniframe = 0;
                // cropbox.X = 0;
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
            drawbox.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            // _spriteBatch.Draw(battexture, drawbox, cropbox, Color.White);
            _spriteBatch.Draw(texture, drawbox, cropbox, Color.White, 0, Vector2.Zero, facingeffect, 1);
        }




    }
}
