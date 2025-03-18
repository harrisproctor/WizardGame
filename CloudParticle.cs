using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class CloudParticle : Entity
    {
        public int maxVel = 25;
        public int hitVel = 5;
        public Rectangle croprect;
        int hoverframes = 0;
        int hoverdir = 1;
        int aniframe;
        int drawbuff;
        int playerdistx;
        int playerdisty;
        //float manavalue = 0.2f;
        int xdir = -1;
        int swaycount = 0;
        int lifetime = 0;


        public SpriteEffects spriteEffects;
        CollisionCheck check;
        Player player;
        ParticleManager particleManager;



        public CloudParticle(CollisionCheck check, Player player, ParticleManager particleManager, int size)
        {
            id = 9888;
            this.player = player;
            this.check = check;
            spriteEffects = SpriteEffects.None;
           // manavalue = mana;
            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = size / 2;
            hitbox.Height = size / 2;
            drawbuff = size / 4;
            drawrect = new Rectangle(0, 0, size, size);
            croprect = new Rectangle(0, 0, 128, 128);
            bounce = 5;
            this.particleManager = particleManager;
            swaycount = particleManager.rnd.Next(0, 50);
            hoverframes = particleManager.rnd.Next(0, 50);
        }

        public override void update()
        {
            //gravity
            yvel = (player.frameCounter.frame % 2) * hoverdir;
            xvel = xdir;


            colliding = false;
            grounded = false;
            check.checkTile(this);

            if (grounded)
            {
                hoverframes = 200;
            }

            if (hoverframes == 0)
            {
                hoverdir = 1;
            }
            else
            {
                hoverdir = -1;
                hoverframes--;
            }
            swaycount++;
            if (swaycount > 10)
            {
                xdir = -xdir;
                swaycount = 0;
                lifetime++;
            }

            if (lifetime > 8)
            {
                particleManager.items.Remove(this);
            }









            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;

            // playerhitcheck();

            //animate
            aniframe = (aniframe + 1) % 41;
            croprect.X = (aniframe > 30) ? 256 : (aniframe / 10) * 128;






        }

        public void playerhitcheck()
        {

        }


        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - drawbuff - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - drawbuff - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }


    }
}
