using System;
using System.Collections.Generic;
using System.Linq;
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
        Einheit[] mEnemy = new Einheit[20];
        private MouseState current_mouse;
        List<Einheit> mAlleEinheiten = new List<Einheit>();
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
            this.IsMouseVisible = true;
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
                mHaraldEinheit[i] = new Einheit(mRandom.Next(0, mWindowWidth/2), mRandom.Next(0, mWindowHeight));
                mHaraldEinheit[i].InfTexture01 = this.Content.Load<Texture2D>("infantrie");
                mHaraldEinheit[i].mFraktion = "Good";
            }
            for (int i = 0; i < mEnemy.Length; i++)
            {
                mEnemy[i] = new Einheit(mRandom.Next(mWindowWidth / 2, mWindowWidth), mRandom.Next(0, mWindowHeight));
                mEnemy[i].InfTexture01 = this.Content.Load<Texture2D>("infantrie");
                mEnemy[i].mFraktion = "Evil";
            }
            mAlleEinheiten.AddRange(mHaraldEinheit);
            mAlleEinheiten.AddRange(mEnemy);
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
            current_mouse = Mouse.GetState();
            // current_mouse.X is the X position of the mouse
            // and current_mouse.Y is the Y position.

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                mGraphics.IsFullScreen = !mGraphics.IsFullScreen;
                mGraphics.ApplyChanges();
            }

            // TODO: Add your update logic here
            //for (int i = 0; i < mHaraldEinheit.Length; i++)
            //{
            //    for (int j = 0; j < mHaraldEinheit.Length; j++)
            //    {
            //        if (i == j) continue;
            //        if (mHaraldEinheit[i].IsCollided(mHaraldEinheit[j]))
            //        {
            //            mHaraldEinheit[i].StepAside(mHaraldEinheit[j]);
            //            goto doublebreak;
            //        }
            //    }
            //    mHaraldEinheit[i].Walk(new Vector2(current_mouse.X, current_mouse.Y));
            //    doublebreak:
            //    ;
            //}

            for (int i = 0; i < mAlleEinheiten.Count; i++)
            {
                if (mAlleEinheiten[i].mLeben < 1)
                {
                    mAlleEinheiten.RemoveAt(i);
                }
            }

            for (int i = 0; i < mAlleEinheiten.Count; i++)
            {   
                for (int j = 0; j < mAlleEinheiten.Count; j++)
                {
                    if (i == j) continue;
                    if (mAlleEinheiten[i].IsCollided(mAlleEinheiten[j]))
                    {
                        mAlleEinheiten[i].StepAside(mAlleEinheiten[j]);
                        if (mAlleEinheiten[i].mFraktion != mAlleEinheiten[j].mFraktion)
                        {
                            mAlleEinheiten[i].mLeben -= 1;
                            mAlleEinheiten[j].mLeben -= 1;
                        }
                        goto doublebreak;
                    }
                }
                mAlleEinheiten[i].Walk(new Vector2(mWindowWidth/2, mWindowHeight/2));
                // mAlleEinheiten[i].Walk(new Vector2(current_mouse.X, current_mouse.Y));
                doublebreak:
                ;
            }

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
            //for (int i = 0; i < mHaraldEinheit.Length; i++)
            //{
            //    // Console.WriteLine(HaraldEinheit[i].PosX);
            //    mSpriteBatch.Draw(texture: mHaraldEinheit[i].InfTexture01, position: mHaraldEinheit[i].Pos, sourceRectangle: null, color: Color.White, rotation: mHaraldEinheit[i].GetDirection(new Vector2(current_mouse.X, current_mouse.Y)), origin: new Vector2(mHaraldEinheit[i].InfTexture01.Width / 2, mHaraldEinheit[i].InfTexture01.Height / 2), scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
            //}
            for (int i = 0; i < mAlleEinheiten.Count; i++)
            {
                // Console.WriteLine(HaraldEinheit[i].PosX);
                if (mAlleEinheiten[i].mFraktion == "Evil")
                {
                mSpriteBatch.Draw(texture: mAlleEinheiten[i].InfTexture01, position: mAlleEinheiten[i].Pos, sourceRectangle: null,
                    color: Color.Black, rotation: mAlleEinheiten[i].GetDirection(new Vector2(mWindowWidth / 2, mWindowHeight / 2)), 
                    origin: new Vector2(mAlleEinheiten[i].InfTexture01.Width / 2, mAlleEinheiten[i].InfTexture01.Height / 2), 
                    scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
                }
                else
                {
                mSpriteBatch.Draw(texture: mAlleEinheiten[i].InfTexture01, position: mAlleEinheiten[i].Pos, sourceRectangle: null, 
                    color: Color.White, rotation: mAlleEinheiten[i].GetDirection(new Vector2(mWindowWidth / 2, mWindowHeight/2)), 
                    origin: new Vector2(mAlleEinheiten[i].InfTexture01.Width / 2, mAlleEinheiten[i].InfTexture01.Height / 2), 
                    scale: 0.1f, effects: SpriteEffects.None, layerDepth: 0f);
                }
            }

            mSpriteBatch.End();
            base.Draw(gameTime: gameTime);
        }
    }
}
