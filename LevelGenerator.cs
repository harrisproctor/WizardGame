﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class LevelGenerator
    {
        public Player player;
        public int[][] rooms1;
        public int[][] rooms2;
        public int[][] rooms3;
        public int[][] rooms4;
        public int[][] rooms5;
        public int[][] rooms6;
        public int[][] rooms7;
        public int[][] rooms8;
        public int[][] roomsstart;
        public int[][] roomsend;
        public int[][][] allrooms;

        Random rnd = new Random();
        private int[] Room1 = new int[]{
            10,10,10,10,10,10,10,10,10,10,
            1,0,0,0,0,0,0,0,0,1,
            1,0,1,0,0,0,0,1,0,1,
            1,0,0,1,0,0,1,0,0,1,
            1,0,0,0,1,1,0,0,0,1,
            1,0,0,0,1,1,0,0,0,1,
            1,0,0,1,0,0,1,0,0,1,
            1,10,1,0,0,0,0,1,10,1,
            1,10,0,0,0,0,0,0,10,1,
            10,10,10,10,10,10,10,10,10,10
    };

        private int[] Room2 = new int[]{
            10,10,10,10,10,10,10,10,10,10,
            10,8,8,8,8,8,8,8,8,10,
            10,0,0,0,0,0,0,0,0,8,
            0,0,0,0,0,0,0,0,0,0,
            0,0,4,4,6,6,4,0,0,0,
            0,0,0,0,0,0,0,4,0,0,
            10,0,0,0,0,0,0,0,0,10,
            10,9,8,6,6,6,0,0,9,9,
            10,10,10,8,8,8,8,10,10,10,
            10,10,10,10,10,10,10,10,10,10
    };

        private int[] Room3 = new int[]{
            10,10,10,10,10,10,10,10,10,10,
            10,0,0,0,0,0,0,0,0,10,
            10,10,10,6,4,4,0,6,6,10,
            0,0,0,0,0,0,10,10,10,10,
            0,0,0,0,0,6,0,0,0,0,
            0,0,0,0,10,0,0,0,0,0,
            7,0,0,0,0,0,0,0,0,7,
            10,8,0,0,0,0,0,0,8,10,
            10,8,8,8,0,0,0,8,8,10,
            10,10,10,7,0,0,7,10,10,10

    };

        private int[] Room4 = new int[]{
            10,10,0,0,0,0,0,0,10,10,
            10,0,0,0,3,4,0,0,0,10,
            0,0,0,0,0,0,0,0,0,0,
            0,0,9,9,11,4,8,7,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,1,8,9,6,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,2,6,9,8,9,6,8,0,0,
            10,0,0,0,0,0,0,0,0,10,
            10,10,10,10,10,10,10,10,10,10
    };

        private int[] Room5 = new int[]{
            10,10,10,0,0,0,10,10,10,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,55,0,0,0,0,55,0,10,
            10,0,55,60,60,60,55,0,0,0,
            0,0,0,0,0,44,44,44,0,0,
            0,0,47,47,50,50,50,47,47,0,
            0,0,50,50,50,50,50,50,50,0,
            10,10,10,10,10,10,10,10,10,10
    };

        private int[] Room6 = new int[]{
            10,10,9,0,0,0,0,0,10,10,
            10,9,0,7,0,0,0,6,0,10,
            10,0,0,0,0,0,0,0,0,10,
            10,10,10,9,9,7,0,0,0,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,46,46,50,50,10,10,10,10,
            10,0,0,0,0,0,0,0,10,10,
            10,0,55,55,55,60,60,10,10,10,
            10,0,0,0,0,0,0,0,0,10,
            10,10,8,4,0,0,7,8,10,10
    };
        private int[] Room7 = new int[]{
            10,10,10,10,10,10,10,10,10,10,
            9,1,1,1,0,0,0,0,0,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,0,0,0,0,1,1,1,10,
            10,0,0,0,9,9,0,0,0,10,
            10,5,5,6,7,8,0,0,0,10,
            10,0,0,0,0,0,0,1,0,10,
            10,0,0,0,0,0,0,10,0,10,
            10,10,0,0,10,0,0,10,0,10,
            10,10,10,10,0,0,0,10,10,10
    };

        private int[] Room8 = new int[]{
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,9,9,9,9,9,9,0,0,
            0,0,9,0,0,0,0,9,0,0,
            0,0,9,0,9,9,0,9,0,0,
            0,0,9,0,9,9,0,9,0,0,
            0,0,9,0,0,0,0,9,0,0,
            50,0,9,9,9,9,9,9,0,50,
            60,0,0,0,0,0,0,0,0,60,
            50,0,0,0,0,0,0,0,0,50
    };



       


        private int[] Room9 = new int[]{
            340,340,340,10,10,10,10,10,10,10,
            10,0,0,0,0,0,0,0,0,10,
            10,10,340,0,0,0,0,0,0,0,
            0,0,0,0,340,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,340,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            340,340,340,340,340,340,340,340,340,340,
            340,340,340,340,340,340,340,340,340,340,
            340,340,340,340,340,340,340,340,340,340,
    };

        

        private int[] Room13 = new int[]{
             10,10,10,10,10,10,10,10,10,10,
10,5,5,5,5,5,5,5,5,10,
10,3,3,3,3,3,3,3,5,10,
10,5,3,0,0,0,0,3,5,10,
10,5,3,0,1,1,0,3,5,10,
10,5,3,0,1,1,0,3,5,10,
10,5,3,0,0,0,0,3,5,10,
10,5,3,3,3,3,3,3,5,10,
10,5,5,5,5,5,5,5,5,10,
10,10,10,10,10,10,10,10,10,10
    };


        private int[] Roomstart = new int[]{
            10,10,10,0,0,0,0,10,10,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,0,0,0,0,0,0,0,10,
            5,0,0,0,0,0,0,0,0,10,
            0,55,60,60,60,55,0,0,0,6,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,44,46,50,50,50,50,341,0,
            0,2,10,10,10,10,10,10,10,0,
            10,10,10,10,10,10,10,10,10,10
    };

        private int[] Roomend = new int[]{
            10,10,10,0,0,0,0,10,10,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,0,0,0,0,0,0,0,10,
            10,0,55,60,60,55,0,0,0,10,
            5,0,0,0,0,0,0,0,0,5,
            0,56,60,57,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,44,48,341,341,10,10,44,0,
            0,0,48,10,10,10,10,10,10,0,
            10,10,10,10,10,10,10,10,10,10
    };

        public TileManager tileManager;



        public LevelGenerator(Player player, TileManager tileManager)
        {
            rooms1 = new int[][] { Room1 };
            rooms2 = new int[][] { Room2, };
            rooms3 = new int[][] { Room3 };
            rooms4 = new int[][] { Room4 };
            rooms5 = new int[][] { Room5 };
            rooms6 = new int[][] { Room6 };
            rooms7 = new int[][] { Room7 };
            rooms8 = new int[][] { Room8 };
            roomsstart = new int[][] { Roomstart };
            roomsend = new int[][] { Roomend };
            allrooms = new int[][][] { rooms1, rooms2, rooms3, rooms4, rooms5, rooms6, rooms7, rooms8 };
            this.player = player;
            this.tileManager = tileManager;
        }

        public int[] roomRandomizer(int[] rooma) 
        {
            int[] room = new int[rooma.Length];
            for (int i = 0; i < room.Length; i++)
            {
                room[i] = rooma[i];
            }


                int prob;

                int entangchoice = rnd.Next(4,6);

            for (int i = 0; i < room.Length; i++) 
            {
                //straight prob tiles
                if (room[i] > 0 && room[i] < 11)
                {
                    if(rnd.Next(0,10) < room[i]) 
                    {
                        room[i] = 1;

                    }
                    else
                    {
                        room[i] = 0;
                    }

                }


                if (room[i] > 10 && room[i] < 21)
                {
                    if (rnd.Next(0, 10) < (room[i]-10))
                    {
                        if(rnd.Next(0,2) == 0)
                        {
                            room[i] = 338;
                        }
                        else
                        {
                            room[i] = 339;
                        }
                        

                    }
                    else
                    {
                        room[i] = 0;
                    }

                }

                if (room[i] > 20 && room[i] < 31)
                {
                    if (rnd.Next(0, 10) < (room[i] - 20))
                    {
                        room[i] = 340;

                    }
                    else
                    {
                        room[i] = 0;
                    }

                }

                if (room[i] > 30 && room[i] < 41)
                {
                    if (rnd.Next(0, 10) < (room[i] - 30))
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            room[i] = 338;
                        }
                        else
                        {
                            room[i] = 339;
                        }


                    }
                    else
                    {
                        room[i] = 1;
                    }

                }
                //entaglement blocks
                if(entangchoice == 4)
                {
                    if (room[i] > 40 && room[i] < 51)
                    {
                        if (rnd.Next(0, 10) < (room[i]-40))
                        {
                            room[i] = 1;

                        }
                        else
                        {
                            room[i] = 0;
                        }

                    }else if(room[i] > 50 && room[i] < 61)
                    {
                        room[i] = 0;
                    }
                }
                else
                {
                    if (room[i] > 50 && room[i] < 61)
                    {
                        if (rnd.Next(0, 10) < (room[i] - 50))
                        {
                            room[i] = 1;

                        }
                        else
                        {
                            room[i] = 0;
                        }

                    }
                    else if (room[i] > 40 && room[i] < 51)
                    {
                        room[i] = 0;
                    }
                }



                //
                if (room[i] == 99)
                {
                    room[i] = 341;
                }



            }
            bool trapped = false;
            int count = 0;
            while (!trapped)
            {
                count++;
                int choice = rnd.Next(11,room.Length-1);
                if ((room[choice-10] == 0 || room[choice-1] == 0 || room[choice + 1] == 0) && ((room[choice] == 1 && room[choice + 1] == 1) || (room[choice] == 1 && room[choice - 1] == 1)))
                {
                    if (rnd.Next(0, 2) == 0)
                    {
                        room[choice] = 338;
                    }
                    else
                    {
                        room[choice] = 339;
                    }
                    count += 130;
                }
                if(count > 132)
                {
                    trapped = true;
                }
            }
           // Debug.WriteLine("start");
           // for (int i = 0; i < room.Length; i++)
           // {
            //    if (i % 10 == 0 && i != 0)
            //    {
             //       Debug.WriteLine("");
            //    }
            //    Debug.Write(room[i]);
               
            
          //  }
          //  Debug.WriteLine("");
          //  Debug.WriteLine("end");
            return room;
        
        }



        public int[] makeRoomRow(int[][] room1type, int[][] room2type, int[][] room3type, int[][] room4type)
        {


            int room1ind;
            int room2ind;
            int room3ind;
            int room4ind;

            
            room1ind = (rnd.Next(room1type.Length));
            room2ind = (rnd.Next(room2type.Length));
            room3ind = (rnd.Next(room3type.Length));
            room4ind = (rnd.Next(room4type.Length));

            int[] room1 = roomRandomizer(room1type[room1ind]);
            int[] room2 = roomRandomizer(room2type[room2ind]);
            int[] room3 = roomRandomizer(room3type[room3ind]);
            int[] room4 = roomRandomizer(room4type[room4ind]);




            int[] Row = new int[400];
            for (int x = 0; x < 10; x++)
            {

                
                    for (int z = 0; z < 10; z++)
                    {
                        Row[(x * 40) + (0 * 10) + z] =  room1[(x * 10) + z];

                    }
                for (int z = 0; z < 10; z++)
                {
                    Row[(x * 40) + (1 * 10) + z] = room2[(x * 10) + z];

                }
                for (int z = 0; z < 10; z++)
                {
                    Row[(x * 40) + (2 * 10) + z] = room3[(x * 10) + z];

                }
                for (int z = 0; z < 10; z++)
                {
                    Row[(x * 40) + (3 * 10) + z] = room4[(x * 10) + z];

                }



            }



            return Row;

        }


        public int[] makeMap()
        {
           int[] testing = makeRoomLayout();
            for (int i = 0; i< 16;i++)
            {
                if (testing[i] == 42)
                {
                    tileManager.startroomind = i; 
                }
            }


            int[][][] roompools = makeroompoolsinlayout(testing);
            

            int[] row1 = makeRoomRow(roompools[0], roompools[1], roompools[2], roompools[3]);
            int[] row2 = makeRoomRow(roompools[4], roompools[5], roompools[6], roompools[7]);
            int[] row3 = makeRoomRow(roompools[8], roompools[9], roompools[10], roompools[11]);
            int[] row4 = makeRoomRow(roompools[12], roompools[13], roompools[14], roompools[15]);
            //create the map
            row1 = row1.Concat(row2).ToArray();
            row2 = row3.Concat(row4).ToArray();
            row1 = row1.Concat(row2).ToArray();
            //add indestruble border
            for (int z = 0; z < 40; z++)
            {
                row1[z] = 1;
                row1[1560 + z] = 1;
                row1[z * 40] = 1;
                if (z > 0)
                {
                    if(row1[(z * 40) - 1] == 0)
                    {
                        row1[(z * 40) - 1] = 1;
                    }
                    
                }
            }
            //add player spawn area
            //row1[(40 * 5) + 5] = 0;
            //row1[(40 * 5) + 6] = 0;
            //row1[(40 * 6) + 5] = 0;
            //row1[(40 * 6) + 6] = 0;
           // row1[(40 * 7) + 5] = 1;
           // row1[(40 * 7) + 6] = 0;


            return row1;

        }

        public int[][][] makeroompoolsinlayout(int[] layout)
        {
            int[][][] result = new int[16][][];
            int choiceind = 0;

            for (int i = 0; i < 16; i++) 
            {
                if (layout[i] == 0)
                {
                    choiceind = rnd.Next(0, 8);
                    result[i] = allrooms[choiceind];

                }
                else if (layout[i] == 22 || layout[i] == 44) 
                {
                    choiceind = rnd.Next(1, 5);
                    if (choiceind == 1)
                    {
                        choiceind = 8;
                    }
                    result[i] = allrooms[choiceind-1];

                }
                else if(layout[i] == 23)
                {
                    result[i] = allrooms[2];
                }
                else if (layout[i] == 33)
                {
                    result[i] = allrooms[5];
                }
                else if (layout[i] == 43)
                {
                    result[i] = allrooms[2];
                }
                else if (layout[i] == 32)
                {
                    result[i] = allrooms[3];
                }
                else if (layout[i] == 34)
                {
                    result[i] = allrooms[3];
                }
                else if (layout[i] == 42)
                {
                    result[i] = roomsstart;
                }
                else if (layout[i] == 30 || layout[i] == 40 || layout[i] == 20)
                {
                    result[i] = roomsend;
                }

            }
            return result;


        }

        public int[] makeRoomLayout()
        {
            //int[][][] mapblueprint = new int[16][][];
            int[] pathmap = new int[16];
            int startingind = rnd.Next(0, 4);
            player.hitbox.Y = 400;
            player.hitbox.X = (960*startingind)+400;


            int endingind = 16;
            int curpathind = startingind;

            int decidingvar = 0;
            int prevdecidingvar = 0;

            pathmap[startingind] = 42;

            if (startingind == 0)
            {
                prevdecidingvar = 2;
            }
            else if (startingind == 3)
            {
                prevdecidingvar = 4;
            }
            else
            {
                prevdecidingvar = rnd.Next(1, 3);
                if (prevdecidingvar == 1)
                {
                    prevdecidingvar = 4;
                }
            }


            while (curpathind != endingind)
            {
                if (prevdecidingvar == 2)
                {
                    curpathind += 1;
                }
                else if (prevdecidingvar == 4)
                {
                    curpathind -= 1;
                }
                else
                {
                    curpathind += 4;
                }
                //determine where to go from new curind
                if (curpathind % 4 == 0)
                {
                    if (curpathind < 12)
                    {
                        if (prevdecidingvar != 4)
                        {
                            decidingvar = rnd.Next(2, 4);
                        }
                        else
                        {
                            decidingvar = 3;
                        }
                    }
                    else
                    {
                        endingind = curpathind;
                        decidingvar = 0;
                    }

                }
                else if (curpathind % 4 == 3)
                {
                    if (curpathind < 12)
                    {
                        if (prevdecidingvar != 2)
                        {
                            decidingvar = rnd.Next(3, 5);
                        }
                        else
                        {
                            decidingvar = 3;
                        }
                    }
                    else
                    {
                        endingind = curpathind;
                        decidingvar = 0;
                    }
                }
                else
                {
                    //middle two columns
                    if (curpathind < 12)
                    {
                        if (prevdecidingvar == 2)
                        {
                            decidingvar = rnd.Next(2, 4);
                        }
                        else if (prevdecidingvar == 4)
                        {
                            decidingvar = rnd.Next(3, 5);
                        }
                        else
                        {
                            decidingvar = rnd.Next(2, 5);
                        }
                    }
                    else
                    {
                        if (prevdecidingvar == 2)
                        {
                            decidingvar = rnd.Next(2, 4);
                            if(decidingvar == 3)
                            {
                                endingind = curpathind;
                                decidingvar = 0;
                            }
                        }
                        else if (prevdecidingvar == 4)
                        {
                            decidingvar = rnd.Next(3, 5);
                            if (decidingvar == 3)
                            {
                                endingind = curpathind;
                                decidingvar = 0;
                            }
                        }
                        else
                        {
                            decidingvar = rnd.Next(2, 5);
                            if (decidingvar == 3)
                            {
                                endingind = curpathind;
                                decidingvar = 0;
                            }
                        }
                    }
                }

                pathmap[curpathind] = int.Parse(prevdecidingvar.ToString() + decidingvar.ToString());
                //Debug.WriteLine(int.Parse(prevdecidingvar.ToString() + decidingvar.ToString()));
                prevdecidingvar = decidingvar;




            }
            return pathmap;
        }


    }
}