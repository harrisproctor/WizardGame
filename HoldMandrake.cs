using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class HoldMandrake : HoldItem
    {
        int manasucktime = 0;
        bool sucking = true;
        int spawnoffsety = 0;
        int spawnoffsetx = 0;
        int partsize = 32;
        int aniframes = 0;

        public HoldMandrake(CollisionCheck check, Player player) : base(check, player)
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
            xoffset = 15;
            setDefaultValues();
        }

        public void setDefaultValues()
        {

            hitbox.X = 200;
            hitbox.Y = 200;
            hitbox.Width = 50;
            hitbox.Height = 60;

            croprect.X = 0;
            croprect.Y = 0;
            croprect.Width = 128;
            croprect.Height = 128;

            drawrect = new Rectangle(0, 0, 80, 80);
            bounce = 5;



        }

        public override void update()
        {
            base.update();
            aniframes++;
            if (aniframes % 15 == 0)
            {
                croprect.X += 128;
                if (croprect.X > 400)
                {
                    croprect.X = 128;
                }
            }
        }
        public override void playeritemupdate()
        {
            update();
            //itemupdate();
        }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X - xoffset - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, croprect, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }
    }
}
