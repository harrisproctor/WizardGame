﻿using Microsoft.Xna.Framework;
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

        public HoldShopItem(CollisionCheck check, Player player,HoldItem truth) : base(check, player)
        {
            this.id = 200;
            this.player = player;
            this.check = check;
            holdoffset = 30;
            xmidoffset = 5;
            xleftholdoffset = -20;
            xrightholdoffset = 30;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;
            trueItem = truth;


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

            id = trueItem.id;

            drawrect = trueItem.drawrect;
            bounce = 5;



        }

        public override void update()
        {
            base.update();
            if (hitbox.Intersects(player.hitbox) && uinum == null)
            {
                ishovered = true;
                uinum = player.ui.addUINumber(drawrect.X, drawrect.Y-100, 699);
                //  Debug.WriteLine("Player hit");



            }
            else if (!hitbox.Intersects(player.hitbox) && uinum != null)
            {
                ishovered = false;
                
                    player.ui.items.Remove(uinum);
                
                
                uinum = null;
            }
            else
            {
                if(uinum != null)
                {
                    drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
                    drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
                    uinum.Relocate(drawrect.X-40, drawrect.Y - 200, 80, 80);
                }
                if (player.epressed)
                {
                    Debug.WriteLine("shit fart");
                }
            }
            
                
                    
                
            

        }



        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }






    }
}