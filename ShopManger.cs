using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace monowizard
{
    internal class ShopManger
    {

        public int shopgridind;
        public Player player;
        public Random rand = new Random();
        public bool isShoponLevel = false;
        public Rectangle shopRect;
        

        public ShopManger(Player player)
        {

            this.player = player;
           

        }

        public void setupShop()
        {

            player.itemManager.addShopItemRand(((shopgridind % 4) * 960)+200,((shopgridind / 4) * 960)+500);
            player.itemManager.addShopItemRand(((shopgridind % 4) * 960) + 450, ((shopgridind / 4) * 960) + 500);
            player.itemManager.addShopItemRand(((shopgridind % 4) * 960) + 700, ((shopgridind / 4) * 960) + 500);
        }

        public void setShopRect() 
        {
        shopRect = new Rectangle((shopgridind % 4) * 960, (shopgridind / 4) * 960,960,960);

        }


        public void update()
        {
           
            if (isShoponLevel)
            {
                if(player.hitbox.X > (shopgridind%4)*960 && player.hitbox.X < ((shopgridind % 4) * 960)+960)
                {
                   
                    if (player.hitbox.Y > (shopgridind / 4) * 960 && player.hitbox.Y < ((shopgridind / 4) * 960) + 960)
                    {
                        
                        





                    }
                }


            }
        }



    }
}
