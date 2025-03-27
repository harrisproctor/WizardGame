using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monowizard
{
    internal class CollisionCheck
    {

        public int[] map;
        public TileManager tileManager;
        int entityLeftWorldX;
        int entityRightWorldX;
        int entityTopWorldY; 
        int entityBottomWorldY;
        int entityLeftCol;
        int entityRightCol;
        int entityTopRow;
        int entityBottomRow;
        int tileNum1, tileNum2, tileNum3;
        int ind1;
        int ind2;
        int ledgegrabspacing;
        Rectangle intersection = new Rectangle(0, 0, 96, 96);

        public CollisionCheck(TileManager tm) 
        { 
            tileManager = tm;
            setMap();
        }

        public void setMap() { 
        this.map = tileManager.map;
        }

        public void checkTilePlayer(Player player)
        {
            setMap();

            entityLeftWorldX = player.hitbox.Left;//entity.solidArea.x;
            entityRightWorldX = player.hitbox.Right;//entity.solidArea.x + entity.solidArea.width;
            entityTopWorldY = player.hitbox.Top;// + entity.solidArea.y;
            entityBottomWorldY = player.hitbox.Bottom;// + entity.sowlidArea.y + entity.solidArea.height;
            //int entityBottomWorldY2 = entity.worldY + entity.solidArea.y + entity.solidArea.height-5;

             entityLeftCol = entityLeftWorldX / 96;
            //int entityLeftColIn = (entityLeftWorldX + 2) / 96;
             entityRightCol = entityRightWorldX / 96;
           // int entityRightColIn = (entityRightWorldX - 2) / 96;
             entityTopRow = entityTopWorldY / 96;
             entityBottomRow = entityBottomWorldY / 96;
            //int entityBottomRow2 = (entityBottomWorldY-5)/gp.tileSize;
            



            if (player.yvel < 0)
            {
                
                entityTopRow = (entityTopWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityTopRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {

                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum1].tileEffect(3,ind1,player);


                }
               
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum2].tileEffect(3, ind2, player);

                }
                entityTopRow = (entityTopWorldY) / 96;

            }
            else if (player.yvel > 0)
            {
                
                entityBottomRow = (entityBottomWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityBottomRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                 if (tileManager.collides[tileNum1] == true )
                {

                    //entity.collisionOn = true;
                    player.grounded = true;
                    player.yvel = 0;
                    player.hitbox.Y = (entityBottomRow * 96)-81;
                    tileManager.tileEffects[tileNum1].tileEffect(1, ind1,player);
                    //entity.yvel = 0 ;
                    //System.out.println("on floor");

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.grounded = true;
                    player.yvel = 0;
                    player.hitbox.Y = (entityBottomRow * 96) - 81;
                    tileManager.tileEffects[tileNum2].tileEffect(1, ind2, player);
                }
                entityBottomRow = entityBottomWorldY / 96;
            }
            if (player.xvel < 0)
            {
                
                entityLeftCol = (entityLeftWorldX + player.xvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityLeftCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;
                    player.xvel = 1;
                    tileManager.tileEffects[tileNum1].tileEffect(2, ind1, player);

                }
                 if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;
                    player.xvel = 1;
                    tileManager.tileEffects[tileNum2].tileEffect(2, ind2,player);
                }
                entityLeftCol = entityLeftWorldX / 96;

            }
            else if (player.xvel > 0)
            {
                
                entityRightCol = (entityRightWorldX + player.xvel) / 96;
                ind1 = entityRightCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;
                    player.xvel = -1;
                    tileManager.tileEffects[tileNum1].tileEffect(4, ind1, player);

                }
                if (tileManager.collides[tileNum2] == true) 
                {
                    player.colliding = true;
                    player.xvel = -1;
                    tileManager.tileEffects[tileNum2].tileEffect(4, ind2,player);
                }
                entityRightCol = entityRightWorldX / 96;

            }
            if (player.consious && player.noledgegrabframes == 0)
            {



                entityTopWorldY = player.hitbox.Top+20;// + entity.solidArea.y;
                entityTopRow = entityTopWorldY / 96;
                //create spacing var that is normally like 10 or 15 but if yvel if greater then that change it so terminal velocity drops still grab ledge
                if(player.yvel < 15)
                {
                    ledgegrabspacing = 15;
                }
                else
                {
                    ledgegrabspacing = player.yvel;
                }

                if ((entityLeftWorldX + 10) - (entityLeftCol * 96) < 15 && ( (entityTopWorldY - (entityTopRow * 96) < ledgegrabspacing) && entityTopWorldY - (entityTopRow * 96) > -ledgegrabspacing) )
                {
                    ind1 = (entityLeftCol - 1) + (entityTopRow * 40);
                    tileNum1 = map[ind1];
                    tileNum2 = map[(entityLeftCol) + ((entityTopRow - 1) * 40)];
                    tileNum3 = map[(entityLeftCol - 1) + ((entityTopRow - 1) * 40)];
                    if (tileManager.collides[tileNum3] == false && player.grounded == false)
                    {

                        if (tileManager.collides[tileNum1] == true && tileManager.collides[tileNum2] == false && player.yvel > -1)
                        {
                            //System.out.println("future");
                            player.ledgegrab = true;
                            player.ledgedir = 0;
                            player.ledgetileind = ind1;
                            player.hitbox.Y = (entityTopRow * 96) - 20;
                            player.hitbox.X = ((entityLeftCol - 1) * 96) + 17 + 80;
                            //tileManager.tileEffects[tileNum1].tileEffect(2, ind1, player);
                        }



                    }
                }
                else if ((entityRightWorldX + 10) - ((entityRightCol + 1) * 96) > -15 && ((entityTopWorldY - (entityTopRow * 96) < ledgegrabspacing) && entityTopWorldY - (entityTopRow * 96) > -ledgegrabspacing))
                {
                    //System.out.println("near right");
                    ind1 = (entityRightCol + 1) + (entityTopRow * 40);
                    tileNum1 = map[ind1];
                    tileNum2 = map[(entityRightCol) + ((entityTopRow - 1) * 40)];
                    tileNum3 = map[(entityRightCol + 1) + ((entityTopRow - 1) * 40)];
                    if (tileManager.collides[tileNum3] == false && player.grounded == false)
                    {

                        if (tileManager.collides[tileNum1] == true && tileManager.collides[tileNum2] == false && player.yvel > -1)
                        {
                            //System.out.println("future righy");
                            player.ledgegrab = true;
                            player.ledgedir = 1;
                            player.ledgetileind = ind1;
                            player.hitbox.Y = (entityTopRow * 96) - 20;
                            player.hitbox.X = ((entityRightCol + 1) * 96) - 4 - 80;
                           // tileManager.tileEffects[tileNum1].tileEffect(4, ind1, player);
                        }



                    }
                }
                
            }
            if (player.ledgegrab == true)
            {
                if (player.ledgedir == 0)
                {
                    
                    ind1 = (entityLeftCol - 1) + ((entityTopRow ) * 40);
                    tileNum1 = map[ind1];
                    if(tileNum1 == 340)
                    {
                        tileManager.tileEffects[tileNum1].tileEffect(2, ind1, player);
                    }
                   
                    
                }
                else
                {
                    ind1 = (entityRightCol + 1) + ((entityTopRow ) * 40);
                    tileNum1 = map[ind1];
                    if (tileNum1 == 340)
                    {
                        tileManager.tileEffects[tileNum1].tileEffect(4, ind1, player);
                    }

                }
            }


        }
        public void checkTilenoE(Entity player)
        {

            entityLeftWorldX = (int)player.hitbox.X;//entity.solidArea.x;
            entityRightWorldX = (int)player.hitbox.X + player.hitbox.Width;//entity.solidArea.x + entity.solidArea.width;
            entityTopWorldY = (int)player.hitbox.Y;// + entity.solidArea.y;
            entityBottomWorldY = (int)player.hitbox.Y + player.hitbox.Height;// + entity.sowlidArea.y + entity.solidArea.height;
                                                                             //int entityBottomWorldY2 = entity.worldY + entity.solidArea.y + entity.solidArea.height-5;

            entityLeftCol = entityLeftWorldX / 96;
            //int entityLeftColIn = (entityLeftWorldX + 2) / 96;
            entityRightCol = entityRightWorldX / 96;
            // int entityRightColIn = (entityRightWorldX - 2) / 96;
            entityTopRow = entityTopWorldY / 96;
            entityBottomRow = entityBottomWorldY / 96;
            //int entityBottomRow2 = (entityBottomWorldY-5)/gp.tileSize;



            if (player.yvel < 0)
            {

                entityTopRow = (entityTopWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityTopRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum1].tileEffect(3, ind1, player);
                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum2].tileEffect(3, ind2, player);
                }
                entityTopRow = (entityTopWorldY) / 96;

            }
            else if (player.yvel > 0)
            {
                entityBottomRow = (entityBottomWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityBottomRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {

                    //entity.collisionOn = true;
                    player.grounded = true;
                    player.yvel = 0;
                    // player.hitbox.Y = (entityBottomRow * 96) - 33;
                    //entity.yvel = 0 ;
                    //System.out.println("on floor");
                    tileManager.tileEffects[tileNum1].tileEffect(1, ind1, player);

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.grounded = true;
                    player.yvel = 0;
                    tileManager.tileEffects[tileNum2].tileEffect(1, ind2, player);
                }
                entityBottomRow = entityBottomWorldY / 96;
            }
            if (player.xvel < 0)
            {

                entityLeftCol = (entityLeftWorldX + player.xvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityLeftCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;

                    player.xvel = player.xvel / player.bounce;
                    player.xvel += 2;
                    tileManager.tileEffects[tileNum1].tileEffect(2, ind1, player);

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;

                    player.xvel = player.xvel / player.bounce;
                    player.xvel += 2;
                    tileManager.tileEffects[tileNum2].tileEffect(2, ind2, player);
                }
                entityLeftCol = entityLeftWorldX / 96;

            }
            else if (player.xvel > 0)
            {

                entityRightCol = (entityRightWorldX + player.xvel) / 96;
                ind1 = entityRightCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;

                    player.xvel = -(player.xvel / player.bounce);
                    player.xvel -= 2;
                    tileManager.tileEffects[tileNum1].tileEffect(4, ind1, player);

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;

                    player.xvel = -(player.xvel / player.bounce);
                    player.xvel -= 2;
                    tileManager.tileEffects[tileNum2].tileEffect(4, ind2, player);
                }
                entityRightCol = entityRightWorldX / 96;

            }
            //eitems for all colliding mf's
            // eitemCheck(player);
        }

        public void checkTile(Entity player)
        {

            entityLeftWorldX = (int)player.hitbox.X;//entity.solidArea.x;
            entityRightWorldX = (int)player.hitbox.X + player.hitbox.Width;//entity.solidArea.x + entity.solidArea.width;
            entityTopWorldY =  (int)player.hitbox.Y;// + entity.solidArea.y;
            entityBottomWorldY = (int)player.hitbox.Y + player.hitbox.Height;// + entity.sowlidArea.y + entity.solidArea.height;
                                                                      //int entityBottomWorldY2 = entity.worldY + entity.solidArea.y + entity.solidArea.height-5;

            entityLeftCol = entityLeftWorldX / 96;
            //int entityLeftColIn = (entityLeftWorldX + 2) / 96;
            entityRightCol = entityRightWorldX / 96;
            // int entityRightColIn = (entityRightWorldX - 2) / 96;
            entityTopRow = entityTopWorldY / 96;
            entityBottomRow = entityBottomWorldY / 96;
            //int entityBottomRow2 = (entityBottomWorldY-5)/gp.tileSize;



            if (player.yvel < 0)
            {
                
                entityTopRow = (entityTopWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityTopRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum1].tileEffect(3, ind1,player);
                }
                if (tileManager.collides[tileNum2] == true) 
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum2].tileEffect(3, ind2, player);
                }
                entityTopRow = (entityTopWorldY) / 96;

            }
            else if (player.yvel > 0)
            {
                entityBottomRow = (entityBottomWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityBottomRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {

                    //entity.collisionOn = true;
                    player.grounded = true;
                    player.yvel = 0;
                    // player.hitbox.Y = (entityBottomRow * 96) - 33;
                    //entity.yvel = 0 ;
                    //System.out.println("on floor");
                    tileManager.tileEffects[tileNum1].tileEffect(1, ind1, player);

                }
                if(tileManager.collides[tileNum2] == true)
                {
                   player.grounded = true;
                    player.yvel = 0;
                    tileManager.tileEffects[tileNum2].tileEffect(1, ind2, player);
                }
                entityBottomRow = entityBottomWorldY / 96;
            }
            if (player.xvel < 0)
            {
                
                entityLeftCol = (entityLeftWorldX + player.xvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityLeftCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;
                    
                    player.xvel = player.xvel / player.bounce;
                    player.xvel += 2;
                    tileManager.tileEffects[tileNum1].tileEffect(2, ind1,player);

                }
                if(tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;

                    player.xvel = player.xvel / player.bounce;
                    player.xvel += 2;
                    tileManager.tileEffects[tileNum2].tileEffect(2, ind2, player);
                }
                entityLeftCol = entityLeftWorldX / 96;

            }
            else if (player.xvel > 0)
            {
                
                entityRightCol = (entityRightWorldX + player.xvel) / 96;
                ind1 = entityRightCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true )
                {
                    player.colliding = true;
                    
                    player.xvel = - (player.xvel/player.bounce);
                    player.xvel -= 2;
                    tileManager.tileEffects[tileNum1].tileEffect(4,ind1,player);

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;

                    player.xvel = -(player.xvel / player.bounce);
                    player.xvel -= 2;
                    tileManager.tileEffects[tileNum2].tileEffect(4, ind2, player);
                }
                entityRightCol = entityRightWorldX / 96;

            }
            //eitems for all colliding mf's
            eitemCheck(player);
        }

        public void eitemCheck(Entity entity)
        {
            foreach (var item in tileManager.itemmanager.eitems)
            {
                if (entity.hitbox.Intersects(item.hitbox))
                {
                    // Handle collision between entity and item
                    Rectangle intersection = Rectangle.Intersect(entity.hitbox, item.hitbox);

                    if (intersection.Width < intersection.Height)
                    {
                        // Horizontal collision
                        if (entity.hitbox.Center.X < item.hitbox.Center.X)
                        {
                            // Entity is to the left of the item
                            entity.hitbox.X -= intersection.Width;
                        }
                        else
                        {
                            // Entity is to the right of the item
                            entity.hitbox.X += intersection.Width;
                        }
                        entity.xvel = 0;
                        entity.colliding = true;
                    }
                    else
                    {
                        // Vertical collision
                        if (entity.hitbox.Center.Y < item.hitbox.Center.Y)
                        {
                            // Entity is above the item
                            entity.hitbox.Y -= intersection.Height;
                            entity.grounded = true;
                        }
                        else
                        {
                            // Entity is below the item
                            entity.hitbox.Y += intersection.Height;
                        }
                        entity.yvel = 0;
                    }
                }
            }
        }


            


        public void onTheLedge(Entity player)
        {
            entityLeftWorldX = (int)player.hitbox.X;//entity.solidArea.x;
            entityRightWorldX = (int)player.hitbox.X + player.hitbox.Width;//entity.solidArea.x + entity.solidArea.width;
            entityTopWorldY = (int)player.hitbox.Y;// + entity.solidArea.y;
            entityBottomWorldY = (int)player.hitbox.Y + player.hitbox.Height;// + entity.sowlidArea.y + entity.solidArea.height;
                                                                             //int entityBottomWorldY2 = entity.worldY + entity.solidArea.y + entity.solidArea.height-5;

            entityLeftCol = entityLeftWorldX / 96;
            //int entityLeftColIn = (entityLeftWorldX + 2) / 96;
            entityRightCol = entityRightWorldX / 96;
            // int entityRightColIn = (entityRightWorldX - 2) / 96;
            entityTopRow = entityTopWorldY / 96;
            entityBottomRow =( entityBottomWorldY+20) / 96;
            //int entityBottomRow2 = (entityBottomWorldY-5)/gp.tileSize;

            ind1 = entityRightCol + (entityBottomRow * 40);
            tileNum1 = map[ind1];
            if (player.xvel > 0)
            {
                if (tileManager.collides[tileNum1] == false && player.grounded)
                {
                    player.onLedge = true;

                }
            }

            ind1 = entityLeftCol + (entityBottomRow * 40);
            tileNum1 = map[ind1];
            if (player.xvel < 0)
            {
                if (tileManager.collides[tileNum1] == false && player.grounded)
                {
                    player.onLedge = true;
                }
            }

        }

        public void spaceToWalk(Entity player)
        {
            entityLeftWorldX = (int)player.hitbox.X;//entity.solidArea.x;
            entityRightWorldX = (int)player.hitbox.X + player.hitbox.Width;//entity.solidArea.x + entity.solidArea.width;
            entityTopWorldY = (int)player.hitbox.Y;// + entity.solidArea.y;
            entityBottomWorldY = (int)player.hitbox.Y + player.hitbox.Height;// + entity.sowlidArea.y + entity.solidArea.height;
                                                                             //int entityBottomWorldY2 = entity.worldY + entity.solidArea.y + entity.solidArea.height-5;

            entityLeftCol = entityLeftWorldX / 96;
            //int entityLeftColIn = (entityLeftWorldX + 2) / 96;
            entityRightCol = entityRightWorldX / 96;
            
            // int entityRightColIn = (entityRightWorldX - 2) / 96;
            entityTopRow = (entityTopWorldY+40) / 96;
            entityBottomRow = (entityBottomWorldY + 20) / 96;
            //int entityBottomRow2 = (entityBottomWorldY-5)/gp.tileSize;

            ind1 = entityRightCol + (entityBottomRow * 40);
            tileNum1 = map[ind1];
            player.spaceToMove = true;
            if (tileManager.collides[tileNum1] == true && player.grounded)
            {
               player.spaceToMove = false;

            }
           

            ind1 = entityLeftCol + (entityBottomRow * 40);
            tileNum1 = map[ind1];
            if (tileManager.collides[tileNum1] == true && player.grounded)
            {
                player.spaceToMove = false;
            }
            entityLeftCol = (entityLeftWorldX-20) / 96;

            entityRightCol = (entityRightWorldX+20) / 96;
            ind1 = entityRightCol + (entityTopRow * 40);
            tileNum1 = map[ind1];
            if (tileManager.collides[tileNum1] == false)
            {
                player.spaceToMove = false;

            }


            ind1 = entityLeftCol + (entityTopRow * 40);
            tileNum1 = map[ind1];
            if (tileManager.collides[tileNum1] == false)
            {
                player.spaceToMove = false;
            }






        }


        public int checkTileRet(Entity player)
        {

            entityLeftWorldX = (int)player.hitbox.X;//entity.solidArea.x;
            entityRightWorldX = (int)player.hitbox.X + player.hitbox.Width;//entity.solidArea.x + entity.solidArea.width;
            entityTopWorldY = (int)player.hitbox.Y;// + entity.solidArea.y;
            entityBottomWorldY = (int)player.hitbox.Y + player.hitbox.Height;// + entity.sowlidArea.y + entity.solidArea.height;
                                                                             //int entityBottomWorldY2 = entity.worldY + entity.solidArea.y + entity.solidArea.height-5;

            entityLeftCol = entityLeftWorldX / 96;
            //int entityLeftColIn = (entityLeftWorldX + 2) / 96;
            entityRightCol = entityRightWorldX / 96;
            // int entityRightColIn = (entityRightWorldX - 2) / 96;
            entityTopRow = entityTopWorldY / 96;
            entityBottomRow = entityBottomWorldY / 96;
            //int entityBottomRow2 = (entityBottomWorldY-5)/gp.tileSize;



            if (player.yvel < 0)
            {

                entityTopRow = (entityTopWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityTopRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum1].tileEffect(3, ind1, player);
                    return ind1;
                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;
                    // player.position.Y += 3;
                    player.yvel = 1;
                    tileManager.tileEffects[tileNum2].tileEffect(3, ind2, player);
                    return ind2;
                }
                entityTopRow = (entityTopWorldY) / 96;

            }
            else if (player.yvel > 0)
            {
                entityBottomRow = (entityBottomWorldY + player.yvel) / 96;
                ind1 = entityLeftCol + (entityBottomRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {

                    //entity.collisionOn = true;
                    player.grounded = true;
                    player.yvel = 0;
                    // player.hitbox.Y = (entityBottomRow * 96) - 33;
                    //entity.yvel = 0 ;
                    //System.out.println("on floor");
                    tileManager.tileEffects[tileNum1].tileEffect(1, ind1, player);
                    return ind1;

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.grounded = true;
                    player.yvel = 0;
                    tileManager.tileEffects[tileNum2].tileEffect(1, ind2, player);
                    return ind2;
                }
                entityBottomRow = entityBottomWorldY / 96;
            }
            if (player.xvel < 0)
            {

                entityLeftCol = (entityLeftWorldX + player.xvel) / 96;
                ind1 = entityLeftCol + (entityTopRow * 40);
                ind2 = entityLeftCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;

                    player.xvel = player.xvel / player.bounce;
                    player.xvel += 2;
                    tileManager.tileEffects[tileNum1].tileEffect(2, ind1, player);
                    return ind1;

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;

                    player.xvel = player.xvel / player.bounce;
                    player.xvel += 2;
                    tileManager.tileEffects[tileNum2].tileEffect(2, ind2, player);
                    return ind2;
                }
                entityLeftCol = entityLeftWorldX / 96;

            }
            else if (player.xvel > 0)
            {

                entityRightCol = (entityRightWorldX + player.xvel) / 96;
                ind1 = entityRightCol + (entityTopRow * 40);
                ind2 = entityRightCol + (entityBottomRow * 40);
                tileNum1 = map[ind1];
                tileNum2 = map[ind2];
                if (tileManager.collides[tileNum1] == true)
                {
                    player.colliding = true;

                    player.xvel = -(player.xvel / player.bounce);
                    player.xvel -= 2;
                    tileManager.tileEffects[tileNum1].tileEffect(4, ind1, player);
                    return ind1;

                }
                if (tileManager.collides[tileNum2] == true)
                {
                    player.colliding = true;

                    player.xvel = -(player.xvel / player.bounce);
                    player.xvel -= 2;
                    tileManager.tileEffects[tileNum2].tileEffect(4, ind2, player);
                    return ind2;
                }
                entityRightCol = entityRightWorldX / 96;

            }
            return -1;
        }







    }
}
