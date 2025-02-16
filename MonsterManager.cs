using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class MonsterManager
    {
        public List<Entity> monsters;
        public CollisionCheck colCheck;
        public Player player;
        public Texture2D batmon1texture;
        public Texture2D brainmon1texture;
        public Texture2D owlmon1texture;
        public Texture2D bookmon1texture;
        public Texture2D owlmagetexture;
        public Texture2D brainyshopkeeptexture;
        public ParticleManager particleManager;
        public Random rand = new Random();
        public BrainShopKeep brainShopKeep;

        public MonsterManager(Player player)
        {
            
            this.player = player;
            colCheck = player.colcheck;
            monsters = new List<Entity>();
           
        }

        public void placelibenemies(int[] mapp, TileManager tm)
        {
            monsters.Clear();

            List<int> freefilled = new List<int>();

            List<int> freesideholes = new List<int>();

            List<int> freetopholes = new List<int>();

            List<int> freecorners = new List<int>();

            List<int> freefloor = new List<int>();

            List<int> freemedspaces = new List<int>();

            for (int i = 0; i < mapp.Length; i++)
            {
                if (i > 79 && i % 40 != 0 && i % 40 != 39)
                {
                    if (tm.collides[mapp[i]] && tm.collides[mapp[i - 40]] == false && mapp[i] != 340)
                    {

                        if (tm.collides[mapp[i - 39]] && tm.collides[mapp[i - 41]])
                        {
                            if (tm.collides[mapp[i - 80]] == false)
                            {
                                freetopholes.Add(i);

                            }
                            else
                            {
                                freefilled.Add(i);
                            }

                        }
                        else if (tm.collides[mapp[i - 39]] || tm.collides[mapp[i - 41]])
                        {
                            if (tm.collides[mapp[i - 80]])
                            {

                                freesideholes.Add(i);


                            }
                            else
                            {
                                freecorners.Add(i);
                            }

                        }
                        else
                        {
                            freefloor.Add(i);
                        }


                    }
                    //2x2 spaces check
                    if(tm.collides[mapp[i]] == false && tm.collides[mapp[i-1]] == false && tm.collides[mapp[i-40]] == false && tm.collides[mapp[i-41]] == false)
                    {
                        freemedspaces.Add(i);

                    }



                }

            }


            int keyind;
            for (int i = 0; i < rand.Next(4,14); i++)
            {
                keyind = freefloor[rand.Next(freefloor.Count)];
                addOwlMonster(((keyind % 40) * 96) + 5, ((keyind / 40) * 96) - 80);
                freefloor.Remove(keyind);
            }
            for (int i = 0; i < rand.Next(4, 14); i++)
            {
                keyind = freefloor[rand.Next(freefloor.Count)];
                addBookMonster(((keyind % 40) * 96) + 5, ((keyind / 40) * 96) - 90);
                freefloor.Remove(keyind);
            }
            for (int i = 0; i < rand.Next(1, 4); i++)
            {
                keyind = freemedspaces[rand.Next(freemedspaces.Count)];
                addBrainMonster(((keyind % 40) * 96) - 95, ((keyind / 40) * 96) - 90);
                freemedspaces.Remove(keyind);
            }
            for (int i = 0; i < rand.Next(1, 4); i++)
            {
                keyind = freemedspaces[rand.Next(freemedspaces.Count)];
                addOwlMageMonster(((keyind % 40) * 96) - 95, ((keyind / 40) * 96) - 90);
                freemedspaces.Remove(keyind);
            }
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].hitbox.Intersects(new Microsoft.Xna.Framework.Rectangle((tm.startroomind*960),0,960,960)))
                {
                    monsters.Remove(monsters[i]);

                }

            }
            player.mm.addBrainShopKeepMonster((( player.shop.shopgridind % 4) * 960) + 400, ((player.shop.shopgridind / 4) * 960) + 200);





        }

        public void addBatDemon(int x, int y)
        {
            monsters.Add(new Batdemon(player, this));
            monsters.Last().texture = batmon1texture;
            monsters.Last().hitbox.X = x;
            monsters.Last().hitbox.Y = y;
        }

        public void addBrainMonster(int x, int y)
        {
            monsters.Add(new brainmonster1(player, this));
            monsters.Last().texture = brainmon1texture;
            monsters.Last().hitbox.X = x;
            monsters.Last().hitbox.Y = y;
        }

        public void addBrainShopKeepMonster(int x, int y)
        {
            monsters.Add(new BrainShopKeep(player, this));
            monsters.Last().texture = brainyshopkeeptexture ;
            monsters.Last().hitbox.X = x;
            monsters.Last().hitbox.Y = y;
            brainShopKeep = monsters.Last() as BrainShopKeep;
        }

        public void addOwlMonster(int x, int y)
        {
            monsters.Add(new OwlMonster1(player, this));
            monsters.Last().texture = owlmon1texture;
            monsters.Last().hitbox.X = x;
            monsters.Last().hitbox.Y = y;
        }

        public void addBookMonster(int x, int y)
        {
            monsters.Add(new BookMon1(player, this));
            monsters.Last().texture = bookmon1texture;
            monsters.Last().hitbox.X = x;
            monsters.Last().hitbox.Y = y;
        }

        public void addOwlMageMonster(int x, int y)
        {
            monsters.Add(new OwlMageMonster(player, this));
            monsters.Last().texture = owlmagetexture;
            monsters.Last().hitbox.X = x;
            monsters.Last().hitbox.Y = y;
        }


        public void update()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].update();
            }

        }
        public void drawAll(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < monsters.Count; i++)

            {
                if (monsters[i].hitbox.X + 96 > player.centerWorldX - player.centerX &&
                          monsters[i].hitbox.X - 96 < player.centerWorldX + player.centerX &&
                          monsters[i].hitbox.Y + 96 > player.centerWorldY - player.centerY &&
                          monsters[i].hitbox.Y - 96 < player.centerWorldY + player.centerY)
                {
                    monsters[i].draw(_spriteBatch);
                }

            }

        }
    }





}

