using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class UI
    {
        public int healthnumb1;
        public int healthnumb2;

        public Texture2D healthfont;

        public Rectangle healthnumb1crop = new Rectangle(0,0,128,128);
        public Rectangle healthnumb1pos = new Rectangle(30, 30, 80, 80);

        public Rectangle healthnumb2crop = new Rectangle(128, 0, 128, 128);
        public Rectangle healthnumb2pos = new Rectangle(100, 30, 80, 80);


        public int mananumb1;
        public int mananumb2;

        public Texture2D manafont;

        public Rectangle mananumb1crop = new Rectangle(0, 0, 128, 128);
        public Rectangle mananumb1pos = new Rectangle(300, 30, 80, 80);

        public Rectangle mananumb2crop = new Rectangle(128, 0, 128, 128);
        public Rectangle mananumb2pos = new Rectangle(370, 30, 80, 80);

        public UI() 
        {
            setHealth(80);
            setMana(5);
        
        }

        public void setHealth(int x) {
            if (x > 9)
            {
                int twosplace = x % 10;
                int onesplace = x / 10;
                healthnumb2crop = new Rectangle((128*twosplace), 0, 128, 128);
                healthnumb1crop = new Rectangle((128 * onesplace), 0, 128, 128);

            }
            else {
                healthnumb2crop = new Rectangle(128, 0, 1, 1);
                healthnumb1crop = new Rectangle((128 * x), 0, 128, 128);

                }
        
        }

        public void setMana(int x)
        {
            if (x > 9)
            {
                int twosplace = x % 10;
                int onesplace = x / 10;
                mananumb2crop = new Rectangle((128 * twosplace), 0, 128, 128);
                mananumb1crop = new Rectangle((128 * onesplace), 0, 128, 128);

            }
            else
            {
                mananumb2crop = new Rectangle(128, 0, 1, 1);
                mananumb1crop = new Rectangle((128 * x), 0, 128, 128);

            }

        }

        public void draw(SpriteBatch _spriteBatch) {


            _spriteBatch.Draw(healthfont, healthnumb1pos,healthnumb1crop, Color.White);
            _spriteBatch.Draw(healthfont, healthnumb2pos, healthnumb2crop, Color.White);
            _spriteBatch.Draw(manafont, mananumb1pos, mananumb1crop, Color.White);
            _spriteBatch.Draw(manafont, mananumb2pos, mananumb2crop, Color.White);


        }



    }
}
