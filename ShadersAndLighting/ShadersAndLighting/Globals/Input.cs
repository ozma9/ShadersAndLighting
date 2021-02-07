using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ShadersAndLighting.Globals
{
    class Input
    {
        static KeyboardState CurrentKeyState;
        static KeyboardState LastKeyState;

        static MouseState CurrentMouseState;
        static MouseState LastMouseState;

        static int CurrentWheelValue;
        static int LastWheelValue;

        public static void Update()
        {
            //Update keyboard state
            LastKeyState = CurrentKeyState;
            CurrentKeyState = Keyboard.GetState();

            //Update mouse state
            LastMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();

            LastWheelValue = CurrentWheelValue;
            CurrentWheelValue = Mouse.GetState().ScrollWheelValue;

        }

        public static bool KeyDown(Keys key)
        {
            return CurrentKeyState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            if (CurrentKeyState.IsKeyDown(key) & LastKeyState.IsKeyUp(key))
                return true;
            return false;
        }

        public static bool LeftMouseClick()
        {
            if(CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public static bool RightMouseClick()
        {
            if (CurrentMouseState.RightButton == ButtonState.Released && LastMouseState.RightButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public static bool MouseWheelUp()
        {
            if (CurrentWheelValue > LastWheelValue)
                return true;
            return false;
        }

        public static bool MouseWheelDown()
        {
            if (CurrentWheelValue < LastWheelValue)
                return true;
            return false;
        }

    }
}
