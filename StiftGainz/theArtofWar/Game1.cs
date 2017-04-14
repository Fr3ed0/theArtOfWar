using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace theArtofWar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// Copyright 2017
    /// Frederic Wolf and Edgar Justus
    /// All Rights Reserved
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random Random = new Random();
        Einheit[] HaraldEinheit = new Einheit[300];
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < HaraldEinheit.Length; i++)
            {
                HaraldEinheit[i] = new Einheit(Random.Next(0, 800), Random.Next(0, 800));
                HaraldEinheit[i].InfTexture01 = this.Content.Load<Texture2D>("infantrie");
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(color: Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            // spriteBatch.Draw(Einheit, Vector2.One);
            for (int i = 0; i < HaraldEinheit.Length; i++)
            {
                // Console.WriteLine(HaraldEinheit[i].PosX);
                spriteBatch.Draw(texture: HaraldEinheit[i].InfTexture01, position: new Vector2(x: HaraldEinheit[i].PosX, y: HaraldEinheit[i].PosY), sourceRectangle: null, color: Color.White, rotation: 1.5f, origin: Vector2.Zero, scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
            }
            // spriteBatch.Draw(texture: HaraldEinheit.InfTexture01, position: new Vector2(x: HaraldEinheit.PosX, y: HaraldEinheit.PosY), sourceRectangle: null, color: Color.White, rotation: 1.5f, origin: Vector2.Zero, scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
            spriteBatch.End();
            base.Draw(gameTime: gameTime);
        }
    }
}
