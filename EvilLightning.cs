using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class EvilLightning : Entity
    {
        int maxVel = 25;
        int hitVel = 5;

        Player player;
        CollisionCheck check;
        float directionX;
        float directionY;
        MagicManager manager;
        Rectangle cropbox;
        float rotat;
        Vector2 middlepoint = new Vector2(32, 32);
        SpriteEffects spriteEffects = SpriteEffects.None;
        int offsetx;
        int offsety;
        int aniframe = 0;
        int destind = -1;

        public EvilLightning(CollisionCheck collisionCheck, Player player, int x, int y, float dirx, float diry, MagicManager magicManager)
        {
            this.player = player;
            check = collisionCheck;
            manager = magicManager;
            id = 1055;
            drawrect = new Rectangle(x, y, 64, 64);
            hitbox = new Rectangle(x, y, 40, 40);
            cropbox = new Rectangle(384, 0, 128, 128);
            directionX = dirx;
            directionY = diry;
            bounce = 98;
            hitrank = 4;





        }

        public override void update()
        {

            xvel = (int)Math.Floor(directionX * 10);
            yvel = (int)Math.Floor(directionY * 10);

            colliding = false;
            grounded = false;

            destind = check.checkTileRet(this);

            if (colliding || grounded)
            {
                manager.items.Remove(this);
                if(destind != -1)
                {
                 
                    check.tileManager.breaktile(destind);
                }


            }

            //hit checl
            hitCheck();

            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;

            //animete
            aniframe = (aniframe + 1) % 31;
            cropbox.Y = (aniframe > 20) ? 256 : (aniframe / 10) * 128;




        }
        public override void hit(Entity entity)
        {


        }
        public void hitCheck()
        {

            if (hitbox.Intersects(player.hitbox))
            {
                player.hit(this);
                manager.items.Remove(this);


            }

            for (int i = 0; i < player.itemManager.items.Count; i++)
            {


                if (hitbox.Intersects(player.itemManager.items[i].hitbox))
                {


                    player.itemManager.items[i].hit(this);
                    manager.items.Remove(this);



                }


            }
            for (int i = 0; i < player.mm.monsters.Count; i++)
            {
                if (hitbox.Intersects(player.mm.monsters[i].hitbox))
                {
                    if(!(player.mm.monsters[i] is BrainShopKeep))
                    {
                        player.mm.monsters[i].hit(this);
                        manager.items.Remove(this);
                    }
                    
                }

            }

                /* for (int i = 0; i < manager.items.Count; i++)
                 {


                     if (hitbox.Intersects(manager.items[i].hitbox))
                     {


                         manager.items[i].hit(this);
                         manager.items.Remove(this);



                     }



                 }*/
            }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X + offsetx - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y + offsety - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, cropbox, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }






    }
}
