using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldSkullShroom : HoldItem
    {
        int aniframes = 0;
        public HoldSkullShroom(CollisionCheck check, Player player) : base(check, player)
        {
            this.id = 102;
            this.player = player;
            this.check = check;
            holdoffset = 10;
            xmidoffset = 25;
            xleftholdoffset = -10;
            xrightholdoffset = 40;
            throwvel = 13;
            spriteEffects = SpriteEffects.None;
            xoffset = 10;
            setDefaultValues();
            ingId = 1;
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 50;
            hitbox.Height = 60;

            croprect.X = 512;
            croprect.Y = 0;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 80, 80);
            bounce = 5;

        }

        public override void playeritemupdate()
        {
            update();
            //itemupdate();
        }
        public override void update()
        {
            base.update();
            aniframes++;
            if (aniframes % 15 == 0)
            {
                croprect.X += 128;
                if (croprect.X > 1000)
                {
                    croprect.X = 512;
                }
            }
        }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - xoffset - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }



    }
}
