using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class SwampLevSetUp
    {
        TileManager tm;
        public SwampLevSetUp(TileManager tmm)
        {
            tm = tmm;
        }



        public void setUpSwampTiles()
        {
            //basics
            for (int i = 65; i < 69; i++)
            {
                tm.collides[i] = true;
                tm.croprects[i] = new Rectangle((128 * ((i-65) % 2)), (128 * ((i-65) / 2)), 128, 128);
                tm.tileEffects[i] = tm.basic;
                tm.istrap[i] = false;
                tm.breakable[i] = true;
            }
            //invincible
            tm.collides[69] = true;
            tm.croprects[69] = new Rectangle(256,0, 128, 128);
            tm.tileEffects[69] = tm.basic;
            tm.istrap[69] = false;
            tm.breakable[69] = false;

            //fake normal
            //invincible
            tm.collides[70] = true;
            tm.croprects[70] = new Rectangle(0, 0, 128, 128);
            tm.tileEffects[70] = tm.basic;
            tm.istrap[70] = false;
            tm.breakable[70] = true;

            //exit
            tm.collides[341] = true;
            tm.croprects[341] = new Rectangle(512, 0, 128, 128);
            tm.tileEffects[341] = tm.trap1;
            tm.istrap[341] = true;
            tm.breakable[341] = false;

            for (int i = 1; i < 65; i++)
            {
                tm.collides[i] = false;
                tm.croprects[i] = new Rectangle(512+(128 * ((i - 1) % 8)), (128 * ((i - 1) / 8)), 128, 128);
                tm.tileEffects[i] = tm.basic;
                tm.istrap[i] = false;
                tm.breakable[i] = true;
            }

            tm.basicgrounds = new int[] { 65, 66, 67, 68, 69, 70 };
            tm.backgroundThershhold = 65;
        }

        public void switchSwampAssets(ContentManager cm)
        {

            if (cm != null)
            {
                cm.Unload();
            }

            cm = new ContentManager(tm.theGame.Services, "Content");
            tm.texts[1] = cm.Load<Texture2D>("tileswamp2");
            for (int i = 2; i < 81; i++)
            {
                tm.texts[i] = tm.texts[1];

            }


        }
    }
}
