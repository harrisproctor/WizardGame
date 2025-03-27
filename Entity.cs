using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class Entity
    {
        //public int worldX, worldY;
        public int yvel;
        public int xvel;
        public bool colliding = false;
        public bool grounded = false;
        //public Vector2 position;
        public Rectangle drawrect;
        public Rectangle croprect;
        public Rectangle hitbox;
        public Texture2D texture;
        public int bounce;
        public int id;
        public int hitrank;
        public bool onExit;
        public bool onLedge;
        public bool spaceToMove;
        public int xoffset;
        public int yoffset;

        public virtual void update() { 
        
        
        
         }

        public virtual void draw(SpriteBatch _spriteBatch) 
        { 
        
        }

        public virtual void hit(Entity entity) 
        { 

        
        }
    }
}
