using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldManaIdol : HoldItem
    {
        public HoldManaIdol(CollisionCheck check, Player player) : base(check, player)
        {
            this.id = 105;
            this.player = player;
            this.check = check;
            holdoffset = 20;
            xmidoffset = 25;
            xleftholdoffset = -20;
            xrightholdoffset = 60;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;

            setDefaultValues();


        }
        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 40;
            hitbox.Height = 50;

            croprect.X = 384;
            croprect.Y = 0;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 64, 64);
            bounce = 5;



        }

        public override void update()
        {
            //gravity
            yvel += (player.frameCounter.frame % 2);
            pickupAble = false;



            colliding = false;
            grounded = false;
            onExit = false;
            check.checkTile(this);
            check.eitemCheck(this);

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
                if (onExit)
                {
                    player.changeMana(10);
                    player.itemManager.items.Remove(this);

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




        }


        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - 10 - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - 5 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);
        }



    }
}
