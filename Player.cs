using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Numerics;
using System.Collections;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Diagnostics;

namespace monowizard
{
    internal class Player : Entity
    {

        //public Texture2D texture;
        //public Rectangle position = new Rectangle(905,485,110,110);
        public Texture2D fireballtexture;
        public Texture2D cloudtexture;
        public Rectangle drawspot = new Rectangle(-5, 10, 118, 118);
        public Vector2 screenpos;
        public SpriteEffects spriteEffects;
        public Random rnd = new Random();
       // public int xvel;
       // public int yvel;
        public int maxVel = 25;
        public int centerX;
        public int centerY;
        public int centerWorldX;
        public int centerWorldY;
        public int camxvel;
        public int camyvel;
       // public bool colliding;
       // public bool grounded;
        public CollisionCheck colcheck;
       // public int[] hitbox;
        public FrameCounter frameCounter;
        public bool jumping = false;
        public int jumpframe = 0;
        public bool runright;
        public bool runleft;
        //0 = right, 1 = left, 2 = up, 3 = down
        public int facing = 0;
        public bool ledgegrab;
        public bool jumpPress = false;
        public ItemManager itemManager;
        public HoldItem heldItem;
        public HoldItem prevheldItem;
        public int framesincethrow;
        public bool lookup = false;
        public bool lookdown = false ;
        int playerdistx;
        int playerdisty;
        public bool consious = true;
        public int framesicneground = 0;
        public bool leftarrow;
        public bool leftact;
        public int health = 6;
        public float mana = 80;
        public float startHealth;
        public float startMana;
        public int uncousiustime;
        //your current cantrip
        //
        public Cantrip cantrip;
        public Cantrip cantrip2;
        public Cantrip cantrip3;
        public Cantrip cantrip4;
        public MonsterManager mm;
        public Game currentGame;
        public UI ui;
        public int iframes = 0;
        public int camlookoffestX;
        public int camlookoffestY;
        public int crouchcounter;
        public int lookupcounter;
        public int noledgegrabframes = 0;
        public int ledgedir = 3;
        public int ledgetileind = 0;
        public Color playertint = Color.White;
        public int switchcolordelay = 1;
        public ShopManger shop;
        public bool epressed = false;
        public bool upAct = false;
        public bool downAct = false;
        public bool rightAct = false;
        public LevelManager levelManager;
        public int jumpStr = 20;
        public bool muddy = false;
        public int mudclean = 50;
        public bool angryLibKeep = false;
        public int elevation;
        public int falldmgThreshold = 800;
        public int maxRunSpeed = 9;
        public int runExcel = 1;
        public int defmaxRunSpeed;
        public int defrunExcel;
        public int jumpPow = -6;
        public int startJumpStr;
        public int startjumpPow;








        public Player()
        {
            id = 1;
            hitrank = 1;
            centerWorldX = 960;
            centerWorldY = 540;
            centerX = 960;
            centerY = 540;
            hitbox.X = 550;
            hitbox.Y = 600;
            hitbox.Width = 80;
            hitbox.Height = 80;
            spriteEffects = SpriteEffects.None;
            levelManager = new LevelManager(this);
            startHealth = health;
            startMana = mana;
            defmaxRunSpeed = maxRunSpeed;
            defrunExcel = runExcel;
            startjumpPow = jumpPow;
            startJumpStr = jumpStr;
            //hitbox = new int[4];
            //left x offset
            // hitbox[0] = 15;
            //right x offsets
            // hitbox[1] =  95;
            //top y offset
            // hitbox[2] = 30;
            //bottom y offset
            // hitbox[3] = 110;



        }



        public void setcolcheck(CollisionCheck colcheck)
        {
              this.colcheck = colcheck;
            
        }

        public void changeHealth(int change) 
        {
            health += change;
            if (health > 99)
            {
                health = 99;
            }
            
            
            ui.setHealth(health);
            if(health < 1)
            {
                //death and reset
                colcheck.tileManager.ogre = false;
                colcheck.tileManager.troll = false;

                colcheck.tileManager.libLevSetUp.switchSwampAssets(colcheck.tileManager.theGame.Content);

                cantrip = null;
                cantrip2 = null;
                cantrip3 = null;
                cantrip4 = null;
                heldItem = null;

                itemManager.items.Clear();
                colcheck.tileManager.magicmanager.items.Clear();
                angryLibKeep = false;
                levelManager.reset();
                changeHealth((int)startHealth - health);
                changeMana((int)startMana - mana);
                xvel = 0;
                yvel = 0;
                maxRunSpeed = defmaxRunSpeed; 
                defrunExcel = runExcel;
                jumpStr = startJumpStr;
                jumpPow = startjumpPow;
                
                ui.items.Clear();
                

                //levelManager.reset();


            }
        }
        public void changeMana(float change)
        {
            mana += change;
            ui.setMana((int)mana);
           
        }

