using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        public void switchSwampAssets(ContentManager cm)
        {

            //if (cm != null)
            //{
            //  cm.Unload();
            //}

            //cm = new ContentManager(tm.theGame.Services, "Content");
            // tm.texts[1] = cm.Load<Texture2D>("tileswamp2");
           tm.texts[1] = tm.texts[398];
            for (int i = 2; i < 330; i++)
            {
                
                    tm.texts[i] = tm.texts[399];
                


            }



        }

        public void setUpLibTiles()
        {
            tm.collides[0] = false;
            tm.collides[1] = true;

            tm.croprects[0] = new Rectangle(0, 0, 1024, 1024);
            tm.croprects[1] = new Rectangle(10, 0, 226, 226);

            for (int i = 0; i < tm.rotations.Length; i++)
            {
                tm.rotations[i] = 0;
            }

            for (int i = 0; i < 338; i++)
            {
                tm.tileEffects[i] = tm.basic;
                tm.istrap[i] = false;
                tm.breakable[i] = true;
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
            tm.breakable[338] = true;

            tm.collides[339] = true;
            tm.croprects[339] = new Rectangle(384, 0, 128, 128);
            tm.tileEffects[339] = tm.trap1;
            tm.istrap[339] = true;
            tm.breakable[339] = true;

            tm.collides[340] = true;
            tm.croprects[340] = new Rectangle(768, 0, 128, 128);
            tm.tileEffects[340] = tm.trap1;
            tm.istrap[340] = true;
            tm.breakable[340] = true;

            tm.collides[341] = true;
            tm.croprects[341] = new Rectangle(512, 0, 128, 128);
            tm.tileEffects[341] = tm.trap1;
            tm.istrap[341] = true;
            tm.breakable[341] = false;

            tm.collides[342] = true;
            tm.croprects[342] = new Rectangle(0, 0, 128, 128);
            tm.tileEffects[342] = tm.basic;
            tm.istrap[342] = false;
            tm.breakable[342] = true;

            tm.collides[343] = true;
            tm.croprects[343] = new Rectangle(128, 0, 128, 128);
            tm.tileEffects[343] = tm.basic;
            tm.istrap[343] = false;
            tm.breakable[343] = true;

            tm.collides[344] = true;
            tm.croprects[344] = new Rectangle(0, 128, 128, 128);
            tm.tileEffects[344] = tm.basic;
            tm.istrap[344] = false;
            tm.breakable[344] = true;

            tm.collides[345] = true;
            tm.croprects[345] = new Rectangle(128, 128, 128, 128);
            tm.tileEffects[345] = tm.basic;
            tm.istrap[345] = false;
            tm.breakable[345] = true;

            tm.collides[346] = true;
            tm.croprects[346] = new Rectangle(256, 128, 128, 128);
            tm.tileEffects[346] = tm.basic;
            tm.istrap[346] = false;
            tm.breakable[346] = true;

            tm.collides[347] = true;
            tm.croprects[347] = new Rectangle(384, 128, 128, 128);
            tm.tileEffects[347] = tm.basic;
            tm.istrap[347] = false;
            tm.breakable[347] = false;

            tm.basicgrounds = new int[] { 342, 343, 344, 345,346,347 };
            tm.backgroundThershhold = 342;
        }
    }
}
