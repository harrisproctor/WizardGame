using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Diagnostics;

namespace monowizard
{
    internal class TileManager
    {
        public Player player;
        public Texture2D[] texts;
        public bool[] collides;
        public Rectangle[] croprects;
        public Tile[] tileEffects;
        public bool[] istrap;

        public Vector2[] toptrims;
        public int quedtoptrims = 0;
        public Vector2[] bottomtrims;
        public int quedbottomtrims = 0;
        public Vector2[] righttrims;
        public int quedrighttrims = 0;
        public Vector2[] lefttrims;
        public int quedlefttrims = 0;

        public int startroomind = 0;


        public Rectangle drawtilerect = new Rectangle(0,0,96,96);
        public Rectangle trimupcroprect = new Rectangle(128, 768, 100, 10);
        public Rectangle trimleftcroprect = new Rectangle(384, 768, 10, 100);
        public Rectangle trimrightcroprect = new Rectangle(256, 768, 10, 100);
        public Rectangle trimbottomcroprect = new Rectangle(0, 768, 100, 10);
        // public Vector2 trimpos = new Vector2();

        public MagicManager magicmanager;
        public TrapGlyph1Tile trap1;
        public Dictionary<int, Truetile> updateTiles = new Dictionary<int, Truetile>();
        public LevelGenerator levelgen;
        public ItemManager itemmanager;
        


        //loop vars
        int worldX;
        int worldY;
        int worldCol = 0;
        int worldRow = 0;
        int tileNum;
        int tileInd;

        public int[] backmap = new int[1600];
        public int[] map = new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,341,341,0,0,0,0,340,340,0,0,0,0,0,0,0,338,0,0,0,1,
            1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,339,
            339,0,0,0,0,0,0,1,0,0,1,0,0,0,339,0,0,0,0,0,1,1,339,1,0,0,0,0,340,0,0,0,0,0,0,1,0,0,0,1,
            1,0,0,1,338,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,338,1,340,1,1,339,1,1,1,1,1,1,1,1,339,1,1,1,1,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,338,
            1,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,340,0,1,0,0,0,1,338,1,1,1,1,1,1,1,1,1,1,1,1,
            1,0,340,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,340,0,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,340,340,340,0,340,340,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,340,340,0,0,0,340,340,0,0,1,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,340,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,0,1,1,
            1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,
            1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,1,
            1,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,
            1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,
            1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,0,1,
            1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,
            1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,
            1,1,0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
            1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};


