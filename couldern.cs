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

        public couldern(Player player)
        {
            drawrect = new Rectangle(256, 256, 256, 256);
            hitbox = new Rectangle(0, 0, 256, 180);
            croprect = new Rectangle(0, 256, 256, 256);
            this.player = player;
            hitVel = 8;
            maxVel = 25;
            xoffset = 0;
            yoffset = 50;
        }







        public override void update()
        {
            yvel += (player.frameCounter.frame % 2);
            //yvel += 2;
            



            colliding = false;
            grounded = false;
            player.colcheck.checkTile(this);

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
            //hitbox.Y += 1;


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
