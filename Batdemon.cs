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
    internal class Batdemon : Entity
    {
        //public Texture2D battexture;
        public Player player;
        //Rectangle hitbox = new Rectangle(1200, 500, 80, 80);
        Rectangle drawbox = new Rectangle(0, 0, 128, 128);
        Rectangle cropbox = new Rectangle(0, 0, 128, 128);
        Rectangle tophitbox = new Rectangle(0, 0, 90, 5);
        int aniframe = 0;
        public bool flapdown;
        public bool leftward = false;
        public SpriteEffects facingeffect = SpriteEffects.None;
        CollisionCheck check;
        int playerdirx;
        int playerdiry;
        Rectangle playerfeet;
        MonsterManager mm;




        public Batdemon(Player player,MonsterManager mm)
        {
            this.player = player;
            id = 33;
            hitbox = new Rectangle(1200, 500, 100, 80);
            check = player.colcheck;
            bounce = 100;
            this.mm = mm;
            


        }

        public override void update()
        {
            yvel = 0;
            xvel = 0;

            playerdirx = hitbox.X - player.hitbox.X;
            playerdiry = hitbox.Y - player.hitbox.Y;
            if (playerdirx < -5)
            {
                xvel++;
                if(facingeffect == SpriteEffects.FlipHorizontally)
                {
                    facingeffect = SpriteEffects.None;
                }
            }
            else if (playerdirx > 5) 
            {
                xvel--;
                if (facingeffect == SpriteEffects.None)
                {
                    facingeffect = SpriteEffects.FlipHorizontally;
                }
            }

            if (playerdiry < -20)
            {
                yvel++;
            }
            else
            {
                yvel--;
            }


            colliding = false;
            grounded = false;
            check.checkTile(this);
            

            hitbox.X += xvel;
            hitbox.Y += yvel;

            hitCheck();






            aniframe++;
            if (aniframe % 5 == 1)
            {
                if (flapdown)
                {
                    cropbox.X += 128;
                    if(cropbox.X > 700)
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

            if(aniframe == 60)
            {
                aniframe = 0;
               // cropbox.X = 0;
            }


        }

        public void hitCheck()
        {
            if (hitbox.Intersects(player.hitbox))
            {
                tophitbox.X = hitbox.X+5;
                tophitbox.Y = hitbox.Y;
                playerfeet = new Rectangle(player.hitbox.X+10, player.hitbox.Y + player.hitbox.Height - 10, player.hitbox.Width - 10, 10); //10
                tophitbox.Height = player.yvel;
                if (tophitbox.Intersects(playerfeet))
                {
                    hitbox.X +=500;
                }
                else
                {
                    player.xvel += xvel*4;
                }
            }
        }

        public override void draw(SpriteBatch _spriteBatch)
        {
            drawbox.X = (int)(hitbox.X-10) - player.centerWorldX + player.centerX;
            drawbox.Y = (int)(hitbox.Y-20) - player.centerWorldY + player.centerY;
           // _spriteBatch.Draw(battexture, drawbox, cropbox, Color.White);
            _spriteBatch.Draw(texture, drawbox, cropbox,  Color.White,0,Vector2.Zero, facingeffect,1);
        }
    }
}
