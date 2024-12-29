using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class UIString : UIElement
    {

        public List<int> digits = new List<int>();
        public List<Rectangle> cropboxes = new List<Rectangle>();
        public List<Rectangle> posboxes = new List<Rectangle>();
        public Texture2D manafont;

        public UIString(int x, int y, int width, int height, int num, Texture2D manafont)
        {

            num = ReverseNumber(num);
            int numdigits = num.ToString().Length;
            for (int i = 0; i < numdigits; i++)
            {
                digits.Add(num % 10);
                num = num / 10;
            }
            for (int i = 0; i < numdigits; i++)
            {
                cropboxes.Add(new Rectangle(128 * digits[i], 0, 128, 128));
                posboxes.Add(new Rectangle(x + (width * i), y, width, height));
            }

            this.manafont = manafont;

        }

        public int Relocate(int x, int y, int width, int height)
        {
            for (int i = 0; i < digits.Count; i++)
            {
                posboxes[i] = new Rectangle(x + (width * i), y, width, height);
            }
            return 0;
        }

        public int ReverseNumber(int num)
        {
            // Convert the number to a string
            string numStr = num.ToString();

            // Reverse the string
            char[] charArray = numStr.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);

            // Convert the reversed string back to an integer
            int reversedNum = int.Parse(reversedStr);

            return reversedNum;
        }


        public override void draw(SpriteBatch _spriteBatch)  
        { 
            for(int i = 0; i < digits.Count; i++)
            {
                _spriteBatch.Draw(manafont, posboxes[i], cropboxes[i], Color.White);
                
            }
        
        }


    }
}
