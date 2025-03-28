using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class MagicWitchBolt1 : Entity
    {
        int maxVel = 25;
        int hitVel = 5;

        Player player;
        CollisionCheck check;
        float directionX;
        float directionY;
        MagicManager manager;
        Rectangle cropbox;
        float rotat;
        Vector2 middlepoint = new Vector2(32, 32);
        SpriteEffects spriteEffects = SpriteEffects.None;
        int offsetx;
        int offsety;
        int aniframe = 0;
        Entity magcol;
        int[] crazywalk;
        int crazypoint = 0;
        int[] crazywalky;
        int crazypointy = 0;




        public MagicWitchBolt1(CollisionCheck collisionCheck, Player player, int x, int y, float dirx, float diry, MagicManager magicManager)
        {
            this.player = player;
            check = collisionCheck;
            manager = magicManager;
            id = 1001;
            hitrank = 3;
            drawrect = new Rectangle(x, y, 64, 64);
            hitbox = new Rectangle(x, y, 40, 40);
            cropbox = new Rectangle(0, 768, 128, 128);
            directionX = dirx;
            directionY = diry;
            bounce = 86;
            crazywalk = new int[] {-5,-5,-5,-5,-10,-8,5,5,5,5,10,8};
            crazywalky = new int[] { -5, -5, -5, -5, 5, 5, 5, 5 };






        }

        public override void update()
        {
            if(crazypoint >= crazywalk.Length-1)
            {
                crazypoint = 0;
            }
            else
            {
                crazypoint++;
            }

            if (crazypointy >= crazywalky.Length - 1)
            {
                crazypointy = 0;
            }
            else
            {
                crazypointy++;
            }



            xvel = (int)Math.Floor(directionX * 10) + crazywalky[crazypointy];
            yvel = (int)Math.Floor(directionY * 10)+ crazywalk[crazypoint];

            colliding = false;
            grounded = false;

            check.checkTile(this);

            if (colliding || grounded)
            {
                manager.items.Remove(this);

            }

            //hit checl
            hitCheck();

            //applie sphysiocs
            hitbox.X += xvel;
            hitbox.Y += yvel;

            //animete
            aniframe = (aniframe + 1) % 31;
            cropbox.X = (aniframe > 20) ? 256 : (aniframe / 10) * 128;




        }
        public override void hit(Entity entity)
        {


        }
        public void hitCheck()
        {

            if (hitbox.Intersects(player.hitbox))
            {
                player.hit(this);
                manager.items.Remove(this);


            }

            for (int i = 0; i < player.itemManager.items.Count; i++)
            {


                if (hitbox.Intersects(player.itemManager.items[i].hitbox))
                {


                    player.itemManager.items[i].hit(this);
                    manager.items.Remove(this);



                }


            }
            for (int i = 0; i < manager.items.Count; i++)
            {

                if (manager.items[i] != this)
                {
                    if (hitbox.Intersects(manager.items[i].hitbox))
                    {


                        magcol = manager.items[i];
                        if (magcol.hitrank == 3 || magcol.hitrank == 4 || magcol.hitrank == 5)
                        {
                            manager.items.Remove(this);
                        }
                        





                    }
                }


            }
            if (magcol != null)
            {

                if (magcol.hitrank == 1 || magcol.hitrank == 2 || magcol.hitrank == 3)
                {
                    manager.items.Remove(magcol);
                }





            }



        }

        public override void draw(SpriteBatch _spriteBatch)
        {



            drawrect.X = (int)hitbox.X + offsetx - player.centerWorldX + player.centerX;
            drawrect.Y = (int)hitbox.Y + offsety - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture, drawrect, cropbox, Color.White, 0, Vector2.Zero, spriteEffects, 1);


        }


    }
}
