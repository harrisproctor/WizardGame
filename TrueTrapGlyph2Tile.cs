using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class TrueTrapGlyph2Tile : Truetile
    {

        bool firing;
        bool canFire = true;
        bool sensed = false;
        int fireDelay = 50;
        public int tileind;
        MagicManager magicManager;
        TileManager tileManager;
        int down;
        int facing;
        int facing2;
        int xspawn;
        int yspawn;



        public TrueTrapGlyph2Tile(MagicManager magicManager, int ind, TileManager tileManager)
        {
            this.magicManager = magicManager;
            tileind = ind;
            this.tileManager = tileManager;
            croprect = new Microsoft.Xna.Framework.Rectangle(384, 0, 128, 128);
        }
        public override void Activate(int side, Entity e)
        {

            if (canFire)
            {
                croprect.X = 128;
                if (side == 1)
                {
                    // Debug.WriteLine("aaaaaas");
                    firing = true;
                    facing = 2;
                    facing2 = 4;
                    down = 3;
                    xspawn = ((tileind % 40) * 96)+ 16;
                    yspawn = ((tileind / 40) * 96) - 64;
                }
                else if (side == 2)
                {
                    firing = true;
                    facing = 1;
                    facing2 = 3;
                    down = 4;
                    xspawn = ((tileind % 40) * 96) + 96;
                    yspawn = ((tileind / 40) * 96) + 48;


                }
                else if (side == 3)
                {
                    firing = true;
                    facing = 2;
                    down = 1;
                    facing2 = 4;
                    xspawn = ((tileind % 40) * 96) + 16;
                    yspawn = ((tileind / 40) * 96) + 96;
                }
                else if (side == 4)
                {
                    firing = true;
                    facing = 1;
                    facing2 = 3;
                    down = 2;
                    xspawn = ((tileind % 40) * 96) - 64;
                    yspawn = ((tileind / 40) * 96) + 16;
                }

            }

        }

        public override void Update()
        {
            if (firing)
            {
                fireDelay -= 1;

                if (fireDelay < 0)
                {
                    croprect.X = 384;
                    magicManager.addMagicWave1(xspawn, yspawn, facing, down);
                    magicManager.addMagicWave1(xspawn, yspawn, facing2, down);
                    fireDelay = 50;
                    firing = false;
                    canFire = true;
                }

            }

        }

    }
}
