using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldMKey : HoldItem
    {
        public HoldMKey(CollisionCheck check, Player player) : base(check, player)
        {
            this.id = 103;
            this.player = player;
            this.check = check;
            holdoffset = 30;
            xmidoffset = 5;
            xleftholdoffset = -20;
            xrightholdoffset = 30;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;

            setDefaultValues();
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 70;
            hitbox.Height = 40;

            croprect.X = 0;
            croprect.Y = 0;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 96, 96);
            bounce = 5;



        }
       
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - 10 - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - 25 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
