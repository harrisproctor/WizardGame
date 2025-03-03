using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class LevelManager
    {
        public Player player;
        public int level = 0;
        public int world = 0;

        public LevelManager(Player p) {
            player = p;
        }
        
        public void reset() 
        {

            level = -1;
            world = 0;
            nextLevel();
        
        }
        public void nextLevel()
        {
            level++;
            if (level < 4)
            {
                world = 1;
                player.colcheck.tileManager.newMap();
            }
            else if (level < 7) 
            {
                world = 2;
                player.colcheck.tileManager.newMapSwamp();


            }
            //Debug.WriteLine("Level: " + level);


        }




    }
}
