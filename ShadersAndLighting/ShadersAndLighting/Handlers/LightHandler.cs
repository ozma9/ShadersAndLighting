using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ShadersAndLighting.Globals;

namespace ShadersAndLighting.Handlers
{
    class LightHandler
    {
        private List<LightSource> lightList;

        public LightHandler()
        {
            lightList = new List<LightSource>();
        }

        public void AddPreset(string _name, Point _centrePoint)
        {
            //Add a preset light to the light list
            LightSource _l = new LightSource();

            switch (_name)
            {
                case "CampFire":

                    //Light 1
                    _l.sourceTexture = Textures.SHADER_star;
                    _l.location = new Rectangle(_centrePoint.X - (Textures.SHADER_star.Width / 2), _centrePoint.Y - (Textures.SHADER_star.Height / 2), Textures.SHADER_star.Width, Textures.SHADER_star.Height);
                    _l.colour = Color.Yellow;
                    _l.jitter = true;
                    _l.jitterAmount = GV.gRandom.Next(2, 6);
                    _l.jitterDelay = GV.gRandom.Next(150, 350);
                    _l.flicker = true;
                    _l.flickerIntensityHigher = 1.0f;
                    _l.flickerIntensityLower = 0.75f;
                    _l.flickerSpeed = GV.gRandom.Next(75,150);
                    lightList.Add(_l);

                    //Light 2
                    _l = new LightSource();
                    _l.sourceTexture = Textures.SHADER_star;
                    _l.location = new Rectangle(_centrePoint.X - Textures.SHADER_star.Width, _centrePoint.Y - Textures.SHADER_star.Height, Textures.SHADER_star.Width * 2, Textures.SHADER_star.Height * 2);
                    _l.colour = Color.Firebrick;
                    _l.jitter = false;
                    _l.flicker = false;
                    lightList.Add(_l);
                    break;
                case "Tree":
                    _l.sourceTexture = Textures.SHADER_corona;
                    _l.location = new Rectangle(_centrePoint.X - Textures.SHADER_corona.Width, _centrePoint.Y - Textures.SHADER_corona.Height, Textures.SHADER_corona.Width * 2, Textures.SHADER_corona.Height * 2);
                    _l.colour = Color.White;
                    _l.jitter = false;
                    _l.flicker = false;
                    lightList.Add(_l);
                    break;
            }
        }

        public void AddCustomLight(LightSource _light)
        {
            //Add a custom light
            LightSource _newLight = new LightSource();
            _newLight.location = _light.location;
            _newLight.sourceTexture = _light.sourceTexture;
            _newLight.colour = _light.colour;
            _newLight.jitter = false;
            _newLight.flicker = false;
            //_newLight.jitterOffset = _light.jitterOffset;
            //_newLight.jitterDelay = _light.jitterDelay;
            //_newLight.jitter = _light.jitter;
            //_newLight.jitterAmount = _light.jitterAmount;

            if (lightList.Count < 250) //Just a precaution~
                lightList.Add(_newLight);
        }

        public void ClearAllLights()
        {
            lightList.Clear();
        }

        public void Update()
        {
            foreach (LightSource _light in lightList)
            {
                if (_light.jitter)
                    _light.ApplyJitter();

                if (_light.flicker)
                    _light.ApplyFlicker();
            }
        }

        public void Draw()
        {
            foreach (LightSource _light in lightList)
            {
                GV.SpriteBatch.Draw(_light.sourceTexture, new Rectangle(_light.location.X + _light.jitterOffset.X, _light.location.Y + _light.jitterOffset.Y, _light.location.Width, _light.location.Height), _light.colour * _light.intensity);
            }
        }

        public List<LightSource> GetLightList()
        {
            return lightList;
        }

    }

    class LightSource
    {
        public Texture2D sourceTexture;
        public Rectangle location;
        public Color colour;
        //public bool isStatic;
        public Single intensity =1f;

        //Jitter stuff
        public bool jitter;
        public Point jitterOffset;
        public int jitterAmount;
        public int jitterDelay;

        //Flickering stuff
        public bool flicker;
        public Single flickerIntensityHigher;
        public Single flickerIntensityLower;
        public int flickerSpeed;
  
        private int jTmr = 0;
        private int fTmr = 0;

        public void ApplyJitter()
        {
            jTmr += Convert.ToInt32(GV.GameTime.ElapsedGameTime.TotalMilliseconds);

            if (jTmr > jitterDelay)
            {
                jTmr = 0;

                if (GV.gRandom.Next(101) < 50)
                {
                    jitterOffset.X = 0;
                    jitterOffset.X = GV.gRandom.Next(-jitterAmount, jitterAmount);
                }
                else
                {
                    jitterOffset.Y = 0;
                    jitterOffset.Y = GV.gRandom.Next(-jitterAmount, jitterAmount);
                }

            }
        }

        public void ApplyFlicker()
        {
            fTmr += Convert.ToInt32(GV.GameTime.ElapsedGameTime.TotalMilliseconds);

            if (fTmr > flickerSpeed)
            {
                fTmr = 0;
                intensity = Convert.ToSingle(GV.gRandom.NextDouble() * (flickerIntensityHigher - flickerIntensityLower) + flickerIntensityLower);
            }
        }
    }
}