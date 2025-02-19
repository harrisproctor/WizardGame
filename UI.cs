using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public Rectangle scroll1crop = new Rectangle(0, 0, 128, 128);
        public Rectangle scroll1pos = new Rectangle(1560, 30, 100, 100);
        public Rectangle scroll2pos = new Rectangle(1680, 30, 100, 100);
        public Rectangle scroll3pos = new Rectangle(1800, 30, 100, 100);
        public Rectangle scroll4pos = new Rectangle(1440, 30, 100, 100);

        


        public int mananumb1;
        public int mananumb2;

        public Texture2D manafont;

        public Rectangle mananumb1crop = new Rectangle(0, 0, 128, 128);
        public Rectangle mananumb1pos = new Rectangle(300, 30, 80, 80);

        public Rectangle mananumb2crop = new Rectangle(128, 0, 128, 128);
        public Rectangle mananumb2pos = new Rectangle(370, 30, 80, 80);

        public List<UIElement> items = new List<UIElement>();

        public Texture2D UIElements;
        public Player player;
        

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

        public UIString addUINumber(int x, int y, int num)
        {
            UIString newstring = new UIString(x, y, 80, 80, num, manafont);
            items.Add(newstring);
            return newstring;

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

            _spriteBatch.Draw(UIElements, scroll1pos, scroll1crop, Color.White);
            _spriteBatch.Draw(player.itemManager.magicsymbols, scroll1pos, player.cantrip.symbcroprect, Color.White);


            _spriteBatch.Draw(UIElements, scroll2pos, scroll1crop, Color.White);
            _spriteBatch.Draw(UIElements, scroll3pos, scroll1crop, Color.White);
            _spriteBatch.Draw(UIElements, scroll4pos, scroll1crop, Color.White);


            for (int i = 0; i < items.Count; i++)
            {
                items[i].draw(_spriteBatch);
                

            }


        }



    }
}
