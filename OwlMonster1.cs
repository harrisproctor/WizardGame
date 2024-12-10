using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class OwlMonster1 : Entity
    {

        public Player player;
        //Rectangle hitbox = new Rectangle(1200, 500, 80, 80);
        Rectangle drawbox = new Rectangle(0, 0, 100, 100);
        Rectangle cropbox = new Rectangle(0, 0, 128, 128);
        Rectangle tophitbox = new Rectangle(0, 0, 70, 5);
        int aniframe = 0;
        public bool flapdown;
        public bool leftward = false;
        public SpriteEffects facingeffect = SpriteEffects.None;
        CollisionCheck check;
        int playerdirx;
        int playerdiry;
        Rectangle playerfeet;
        MonsterManager mm;




        public OwlMonster1(Player player, MonsterManager mm)
        {
            this.player = player;
            id = 33;
            hitbox = new Rectangle(1200, 500, 80, 50);
            check = player.colcheck;
            bounce = 100;
            this.mm = mm;



        }

        public override void hit(Entity entity)
        {


            if (entity.id == 101 || entity.id == 102 || entity.id == 103 || entity.id == 104 || entity.id == 105)
            {


                die();




            }
            else if (entity.id == 1)
            {
                if (player.cantrip.id == 1)
                {
                    die();


                }
            }else if(entity.id == 1001) 
            {
                die();
            }
            else if (entity.id == 1002)
            {
                die();
            }






        }

        public void die()
        {
            player.mm.monsters.Remove(this);
            player.mm.particleManager.addManaSmall(hitbox.X + 20, hitbox.Y, 1, -5, 32, 0.2f);
            player.mm.particleManager.addManaSmall(hitbox.X + 30, hitbox.Y + 40, -1, -5, 32, 0.2f);
            player.mm.particleManager.addManaSmall(hitbox.X + 60, hitbox.Y + 40, 0, -8, 32, 0.1f);

            player.mm.particleManager.addOwlFeather(hitbox.X + 20, hitbox.Y, 5, -5);
            player.mm.particleManager.addOwlFeather(hitbox.X + 30, hitbox.Y + 40, -5, -5);
            player.mm.particleManager.addOwlFeather(hitbox.X + 60, hitbox.Y + 40, 0, -8);
        }

        public override void update()
        {
            yvel = 0;
            xvel = 0;

            playerdirx = hitbox.X - player.hitbox.X;
            playerdiry = hitbox.Y - player.hitbox.Y;
            if (playerdirx < -5)
            {
                xvel += 2;
                if (facingeffect == SpriteEffects.FlipHorizontally)
                {
                    facingeffect = SpriteEffects.None;
                }
            }
            else if (playerdirx > 5)
            {
                xvel -= 2;
                if (facingeffect == SpriteEffects.None)
                {
                    facingeffect = SpriteEffects.FlipHorizontally;
                }
            }

            if (playerdiry < 0)
            {
                yvel+=2;
            }
            else
            {
                yvel-=2;
            }


            colliding = false;
            grounded = false;
            check.checkTile(this);


            hitbox.X += xvel;
            hitbox.Y += yvel;

            hitCheck();






            aniframe++;
            if (aniframe % 4 == 1)//4
            {
                if (flapdown)
                {
                    cropbox.X += 128;
                    if (cropbox.X > 600)
                    {
                        cropbox.X -= 128;
                        flapdown = false;

                    }
                }
                else
                {
                    cropbox.X -= 128;
                    if (cropbox.X < 0)
                    {
                        cropbox.X += 128;
                        flapdown = true;

                    }

                }

            }

            if (aniframe == 60)
            {
                aniframe = 0;
                // cropbox.X = 0;
            }


        }

        public void hitCheck()
        {
            if (hitbox.Intersects(player.hitbox))
            {
                tophitbox.X = hitbox.X + 5;
                tophitbox.Y = hitbox.Y;
                playerfeet = new Rectangle(player.hitbox.X + 10, player.hitbox.Y + player.hitbox.Height - 10, player.hitbox.Width - 10, 10); //10
                tophitbox.Height = player.yvel;
                if (tophitbox.Intersects(playerfeet))
                {
                    die();
                    player.yvel = -9;
                }
                else
                {
                    player.hit(this);
                   

                }
            }
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
            drawbox.X = (int)(hitbox.X - 10) - player.centerWorldX + player.centerX;
            drawbox.Y = (int)(hitbox.Y - 30) - player.centerWorldY + player.centerY;
            // _spriteBatch.Draw(battexture, drawbox, cropbox, Color.White);
            _spriteBatch.Draw(texture, drawbox, cropbox, Color.White, 0, Vector2.Zero, facingeffect, 1);
        }




    }
}
