using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace monowizard
{
    internal class HoldItem : Entity
    {
       
        public int maxVel = 25;
        public int hitVel = 5;
        public int throwvel;
        public Rectangle croprect;
        public int holdoffset;
        public int xmidoffset;
        public int xleftholdoffset;
        public int xrightholdoffset;
        public SpriteEffects spriteEffects;
        
        public bool pickupAble = false;
        public Player player;
        public CollisionCheck check;

        



        public HoldItem(CollisionCheck check,Player player)
        {
            id = 101;
            this.check = check;
            this.player = player;
            holdoffset = 30;
            xmidoffset = 25;
            xleftholdoffset = -5;
            xrightholdoffset = 60;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;

            setDefaultValues();
          
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 32;
            hitbox.Height = 32;
            drawrect = new Rectangle(0, 0, 32, 32);
            bounce = 5;



        }

       

        public override void update()
        {
            //gravity
            yvel += (player.frameCounter.frame % 2);
            pickupAble = false;


            
                colliding = false;
                grounded = false;
                check.checkTile(this);

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
                else if(xvel < -maxVel)
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

            


        }

        public override void hit(Entity entity)
        {
            
            xvel = entity.xvel/2;
            yvel = entity.yvel / 2;
            if(this == player.heldItem)
            {
                player.prevheldItem = this;
                hitbox.Y = player.hitbox.Y;
                hitbox.X = player.hitbox.X + xmidoffset;
                player.heldItem = null;
            }
        }

        public virtual void hitCheck()
        {
            if(this != player.heldItem) { 
            if (hitbox.Intersects(player.hitbox)) {
                player.hit(this);
            
            }
            
                for (int i = 0;i < player.itemManager.items.Count; i++) 
                {

                    if (this != player.itemManager.items[i])
                    {
                        if (hitbox.Intersects(player.itemManager.items[i].hitbox))
                        {


                            player.itemManager.items[i].hit(this);
                            


                        }
                    }

                }
                for (int i = 0; i < player.mm.monsters.Count; i++)
                {

                    
                        if (hitbox.Intersects(player.mm.monsters[i].hitbox))
                        {


                            player.mm.monsters[i].hit(this);



                        }
                    

                }



            }

        }
        
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, Color.White);


        }



    }
}
