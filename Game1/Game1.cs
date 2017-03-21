using Game1.Engine;
using Game1.Engine.Entites;
using Game1.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1 {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random Random;

        Texture2D BananaTexture;
        Texture2D Background;

        Texture2D IndependentTexture;

        Button Merkel;

        Texture2D MerkelNeutral;
        Texture2D MerkelRollOver;
        Texture2D MerkelClick;

        Player Banana;
        //Player Banana2;
        //Player Banana3;
        //Player Banana4;

        Monster Independent;

        public static Dictionary<string, Entity> GameObjects = new Dictionary<string, Entity>();

        public static GraphicsDeviceManager GraphicsDeviceManager;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GraphicsDeviceManager = this.graphics;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            Random = new Random();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Background = this.Content.Load<Texture2D>("Images/Backgrounds/Background");

            BananaTexture = this.Content.Load<Texture2D>("Images/Entities/Banana");

            Banana = new Player(BananaTexture, Vector2.Zero);
            //Banana2 = new Player(BananaTexture, new Vector2(Random.Next(0, 640), Random.Next(0, 400)));
            //Banana3 = new Player(BananaTexture, new Vector2(Random.Next(0, 640), Random.Next(0, 400)));
            //Banana4 = new Player(BananaTexture, new Vector2(Random.Next(0, 640), Random.Next(0, 400)));

            IndependentTexture = this.Content.Load<Texture2D>("Images/Entities/Independent");

            Independent = new Monster(IndependentTexture, new Vector2(400,400));

            GameObjects.Add("Player", Banana);
            //GameObjects.Add("Banana #2", Banana2);
            //GameObjects.Add("Banana #3", Banana3);
            //GameObjects.Add("Banana #4", Banana4);


            GameObjects.Add("Enemy", Independent);





            MerkelNeutral = this.Content.Load<Texture2D>("Images/Drawables/MerkelNeutral");
            MerkelRollOver = this.Content.Load<Texture2D>("Images/Drawables/MerkelRollOver");
            MerkelClick = this.Content.Load<Texture2D>("Images/Drawables/MerkelClick");

            Merkel = new Button(MerkelNeutral, MerkelRollOver, MerkelClick, new Vector2(200, 100));

            int ScreenWidth = this.GraphicsDevice.Viewport.Width;
            int ScreenHeight = this.GraphicsDevice.Viewport.Height;

            GlobalResources.ScreenWidth = ScreenWidth;
            GlobalResources.ScreenHeight = ScreenHeight;


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            this.IsMouseVisible = true;



            Merkel.Update(gameTime);

            //Banana.Update(gameTime);
            //Banana2.Update(gameTime);
            //Banana3.Update(gameTime);
            //Banana4.Update(gameTime);

            foreach (Entity Entity in GameObjects.Values) {
                Entity.Update(gameTime);
            }

            //foreach (Drawable Drawable in GameObjects.Values) {
            //    bool Stalemate = new bool();
            //    if (Stalemate) {
                    
            //    }
            //}


            base.Update(gameTime);
        }

        public static bool CanMove(Rectangle TargetPosition, Rectangle CurrentPosition) {
            bool AllowMovement = true;
            foreach(Entity Entity in GameObjects.Values) {

                if(Entity.Bounds != CurrentPosition && TargetPosition.Intersects(Entity.Bounds)) {
                    AllowMovement = false;
                }

            }
            return AllowMovement;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SpriteBatch batch = new SpriteBatch(this.GraphicsDevice);
            batch.Begin();

            batch.Draw(Background, new Rectangle(0, 0, 840, 600), Color.White);


            Merkel.Draw(batch);

            //Banana.Draw(batch);
            //Banana2.Draw(batch);
            //Banana3.Draw(batch);
            //Banana4.Draw(batch);

            foreach (Entity Entity in GameObjects.Values) {
                Entity.Draw(batch);





            }
            base.Draw(gameTime);
            batch.End();
        }
    }
}
