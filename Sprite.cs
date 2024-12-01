using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace monowizard
{
    internal class Sprite
    {
        public Texture2D texture;
        public Rectangle position;

        public Sprite(Texture2D texture, Rectangle position) {
            this.texture = texture;
            this.position = position;
        
        }





    }

}
