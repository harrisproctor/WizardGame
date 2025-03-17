using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace monowizard
{
    internal class HoldShopItem : HoldItem
    {
        HoldItem trueItem = null;
        public bool ishovered = false;
        public UIString uinum = null;
        public int price;
        public int shopind;
        public Rectangle shoprect;
        public Rectangle symbdrawrect;
        public CantripScroll sepll;

        public HoldShopItem(CollisionCheck check, Player player,HoldItem truth,int shopind,int price) : base(check, player)
        {
            this.id = 200;
            this.player = player;
            this.check = check;
            this.price = price;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;
            trueItem = truth;
            this.shopind = shopind;
            shoprect = new Rectangle((shopind % 4) *960, (shopind / 4) * 960,960,960);
            if (trueItem is CantripScroll)
            {
              //  Debug.WriteLine("Cantrip");
                sepll = trueItem as CantripScroll; 
                sepll.symbols = player.itemManager.magicsymbols;
                sepll.texture = player.itemManager.libitems1;
            }



            setDefaultValues();
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = trueItem.hitbox.Width;
            hitbox.Height = trueItem.hitbox.Height;

            croprect.X = trueItem.croprect.X;
            croprect.Y = trueItem.croprect.Y;
            croprect.Width = trueItem.croprect.Width;
            croprect.Height = trueItem.croprect.Height;
            holdoffset = trueItem.holdoffset;
            xmidoffset = trueItem.xmidoffset;
            xleftholdoffset = trueItem.xleftholdoffset;
            xrightholdoffset = trueItem.xrightholdoffset;

            id = trueItem.id;

            drawrect = trueItem.drawrect;
            bounce = 5;



        }

        public override void update()
        {
            base.update();

            if (hitbox.Intersects(shoprect))
            {
                if (hitbox.Intersects(player.hitbox) && uinum == null)
                {
                    ishovered = true;
                    uinum = player.ui.addUINumber(drawrect.X - 40, drawrect.Y - 100, price);
                    //  Debug.WrihitbteLine("Player hit");



                }
                else if (!hitbox.Intersects(player.hitbox) && uinum != null)
                {
                    ishovered = false;

                    player.ui.items.Remove(uinum);
                    Debug.WriteLine(uinum != null);

                    uinum = null;
                }
                else
                {

                    if (uinum != null && this == player.heldItem)
                    {
                       // Debug.WriteLine("gos is sed");
                        drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
                        drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
                        uinum.Relocate(drawrect.X - 40, drawrect.Y - 200, 80, 80);

                        if (player.epressed)
                        {
                            if (player.mana > price)
                            {
                                delete();
                                player.itemManager.itemsinshop.Remove(this);
                                player.changeMana(-price);
                            }
                        }
                    }

                }
            }
            else {
                //robbery
                //delete();
                player.itemManager.robbedShop();
                
            
            }
            
                
                    
                
            

        }

        public void delete()
        {
            if (trueItem is HoldBook)
            {
                player.itemManager.addBook(hitbox.X, hitbox.Y);
                

            }
            else if (trueItem is HoldCrystalRock)
            {
                player.itemManager.addCrystalRock(hitbox.X, hitbox.Y);
            }
            else if (trueItem is HoldMKey)
            {
                player.itemManager.addMKey(hitbox.X, hitbox.Y);
            }
            else if (trueItem is CantripScroll)
            {

                player.itemManager.addMagicScroll(hitbox.X, hitbox.Y,sepll.cantripnum);
            }
            else if (trueItem is HoldMinorHealWand)
            {

                player.itemManager.addMinorHealWand(hitbox.X, hitbox.Y);
            }
            else if (trueItem is HoldMagicArrowWand)
            {

                player.itemManager.addMagicArrowWand(hitbox.X, hitbox.Y);
            }

            if (this == player.heldItem)
            {
                player.heldItem = player.itemManager.items.Last();
            }

            //player.changeMana(-10);
            player.itemManager.addMomentum(xvel, yvel);

            ishovered = false;

            player.ui.items.Remove(uinum);


            uinum = null;
            player.itemManager.items.Remove(this);
            //player.itemManager.itemsinshop.Remove(this);
        }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
             _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);
            if (trueItem is CantripScroll) 
            {
            sepll.drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
            sepll.drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            sepll.drawforshop(_spriteBatch);

            }


        }






    }
}
