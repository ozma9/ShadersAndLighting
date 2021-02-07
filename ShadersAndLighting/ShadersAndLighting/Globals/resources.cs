using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;

namespace ShadersAndLighting.Globals
{
        class Fonts
        {
            public static SpriteFont fontCalibri;


            public static void Load()
            {
                fontCalibri = GV.Content.Load<SpriteFont>("Fonts/Calibri");
            }
        }

        class Textures
        {
            public static Texture2D px;

            public static Texture2D tileset;
            public static Texture2D trees;
            public static Texture2D foliage;
            public static Texture2D campfire;

            //Shaders
            public static Texture2D SHADER_corona;
            public static Texture2D SHADER_divine;
            public static Texture2D SHADER_iris;
            public static Texture2D SHADER_pearl;
            public static Texture2D SHADER_star;
            public static Texture2D SHADER_sun;
            public static Texture2D SHADER_darkball;

            public static void Load()
            {
                px = GV.Content.Load<Texture2D>("Textures/pixel");

			tileset = GV.Content.Load<Texture2D>("Textures/tiles");
			trees = GV.Content.Load<Texture2D>("Textures/trees");
			foliage = GV.Content.Load<Texture2D>("Textures/foliage");

			campfire = GV.Content.Load<Texture2D>("Textures/campfire");

                //Shaders
			SHADER_corona = GV.Content.Load<Texture2D>("Textures/shaders/corona");
			SHADER_divine = GV.Content.Load<Texture2D>("Textures/shaders/divine");
			SHADER_iris = GV.Content.Load<Texture2D>("Textures/shaders/iris");
			SHADER_pearl = GV.Content.Load<Texture2D>("Textures/shaders/pearl");
			SHADER_star = GV.Content.Load<Texture2D>("Textures/shaders/star");
			SHADER_sun = GV.Content.Load<Texture2D>("Textures/shaders/sun");
			SHADER_darkball = GV.Content.Load<Texture2D>("Textures/shaders/darkball");
            }
        }

        class Effects
        {
            public static Effect lighting;

            public static void Load()
            {

            //byte[] newCode;
            //List<byte> byteList = new List<byte>();

            //string _a = "";

            //foreach (char _b in GV.shader)
            //{
            //    if (_b.ToString() == ",")
            //    {
            //        byteList.Add(byte.Parse(_a));
            //        _a = "";
            //    }
            //    else
            //    {
            //        _a += _b;
            //    }
            //}

            //newCode = byteList.ToArray();
            //lighting = new Effect (GV.Graphics.GraphicsDevice, newCode);
		
                lighting = GV.Content.Load<Effect>("Effects/lighting");
                //blur = GV.Content.Load<Effect>("Effects/blur");

            }
        }

}
