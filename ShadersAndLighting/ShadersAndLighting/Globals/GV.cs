﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShadersAndLighting.Globals
{
    class GV
    {
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static bool WindowFocused;
        public static Point GameSize;
        public static Random gRandom;
        public static SystemVersion Version;

        public static int fps = 0;
		//public const string shader = "77,71,70,88,5,1,0,1,0,91,20,0,0,68,88,66,67,105,73,218,53,249,41,23,26,157,154,244,66,255,80,139,213,1,0,0,0,91,20,0,0,5,0,0,0,52,0,0,0,188,2,0,0,140,3,0,0,243,19,0,0,39,20,0,0,65,111,110,57,128,2,0,0,128,2,0,0,0,2,255,255,84,2,0,0,44,0,0,0,0,0,44,0,0,0,44,0,0,0,44,0,2,0,36,0,0,0,44,0,0,0,0,0,1,1,1,0,0,2,255,255,254,255,122,0,68,66,85,71,40,0,0,0,176,1,0,0,0,0,0,0,1,0,0,0,112,0,0,0,7,0,0,0,116,0,0,0,4,0,0,0,96,1,0,0,172,0,0,0,67,58,92,92,80,114,111,103,114,97,109,32,70,105,108,101,115,32,40,120,56,54,41,92,92,77,83,66,117,105,108,100,92,92,77,111,110,111,71,97,109,101,92,92,118,51,46,48,92,92,50,77,71,70,88,92,92,108,105,103,104,116,105,110,103,46,102,120,0,171,171,171,40,0,0,0,0,0,255,255,240,1,0,0,0,0,255,255,252,1,0,0,0,0,255,255,8,2,0,0,13,0,0,0,20,2,0,0,14,0,0,0,36,2,0,0,15,0,0,0,52,2,0,0,10,0,0,0,68,2,0,0,80,105,120,101,108,83,104,97,100,101,114,70,117,110,99,116,105,111,110,0,1,0,3,0,1,0,4,0,1,0,0,0,0,0,0,0,5,0,0,0,0,0,1,0,2,0,3,0,6,0,0,0,0,0,1,0,2,0,3,0,105,110,112,117,116,0,84,101,120,116,117,114,101,67,111,111,114,100,115,0,1,0,3,0,1,0,4,0,1,0,0,0,0,0,0,0,238,0,0,0,252,0,0,0,5,0,0,0,1,0,4,0,1,0,1,0,12,1,0,0,0,0,0,0,0,0,1,0,2,0,3,0,108,105,103,104,116,67,111,108,111,114,0,171,4,0,0,0,0,0,1,0,2,0,3,0,109,97,105,110,67,111,108,111,114,0,171,171,3,0,0,0,0,0,1,0,2,0,3,0,0,0,0,0,172,0,0,0,192,0,0,0,2,0,0,0,208,0,0,0,172,0,0,0,232,0,0,0,20,1,0,0,1,0,0,0,36,1,0,0,0,0,0,0,48,1,0,0,252,0,0,0,1,0,0,0,60,1,0,0,0,0,0,0,72,1,0,0,252,0,0,0,1,0,0,0,84,1,0,0,77,105,99,114,111,115,111,102,116,32,40,82,41,32,72,76,83,76,32,83,104,97,100,101,114,32,67,111,109,112,105,108,101,114,32,57,46,50,57,46,57,53,50,46,51,49,49,49,0,171,171,171,31,0,0,2,0,0,0,128,0,0,15,176,31,0,0,2,0,0,0,144,0,8,15,160,31,0,0,2,0,0,0,144,1,8,15,160,66,0,0,3,0,0,15,128,0,0,228,176,0,8,228,160,66,0,0,3,1,0,15,128,0,0,228,176,1,8,228,160,5,0,0,3,0,0,15,128,0,0,228,128,1,0,228,128,1,0,0,2,0,8,15,128,0,0,228,128,255,255,0,0,83,72,68,82,200,0,0,0,64,0,0,0,50,0,0,0,90,0,0,3,0,96,16,0,0,0,0,0,90,0,0,3,0,96,16,0,1,0,0,0,88,24,0,4,0,112,16,0,0,0,0,0,85,85,0,0,88,24,0,4,0,112,16,0,1,0,0,0,85,85,0,0,98,16,0,3,50,16,16,0,0,0,0,0,101,0,0,3,242,32,16,0,0,0,0,0,104,0,0,2,2,0,0,0,69,0,0,9,242,0,16,0,0,0,0,0,70,16,16,0,0,0,0,0,70,126,16,0,0,0,0,0,0,96,16,0,0,0,0,0,69,0,0,9,242,0,16,0,1,0,0,0,70,16,16,0,0,0,0,0,70,126,16,0,1,0,0,0,0,96,16,0,1,0,0,0,56,0,0,7,242,32,16,0,0,0,0,0,70,14,16,0,0,0,0,0,70,14,16,0,1,0,0,0,62,0,0,1,83,68,66,71,95,16,0,0,84,0,0,0,31,3,0,0,80,3,0,0,100,3,0,0,5,17,0,0,1,0,0,0,0,0,0,0,4,0,0,0,16,0,0,0,18,0,0,0,64,6,0,0,6,0,0,0,240,7,0,0,18,0,0,0,128,8,0,0,8,0,0,0,232,9,0,0,9,0,0,0,136,10,0,0,20,12,0,0,160,12,0,0,0,0,0,0,62,0,0,0,62,0,0,0,181,2,0,0,0,0,0,0,69,0,0,0,1,0,0,0,4,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,1,0,0,0,2,0,0,0,3,0,0,0,10,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,11,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,12,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,13,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,255,255,255,255,255,255,255,255,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,0,0,0,0,0,0,0,3,0,0,0,92,0,0,0,3,0,0,0,80,0,0,0,1,0,0,0,69,0,0,0,1,0,0,0,4,0,0,0,1,0,0,0,255,255,255,255,0,0,0,0,1,0,0,0,2,0,0,0,3,0,0,0,14,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,15,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,16,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,17,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,0,0,0,0,1,0,0,0,255,255,255,255,255,255,255,255,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0,0,0,0,0,0,0,3,0,0,0,116,0,0,0,3,0,0,0,104,0,0,0,2,0,0,0,56,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,1,0,0,0,2,0,0,0,3,0,0,0,6,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,1,0,0,0,1,0,0,0,7,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,1,0,0,0,1,0,0,0,8,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,1,0,0,0,1,0,0,0,9,0,0,0,0,0,0,0,255,255,255,255,0,0,0,128,255,255,255,127,0,0,128,255,0,0,128,127,1,0,0,0,1,0,0,0,255,255,255,255,255,255,255,255,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,3,0,0,0,128,0,0,0,2,0,0,0,56,0,0,0,3,0,0,0,62,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,3,0,0,0,128,0,0,0,0,0,0,0,0,0,0,0,13,0,0,0,10,0,0,0,255,255,255,255,255,255,255,255,1,0,0,0,0,0,0,0,14,0,0,0,10,0,0,0,255,255,255,255,255,255,255,255,2,0,0,0,0,0,0,0,9,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,5,0,0,0,0,0,0,0,9,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,5,0,0,0,1,0,0,0,9,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,5,0,0,0,2,0,0,0,9,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,5,0,0,0,3,0,0,0,10,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,4,0,0,0,0,0,0,0,10,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,4,0,0,0,1,0,0,0,10,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,4,0,0,0,2,0,0,0,10,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,4,0,0,0,3,0,0,0,11,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,7,0,0,0,0,0,0,0,11,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,7,0,0,0,1,0,0,0,11,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,7,0,0,0,2,0,0,0,11,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,7,0,0,0,3,0,0,0,12,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,8,0,0,0,0,0,0,0,12,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,8,0,0,0,1,0,0,0,12,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,8,0,0,0,2,0,0,0,12,0,0,0,3,0,0,0,255,255,255,255,255,255,255,255,8,0,0,0,3,0,0,0,2,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,255,255,255,255,3,0,0,0,0,0,0,0,255,255,255,255,0,0,0,0,1,0,0,0,255,255,255,255,0,0,0,0,7,0,0,0,255,255,255,255,0,0,0,0,255,255,255,255,255,255,255,255,1,0,0,0,7,0,0,0,255,255,255,255,1,0,0,0,255,255,255,255,255,255,255,255,0,0,0,0,6,0,0,0,255,255,255,255,0,0,0,0,255,255,255,255,255,255,255,255,1,0,0,0,6,0,0,0,255,255,255,255,1,0,0,0,255,255,255,255,255,255,255,255,0,0,0,0,7,0,0,0,11,0,0,0,31,0,0,0,0,3,0,0,0,0,0,0,1,0,0,0,8,0,0,0,9,0,0,0,149,0,0,0,0,0,0,0,2,0,0,0,8,0,0,0,11,0,0,0,170,0,0,0,0,0,0,0,3,0,0,0,8,0,0,0,12,0,0,0,211,0,0,0,0,0,0,0,10,0,0,0,7,0,0,0,19,0,0,0,99,1,0,0,0,0,0,0,10,0,0,0,46,0,0,0,5,0,0,0,138,1,0,0,0,0,0,0,12,0,0,0,11,0,0,0,8,0,0,0,170,1,0,0,0,0,0,0,13,0,0,0,11,0,0,0,9,0,0,0,217,1,0,0,0,0,0,0,14,0,0,0,11,0,0,0,10,0,0,0,20,2,0,0,0,0,0,0,10,0,0,0,46,0,0,0,5,0,0,0,138,1,0,0,0,0,0,0,10,0,0,0,7,0,0,0,19,0,0,0,99,1,0,0,0,0,0,0,13,0,0,0,11,0,0,0,9,0,0,0,217,1,0,0,0,0,0,0,14,0,0,0,11,0,0,0,10,0,0,0,20,2,0,0,0,0,0,0,2,0,0,0,8,0,0,0,11,0,0,0,170,0,0,0,0,0,0,0,3,0,0,0,8,0,0,0,12,0,0,0,211,0,0,0,0,0,0,0,13,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,25,1,0,0,16,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,243,2,0,0,7,0,0,0,4,0,0,0,4,0,0,0,1,0,0,0,250,2,0,0,6,0,0,0,1,0,0,0,20,0,0,0,4,0,0,0,99,1,0,0,19,0,0,0,2,0,0,0,24,0,0,0,1,0,0,0,250,2,0,0,6,0,0,0,2,0,0,0,32,0,0,0,4,0,0,0,99,1,0,0,19,0,0,0,3,0,0,0,40,0,0,0,1,0,0,0,250,2,0,0,6,0,0,0,3,0,0,0,52,0,0,0,4,0,0,0,99,1,0,0,19,0,0,0,4,0,0,0,64,0,0,0,1,0,0,0,0,0,0,0,4,0,0,0,1,0,0,0,1,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,255,255,255,255,2,0,0,0,0,0,0,0,4,0,0,0,1,0,0,0,1,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,4,0,0,0,1,0,0,0,1,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,4,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,255,255,255,255,4,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,4,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,6,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,2,0,0,0,6,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,2,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,255,255,255,255,7,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,4,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,10,0,0,0,8,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,4,0,0,0,255,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,14,0,0,0,3,0,0,0,0,0,0,0,1,0,0,0,2,0,0,0,4,0,0,0,6,0,0,0,5,0,0,0,6,0,0,0,6,0,0,0,7,0,0,0,5,0,0,0,6,0,0,0,7,0,0,0,6,0,0,0,7,0,0,0,8,0,0,0,5,0,0,0,6,0,0,0,7,0,0,0,8,0,0,0,1,0,0,0,5,0,0,0,7,0,0,0,2,0,0,0,3,0,0,0,1,0,0,0,2,0,0,0,5,0,0,0,8,0,0,0,4,0,0,0,5,0,0,0,1,0,0,0,6,0,0,0,7,0,0,0,1,0,0,0,67,58,92,80,114,111,103,114,97,109,32,70,105,108,101,115,32,40,120,56,54,41,92,77,83,66,117,105,108,100,92,77,111,110,111,71,97,109,101,92,118,51,46,48,92,50,77,71,70,88,92,108,105,103,104,116,105,110,103,46,102,120,35,108,105,110,101,32,49,32,34,67,58,92,92,80,114,111,103,114,97,109,32,70,105,108,101,115,32,40,120,56,54,41,92,92,77,83,66,117,105,108,100,92,92,77,111,110,111,71,97,109,101,92,92,118,51,46,48,92,92,50,77,71,70,88,92,92,108,105,103,104,116,105,110,103,46,102,120,34,10,116,101,120,116,117,114,101,32,108,105,103,104,116,77,97,115,107,32,59,32,10,115,97,109,112,108,101,114,32,109,97,105,110,83,97,109,112,108,101,114,32,58,32,114,101,103,105,115,116,101,114,32,40,32,115,48,32,41,32,59,32,10,115,97,109,112,108,101,114,32,108,105,103,104,116,83,97,109,112,108,101,114,32,61,32,115,97,109,112,108,101,114,95,115,116,97,116,101,32,123,32,84,101,120,116,117,114,101,32,61,32,60,32,108,105,103,104,116,77,97,115,107,32,62,32,59,32,125,32,59,32,10,10,115,116,114,117,99,116,32,80,105,120,101,108,83,104,97,100,101,114,73,110,112,117,116,32,10,123,32,10,32,32,32,32,102,108,111,97,116,52,32,84,101,120,116,117,114,101,67,111,111,114,100,115,32,58,32,84,69,88,67,79,79,82,68,48,32,59,32,10,125,32,59,32,10,10,102,108,111,97,116,52,32,80,105,120,101,108,83,104,97,100,101,114,70,117,110,99,116,105,111,110,32,40,32,80,105,120,101,108,83,104,97,100,101,114,73,110,112,117,116,32,105,110,112,117,116,32,41,32,58,32,67,79,76,79,82,48,32,10,123,32,10,32,32,32,32,102,108,111,97,116,50,32,116,101,120,67,111,111,114,100,32,61,32,105,110,112,117,116,32,46,32,84,101,120,116,117,114,101,67,111,111,114,100,115,32,59,32,10,32,32,32,32,102,108,111,97,116,52,32,109,97,105,110,67,111,108,111,114,32,61,32,116,101,120,50,68,32,40,32,109,97,105,110,83,97,109,112,108,101,114,32,44,32,116,101,120,67,111,111,114,100,32,41,32,59,32,10,32,32,32,32,102,108,111,97,116,52,32,108,105,103,104,116,67,111,108,111,114,32,61,32,116,101,120,50,68,32,40,32,108,105,103,104,116,83,97,109,112,108,101,114,32,44,32,116,101,120,67,111,111,114,100,32,41,32,59,32,10,32,32,32,32,114,101,116,117,114,110,32,109,97,105,110,67,111,108,111,114,32,42,32,108,105,103,104,116,67,111,108,111,114,32,59,32,10,125,32,10,10,116,101,99,104,110,105,113,117,101,32,84,101,99,104,110,105,113,117,101,49,32,10,123,32,10,32,32,32,32,112,97,115,115,32,80,97,115,115,49,32,10,32,32,32,32,123,32,10,32,32,32,32,32,32,32,32,80,105,120,101,108,83,104,97,100,101,114,32,61,32,99,111,109,112,105,108,101,32,112,115,95,52,95,48,95,108,101,118,101,108,95,57,95,49,32,80,105,120,101,108,83,104,97,100,101,114,70,117,110,99,116,105,111,110,32,40,32,41,32,59,32,10,32,32,32,32,125,32,10,125,32,10,71,108,111,98,97,108,115,76,111,99,97,108,115,80,105,120,101,108,83,104,97,100,101,114,73,110,112,117,116,58,58,84,101,120,116,117,114,101,67,111,111,114,100,115,77,105,99,114,111,115,111,102,116,32,40,82,41,32,72,76,83,76,32,83,104,97,100,101,114,32,67,111,109,112,105,108,101,114,32,57,46,50,57,46,57,53,50,46,51,49,49,49,0,80,105,120,101,108,83,104,97,100,101,114,70,117,110,99,116,105,111,110,0,112,115,95,52,95,48,0,73,83,71,78,44,0,0,0,1,0,0,0,8,0,0,0,32,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,15,3,0,0,84,69,88,67,79,79,82,68,0,171,171,171,79,83,71,78,44,0,0,0,1,0,0,0,8,0,0,0,32,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,15,0,0,0,83,86,95,84,97,114,103,101,116,0,171,171,2,0,0,0,0,0,0,1,1,0,1,0,2,3,7,11,109,97,105,110,83,97,109,112,108,101,114,0,0,0,0,0,0,3,7,9,108,105,103,104,116,77,97,115,107,0,0,0,0,0,0,1,10,84,101,99,104,110,105,113,117,101,49,0,1,5,80,97,115,115,49,0,255,0,0,0,0,";
		
    }

    public enum SystemVersion
    {
        PC,
        Tablet
    }
}