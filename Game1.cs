﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace monowizard
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        RenderTarget2D _renderTarget;
        TileManager _tileManager;
        CollisionCheck _collisionCheck;
        FrameCounter _frameCounter;
        ItemManager _itemManager;
        MonsterManager _monsterManager;
        MagicManager _magicManager;
        UI ui;
        ParticleManager _particleManager;
        //Batdemon battdemon;
        
        

        Sprite sprite;
        Player player;

        public float scale = 0.44444f;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 100f);

            IsFixedTimeStep = true;

            Window.AllowUserResizing = true;
            _frameCounter = new FrameCounter();
            player = new Player();

            _tileManager = new TileManager(player);
            _collisionCheck = new CollisionCheck(_tileManager);
            ui = new UI();


            player.currentGame = this;
            player.ui = ui;
            ui.setHealth(player.health);
            player.setcolcheck(_collisionCheck);
            player.frameCounter = _frameCounter;
            

            _itemManager = new ItemManager();
            _itemManager.colCheck = _collisionCheck;
            _itemManager.player = player;
            _magicManager = new MagicManager(_collisionCheck,player);
            _particleManager = new ParticleManager(_collisionCheck,player);
            //
            _tileManager.magicmanager = _magicManager;
            _tileManager.trap1.manager = _tileManager;
            _tileManager.initateTraps();
            _tileManager.itemmanager = _itemManager;

            player.itemManager = _itemManager;
            // player.cantrip = new HandFireCantrip(player);
            player.cantrip = new JumpCantrip(player);
            _monsterManager = new MonsterManager(player);
            _monsterManager.particleManager = _particleManager;
            player.mm = _monsterManager;
           // battdemon = new Batdemon(player);

            

            

            base.Initialize();

            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.ApplyChanges();
           
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderTarget = new RenderTarget2D(GraphicsDevice,1920,1080);
            //_tileManager = new TileManager();

            // TODO: use this.Content to load your game content here
            //Tile[] tiles = new Tile[10];
           // tiles[0].texture = Content.Load<Texture2D>("shittyself");
            
            player.texture = Content.Load<Texture2D>("cocovon");
            _tileManager.texts[0] = Content.Load<Texture2D>("bookshelftile1");
            _tileManager.texts[1] = Content.Load<Texture2D>("woodtileslib5");
            _tileManager.texts[340] = _tileManager.texts[1];
            _tileManager.texts[341] = _tileManager.texts[1];
            _tileManager.texts[2] = Content.Load<Texture2D>("libarybackground2");
            for (int i = 2;i < 322; i++)
            {
                _tileManager.texts[i] = _tileManager.texts[2];
            }
           
            for (int i = 322; i < 326; i++)
            {
                _tileManager.texts[i] = _tileManager.texts[1];

            }
            _tileManager.texts[338] = Content.Load<Texture2D>("trapproto2");
            _tileManager.texts[339] = _tileManager.texts[338];



            _itemManager.rocktext = Content.Load<Texture2D>("items/littlerock1");
            _itemManager.libitems1 = Content.Load<Texture2D>("itemslib2");
            _itemManager.magicsymbols = Content.Load<Texture2D>("libcantripsymb");
            _particleManager.libtexts1 = Content.Load<Texture2D>("particles/libparticles1");
            _particleManager.windcloudmanatext = Content.Load<Texture2D>("particles/particlues1");

            ui.healthfont = Content.Load<Texture2D>("numberswithred2");
            ui.manafont = Content.Load<Texture2D>("numberswithblue2");
            player.fireballtexture = Content.Load<Texture2D>("boomspiretsheet");
            player.cloudtexture = _particleManager.windcloudmanatext;
            _monsterManager.batmon1texture = Content.Load<Texture2D>("batdemon2.3");//("brainmon1");//("batdemon2.3")
            _monsterManager.brainmon1texture = Content.Load<Texture2D>("brainmon3");//("brainmon3");
            _monsterManager.owlmon1texture = Content.Load<Texture2D>("owlexe2");
            _monsterManager.bookmon1texture = Content.Load<Texture2D>("badmonbook");
            _magicManager.effectstext1 = Content.Load<Texture2D>("itsatrapmagic2");
            

            //_monsterManager.addBatDemon();
            // _monsterManager.addBrainMonster(900,300);
           // _monsterManager.addBrainMonster(900, 1300);
           // _monsterManager.addOwlMonster(1900,600);

            // _monsterManager.addOwlMonster(2500, 600);



            _itemManager.addBook(800, 600);
            _itemManager.addMKey(700, 400);
            _itemManager.addManaIdol(300, 600);
            // _itemManager.addCrystalRock(1800, 600);
            //_itemManager.addMagicScroll(1200, 400);
            //add rocks when loading content because uhhhhhhhhhhhh yeah
           // _monsterManager.addOwlMonster(1200,500);
            for (int i = 0; i < 10; i++)
            {
              //  _monsterManager.addBrainMonster(900+(i*300), 600);
             //  _monsterManager.addOwlMonster(900 + (i * 300), 1600 + (i * 100));
                _itemManager.addMChest(2600+(100*i), 600);
               // _particleManager.addManaSmall(1600 + (100 * i), 600,0,0,64,1f);
               
            }
           // _monsterManager.addBrainMonster(900 , 600);
            player.changeMana(0);



            //_tileManager.setTiles();


        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            _frameCounter.update();
            
            _itemManager.update();

          

            player.update(keyState);

            
            _monsterManager.update();

            _tileManager.update();

            _magicManager.update();

            if (player.cantrip != null)
            {
                player.cantrip.update();
            }

            _particleManager.update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            scale = 1f / (1920f / _graphics.GraphicsDevice.Viewport.Width);

            GraphicsDevice.SetRenderTarget(_renderTarget);
            //GraphicsDevice.Clear(Color.Black);


            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            //sub in rectangle for vector to scale texture
            _tileManager.draw(_spriteBatch);


            if (player.cantrip != null)
            {
                player.cantrip.predraw(_spriteBatch);
            }

            player.screenpos.X = player.hitbox.X-15 - player.centerWorldX + player.centerX;
            player.screenpos.Y = player.hitbox.Y-30 - player.centerWorldY + player.centerY;
            _spriteBatch.Draw(texture: player.texture, position: player.screenpos, sourceRectangle: player.drawspot,color: player.playertint,0,Vector2.Zero,1, effects: player.spriteEffects,1);
          

           
            _monsterManager.drawAll(_spriteBatch);

           // _spriteBatch.Draw(texture: player.texture, position: player.screenpos, sourceRectangle: player.drawspot, color: Color.White, 0, Vector2.Zero, 1, effects: player.spriteEffects, 1);

            _itemManager.drawAll(_spriteBatch);


            if (player.cantrip != null)
            {
                player.cantrip.draw(_spriteBatch);
            }

            _magicManager.drawAll(_spriteBatch);

            _particleManager.drawAll(_spriteBatch);

            ui.draw(_spriteBatch);
            _spriteBatch.End();

            
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.Draw( _renderTarget,Vector2.Zero,null,Color.White,0f,Vector2.Zero,scale,SpriteEffects.None,0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}