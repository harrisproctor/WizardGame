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
            for (int i = 0; i < tm.backmap.Length; i++)
            {
                tm.backmap[i] = 0;
            }


            //basics
            for (int i = 260; i < 265; i++)
            {
                tm.collides[i] = true;
                tm.croprects[i] = new Rectangle((128 * ((i-260) % 2)), (128 * ((i-260) / 2)), 128, 128);
                tm.tileEffects[i] = tm.basic;
                tm.istrap[i] = false;
                tm.breakable[i] = true;
            }
            //invincible
            tm.collides[265] = true;
            tm.croprects[265] = new Rectangle(256,0, 128, 128);
            tm.tileEffects[265] = tm.basic;
            tm.istrap[265] = false;
            tm.breakable[265] = false;

            //fake normal
            //invincible
            tm.collides[266] = true;
            tm.croprects[266] = new Rectangle(0, 0, 128, 128);
            tm.tileEffects[266] = tm.basic;
            tm.istrap[266] = false;
            tm.breakable[266] = true;

            //exit
            tm.collides[341] = true;
            tm.croprects[341] = new Rectangle(512, 0, 128, 128);
            tm.tileEffects[341] = tm.trap1;
            tm.istrap[341] = true;
            tm.breakable[341] = false;

            for (int i = 2; i < 258; i++)
            {
                tm.collides[i] = false;
                tm.croprects[i] = new Rectangle(512+(128 * ((i - 2) % 8)), (128 * ((i - 2) / 8)), 128, 128);
                tm.tileEffects[i] = tm.basic;
                tm.istrap[i] = false;
                tm.breakable[i] = true;
            }

            tm.basicgrounds = new int[] { 260, 261, 262, 263, 264, 265, 266 };
            tm.backgroundThershhold = 258;
        }

        public void switchSwampAssets(ContentManager cm)
        {

            //if (cm != null)
            //{
              //  cm.Unload();
            //}

            //cm = new ContentManager(tm.theGame.Services, "Content");
           // tm.texts[1] = cm.Load<Texture2D>("tileswamp2");
            for (int i = 0; i < 330; i++)
            {
                tm.texts[i] = tm.swamptiles;

            }


        }
    }
}