        public override void hit(Entity entity) {

            if (iframes == 0)
            {
                if ((entity == prevheldItem && framesincethrow != 0) == false)
                {



                    if (ledgegrab == true)
                    {
                        ledgegrab = false;
                        noledgegrabframes++;
                    }
                    switch (entity.hitrank)
                    {
                        case 1:
                            // Code to execute if variable == value1
                            xvel += entity.xvel;
                            consious = false;
                            changeHealth(-1);
                            iframes = 50;
                            break;
                        case 2:
                            xvel += entity.xvel * 2;
                            //consious = false;
                            changeHealth(-1);
                            iframes = 50;
                            // Code to execute if variable == value2
                            break;
                        case 3:
                            xvel += entity.xvel;
                            consious = false;
                            changeHealth(-2);
                            iframes = 50;
                            // Code to execute if variable == value2
                            break;
                        case 4:
                            xvel += entity.xvel;
                            consious = false;
                            changeHealth(-3);
                            iframes = 50;
                            // Code to execute if variable == value2
                            break;
                        case 5:
                            xvel += entity.xvel;
                            consious = false;
                            changeHealth(-10);
                            iframes = 50;
                            // Code to execute if variable == value2
                            break;
                        // Add more cases as needed
                        case 6:
                            consious = false;
                            if (entity.xvel > 0)
                            {
                                xvel += 15;
                            }
                            else
                            {
                                xvel -= 15;
                            }
                            // xvel += (entity.xvel * 11);
                            changeHealth(-1);
                            iframes = 50;
                            break;
                        case 7:
                            //consious = false;
                            if (entity.xvel > 0)
                            {
                                xvel += 12;
                            }
                            else
                            {
                                xvel -= 12;
                            }
                            // xvel += (entity.xvel * 11);
                            changeHealth(-1);
                            iframes = 50;
                            break;
                        default:
                            // Code to execute if none of the cases match
                            
                            break;
                    }


                    /*  if (entity.id == 101)
                      {
                          xvel += entity.xvel;
                          consious = false;
                          changeHealth(-1);
                          iframes = 50;


                      }
                      else if (entity.id == 102)
                      {
                          xvel += entity.xvel;
                          consious = false;
                          changeHealth(-1);
                          iframes = 50;

                      }
                      else if (entity.id == 103)
                      {
                          xvel += entity.xvel;
                          consious = false;
                          changeHealth(-1);
                          iframes = 50;

                      }
                      else if (entity.id == 104)
                      {
                          xvel += entity.xvel;
                          consious = false;
                          changeHealth(-1);
                          iframes = 50;

                      }
                      else if (entity.id == 105)
                      {
                          xvel += entity.xvel;
                          consious = false;
                          changeHealth(-1);
                          iframes = 50;

                      }
                      else if (entity.id == 34)
                      {
                          consious = false;
                          if (entity.xvel > 0)
                          {
                              xvel += 15;
                          }
                          else
                          {
                              xvel -= 15; 
                          }
                         // xvel += (entity.xvel * 11);
                          changeHealth(-1);
                          iframes = 50;
                      }
                      else if (entity.id == 33)
                      {
                          // consious = false;
                          xvel += entity.xvel * 8;
                          changeHealth(-1);
                          iframes = 50;
                      }
                      else if (entity.id == 35)
                      {
                          // consious = false;
                          xvel += entity.xvel * 8;
                          changeHealth(-1);
                          iframes = 50;
                      }
                      else if (entity.id == 1001)
                      {
                          consious = false;
                          xvel += entity.xvel;
                          yvel += entity.yvel;
                          changeHealth(-1);
                          iframes = 50;
                      }
                      else if (entity.id == 1002)
                      {
                          consious = false;
                          xvel += entity.xvel;
                          yvel += entity.yvel;
                          changeHealth(-1);
                          iframes = 50;
                      }
                      else if (entity.id == 1055)
                      {
                          consious = false;
                          xvel += entity.xvel;
                          yvel += entity.yvel;
                          changeHealth(-3);
                          iframes = 50;
                      }
                      else if(entity.id == 144)
                      {
                          changeHealth((-health) - 2);
                      }*/
                }
            }

        }


