using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class TrapGlyph1Tile : Tile
    {
        public TileManager manager;
        int xspawn;
        int yspawn;
        

        public override void tileEffect(int side,int ind, Entity e)
        {
            if (manager.updateTiles.ContainsKey(ind))
            {
                manager.updateTiles[ind].Activate(side, e);
            }
           
           





        }
    }
}
