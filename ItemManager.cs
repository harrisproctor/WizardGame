using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class ItemManager
    {
        public List<HoldItem> items;
        public CollisionCheck colCheck;
        public Player player;
        public Texture2D rocktext;
        public Texture2D libitems1;
        public Texture2D magicsymbols;
        public int rockx = 200;
        public int MKeyind;
        public Random rand = new Random();

        public ItemManager() {
            items = new List<HoldItem>();
            
        }

        public void placeLibItems(int[] mapp, TileManager tm)
        {

            if(player.heldItem != null)
            {
                HoldItem curheld = player.heldItem;
                items.Clear();

                items.Add(curheld);
                player.heldItem = curheld;
            }
            else
            {
                items.Clear();
            }



            List<int> freefilled = new List<int>();

            List<int> freesideholes = new List<int>();

            List<int> freetopholes = new List<int>();
            
            List<int> freecorners = new List<int>();

            List<int> freefloor = new List<int>();

            for (int i = 0; i < mapp.Length; i++) 
            {
                if(i > 79 && i % 40 != 0 && i % 40 != 39)
                {
                    if (tm.collides[mapp[i]] && tm.collides[mapp[i-40]] == false && mapp[i] != 340)
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
                        else if(tm.collides[mapp[i - 39]] || tm.collides[mapp[i - 41]])
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



                }
            
            }

            int keyind;
            if (freetopholes.Count > 0)
            {
                keyind = freetopholes[rand.Next(freetopholes.Count)];
                addMKey(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 50);
                freetopholes.Remove(keyind);

                keyind = freetopholes[rand.Next(freetopholes.Count)];
                addManaIdol(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 50);
                freetopholes.Remove(keyind);

            }
            else
            {
                keyind = freecorners[rand.Next(freecorners.Count)];
                addMKey(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 50);
                freecorners.Remove(keyind);

                keyind = freetopholes[rand.Next(freetopholes.Count)];
                addManaIdol(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 50);
                freetopholes.Remove(keyind);
            }
            

            
            keyind = freecorners[rand.Next(freecorners.Count)];
            addMChest(((keyind % 40) * 96) + 5, ((keyind / 40) * 96) - 80);



            for (int i = 0; i < 10; i++) 
            {
                keyind = freefloor[rand.Next(freefloor.Count)];
                addBook(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 80);
                freefloor.Remove(keyind);
            }



        }

        public void addMagicScroll(int x, int y, int spell) {
            if (spell == 1)
            {
                items.Add(new CantripScroll(colCheck, player, this, new HandFireCantrip(player)));
            }
            else if (spell == 2) 
            {
                items.Add(new CantripScroll(colCheck, player, this, new SummonRockCantrip(player)));

            }
            else if (spell == 3)
            {
                items.Add(new CantripScroll(colCheck, player, this, new FloatCantrip(player)));

            }

            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            

        }

        public void addRock()
        {
            items.Add(new HoldItem(colCheck, player));
            items.Last().texture = rocktext;
            items.Last().hitbox.X = rockx;
            items.Last().hitbox.Y = 200;
            rockx += 80;
        }
        public void addBook(int x, int y)
        {
            items.Add(new HoldBook(colCheck, player));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }
        public void addCrystalRock(int x, int y)
        {
            items.Add(new HoldCrystalRock(colCheck, player));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }
        public void addMKey(int x, int y)
        {
            MKeyind = items.Count;
            items.Add(new HoldMKey(colCheck, player));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addMChest(int x, int y)
        {
            items.Add(new HoldMChest(colCheck, player,this));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addManaIdol(int x, int y)
        {
            items.Add(new HoldManaIdol(colCheck, player));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void update()
        {
            for (int i = 0; i < items.Count; i++)

            {
                if (items[i] != player.heldItem)
                {
                    items[i].update();
                }
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