        public void update(KeyboardState keyState) {
            if(iframes > 0) 
            {
                iframes--;
                playertint = Color.Gray;
                   
                if (iframes == 0)
                {
                    playertint = Color.White;
                }
            }

            if (consious)
            {
                jumping = false;
                runright = false;
                runleft = false;
                lookdown = false;
                lookup = false;
                leftarrow = false;
                onExit = false;



                
                if (keyState.IsKeyDown(Keys.D))
                {
                    runright = true;
                    spriteEffects = SpriteEffects.None;
                    facing = 0;
                    if (xvel < maxRunSpeed)
                    {
                        xvel += runExcel;

                    }



                }

                if (keyState.IsKeyDown(Keys.W))
                {
                    lookup = true;
                    lookupcounter++;

                }
                else
                {
                    lookupcounter = 0;

                }
                if (keyState.IsKeyDown(Keys.A))
                {
                    runleft = true;
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    facing = 1;
                    if (xvel > -maxRunSpeed)
                    {
                        xvel -= runExcel;
                    }




                }
                if (keyState.IsKeyDown(Keys.Space))
                {
                    if (!jumpPress)
                    {
                        jumping = true;
                    }




                }
                else if (keyState.IsKeyUp(Keys.Space))
                {
                    jumpPress = false;


                }

                if (keyState.IsKeyDown(Keys.S))
                {
                    lookdown = true;
                    crouchcounter++;


                }
                else
                {
                    crouchcounter = 0;
                }

                if (keyState.IsKeyDown(Keys.Left))
                {
                    leftarrow = true;
                    if (lookdown && leftact) 
                    {
                        leftact = false;
                        if(heldItem == null)
                        {
                            for (int i = 0; i < itemManager.items.Count; i++)
                            {


                                if (itemManager.items[i].hitbox.Intersects(hitbox))
                                {

                                   
                                        
                                        heldItem = itemManager.items[i];
                                        break;



                                    

                                }
                            }
                            if ( heldItem == null && cantrip != null)
                            {
                                if (mana >= cantrip.manacost)
                                {

                                    changeMana(-cantrip.manacost);
                                    leftact = false;
                                    
                                    cantrip.isupordown = -1;
                                    
                                    cantrip.cast();
                                }


                            }
                        }
                        else
                        {
                            //drop item
                            //make sure its
                            if (heldItem.hitbox.Y + heldItem.hitbox.Height > hitbox.Y + hitbox.Height)
                            {
                                heldItem.hitbox.Y = hitbox.Y;

                            }
                            if (facing == 0)
                            {
                                heldItem.xvel = 2;

                            }
                            else
                            {

                                heldItem.xvel = -2;

                            }
                            //make sure its not in wall
                            colcheck.checkTile(heldItem);
                            if (heldItem.colliding)
                            {
                                heldItem.hitbox.X = hitbox.X + heldItem.xmidoffset;


                            }


                            framesincethrow++;
                            prevheldItem = heldItem;
                            heldItem = null;
                        }
                    }
                    if( leftact && heldItem == null && cantrip != null)
                    {
                        if (mana >= cantrip.manacost)
                        {

                            changeMana(-cantrip.manacost);
                            leftact = false;
                            if (lookup)
                            {
                                cantrip.isupordown = 1;
                            }
                            else
                            {
                                cantrip.isupordown = 0;
                            }
                            cantrip.cast();
                        }
                        

                    }
                    if (heldItem != null && leftact)
                    {
                        leftact = false;
                        heldItem.use();
                    }
                    if (cantrip != null && heldItem == null)
                    {
                        cantrip.keyrelease = false;
                    }


                }
                else if (keyState.IsKeyUp(Keys.Left))
                {
                    leftarrow = false;
                    leftact = true;
                    if (cantrip != null)
                    {
                        cantrip.keyrelease = true;
                    }


                }
                if (keyState.IsKeyDown(Keys.Up))
                {
                    if (cantrip2 != null && upAct == false)
                    {
                        if (mana >= cantrip2.manacost)
                        {
                            changeMana(-cantrip2.manacost);
                            upAct = true;
                            if (lookup)
                            {
                                cantrip2.isupordown = 1;
                            }else if (lookdown)
                            {
                                cantrip2.isupordown = -1;
                            }
                            else
                            {
                                cantrip2.isupordown = 0;
                            }
                            cantrip2.cast();
                           
                        }
                    }
                    if (cantrip2 != null)
                    {
                        cantrip2.keyrelease = false;
                    }
                }
                else if (keyState.IsKeyUp(Keys.Up))
                {
                    upAct = false;
                    if (cantrip2 != null)
                    {
                        cantrip2.keyrelease = true;
                    }
                }
                if (keyState.IsKeyDown(Keys.Down))
                {
                    if (cantrip3 != null && downAct == false)
                    {
                        if (mana >= cantrip3.manacost)
                        {
                            changeMana(-cantrip3.manacost);
                            downAct = true;
                            if (lookup)
                            {
                                cantrip3.isupordown = 1;
                            }
                            else if (lookdown)
                            {
                                cantrip3.isupordown = -1;
                            }
                            else
                            {
                                cantrip3.isupordown = 0;
                            }
                            cantrip3.cast();
                            
                        }
                    }
                    if (cantrip3 != null)
                    {
                        cantrip3.keyrelease = false;
                    }
                }
                else if (keyState.IsKeyUp(Keys.Down))
                {
                    downAct = false;
                    if(cantrip3 != null)
                    {
                        cantrip3.keyrelease = true;
                    }
                    
                }
                if (keyState.IsKeyDown(Keys.Right))
                {
                    if (cantrip4 != null && rightAct == false)
                    {
                        if (mana >= cantrip4.manacost)
                        {
                            changeMana(-cantrip4.manacost);
                            rightAct = true;
                            if (lookup)
                            {
                                cantrip4.isupordown = 1;
                            }
                            else if (lookdown)
                            {
                                cantrip4.isupordown = -1;
                            }
                            else
                            {
                                cantrip4.isupordown = 0;
                            }
                            cantrip4.cast();
                            
                        }
                    }
                    if (cantrip4 != null)
                    {
                        cantrip4.keyrelease = false;
                    }
                }
                else if (keyState.IsKeyUp(Keys.Right))
                {
                    rightAct = false;
                    if (cantrip4 != null)
                    {
                        cantrip4.keyrelease = true;
                    }
                }

                if (keyState.IsKeyDown(Keys.D1))
                {
                    if (cantrip != null) 
                    {
                        itemManager.addMagicScroll(hitbox.X, hitbox.Y, cantrip.cantripnum);
                        itemManager.items.Last().yvel = -12;
                        cantrip.drop();
                    }
                    
                    cantrip = null;
                }
                if (keyState.IsKeyDown(Keys.D2))
                {
                    if (cantrip2 != null)
                    {
                        itemManager.addMagicScroll(hitbox.X, hitbox.Y, cantrip2.cantripnum);
                        itemManager.items.Last().yvel = -12;
                        cantrip2.drop();
                    }
                    cantrip2 = null;
                }

                if (keyState.IsKeyDown(Keys.D3))
                {
                    if (cantrip3 != null)
                    {
                        itemManager.addMagicScroll(hitbox.X, hitbox.Y, cantrip3.cantripnum);
                        itemManager.items.Last().yvel = -12;
                        cantrip3.drop();
                    }
                    cantrip3 = null;
                }
                if (keyState.IsKeyDown(Keys.D4))
                {
                    if (cantrip4 != null)
                    {
                        itemManager.addMagicScroll(hitbox.X, hitbox.Y, cantrip4.cantripnum);
                        itemManager.items.Last().yvel = -12;
                        cantrip4.drop();
                    }
                    cantrip4 = null;

                }



                //throw i frames
                if (framesincethrow > 0)
                {
                    if (framesincethrow < 20)
                    {
                        framesincethrow++;
                    }
                    else
                    {
                        framesincethrow = 0;
                    }
                }
                //no ledge grab frames
                if (noledgegrabframes > 0)
                {
                    if (noledgegrabframes < 18)
                    {
                        noledgegrabframes++;
                    }
                    else
                    {
                        noledgegrabframes = 0;
                    }
                }



                //gravity
                yvel += (frameCounter.frame % 2);

                //friction of control
                if (!runleft && !runright && frameCounter.frame % 10 == 0)
                {
                    xvel = xvel / 2;
                }




                if (framesicneground < 10)
                {


                    if (jumping && jumpframe == 0)
                    {
                        if (lookdown) { 
                            ledgegrab = false;
                            framesicneground += 10;
                            noledgegrabframes++;
                        }
                        else
                        {
                            // Debug.WriteLine();
                            framesicneground += 10;
                            jumpframe++;
                            ledgegrab = false;
                        }
                        
                        

                    }



                }


                if (jumpframe > 0)
                {

                    if (jumpframe < jumpStr)
                    {
                        //god lock curse
                        yvel = jumpPow;

                        jumpframe++;

                    }
                    else
                    {
                        jumpframe = 0;
                        jumpPress = true;
                       // jumpStr = 20;
                    }

                    if (!jumping)
                    {
                        jumpframe = 0;
                        jumpPress = true;
                        //jumpStr = 20;
                    }
                }

                //start collsion check
                grounded = false;
                colliding = false;

                colcheck.checkTilePlayer(this);
                colcheck.eitemCheck(this);


                if (grounded) {
                    //friction
                    if(elevation < hitbox.Y - falldmgThreshold)
                    {
                        changeHealth(-1);
                        consious = false;
                    }
                    elevation = hitbox.Y;
                    
                    if (xvel > 0)
                    {
                        xvel -= 1;

                    }
                    else if (xvel < 0)
                    {
                        xvel += 1;

                    }

                    framesicneground = 0;

                }
                else
                {
                    framesicneground++;
                    if(elevation > hitbox.Y)
                    {
                        elevation = hitbox.Y;
                    }
                }


              
                



                //ledge grab stop

                if (ledgegrab)
                {
                    xvel = 0;
                    yvel = 0;
                    jumpframe = 0;
                    framesicneground = 0;
                    elevation = hitbox.Y;
                    if (colcheck.tileManager.collides[colcheck.tileManager.map[ledgetileind]] == false)
                    {
                        ledgegrab = false;
                        noledgegrabframes++;
                    }

                    if(ledgedir == 0)
                    {
                   // int ind1 = (entityLeftCol - 1) + (entityTopRow * 40);
                   // int tileNum1 = map[ind1];
                    }
                    else
                    {

                    }


                }

               


                //limit physics
                if (xvel > maxVel)
                {
                    xvel = maxVel;
                }
                else if (xvel < -maxVel)
                {
                    xvel = -maxVel;
                }

                if (yvel > maxVel)
                {
                    yvel = maxVel;
                }
                else if (yvel < -maxVel)
                {
                    yvel = -maxVel;
                }

                if(muddy)
                {
                    
                     //xvel = xvel/2;
                    jumpStr = 7;
                    maxVel = 10;
                    mudclean--;
                    if (mudclean < 1)
                    {
                        muddy = false;
                        mudclean = 50;
                    }
                }
                else
                {
                    maxVel = 25;
                    jumpStr = 20;
                }


                //holditem at correct popsition
                if (heldItem != null)
                {
                    if (facing == 1)
                    {
                        heldItem.hitbox.X = hitbox.X + heldItem.xleftholdoffset;
                        heldItem.hitbox.Y = hitbox.Y + heldItem.holdoffset;
                        if(heldItem.spriteEffects == SpriteEffects.None)
                        {
                            heldItem.spriteEffects = SpriteEffects.FlipHorizontally;
                        }

                    }
                    else
                    {
                        heldItem.hitbox.X = hitbox.X + heldItem.xrightholdoffset;
                        heldItem.hitbox.Y = hitbox.Y + heldItem.holdoffset;
                        if (heldItem.spriteEffects == SpriteEffects.FlipHorizontally)
                        {
                            heldItem.spriteEffects = SpriteEffects.None;
                        }
                    }

                }

                //applie sphysiocs
                hitbox.X += xvel;
                hitbox.Y += yvel;


                if (keyState.IsKeyDown(Keys.E))
                {
                    if (onExit)
                    {
                        //colcheck.tileManager.newMapSwamp();
                        levelManager.nextLevel();
                    }
                    epressed = true;
                }
                else
                {
                    epressed = false;
                }



                //
                if (crouchcounter > 50)
                {
                    if(camlookoffestY < 512)
                    {
                        camlookoffestY += 10;
                    }
                }
                else 
                {
                    if(camlookoffestY != 0 && lookupcounter < 50)
                    {
                        if(camlookoffestY > 0)
                        { 
                        camlookoffestY -= 10;

                        }
                        else
                        {
                            camlookoffestY += 10;
                        }
                    }
                }

                if (lookupcounter > 50)
                {
                    if (camlookoffestY > -512)
                    {
                        camlookoffestY -= 10;
                    }
                }
                

                //move camera in accordence with player
                moveCam();


            }
            else {
                //uncousious

                //gravity first
                
                yvel += (frameCounter.frame % 2);

                //start collsion check
                grounded = false;
                colliding = false;

                colcheck.checkTilePlayer(this);
                colcheck.eitemCheck(this);


                if (grounded)
                {
                    //friction
                    if (xvel > 0)
                    {
                        xvel -= 1;

                    }
                    else if (xvel < 0)
                    {
                        xvel += 1;

                    }

                    framesicneground = 0;

                }
                else
                {
                    framesicneground++;
                }


                //limit physics
                if (xvel > maxVel)
                {
                    xvel = maxVel;
                }
                else if (xvel < -maxVel)
                {
                    xvel = -maxVel;
                }

                if (yvel > maxVel)
                {
                    yvel = maxVel;
                }
                else if (yvel < -maxVel)
                {
                    yvel = -maxVel;
                }

                //applie sphysiocs
                hitbox.X += xvel;
                hitbox.Y += yvel;

                //
                uncousiustime++;

                if (uncousiustime == 1) 
                {
                    drawspot = new Rectangle(1148, 10, 118, 118);
                    if (heldItem != null)
                    {
                        prevheldItem = heldItem;
                                           
                        heldItem.hitbox.Y = hitbox.Y;

                        
                        heldItem.hitbox.X = hitbox.X + heldItem.xmidoffset;


                        
                        heldItem = null;
                    }

                }

                if(uncousiustime > 200)
                {
                    drawspot = new Rectangle(-5, 10, 118, 118);
                    consious = true;
                    uncousiustime = 0;

                }





                moveCam();





            }

        }

