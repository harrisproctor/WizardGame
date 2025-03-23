using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class ItemManager
    {
        public List<HoldItem> items;
        public List<Entity> eitems;
        public CollisionCheck colCheck;
        public Player player;
        public Texture2D rocktext;
        public Texture2D libitems1;
        public Texture2D magicsymbols;
        public Texture2D swampitems1;
        public int rockx = 200;
        public int MKeyind;
        public Random rand = new Random();
        public List<HoldItem> libShopItems;
        public List<HoldShopItem> itemsinshop;

        public ItemManager() {
            items = new List<HoldItem>();
            itemsinshop = new List<HoldShopItem>();
            eitems = new List<Entity>();


        }

        public void robbedShop()
        {
            
            foreach(var item in itemsinshop)
            {
                item.delete();
            }

                player.mm.brainShopKeep.angry = true;
            player.angryLibKeep = true;
            itemsinshop.Clear();
            itemsinshop = new List<HoldShopItem>();







        }

        public void placeSwampItems(int[] mapp, TileManager tm)
        {
            itemsinshop.Clear();
            itemsinshop = new List<HoldShopItem>();
            libShopItems = new List<HoldItem>();
            libShopItems.Add(new HoldBook(colCheck, player));
            libShopItems.Add(new HoldCrystalRock(colCheck, player));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new MagicWaveCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new MagicArrowCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new JumpCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new HandFireCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new SummonRockCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new FloatCantrip(player)));

            if (player.heldItem != null)
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
            eitems.Clear();


            addCouldern(((player.shop.shopgridind % 4) * 960) + 350, ((player.shop.shopgridind / 4) * 960) + 300);

            List<int> ingredientspots = new List<int>();

            for (int i = 0; i < mapp.Length; i++)
            { 
                //ingredient tiles
                if(mapp[i] == 267)
                {
                    ingredientspots.Add(i - 40);
                }
            
            }
            foreach(int i in ingredientspots)
            {
                addIngredient(((i % 40) * 96) + 15, ((i / 40) * 96) - 50);
                
            }

            }

        public void fixMKeyind()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is HoldMKey)
                {
                    MKeyind = i;
                }
            }
        }

            public void placeLibItems(int[] mapp, TileManager tm)
        {
            itemsinshop.Clear();
            itemsinshop = new List<HoldShopItem>();
            libShopItems = new List<HoldItem>();
            libShopItems.Add(new HoldBook(colCheck, player));
            libShopItems.Add(new HoldCrystalRock(colCheck, player));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new MagicWaveCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new MagicArrowCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new JumpCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new HandFireCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new SummonRockCantrip(player)));
            libShopItems.Add(new CantripScroll(colCheck, player, this, new FloatCantrip(player)));
            libShopItems.Add(new HoldMinorHealWand(colCheck, player));
            libShopItems.Add(new HoldMagicArrowWand(colCheck, player));
            if (player.heldItem != null)
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
            eitems.Clear();



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
            if (freetopholes.Count > 1)
            {
                
                keyind = freetopholes[rand.Next(freetopholes.Count)];
                addMKey(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 50);
                freetopholes.Remove(keyind);

                keyind = freetopholes[rand.Next(freetopholes.Count)];
                addManaIdol(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 60);
                freetopholes.Remove(keyind);

            }
            else
            {
                keyind = freecorners[rand.Next(freecorners.Count)];
                addMKey(((keyind % 40) * 96) + 15, ((keyind / 40) * 96) - 60);
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

            player.shop.setShopRect();
            List<HoldItem> deleteitems = new List<HoldItem>();
            foreach (var money in items)
            {
               if( money.hitbox.Intersects(player.shop.shopRect) )
                {
                    //items.Remove(money);
                    deleteitems.Add(money);
                }
            }
            foreach (var money in deleteitems)
            {
                items.Remove(money);
            }
            

            player.shop.setupShop();



        }

        public void addMomentum(int x, int y)
        {
            items.Last().xvel = x;
            items.Last().yvel = y;
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
            else if (spell == 4)
            {
                items.Add(new CantripScroll(colCheck, player, this, new JumpCantrip(player)));

            }
            else if (spell == 5)
            {
                items.Add(new CantripScroll(colCheck, player, this, new MagicArrowCantrip(player)));

            }
            else if (spell == 6)
            {
                items.Add(new CantripScroll(colCheck, player, this, new MagicWaveCantrip(player)));

            }
            else if (spell == 7)
            {
                items.Add(new CantripScroll(colCheck, player, this, new weakHealCantrip(player)));

            }
            else if (spell == 8)
            {
                items.Add(new CantripScroll(colCheck, player, this, new DrillCantrip(player)));

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

        public void addIngredient(int x, int y)
        {
            int poggies = player.rnd.Next(0,3);
            if(poggies == 0)
            {
                addMandrake(x, y);
            }else if(poggies == 1)
            {
                addSkullShroom(x, y);
            }
            else
            {
                addMagicFlower1(x, y);
            }

        }

        public void addMandrake(int x, int y)
        {
            items.Add(new HoldMandrake(colCheck, player));
            items.Last().texture = swampitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addSkullShroom(int x, int y)
        {
            items.Add(new HoldSkullShroom(colCheck, player));
            items.Last().texture = swampitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addItem(HoldItem holder,int x,int y)
        {
            items.Add(holder);
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            
        }

        public void addBook(int x, int y)
        {
            items.Add(new HoldBook(colCheck, player));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addMagicFlower1(int x, int y)
        {
            items.Add(new HoldMagicFlower1(colCheck, player));
            items.Last().texture = swampitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addBatWing(int x, int y)
        {
            items.Add(new HoldBatWing(colCheck, player));
            items.Last().texture = swampitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addMinorHealWand(int x, int y)
        {
            items.Add(new HoldMinorHealWand(colCheck, player));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            //rockx += 80;
        }

        public void addMagicArrowWand(int x, int y)
        {
            items.Add(new HoldMagicArrowWand(colCheck, player));
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

        public void addCouldern(int x, int y)
        {
            eitems.Add(new couldern(player));
            eitems.Last().texture = swampitems1;
            eitems.Last().hitbox.X = x;
            eitems.Last().hitbox.Y = y;
        }

        public void addShopItemRand(int x, int y, int shopind)
        {
            HoldItem randchoice;
            randchoice = libShopItems[rand.Next(libShopItems.Count)];


            items.Add(new HoldShopItem(colCheck, player,randchoice, shopind,rand.Next(5,27)));
            items.Last().texture = libitems1;
            items.Last().hitbox.X = x;
            items.Last().hitbox.Y = y;
            itemsinshop.Add((HoldShopItem)items.Last());

            //Debug.WriteLine("help");
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
                else if (items[i] is HoldShopItem)
                {
                    items[i].update();
                }
                else
                {
                    items[i].playeritemupdate();
                }
            }

            foreach(Entity e in eitems)
            {
                e.update();
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
            foreach (Entity e in eitems)
            {
                if (e.hitbox.X + e.hitbox.Width > player.centerWorldX - player.centerX &&
                          e.hitbox.X - e.hitbox.Width < player.centerWorldX + player.centerX &&
                          e.hitbox.Y + e.hitbox.Height > player.centerWorldY - player.centerY &&
                          e.hitbox.Y - e.hitbox.Height < player.centerWorldY + player.centerY)
                {
                    e.draw(_spriteBatch);
                }
                
            }

        }
    }
}
