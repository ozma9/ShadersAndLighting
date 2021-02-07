using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadersAndLighting.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ShadersAndLighting.Handlers;

namespace ShadersAndLighting.Screens
{
    class Lighting : ScreenManagement.BaseScreen
    {
        private RenderTarget2D screenBackBuffer;
        private RenderTarget2D lightingBuffer;
        private Single ambientLighting;

        //GUI Strings
        private string infoString;
        private string infoString2;

        //Mouse spotlight
        private bool showMouseLight;
        private LightSource mouseLight;
        private byte sTextureCount = 0;
        private byte sColourCount = 0;
        private string colourString;

        //Map
        private MapHandler mapHandler;

        //Lighting
        private LightHandler lightHandler;

        public Lighting()
        {
            screenBackBuffer = new RenderTarget2D(GV.Graphics.GraphicsDevice, GV.GameSize.X, GV.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None);
            lightingBuffer = new RenderTarget2D(GV.Graphics.GraphicsDevice, GV.GameSize.X, GV.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None);

            hasEffects = true;
            ambientLighting = 0.9f;

            mapHandler = new MapHandler();
            lightHandler = new LightHandler();
            UpdateCampFireLights();

            mouseLight = new LightSource();
            mouseLight.sourceTexture = Textures.SHADER_sun;
            mouseLight.location = new Rectangle(0, 0, Textures.SHADER_sun.Width * 2, Textures.SHADER_sun.Height * 2);
            MouseColourPicker();
            showMouseLight = true;

        }

        public override void Update()
        {

            //Update string
            infoString =
                "FPS: " + GV.fps + System.Environment.NewLine +
                "Shaders Enabled: " + hasEffects + System.Environment.NewLine +
                "Mouse spot light Enabled: " + showMouseLight + System.Environment.NewLine +
                "Ambient Lighting: " + ambientLighting.ToString("0.00") + System.Environment.NewLine +
                "Object Count: " + mapHandler.getObjectList().Count + System.Environment.NewLine +
                "Light Count: " + lightHandler.GetLightList().Count;

            //Update handlers
            mapHandler.Update();
            if (hasEffects)
                lightHandler.Update();

            //Update spotlight
            if (GV.Version == SystemVersion.PC)
            {
                mouseLight.location.X = Mouse.GetState().X - mouseLight.sourceTexture.Width;
                mouseLight.location.Y = Mouse.GetState().Y - mouseLight.sourceTexture.Height;
            }
        }

        public override void Draw()
        {
            GV.Graphics.GraphicsDevice.SetRenderTarget(screenBackBuffer);
            GV.Graphics.GraphicsDevice.Clear(Color.Black);

            GV.SpriteBatch.Begin();
            //GV.SpriteBatch.Draw(Textures.px, new Rectangle(0, 0, GV.GameSize.X, GV.GameSize.Y), Color.White);

            //Draw Map
            mapHandler.DrawMap();

            //Draw Objects
            mapHandler.DrawObjects();

            GV.SpriteBatch.End();

            GV.Graphics.GraphicsDevice.SetRenderTarget(null);
        }

        public override void DrawGUI()
        {
            GV.SpriteBatch.Begin();

            if (GV.Version == SystemVersion.Tablet)
            {

                Viewport _tmp = GV.Graphics.GraphicsDevice.Viewport;

                GV.SpriteBatch.DrawString(Fonts.fontCalibri, infoString, new Vector2((_tmp.Width - Fonts.fontCalibri.MeasureString(infoString).X) - 15, (_tmp.Height - Fonts.fontCalibri.MeasureString(infoString).Y) - 15), Color.White);
                GV.SpriteBatch.DrawString(Fonts.fontCalibri, infoString2, new Vector2(15, (_tmp.Height - Fonts.fontCalibri.MeasureString(infoString2).Y) - 15), Color.White);
                GV.SpriteBatch.DrawString(Fonts.fontCalibri, _tmp.ToString(), Vector2.Zero, Color.White);
            }
            else if (GV.Version == SystemVersion.PC)
            {

                GV.SpriteBatch.DrawString(Fonts.fontCalibri, infoString, new Vector2((GV.GameSize.X - Fonts.fontCalibri.MeasureString(infoString).X) - 15, (GV.GameSize.Y - Fonts.fontCalibri.MeasureString(infoString).Y) - 15), Color.White);
                GV.SpriteBatch.DrawString(Fonts.fontCalibri, infoString2, new Vector2(15, (GV.GameSize.Y - Fonts.fontCalibri.MeasureString(infoString2).Y) - 15), Color.White);
                //GV.SpriteBatch.DrawString(Fonts.fontCalibri, sColourCount.ToString(), Vector2.Zero, Color.White);
            }
            GV.SpriteBatch.End();
        }

