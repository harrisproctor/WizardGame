using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace monowizard
{
    internal class Cantrip
    {
        public int id;
        public int pushonhit;
        public float manacost;
        public Rectangle symbcroprect;
        public int cantripnum;
        public bool keyrelease = false;
        public int isupordown = 0;
        

        public virtual void cast() { }

        public virtual void update() { }

        public virtual void predraw(SpriteBatch _spriteBatch) { }

        public virtual void draw(SpriteBatch _spriteBatch) { }





        

    }
}
