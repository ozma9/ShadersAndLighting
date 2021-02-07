using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ShadersAndLighting.Globals;
using ShadersAndLighting.ScreenManagement;

namespace ShadersAndLighting
{
    public class LightShade : Microsoft.Xna.Framework.Game
    {
        private ScreenManager scrnMngr;

        public LightShade()
        {
            GV.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            scrnMngr = new ScreenManager();
        }
        protected override void Initialize()
        {
            this.Window.Title = "Shaders and Lighting";
            this.IsMouseVisible = true;
            Window.AllowUserResizing = false;
            GV.Graphics.IsFullScreen = false;
            GV.GameSize = new Point(1280, 720);
            //GV.GameSize = new Point(1920, 1080);
            GV.Graphics.PreferredBackBufferWidth = GV.GameSize.X;
            GV.Graphics.PreferredBackBufferHeight = GV.GameSize.Y;
            GV.Graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GV.Version = SystemVersion.PC;
            GV.SpriteBatch = new SpriteBatch(GraphicsDevice);
            GV.Content = this.Content;
            GV.gRandom = new Random();

            //Load assets
            Fonts.Load();
            Textures.Load();
            Effects.Load();

            //Add screens to screen manager
            ScreenManager.AddScreen(new Screens.Lighting());
        }

        protected override void Update(GameTime gameTime)
        {
            GV.WindowFocused = this.IsActive;
            GV.GameTime = gameTime;

            //Update Screens
            scrnMngr.Update();

            //Update Input
            Input.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            scrnMngr.Draw();
            scrnMngr.DrawEffects();
            scrnMngr.DrawGUI();

            base.Draw(gameTime);
        }
    }
}
