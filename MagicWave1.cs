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
    internal class MagicWave1 : Entity
    {
        int maxVel = 25;
        int hitVel = 5;

        Player player;
        CollisionCheck check;
        int facing;
        int down;
        MagicManager manager;
        Rectangle cropbox;
        float rotat;
        Vector2 middlepoint = new Vector2(64, 128);
        SpriteEffects effectflip = SpriteEffects.None;
        int floortype;
        int frontoffsetx;
        int frontoffsety;



        public MagicWave1(CollisionCheck collisionCheck, Player player, int x, int y,int facing,int down, MagicManager magicManager, float rotat)
        {
            this.player = player;
            check = collisionCheck;
            manager = magicManager;
            id = 1002;
            drawrect = new Rectangle(x, y, 64, 64);
            hitbox = new Rectangle(x, y, 64, 32);
            cropbox = new Rectangle(0, 0, 128, 128);
            this.facing = facing;
            this.down = down;
            bounce = 100;
            this.rotat = rotat;


            if (down == 3)
            {
                hitbox = new Rectangle(x, y, 64, 45);
                if (facing == 2)
                {
                    cropbox = new Rectangle(128, 256, 128, 128);
                    frontoffsetx = hitbox.Width;
                    effectflip = SpriteEffects.None;
                }
                else
                {

                    cropbox = new Rectangle(0, 0, 128, 128);
                    effectflip = SpriteEffects.None;
                }
            }
            else if(down == 1) 
                {
                hitbox = new Rectangle(x, y, 64, 45);
                if (facing == 2)
                {
                    cropbox = new Rectangle(128, 256, 128, 128);
                    frontoffsetx = hitbox.Width;
                    effectflip = SpriteEffects.FlipVertically;
                }
                else
                {

                    cropbox = new Rectangle(0, 0, 128, 128);
                    effectflip = SpriteEffects.FlipVertically;
                }
            }
            else if (down == 2)
            {
                //Debug.WriteLine("it worked");
                hitbox = new Rectangle(x, y, 45, 64);
                if (facing == 3)
                {
                    cropbox = new Rectangle(128, 128, 128, 128);
                    frontoffsetx = hitbox.Width;
                    effectflip = SpriteEffects.None;
                }
                else
                {

                    cropbox = new Rectangle(0, 128, 128, 128);
                    effectflip = SpriteEffects.FlipHorizontally;
                }

            }
            else if (down == 4)
            {
                //Debug.WriteLine("it worked");
                hitbox = new Rectangle(x, y, 45, 64);
                if (facing == 3)
                {
                    cropbox = new Rectangle(0, 128, 128, 128);
                    frontoffsetx = hitbox.Width;
                    effectflip = SpriteEffects.FlipVertically;
                }
                else
                {

                    cropbox = new Rectangle(0, 128, 128, 128);
                    effectflip = SpriteEffects.None;
                }

            }









        }

        public override void update()
        {



            if (facing == 1)
            {
                yvel = -12;

            }
            else if (facing == 2)
            {
                xvel = 12;
            }
            else if (facing == 3)
            {
                yvel = 12;
            }
            else if (facing == 4)
            {
                xvel = -12;
            }





            //hit checl
            hitCheck();
            floorcheck();



            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;




        }

        public void floorcheck()
        {
            if (down == 3)
            {
                floortype = check.map[((hitbox.X + frontoffsetx) / 96) + (((hitbox.Y + hitbox.Height + 55) / 96) * 40)];
                if (check.tileManager.collides[floortype] == false)
                {
                    manager.items.Remove(this);
                }
                floortype = check.map[((hitbox.X + frontoffsetx) / 96) + (((hitbox.Y + hitbox.Height) / 96) * 40)];
                if (check.tileManager.collides[floortype] == true)
                {
                    manager.items.Remove(this);
                }
            }
            else if (down == 1)
            {
                floortype = check.map[((hitbox.X + frontoffsetx) / 96) + (((hitbox.Y - 55) / 96) * 40)];
                if (check.tileManager.collides[floortype] == false)
                {
                    manager.items.Remove(this);
                }
                floortype = check.map[((hitbox.X + frontoffsetx) / 96) + (((hitbox.Y + hitbox.Height) / 96) * 40)];
                if (check.tileManager.collides[floortype] == true)
                {
                    manager.items.Remove(this);
                }

            }
            else if (down == 4)
            {
                if (facing == 1)
                {
                    floortype = check.map[((hitbox.X - 55) / 96) + (((hitbox.Y) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == false)
                    {
                        manager.items.Remove(this);
                    }
                    floortype = check.map[((hitbox.X) / 96) + (((hitbox.Y) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == true)
                    {
                        manager.items.Remove(this);
                    }
                }
                else
                {
                    floortype = check.map[((hitbox.X - 55) / 96) + (((hitbox.Y + hitbox.Height) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == false)
                    {
                        manager.items.Remove(this);
                    }
                    floortype = check.map[((hitbox.X) / 96) + (((hitbox.Y + hitbox.Height) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == true)
                    {
                        manager.items.Remove(this);
                    }

                }
            }
            else if (down == 2)
            {
                if (facing == 1)
                {
                    floortype = check.map[((hitbox.X + 96) / 96) + (((hitbox.Y) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == false)
                    {
                        manager.items.Remove(this);
                    }
                    floortype = check.map[((hitbox.X) / 96) + (((hitbox.Y) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == true)
                    {
                        manager.items.Remove(this);
                    }
                }
                else
                {
                    floortype = check.map[((hitbox.X + 96) / 96) + (((hitbox.Y + hitbox.Height) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == false)
                    {
                        manager.items.Remove(this);
                    }
                    floortype = check.map[((hitbox.X) / 96) + (((hitbox.Y + hitbox.Height) / 96) * 40)];
                    if (check.tileManager.collides[floortype] == true)
                    {
                        manager.items.Remove(this);
                    }

                }
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





        }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, cropbox, Color.White, 0, Vector2.Zero, effectflip, 1);


        }


    }
}
