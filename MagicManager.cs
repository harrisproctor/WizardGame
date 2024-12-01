using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace monowizard
{
    internal class MagicManager
    {
        public List<Entity> items;
        public CollisionCheck colCheck;
        public Player player;
        public Texture2D effectstext1;

        
        public MagicManager(CollisionCheck collisionCheck, Player player) 
        {
        this.player = player;
        items = new List<Entity>();
        colCheck = collisionCheck;
        
        
        }


        public void addMagicArrow1(int x, int y, int dirx, int diry) 
        {
            float rotation = 0.5f;
           
            items.Add(new MagicArrow1(colCheck,player,x,y,dirx,diry,this,0));
            items.Last().texture = effectstext1;
           // Debug.WriteLine("magic");
        
        }

        public void addMagicWave1(int x, int y, int facing, int down)
        {
           
            items.Add(new MagicWave1(colCheck, player, x, y, facing, down, this, 0));
            items.Last().texture = effectstext1;
            // Debug.WriteLine("magic");

        }


        public void update()
        {
            for (int i = 0; i < items.Count; i++)

            {
               
                    items[i].update();
                    
                
            }

        }
        public void drawAll(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < items.Count; i++)

            {
                if (items[i].hitbox.X + 96 > player.centerWorldX - player.centerX &&
                          items[i].hitbox.X - 96 < player.centerWorldX + player.centerX &&
                          items[i].hitbox.Y + 96 > player.centerWorldY - player.centerY &&
                          items[i].hitbox.Y - 96 < player.centerWorldY + player.centerY)
                {
                    items[i].draw(_spriteBatch);
                }

            }

        }
    }
}
