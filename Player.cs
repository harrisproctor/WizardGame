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
        public int health = 40;
        public float mana = 50;
        public int uncousiustime;
        //yourcurrent cantrip
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








        public Player()
        {
            id = 1;
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

            //hitbox = new int[4];
            //left x offset
            // hitbox[0] = 15;
            //right x offset
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
            ui.setHealth(health);
            if(health < 1)
            {
                drawspot.Y += 768;
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

                    if (entity.id == 101)
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
                    if (xvel < 9)
                    {
                        xvel += 1;

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
                    if (xvel > -9)
                    {
                        xvel -= 1;
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
                    if(!lookdown && leftact && heldItem == null && cantrip != null)
                    {
                        if (mana >= cantrip.manacost)
                        {

                            changeMana(-cantrip.manacost);
                            leftact = false;
                            cantrip.cast();
                        }
                        

                    }
                    if (heldItem != null && leftact)
                    {
                        leftact = false;
                        if (heldItem.hitbox.Y + heldItem.hitbox.Height > hitbox.Y + hitbox.Height) {
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


                }
                else if (keyState.IsKeyUp(Keys.Left))
                {
                    leftarrow = false;
                    leftact = true;


                }
                if (keyState.IsKeyDown(Keys.Up))
                {
                    if (cantrip2 != null && upAct == false)
                    {
                        if (mana >= cantrip2.manacost)
                        {
                            changeMana(-cantrip2.manacost);
                            upAct = true;
                            cantrip2.cast();
                           
                        }
                    }
                }else if (keyState.IsKeyUp(Keys.Up))
                {
                    upAct = false;
                }
                if (keyState.IsKeyDown(Keys.Down))
                {
                    if (cantrip3 != null && downAct == false)
                    {
                        if (mana >= cantrip3.manacost)
                        {
                            changeMana(-cantrip3.manacost);
                            downAct = true;
                            cantrip3.cast();
                            
                        }
                    }
                }
                else if (keyState.IsKeyUp(Keys.Down))
                {
                    downAct = false;
                }
                if (keyState.IsKeyDown(Keys.Right))
                {
                    if (cantrip4 != null && rightAct == false)
                    {
                        if (mana >= cantrip4.manacost)
                        {
                            changeMana(-cantrip4.manacost);
                            rightAct = true;
                            cantrip4.cast();
                            
                        }
                    }
                }else if (keyState.IsKeyUp(Keys.Right))
                {
                    rightAct = false;
                }

                if (keyState.IsKeyDown(Keys.D1))
                {
                    cantrip = null;
                }
                if (keyState.IsKeyDown(Keys.D2))
                {
                    cantrip2 = null;
                }

                if (keyState.IsKeyDown(Keys.D3))
                {
                    cantrip3 = null;
                }
                if (keyState.IsKeyDown(Keys.D4))
                {
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

                    if (jumpframe < 20)
                    {
                        yvel = -6;

                        jumpframe++;

                    }
                    else
                    {
                        jumpframe = 0;
                        jumpPress = true;
                    }

                    if (!jumping)
                    {
                        jumpframe = 0;
                        jumpPress = true;
                    }
                }

                //start collsion check
                grounded = false;
                colliding = false;

                colcheck.checkTilePlayer(this);


                if (grounded) {
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


              
                



                //ledge grab stop

                if (ledgegrab)
                {
                    xvel = 0;
                    yvel = 0;
                    jumpframe = 0;
                    framesicneground = 0;
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
