﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class MagicArrow2 : Entity
    {

        int maxVel = 25;
        int hitVel = 5;

        Player player;
        CollisionCheck check;
        int directionX;
        int directionY;
        MagicManager manager;
        Rectangle cropbox;
        float rotat;
        Vector2 middlepoint = new Vector2(32, 32);
        SpriteEffects spriteEffects = SpriteEffects.None;
        int offsetx;
        int offsety;
        Entity magcol;
        int aniframe = 0;



        public MagicArrow2(CollisionCheck collisionCheck, Player player, int x, int y, int dirx, int diry, MagicManager magicManager, float rotat)
        {
            this.player = player;
            check = collisionCheck;
            manager = magicManager;
            id = 1001;
            hitrank = 3;
            drawrect = new Rectangle(x, y, 64, 64);
            hitbox = new Rectangle(x, y, 32, 32);
            cropbox = new Rectangle(128, 0, 128, 128);
            directionX = dirx;
            directionY = diry;
            bounce = 100;
            this.rotat = rotat;
            if (dirx == 1)
            {
                cropbox = new Rectangle(512, 0, 128, 128);
                spriteEffects = SpriteEffects.FlipHorizontally;
                offsetx = -16;
                offsety = -10;
            }
            else if (dirx == -1)
            {
                cropbox = new Rectangle(512, 0, 128, 128);
                offsetx = -16;
                offsety = -10;
            }
            else if (diry == -1)
            {
                cropbox = new Rectangle(0, 256, 128, 128);
                offsetx = -8;
                offsety = 0;
            }
            else if (diry == 1)
            {
                spriteEffects = SpriteEffects.FlipVertically;
                cropbox = new Rectangle(0, 256, 128, 128);
                offsetx = -16;
                offsety = -32;
            }

        }

        public override void update()
        {




            xvel = directionX * 15;
            yvel = directionY * 15;

            colliding = false;
            grounded = false;

            check.checkTile(this);

            if (colliding || grounded)
            {
                manager.items.Remove(this);

            }


            //hit checl
            hitCheck();



            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;

            if(directionX != 0)
            {
                //animete
                aniframe = (aniframe + 1) % 31;
                cropbox.Y = (aniframe > 20) ? 384 : (aniframe / 10) * 128;
            }




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


                    player.mm.monsters[i].hit(this);
                    manager.items.Remove(this);



                }


            }

            for (int i = 0; i < manager.items.Count; i++)
            {

                if (manager.items[i] != this)
                {
                    if (hitbox.Intersects(manager.items[i].hitbox))
                    {
                        magcol = manager.items[i];
                        if (magcol.hitrank == 3 || magcol.hitrank == 4 || magcol.hitrank == 5)
                        {
                            manager.items.Remove(this);
                        }

                    }
                }


            }
            if (magcol != null)
            {

                if (magcol.hitrank == 1 || magcol.hitrank == 2 || magcol.hitrank == 3)
                {
                    manager.items.Remove(magcol);
                }





            }






        }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X + offsetx - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y + offsety - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, cropbox, Color.White, rotat, Vector2.Zero, spriteEffects, 1);


        }


    }
}