        public void throwitem() 
        {
            if (heldItem.hitbox.Y + heldItem.hitbox.Height > hitbox.Y + hitbox.Height)
            {
                heldItem.hitbox.Y = hitbox.Y;



            }

            if (facing == 0)
            {
                heldItem.xvel = xvel + heldItem.throwvel;


            }
            else
            {

                heldItem.xvel = xvel - heldItem.throwvel;


            }
            heldItem.yvel = yvel - 10;
            if (lookup)
            {
                heldItem.yvel = yvel - 15;
            }
            else if (lookdown)
            {
                heldItem.yvel = yvel + 5;

            }
            //make sure its not in wall
            colcheck.checkTile(heldItem);
            if (heldItem.colliding)
            {
                heldItem.hitbox.X = hitbox.X + heldItem.xmidoffset;


            }

            framesincethrow++;
            prevheldItem = heldItem;
            heldItem = null;
        }
        public void moveCam()
        {

            //camera stuff
            playerdistx = 55 + hitbox.X + camlookoffestX - centerWorldX;
            playerdisty = 55 + hitbox.Y + camlookoffestY - centerWorldY;
            //Console.WriteLine(playerdisty);
            if (playerdistx > 20)
            {
                camxvel = playerdistx / 10;
            }
            else if (playerdistx < -20)
            {
                camxvel = playerdistx / 10;
            }
            else
            {
                camxvel = camxvel / 2;
            }

            //y time
            if (playerdisty > 20)
            {

                camyvel = playerdisty / 15;
            }
            else if (playerdisty < -20)
            {
                camyvel = playerdisty / 15;
            }
            else
            {
                camyvel = camyvel / 2;
            }



            centerWorldX += camxvel;
            centerWorldY += camyvel;



            if (centerWorldY > 3300)
            {
                centerWorldY = 3300;
            }
            if (centerWorldY < 540)
            {
                centerWorldY = 540;
            }
            if (centerWorldX > 2880)
            {
                centerWorldX = 2880;
            }
            if (centerWorldX < 960)
            {
                centerWorldX = 960;
            }






            //camera move
            //centerWorldY > 540
            // centerWorldY < 3300
            //wasgrounded = grounded;
        }






    }

    


}
