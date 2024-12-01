using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldCrystalRock : HoldItem
    {
        public HoldCrystalRock(CollisionCheck check, Player player) : base(check, player)
        {
            this.id = 101;
            this.player = player;
            this.check = check;
            holdoffset = 30;
            xmidoffset = 25;
            xleftholdoffset = 0;
            xrightholdoffset = 60;
            throwvel = 14;
            spriteEffects = SpriteEffects.None;

            setDefaultValues();


        }
        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 40;
            hitbox.Height = 35;

            croprect.X = 0;
            croprect.Y = 128;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 40, 40);
            bounce = 5;



        }
        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
