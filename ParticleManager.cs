using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{



    internal class ParticleManager
    {
        public List<Entity> items;
        public CollisionCheck colCheck;
        public Player player;
        public Texture2D libtexts1;
        public Texture2D windcloudmanatext;
       public Random rnd = new Random();

        public ParticleManager(CollisionCheck collisionCheck, Player player) 
        {
            this.player = player;
            items = new List<Entity>();
            colCheck = collisionCheck;
            

        }



        public void addBrainChunk(int x, int y, int xvel, int yvel)
        {

            items.Add(new brainchunk(colCheck,player,this));
            items.Last().texture = libtexts1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            items.Last().xvel = xvel;
            items.Last().yvel = yvel;
            // Debug.WriteLine("magic");

        }

        public void addWindParticle(int x, int y, int xvel, int yvel,int facing)
        {

            items.Add(new WindParticle(colCheck, player, this,facing));
            items.Last().texture = windcloudmanatext;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            items.Last().xvel = xvel;
            items.Last().yvel = yvel;

            
            // Debug.WriteLine("magic");

        }

        public void addOwlFeather(int x, int y, int xvel, int yvel)
        {

            items.Add(new OwlFeatherPart(colCheck, player, this));
            items.Last().texture = libtexts1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            items.Last().xvel = xvel;
            items.Last().yvel = yvel;
            // Debug.WriteLine("magic");

        }

        public void addManaSmall(int x, int y, int xvel, int yvel,int size,float manavalue)
        {

            items.Add(new ManaSmall(colCheck, player, this,size,manavalue));
            items.Last().texture = windcloudmanatext;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            items.Last().xvel = xvel;
            items.Last().yvel = yvel;
            
            // Debug.WriteLine("magic");


        }

        public void addHealSmall(int x, int y, int xvel, int yvel, int size, float manavalue)
        {

            items.Add(new healParticle(colCheck, player, this, size, manavalue));
            items.Last().texture = windcloudmanatext;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            items.Last().xvel = xvel;
            items.Last().yvel = yvel;

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
