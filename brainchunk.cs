using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace monowizard
{
    internal class brainchunk : Entity
    {

        public int maxVel = 25;
        public int hitVel = 5;
        public Rectangle croprect;
       
        public SpriteEffects spriteEffects;
        CollisionCheck check;
        Player player;
        ParticleManager particleManager;
        


        public brainchunk(CollisionCheck check,Player player, ParticleManager particleManager)
        {
            id = 101;
            this.player = player;
            this.check = check;
            spriteEffects = SpriteEffects.None;


            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 32;
            hitbox.Height = 32;
            drawrect = new Rectangle(0, 0, 64, 64);
            croprect = new Rectangle(128, 0, 128, 128);
            bounce = 5;
            this.particleManager = particleManager;
        }

        public override void update()
        {
            //gravity
            yvel += (player.frameCounter.frame % 2);



            colliding = false;
            grounded = false;
            check.checkTile(this);

            if (grounded)
            {
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



            drawrect.X = (int)hitbox.X - 16 - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - 16 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }




    }
}
