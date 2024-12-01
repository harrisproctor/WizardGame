using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class TruetrapglyphTile1 : Truetile
    {

        bool firing;
        bool canFire = true;
        bool sensed = false;
        int fireDelay = 50;
        public int tileind;
        MagicManager magicManager;
        int xdirect;
        int ydirect;
        int xspawn;
        int yspawn;
        


        public TruetrapglyphTile1(MagicManager magicManager, int ind)
        {
            this.magicManager = magicManager;
            tileind = ind;
            croprect = new Microsoft.Xna.Framework.Rectangle(384, 0, 128, 128);
        }
        public override void Activate(int side, Entity e)
        {
            
            if (canFire) 
            {
                croprect.X = 256;
                if (side == 1)
                {
                    // Debug.WriteLine("aaaaaas");
                    firing = true;
                    xdirect = 0;
                    ydirect = -1;
                    xspawn = ((tileind % 40) * 96) + 32;
                    yspawn = ((tileind / 40) * 96) - 32;
                }
                else if (side == 2)
                {
                    firing = true;
                    xdirect = 1;
                    ydirect = 0;
                    xspawn = ((tileind % 40) * 96) + 96;
                    yspawn = ((tileind / 40) * 96) + 16;


                }
                else if (side == 3) 
                {
                    firing = true;
                    xdirect = 0;
                    ydirect = 1;
                    xspawn = ((tileind % 40) * 96) + 32;
                    yspawn = ((tileind / 40) * 96) + 96;
                }
                else if (side == 4)
                {
                    firing = true;
                    xdirect = -1;
                    ydirect = 0;
                    xspawn = ((tileind % 40) * 96) - 32;
                    yspawn = ((tileind / 40) * 96) + 16;
                }

            }
            
        }

        public override void Update()
        {
            if (firing) {
                fireDelay -= 1;

                if (fireDelay < 0) {
                    croprect.X = 384;
                    magicManager.addMagicArrow1(xspawn, yspawn, xdirect, ydirect);
                    fireDelay = 50;
                    firing = false;
                    canFire = true;
                }
            
            }

        }




    }
}