        public override void DrawEffects()
        {
            GV.Graphics.GraphicsDevice.SetRenderTarget(lightingBuffer);
            GV.Graphics.GraphicsDevice.Clear(Color.White);

            //Ambient
            GV.SpriteBatch.Begin();
            GV.SpriteBatch.Draw(Textures.px, new Rectangle(0, 0, GV.GameSize.X, GV.GameSize.Y), Color.Black * ambientLighting);
            GV.SpriteBatch.End();

            GV.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            //Draw Lights
            if (hasEffects)
            {
                lightHandler.Draw();
                //GV.SpriteBatch.Draw(mouseLight.sourceTexture, new Rectangle(mouseLight.location.X+256,mouseLight.location.Y+256,mouseLight.location.Width,mouseLight.location.Height), new Rectangle(0, 0, mouseLight.sourceTexture.Width, mouseLight.sourceTexture.Height), mouseLight.colour, rotate, new Vector2(128,128), SpriteEffects.None, 0f);
                if (showMouseLight)
                    GV.SpriteBatch.Draw(mouseLight.sourceTexture, mouseLight.location, mouseLight.colour);
            }

            GV.SpriteBatch.End();

            GV.Graphics.GraphicsDevice.SetRenderTarget(null);
        }

        public override void FinalizeEffects()
        {
            switch (hasEffects)
            {
                case true:

                    GV.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    Effects.lighting.Parameters["lightMask"].SetValue(lightingBuffer);
                    Effects.lighting.CurrentTechnique.Passes[0].Apply();
                    GV.SpriteBatch.Draw(screenBackBuffer, Vector2.Zero, Color.White);
                    GV.SpriteBatch.End();

                    break;
                case false:

                    GV.SpriteBatch.Begin();
                    GV.SpriteBatch.Draw(screenBackBuffer, new Rectangle(0, 0, GV.Graphics.GraphicsDevice.Viewport.Width, GV.Graphics.GraphicsDevice.Viewport.Height), Color.White);
                    GV.SpriteBatch.End();

                    break;
            }
        }

