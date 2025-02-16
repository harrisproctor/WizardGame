using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class LibLevSetUp
    {
        TileManager tm;
        public LibLevSetUp(TileManager tmm)
        {
            tm = tmm;
        }

        public void setUpLibTiles()
        {
            tm.collides[0] = false;
            tm.collides[1] = true;

            tm.croprects[0] = new Rectangle(0, 0, 1024, 1024);
            tm.croprects[1] = new Rectangle(10, 0, 226, 226);

            for (int i = 0; i < 338; i++)
            {
                tm.tileEffects[i] = tm.basic;
                tm.istrap[i] = false;
            }

            for (int i = 0; i < 320; i++)
            {
                tm.collides[i + 2] = false;
                tm.croprects[i + 2] = new Rectangle((96 * (i % 40)), (96 * (i / 40)), 96, 96);
            }
            for (int i = 322; i < 338; i++)
            {
                tm.collides[i] = true;
                tm.croprects[i] = new Rectangle((96 * ((i - 322) % 4)), (96 * ((i - 322) / 4)), 96, 96);
            }

            tm.collides[338] = true;
            tm.croprects[338] = new Rectangle(384, 0, 128, 128);
            tm.tileEffects[338] = tm.trap1;
            tm.istrap[338] = true;

            tm.collides[339] = true;
            tm.croprects[339] = new Rectangle(384, 0, 128, 128);
            tm.tileEffects[339] = tm.trap1;
            tm.istrap[339] = true;

            tm.collides[340] = true;
            tm.croprects[340] = new Rectangle(768, 0, 128, 128);
            tm.tileEffects[340] = tm.trap1;
            tm.istrap[340] = true;

            tm.collides[341] = true;
            tm.croprects[341] = new Rectangle(512, 0, 128, 128);
            tm.tileEffects[341] = tm.trap1;
            tm.istrap[341] = true;

            tm.collides[342] = true;
            tm.croprects[342] = new Rectangle(0, 0, 128, 128);
            tm.tileEffects[342] = tm.basic;
            tm.istrap[342] = false;

            tm.collides[343] = true;
            tm.croprects[343] = new Rectangle(128, 0, 128, 128);
            tm.tileEffects[343] = tm.basic;
            tm.istrap[343] = false;

            tm.collides[344] = true;
            tm.croprects[344] = new Rectangle(0, 128, 128, 128);
            tm.tileEffects[344] = tm.basic;
            tm.istrap[344] = false;

            tm.collides[345] = true;
            tm.croprects[345] = new Rectangle(128, 128, 128, 128);
            tm.tileEffects[345] = tm.basic;
            tm.istrap[345] = false;

            tm.basicgrounds = new int[] { 342, 343, 344, 345 };
            tm.backgroundThershhold = 342;
        }
    }
}
