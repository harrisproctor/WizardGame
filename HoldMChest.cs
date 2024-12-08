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
    internal class HoldMChest : HoldItem
    {
        bool open = false;
        public ItemManager itemManager;
        Random random;

        public HoldMChest(CollisionCheck check, Player player,ItemManager itemManager) : base(check, player)
        {
            this.id = 104;
            this.player = player;
            this.check = check;
            holdoffset = 0;
            xmidoffset = 5;
            xleftholdoffset = -20;
            xrightholdoffset = 30;
            throwvel = 8;
            spriteEffects = SpriteEffects.None;
            this.itemManager = itemManager;
            random = new Random();
            
            

            setDefaultValues();
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 70;
            hitbox.Height = 70;

            croprect.X = 128;
            croprect.Y = 0;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 128, 128);
            bounce = 5;



        }
        public override void hit(Entity entity)
        {

            xvel = entity.xvel / 2;
            yvel = entity.yvel / 2;
            if (this == player.heldItem)
            {
                player.prevheldItem = this;
                hitbox.Y = player.hitbox.Y;
                hitbox.X = player.hitbox.X + xmidoffset;
                player.heldItem = null;
            }
            
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
            checkChest();
            


            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;




        }

        public void checkChest()
        {
            if (open == false)
            {
                if (hitbox.Intersects(player.itemManager.items[player.itemManager.MKeyind].hitbox))
                {
                    openChest();
                    open = true;
                    
                }
            }
        }

        public void openChest()
        {
            // Debug.WriteLine("grey hirse");

            croprect.X = 256;
            int spell = random.Next(1, 7);
            itemManager.addMagicScroll(hitbox.X,hitbox.Y-20,spell);
            itemManager.items.Last().yvel = -12;
            
            
        }
 
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - 20 - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - 20 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
