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
        GraphicsDeviceManager mGraphics;
        private int mWindowWidth;
        private int mWindowHeight;
        SpriteBatch mSpriteBatch;
        Random mRandom = new Random();
        Einheit[] mHaraldEinheit = new Einheit[30];
        private float[] mRotation = new float[30];

        public Game1()
        {
            mGraphics = new GraphicsDeviceManager(this);
            mGraphics.IsFullScreen = false;
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
            mWindowWidth = GraphicsDevice.Viewport.Width;
            mWindowHeight = GraphicsDevice.Viewport.Height;
            // Create a new SpriteBatch, which can be used to draw textures.
            mSpriteBatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < mHaraldEinheit.Length; i++)
            {
                mHaraldEinheit[i] = new Einheit(mRandom.Next(0, mWindowWidth), mRandom.Next(0, mWindowHeight));
                mHaraldEinheit[i].InfTexture01 = this.Content.Load<Texture2D>("infantrie");
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

            // Code to get the postion of the mouse.
            MouseState current_mouse = Mouse.GetState();
            // current_mouse.X is the X position of the mouse
            // and current_mouse.Y is the Y position.

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                mGraphics.IsFullScreen = true;
                mGraphics.ApplyChanges();
            }

            for (int i = 0; i < mRotation.Length; i++)
            {
                double a = Math.Abs(mHaraldEinheit[i].Pos.Y-current_mouse.Y);
                double b = Math.Abs(mHaraldEinheit[i].Pos.X-current_mouse.X);
                double c = Math.Sqrt(Math.Pow(a,2)+Math.Pow(b,2));
                mRotation[i] = (float) Math.Sin(a/c);
            }
            Console.WriteLine("X: {0} Y: {1} Winkel: {2}", mHaraldEinheit[0].Pos.X, mHaraldEinheit[0].Pos.Y, mRotation[0]);
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
            mSpriteBatch.Begin();
            // spriteBatch.Draw(Einheit, Vector2.One);
            for (int i = 0; i < mHaraldEinheit.Length; i++)
            {
                // Console.WriteLine(HaraldEinheit[i].PosX);
                mSpriteBatch.Draw(texture: mHaraldEinheit[i].InfTexture01, position: mHaraldEinheit[i].Pos, sourceRectangle: null, color: Color.White, rotation: mRotation[i], origin: new Vector2(mHaraldEinheit[i].InfTexture01.Width/2, mHaraldEinheit[i].InfTexture01.Height/2), scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
            }
            
            // spriteBatch.Draw(texture: HaraldEinheit.InfTexture01, position: new Vector2(x: HaraldEinheit.PosX, y: HaraldEinheit.PosY), sourceRectangle: null, color: Color.White, rotation: 1.5f, origin: Vector2.Zero, scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
            mSpriteBatch.End();
            base.Draw(gameTime: gameTime);
        }
    }
}
