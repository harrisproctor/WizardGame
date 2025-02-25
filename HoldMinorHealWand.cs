using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldMinorHealWand : HoldItem
    {
        public HoldMinorHealWand(CollisionCheck check, Player player) : base(check, player)
        {
            this.id = 102;
            this.player = player;
            this.check = check;
            holdoffset = 20;
            xmidoffset = 25;
            xleftholdoffset = -20;
            xrightholdoffset = 60;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;

            setDefaultValues();


        }
        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 40;
            hitbox.Height = 50;

            croprect.X = 0;
            croprect.Y = 256;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 64, 64);
            bounce = 10;



        }
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - 10 - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - 5 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