        public TileManager(Player player)
        {
            levelgen = new LevelGenerator(player,this);
            this.player = player;
           // map = levelgen.makeMap();
           for (int i = 0;i<backmap.Length;i++)
            {
                backmap[i] = 0;
            }

            generlibback(backmap);

            

            generlibback(map);
            // generlibfront(map);

            makeLibBricks(map);





            collides = new bool[400];
            texts = new Texture2D[400];
            croprects = new Rectangle[400];
            tileEffects = new Tile[400];
            istrap = new bool[400];
            Tile basic = new BasicTile();
            trap1 = new TrapGlyph1Tile();
            

            

            toptrims = new Vector2[400];
            lefttrims = new Vector2[400];
            righttrims = new Vector2[400];
            bottomtrims = new Vector2[400];

            
            collides[0] = false;
            collides[1] = true;
            

            croprects[0] = new Rectangle(0, 0, 1024, 1024);
            croprects[1] = new Rectangle(10, 0, 226, 226);

            for (int i = 0; i < 338; i++)
            {
                tileEffects[i] = basic;
                istrap[i] = false;

            }

            for (int i = 0; i < 320; i++)
            {
                collides[i+2] = false;
                croprects[i+2] = new Rectangle((96*(i % 40)), (96 * (i / 40)), 96, 96);
                
            }
            for (int i = 322; i < 338; i++)
            {
                collides[i] = true;
                croprects[i] = new Rectangle((96 * ((i-322) % 4)), (96 * ((i - 322) / 4)), 96, 96);

            }
            collides[338] = true;
            croprects[338] = new Rectangle(384, 0, 128, 128);
            tileEffects[338] = trap1;
            istrap[338] = true;

            collides[339] = true;
            croprects[339] = new Rectangle(384, 0, 128, 128);
            tileEffects[339] = trap1;
            istrap[339] = true;

            collides[340] = true;
            croprects[340] = new Rectangle(768, 0, 128, 128);
            tileEffects[340] = trap1;
            istrap[340] = true;

            collides[341] = true;
            croprects[341] = new Rectangle(512, 0, 128, 128);
            tileEffects[341] = trap1;
            istrap[341] = true;

            
             collides[342] = true;
             croprects[342] = new Rectangle(0,0,128,128);
            tileEffects[342] = basic;
            istrap[342] = false;

            collides[343] = true;
            croprects[343] = new Rectangle(128, 0, 128, 128);
            tileEffects[343] = basic;
            istrap[343] = false;

            collides[344] = true;
            croprects[344] = new Rectangle(0, 128, 128, 128);
            tileEffects[344] = basic;
            istrap[344] = false;

            collides[345] = true;
            croprects[345] = new Rectangle(128, 128, 128, 128);
            tileEffects[345] = basic;
            istrap[345] = false;





            /** croprects[2] = new Rectangle(0, 0, 192, 192);
             croprects[3] = new Rectangle(192, 0, 192, 192);
             croprects[4] = new Rectangle(0, 192, 192, 192);
             croprects[5] = new Rectangle(192, 192, 192, 192);
             croprects[6] = new Rectangle(0, 384, 192, 192);
             croprects[7] = new Rectangle(192, 384, 192, 192);
             croprects[8] = new Rectangle(0, 572, 192, 192);
             croprects[9] = new Rectangle(192, 572, 192, 192);*/

        }

