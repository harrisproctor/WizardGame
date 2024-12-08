using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class WindParticle : Entity
    {

        public int maxVel = 25;
        public int hitVel = 5;
        public Rectangle croprect;
        public Vector2 center;
        float rotat = 0;
        float rotatby = 0;


        public SpriteEffects spriteEffects;
        CollisionCheck check;
        Player player;
        ParticleManager particleManager;



        public WindParticle(CollisionCheck check, Player player, ParticleManager particleManager,int facing)
        {
            id = 101;
            this.player = player;
            this.check = check;
            
            if(facing == 0)
            {
                spriteEffects = SpriteEffects.None;
                rotatby = -0.1f;
            }
            else
            {
                spriteEffects = SpriteEffects.FlipHorizontally;

                rotatby = 0.1f;
            }


            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 32;
            hitbox.Height = 32;
            center = new Vector2(64, 64);
            drawrect = new Rectangle(0, 0, 64, 64);
            croprect = new Rectangle(384, 0, 128, 128);
            bounce = 5;
            this.particleManager = particleManager;
        }

        public override void update()
        {



            yvel = 1;

            colliding = false;
            grounded = false;
            check.checkTile(this);
            rotat += rotatby;
            
            if (grounded || colliding)
            {
                particleManager.items.Remove(this);
            }
            if (rotat > 12 || rotat < -12)
            {
                rotat = 0;
                particleManager.items.Remove(this);
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




            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;




        }


        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X  - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, rotat, center, spriteEffects, 1);


        }





    }
}
