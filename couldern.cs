using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace monowizard
{
    internal class couldern : Entity
    {
        Player player;
        private int maxVel;
        private int hitVel;
        private int aniframes;
        public Rectangle topbox;
        public int ingid1;
        public int ingid2;

        public couldern(Player player)
        {
            drawrect = new Rectangle(256, 256, 256, 256);
            hitbox = new Rectangle(0, 0, 230, 165);
            croprect = new Rectangle(0, 256, 256, 256);
            topbox = new Rectangle(0,0,220,10);

            this.player = player;
            hitVel = 8;
            maxVel = 25;
            xoffset = 10;
            yoffset = 65;
            ingid1 = 0;
            ingid2 = 0;
        }







        public override void update()
        {
            yvel += (player.frameCounter.frame % 2);
            //yvel += 2;
            



            colliding = false;
            grounded = false;
            player.colcheck.checkTilenoE(this);

            //Debug.WriteLine("yvel: " + colliding);
            //Debug.WriteLine("xvel: " + grounded);
            if (grounded)
            {
                //friction
                if (xvel != 0)
                {

                    if (xvel > 0)
                    {
                        xvel -= 1;

                    }
                    else if (xvel < 0)
                    {
                        xvel += 1;

                    }
                }
            }


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


            //hit check
            if (xvel > hitVel)
            {
                hitCheck();
            }
            else if (yvel > hitVel)
            {
                hitCheck();
            }
            else if (xvel < -hitVel)
            {
                hitCheck();
            }
            else if (yvel < -hitVel)
            {
                hitCheck();
            }


            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;
            topbox.X = hitbox.X+5;
            topbox.Y = hitbox.Y-5;
            //hitbox.Y += 1;

            ingCheck();


            aniframes++;
            if (aniframes % 12 == 0)
            {
                croprect.X += 256;
                if (croprect.X > 1000)
                {
                    croprect.X = 0;
                }
            }



        }

        public void ingCheck()
        {
            for (int i = 0; i < player.itemManager.items.Count; i++)
            {
                if (player.itemManager.items[i].hitbox.Intersects(topbox))
                {
                    if(player.itemManager.items[i].ingId != 0)
                    {

                        int ingid = player.itemManager.items[i].ingId;
                        if(player.heldItem == player.itemManager.items[i])
                        {
                            player.heldItem = null;
                        }
                        player.itemManager.items.Remove(player.itemManager.items[i]);
                        //Debug.WriteLine(ingid);
                        if (ingid1 == 0)
                        {
                            ingid1 = ingid;
                        }else if(ingid2 == 0)
                        {
                            ingid2 = ingid;
                        }
                       // Debug.WriteLine(ingid1);
                       // Debug.WriteLine(ingid2);
                        if (ingid1 != 0 && ingid2 != 0)
                        {
                            //Debug.WriteLine(ingid1);
                            //Debug.WriteLine(ingid2);
                            //id 1 = skullshroom, id 4 = batwing,
                            if (ingid1 == 1)
                            {
                                if(ingid2 == 4)
                                {
                                    player.itemManager.addMagicScroll(hitbox.X + 100, hitbox.Y - 70, 7);
                                    player.itemManager.items.Last().yvel = -12;
                                }
                            }
                            else if(ingid1 == 4)
                            {
                                if (ingid2 == 1)
                                {
                                    player.itemManager.addMagicScroll(hitbox.X + 100, hitbox.Y - 70, 7);
                                    player.itemManager.items.Last().yvel = -12;
                                }
                            }
                            ingid1 = 0;
                            ingid2 = 0;
                        }
                    }
                }


            }
        }

        public virtual void hitCheck()
        {
            
                if (hitbox.Intersects(player.hitbox))
                {
                    player.hit(this);

                }

      
                for (int i = 0; i < player.mm.monsters.Count; i++)
                {


                    if (hitbox.Intersects(player.mm.monsters[i].hitbox))
                    {


                        player.mm.monsters[i].hit(this);



                    }


                }



            

        }



        public override void draw(SpriteBatch _spriteBatch)
        {
            drawrect.X = (int)hitbox.X - xoffset - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - yoffset - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Microsoft.Xna.Framework.Vector2.Zero, SpriteEffects.None, 1);

        }
    }
}
