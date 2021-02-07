using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ShadersAndLighting.Globals;
using Microsoft.Xna.Framework.Input;

namespace ShadersAndLighting.ScreenManagement
{
    public abstract class BaseScreen
    {
        public string Name = "";
        public ScreenState State = ScreenState.Active;
        public Single Position;
        public bool Focused = false;
        public bool GrabFocus = true;
        public bool hasEffects = false;


        public virtual void HandleInput()
        {
            // Handle Input for keyboard events.
        }

        public virtual void HandleTouch()
        {
            // Handle touch events (for tablets or phones)
        }

        public virtual void Update()
        {
            // General update events.
        }

        public virtual void Draw()
        {
            // Primary Draw events.
        }

        public virtual void DrawEffects()
        {
            // Secondary draw events (lighting).
        }

        public virtual void FinalizeEffects()
        {
            // Finish drawing
        }

        public virtual void DrawGUI()
        {
            //Draw the GUI (elements that arn't affected by shaders)
        }

        public virtual void Unload()
        {
            // Shut down screen.
            State = ScreenState.Shutdown;
        }

    }

    public class ScreenManager
    {
        private static List<BaseScreen> Screens;
        private static List<BaseScreen> RemoveScreens;

        //Fps Info
        private int fpsCounter = 0;
        private double fpsTimer = 0;

        public ScreenManager()
        {
            Screens = new List<BaseScreen>();
            RemoveScreens = new List<BaseScreen>();
        }

        public void Update()
        {
            // Generate list of dead screens for removal
            foreach (BaseScreen foundscreen in Screens)
            {
                if (foundscreen.State == ScreenState.Shutdown)
                {
                    RemoveScreens.Add(foundscreen);
                }
                else
                {
                    foundscreen.Focused = false;
                }
            }

            // Remove dead screens
            foreach (BaseScreen foundscreen in RemoveScreens)
            {
                Screens.Remove(foundscreen);
            }

            // Check screen focus
            if (Screens.Count > 0)
            {
                for (int i = Screens.Count - 1; i >= 0; i += -1)
                {
                    if (Screens[i].GrabFocus)
                    {
                        Screens[i].Focused = true;
                        break;
                    }

                }

            }

            //Update fps counter
            if (GV.GameTime.TotalGameTime.TotalMilliseconds > fpsTimer)
            {
                GV.fps = fpsCounter;
                fpsTimer = GV.GameTime.TotalGameTime.TotalMilliseconds + 1000;
                fpsCounter = 1;
            }
            else
            {
                fpsCounter += 1;
            }


            if (GV.WindowFocused)
            {
                // Handle Input for focused screen
                foreach (BaseScreen foundscreen in Screens)
                {
                    foundscreen.Update();

                    if (GV.Version == SystemVersion.PC)
                        foundscreen.HandleInput();
                    else if (GV.Version == SystemVersion.Tablet)
                        foundscreen.HandleTouch();

                }
            }
        }

        // Draw Screens
        public void Draw()
        {
            foreach (BaseScreen foundscreen in Screens)
            {
                if (foundscreen.State == ScreenState.Active)
                    foundscreen.Draw();
            }
        }

        // Draw any effects
        public void DrawEffects()
        {
            foreach (BaseScreen foundscreen in Screens)
            {
                if (foundscreen.State == ScreenState.Active)
                {
                    foundscreen.DrawEffects();
                    foundscreen.FinalizeEffects();
                }
            }
        }

        //Draw GUI
        public void DrawGUI()
        {
            foreach (BaseScreen foundscreen in Screens)
            {
                if (foundscreen.State == ScreenState.Active)
                    foundscreen.DrawGUI();
            }
        }

        // Add screen
        public static void AddScreen(BaseScreen _name)
        {
            bool _addScreen = true;

            foreach (BaseScreen foundscreen in Screens)
            {
                if (_name.Name == foundscreen.Name)
                {
                    _addScreen = false;
                    break;
                }
            }

            if (_addScreen) Screens.Add(_name);

        }

        // Remove screen
        public static void UnloadScreen(string _name)
        {
            foreach (BaseScreen foundscreen in Screens)
            {
                if (foundscreen.Name == _name)
                {
                    foundscreen.Unload();
                    break;
                }

            }

        }

        // See if a screen is active
        public static bool QueryScreen(string _name)
        {
            foreach (BaseScreen foundscreen in Screens)
            {
                if (foundscreen.Name == _name) return true;
            }
            return false;
        }
    }

    public enum ScreenState
    {
        Active,
        Shutdown,
        Hidden
    }
}
