using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class CantripScroll: HoldItem
    {
        public Cantrip spell;
        public Rectangle symbcroprect;
        public Texture2D symbols;
        public Rectangle symbdrawrect;
        public ItemManager itemManager;



        public CantripScroll(CollisionCheck check, Player player, ItemManager itemManager,Cantrip spell) : base(check, player)
        {
            this.id = 106;
            this.player = player;
            this.check = check;
            holdoffset = 0;
            xmidoffset = 5;
            xleftholdoffset = -20;
            xrightholdoffset = 30;
            throwvel = 8;
            spriteEffects = SpriteEffects.None;
            this.itemManager = itemManager;
            symbols = itemManager.magicsymbols;
            symbdrawrect = new Rectangle(0, 0, 40, 40);
            this.spell = spell;
            symbcroprect = spell.symbcroprect;


            setDefaultValues();
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 70;
            hitbox.Height = 70;

            croprect.X = 384;
            croprect.Y = 128;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 100, 100);
            bounce = 5;



        }
        public override void hit(Entity entity)
        {

            xvel = entity.xvel / 2;
            yvel = entity.yvel / 2;
            if (this == player.heldItem)
            {
                player.prevheldItem = this;
                hitbox.Y = player.hitbox.Y;
                hitbox.X = player.hitbox.X + xmidoffset;
                player.heldItem = null;
            }

        }
        public override void update()
        {
            //gravity
            yvel += (player.frameCounter.frame % 2);
            pickupAble = false;



            colliding = false;
            grounded = false;
            check.checkTile(this);

            if (grounded)
            {
                checkPlayer();
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

            



            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;




        }

        public void checkPlayer()
        {
            
                if (hitbox.Intersects(player.hitbox))
                {
                player.cantrip = spell;
                itemManager.items.Remove(this);
                    

                }
            
        }

       

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - 20 - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - 20 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);

            symbdrawrect.X = drawrect.X + 30;
            symbdrawrect.Y = drawrect.Y + 30;
            _spriteBatch.Draw(symbols, symbdrawrect, symbcroprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
        public void drawforshop(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);

            symbdrawrect.X = drawrect.X + 30;
            symbdrawrect.Y = drawrect.Y + 30;
            _spriteBatch.Draw(symbols, symbdrawrect, symbcroprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }


    }
}