        public void initateTraps()
        {
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 338)
                {
                    updateTiles.Add(i, new TruetrapglyphTile1(magicmanager, i));
                }
                if (map[i] == 339)
                {
                    updateTiles.Add(i, new TrueTrapGlyph2Tile(magicmanager, i,this));
                }
                if (map[i] == 340)
                {
                    updateTiles.Add(i, new ScafoldingTrueTile( i, this));
                }
                if (map[i] == 341)
                {
                    updateTiles.Add(i, new ExitTrueTile(i, this));
                }
            }
        }

        public void newMap()
        {
            map = levelgen.makeMap();
            generlibback(map);
            makeLibBricks(map);

            updateTiles = new Dictionary<int, Truetile>();
            initateTraps();
            itemmanager.placeLibItems(map,this);
            player.mm.placelibenemies(map,this);
            player.mm.particleManager.items.Clear();

            
        }

        public void update()
        {
            foreach (KeyValuePair<int, Truetile> entry in updateTiles)
            {
                // do something with entry.Value or entry.Key
                entry.Value.Update();
            }
        }
        

        public void draw(SpriteBatch _spriteBatch)
        {
             worldCol = 0;
             worldRow = 0;
            
            
            



            while (worldCol < 40 && worldRow < 40)
            {

                tileInd = worldCol + (worldRow * 40);
                tileNum = map[tileInd];

                worldX = worldCol * 96;
                worldY = worldRow * 96;
                drawtilerect.X = worldX - player.centerWorldX + player.centerX;
                drawtilerect.Y = worldY - player.centerWorldY + player.centerY;



                  if (worldX + 96 > player.centerWorldX - player.centerX &&
                          worldX - 96 < player.centerWorldX + player.centerX &&
                          worldY + 96 > player.centerWorldY - player.centerY &&
                          worldY - 96 < player.centerWorldY + player.centerY)
                  {


                    if (istrap[tileNum]) 
                    {
                        _spriteBatch.Draw(texts[100], drawtilerect, croprects[backmap[tileInd]], Color.White);

                        _spriteBatch.Draw(texts[tileNum], drawtilerect, updateTiles[tileInd].croprect, Color.White);
                        
                    }
                    else
                    {
                        _spriteBatch.Draw(texts[tileNum], drawtilerect, croprects[tileNum], Color.White);
                    }
                       
                    
                    if (tileNum == 342 || tileNum == 343 || tileNum == 344 || tileNum == 345)//collides[tileNum]
                    {
                        if (tileInd > 40)
                        {

                            if (map[tileInd - 40] < 342)//(collides[map[tileInd-40]] == false)
                            {
                                toptrims[quedtoptrims].X = drawtilerect.X - 2;
                                toptrims[quedtoptrims].Y = drawtilerect.Y - 3;
                                quedtoptrims++;
                                
                            }
                        }
                        if (tileInd < 1560)
                        {

                            if (map[tileInd + 40] < 342) //(collides[map[tileInd + 40]] == false)
                            {
                                bottomtrims[quedbottomtrims].X = drawtilerect.X - 2;
                                bottomtrims[quedbottomtrims].Y = drawtilerect.Y + 94;
                                quedbottomtrims++;

                            }
                        }
                        if (tileInd % 40 > 0) {
                            if (map[tileInd - 1] < 342)//(collides[map[tileInd - 1]] == false)
                            {
                                lefttrims[quedlefttrims].X = drawtilerect.X - 3;
                                lefttrims[quedlefttrims].Y = drawtilerect.Y - 2;
                                quedlefttrims++;

                            }


                        }
                        if (tileInd % 40 < 39)
                        {
                            if (map[tileInd + 1] < 342)//(collides[map[tileInd + 1]] == false)
                            {
                                righttrims[quedrighttrims].X = drawtilerect.X + 94;
                                righttrims[quedrighttrims].Y = drawtilerect.Y - 2;
                                quedrighttrims++;

                            }


                        }
                    }


                  }


                worldCol++;

                if (worldCol == 40)
                {
                    worldCol = 0;

                    worldRow++;


                }


            }


            for (int i = 0; i < quedtoptrims; i++) 
            {
                _spriteBatch.Draw(texts[1], toptrims[i], trimupcroprect, Color.White);
            }
            quedtoptrims = 0;

            for (int i = 0; i < quedlefttrims; i++)
            {
                _spriteBatch.Draw(texts[1], lefttrims[i], trimleftcroprect, Color.White);
            }
            quedlefttrims = 0;

            for (int i = 0; i < quedrighttrims; i++)
            {
                _spriteBatch.Draw(texts[1], righttrims[i], trimrightcroprect, Color.White);
            }
            quedrighttrims = 0;

            for (int i = 0; i < quedbottomtrims; i++)
            {
                _spriteBatch.Draw(texts[1], bottomtrims[i], trimbottomcroprect, Color.White);
            }
            quedbottomtrims = 0;

            //drawends
        }

        public void generlibback(int[] map)
        {
            for (int i = 0; i < map.Length; i++) 
            {
                if (map[i] == 0) { 
                map[i] = 2 + (i % 320);
                }
            }
        }

        public void makeLibBricks(int[] map)
        {
            Random rand = new Random();
            int choice = 342;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    choice = 342;
                    choice += rand.Next(0, 4);
                    map[i] = choice;
                }

            }
                


        }

        public void generlibfront(int[] map)
        {
            bool onesrow = false;
            bool firstpick = true;
            int symb = 1;

            for (int i = 0; i < map.Length; i++)
            {
                if (i % 40 == 0) {
                    onesrow = !onesrow;
                }
                if (onesrow) {
                    if (firstpick) 
                    {
                        symb = 322;
                        firstpick = false;
                    }
                    else
                    {
                        symb = 323;
                        firstpick = true;
                    }
                }
                else
                {
                    if (firstpick)
                    {
                        symb = 324;
                        firstpick = false;
                    }
                    else
                    {
                        symb = 325;
                        firstpick = true;
                    }

                }

                if (map[i] == 1)
                {
                    map[i] = symb;
                }
            }
        }

    }

}
