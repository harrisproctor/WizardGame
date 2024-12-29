using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class UIElement
    {

        public virtual void draw(SpriteBatch _spriteBatch)
        {


        }

        public virtual int Relocate(int x, int y, int width, int height)
        {
            return 0;
        }




    }
}