        public override void HandleInput()
        {
            if (Input.KeyPressed(Keys.Escape)) //Quit
                System.Environment.Exit(0);

            if (Input.KeyPressed(Keys.F1)) //Enable / Disable shaders
                hasEffects = !hasEffects;

            if (Input.KeyPressed(Keys.F2)) //New map, clear lights, make new campfire lights
            {
                mapHandler = new MapHandler();
                lightHandler.ClearAllLights();
                UpdateCampFireLights();
            }

            if (Input.KeyPressed(Keys.F3)) //Clear all lights (apart from mouse spotlight)
            {
                lightHandler.ClearAllLights();
                mapHandler.RemoveCampFires();
            }

            if (Input.KeyPressed(Keys.F4)) //Clear lights, readd campfire lights and add glowing effect for trees
            {
                lightHandler.ClearAllLights();
                UpdateCampFireLights();
                foreach (ObjectList _obj in mapHandler.getObjectList())
                {
                    if (_obj.name == "Tree")
                        lightHandler.AddPreset("Tree", _obj.GetCentre());
                }
            }

            if (Input.KeyPressed(Keys.F5)) //Show or Hide Mouse spot light
                showMouseLight = !showMouseLight;

            if (Input.KeyDown(Keys.S) && ambientLighting > 0f) //Decrease the ambient lighting overlay (make it brighter)
                ambientLighting -= 0.005f;

            if (Input.KeyDown(Keys.W) && ambientLighting < 1f) //Increase the ambient lighting overlay (make it darker)
                ambientLighting += 0.005f;

            if (Input.LeftMouseClick() && showMouseLight) //Add a new custom light to the light handler
            {
                lightHandler.AddCustomLight(mouseLight);
            }

            if (Input.RightMouseClick() && showMouseLight) //Cycle through shaders
            {
                sTextureCount += 1;

                switch (sTextureCount)
                {
                    case 0:
                        mouseLight.sourceTexture = Textures.SHADER_sun;
                        break;
                    case 1:
                        mouseLight.sourceTexture = Textures.SHADER_star;
                        break;
                    case 2:
                        mouseLight.sourceTexture = Textures.SHADER_pearl;
                        break;
                    case 3:
                        mouseLight.sourceTexture = Textures.SHADER_iris;
                        break;
                    case 4:
                        mouseLight.sourceTexture = Textures.SHADER_divine;
                        break;
                    case 5:
                        mouseLight.sourceTexture = Textures.SHADER_corona;
                        break;
                    case 6:
                        mouseLight.sourceTexture = Textures.SHADER_darkball;
                        break;
                }

                mouseLight.location.Width = mouseLight.sourceTexture.Width * 2;
                mouseLight.location.Height = mouseLight.sourceTexture.Height * 2;

                if (sTextureCount >= 6)
                    sTextureCount = 0;
            }

            if (Input.MouseWheelDown() | Input.KeyPressed(Keys.PageDown) && showMouseLight) //Cycle through colours
            {
                if (sColourCount == 0)
                    sColourCount = 9;
                else
                    sColourCount -= 1;

                MouseColourPicker();
            }

            if (Input.MouseWheelUp() | Input.KeyPressed(Keys.PageUp) && showMouseLight) //Cycle through colours
            {
                sColourCount += 1;
                if (sColourCount > 9)
                    sColourCount = 0;
                MouseColourPicker();
            }

        }

        public override void HandleTouch()
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation tl in touchCollection)
            {
                switch (tl.State)
                {
                    case TouchLocationState.Moved:
                        {
                            mouseLight.location.X = (int)tl.Position.X - mouseLight.sourceTexture.Width;
                            mouseLight.location.Y = (int)tl.Position.Y - mouseLight.sourceTexture.Height;
                            break;
                        }
                }
            }
        }

        private void MouseColourPicker()
        {
            switch (sColourCount)
            {
                case 0:
                    mouseLight.colour = Color.White;
                    colourString = "White";
                    break;
                case 1:
                    mouseLight.colour = Color.DeepSkyBlue;
                    colourString = "DeepSkyBlue";
                    break;
                case 2:
                    mouseLight.colour = Color.Firebrick;
                    colourString = "Firebrick";
                    break;
                case 3:
                    mouseLight.colour = Color.LawnGreen;
                    colourString = "LawnGreen";
                    break;
                case 4:
                    mouseLight.colour = Color.Yellow;
                    colourString = "Yellow";
                    break;
                case 5:
                    mouseLight.colour = Color.Violet;
                    colourString = "Violet";
                    break;
                case 6:
                    mouseLight.colour = Color.DarkOrange;
                    colourString = "DarkOrange";
                    break;
                case 7:
                    mouseLight.colour = Color.HotPink;
                    colourString = "HotPink";
                    break;
                case 8:
                    mouseLight.colour = Color.DodgerBlue;
                    colourString = "DodgerBlue";
                    break;
                case 9:
                    mouseLight.colour = Color.DimGray;
                    colourString = "DimGray";
                    break;
            }

            infoString2 =
                "F1: Enable/Disable Shaders" + System.Environment.NewLine +
                "F2: New Map" + System.Environment.NewLine +
                "F3: Clear Lights" + System.Environment.NewLine +
                "F4: Glowing trees" + System.Environment.NewLine +
                "F5: Show / Hide Mouse spot light" + System.Environment.NewLine +
                "W / S: Increase/Decrease ambient lighting" + System.Environment.NewLine +
                "Left Click: Place new light" + System.Environment.NewLine +
                "Right Click: Cycle shaders" + System.Environment.NewLine +
                "Scroll Wheel: Cycle colours (" + colourString + ")";
        }

        private void UpdateCampFireLights()
        {
            foreach (ObjectList _obj in mapHandler.getObjectList())
            {
                if (_obj.name == "CampFire")
                    lightHandler.AddPreset("CampFire", _obj.GetCentre());
            }
        }

    }
}
