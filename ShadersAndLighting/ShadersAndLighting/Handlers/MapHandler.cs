using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShadersAndLighting.Globals;

namespace ShadersAndLighting.Handlers
{
    class MapHandler
    {
        private List<TileProperties> tileList;
        private List<ObjectList> objectList;
        private Random rnd;
        private int tmr;

        public MapHandler()
        {
            //Build a new map
            tileList = new List<TileProperties>();
            objectList = new List<ObjectList>();
            rnd = new Random();

            //Base Map
            for (int x = 0; x <= GV.GameSize.X / 32; x++)
            {
                for (int y = 0; y <= GV.GameSize.Y / 32; y++)
                {
                    TileProperties _t = new TileProperties();
                    _t.sourceImage = Textures.tileset;
                    _t.location = new Rectangle(x * 32, y * 32, 32, 32);
                    _t.colourTint = Color.White;

                    int _c = rnd.Next(1001);

                    if (_c < 980)
                    {
                        _t.sourceRectangle = new Rectangle(0, 0, 32, 32);
                    }
                    else if (_c < 990)
                    {
                        _t.sourceRectangle = new Rectangle(64, 0, 32, 32);
                    }
                    else
                    {
                        _t.sourceRectangle = new Rectangle(64, 32, 32, 32);
                    }

                    tileList.Add(_t);
                }
            }

            List<ObjectList> tmpObjectList = new List<ObjectList>();
            ObjectList _o;

            //Campfires
            for (int x = 0; x <= 3; x++)
            {
                _o = new ObjectList();
                _o.name = "CampFire";
                _o.colourTint = Color.White;
                _o.sourceImage = Textures.campfire;
                _o.sourceRectangle = new Rectangle(0, 0, 64, 64);
                _o.drawDepth = 2;
                _o.animated = true;

                switch (x)
                {
                    case 0:
                        _o.location = new Rectangle(250, 100, 64, 64);
                        break;
                    case 1:
                        _o.location = new Rectangle(GV.GameSize.X - 332, 100, 64, 64);
                        break;
                    case 2:
                        _o.location = new Rectangle(250, GV.GameSize.Y - 164, 64, 64);
                        break;
                    case 3:
                        _o.location = new Rectangle(GV.GameSize.X - 332, GV.GameSize.Y - 164, 64, 64);
                        break;
                }

                tmpObjectList.Add(_o);
            }

            //Objects
            for (int x = 0; x <= rnd.Next(15, 35); x++)
            {
                _o = new ObjectList();
                _o.colourTint = Color.White;
                _o.animated = false;

                if (rnd.Next(101) < 66)
                {
                    //Tree
                    _o.name = "Tree";
                    _o.sourceImage = Textures.trees;
                    _o.sourceRectangle = new Rectangle(168 * rnd.Next(0, 4), 0, 168, 245);
                    _o.location = new Rectangle(rnd.Next(0, GV.GameSize.X - 168), rnd.Next(0, GV.GameSize.Y - 245), 168, 245);
                    _o.drawDepth = 1;
                }
                else
                {
                    //Foliage
                    _o.name = "Foliage";
                    _o.sourceImage = Textures.foliage;
                    _o.sourceRectangle = new Rectangle(160 * rnd.Next(0, 4), 0, 160, 160);
                    _o.location = new Rectangle(rnd.Next(0, GV.GameSize.X - 160), rnd.Next(0, GV.GameSize.Y - 160), 160, 160);
                    _o.drawDepth = 0;
                }

                //Add to list if it doesn't overlap the campfire
                bool _okToAdd = true;
                foreach (ObjectList _obj in tmpObjectList)
                {
                    if (_obj.name == "CampFire" && _obj.location.Intersects(_o.location))
                    {
                        _okToAdd = false;
                        break;
                    }
                 
                    
                }

                if (_okToAdd)
                    tmpObjectList.Add(_o);
            }

            //Order list
            objectList.AddRange(tmpObjectList.OrderBy(x => x.drawDepth));

        }

        public void Update()
        {
            foreach (ObjectList _obj in objectList)
            {
                if (_obj.animated)
                {
                    tmr += Convert.ToInt32(GV.GameTime.ElapsedGameTime.TotalMilliseconds);
                    if (tmr > 180)
                    {
                        tmr = 0;

                        if (_obj.name == "CampFire")
                        {
                            _obj.sourceRectangle.X += 64;
                            if (_obj.sourceRectangle.X >= 320)
                                _obj.sourceRectangle.X = 0;
                        }
                    }
                }
            }
        }

        public void DrawMap()
        {
            foreach (TileProperties _tile in tileList)
            {
                GV.SpriteBatch.Draw(_tile.sourceImage, _tile.location, _tile.sourceRectangle, _tile.colourTint);
            }
        }

        public void DrawObjects()
        {
            foreach (ObjectList _object in objectList)
            {
                GV.SpriteBatch.Draw(_object.sourceImage, _object.location, _object.sourceRectangle, _object.colourTint);
                //GV.SpriteBatch.Draw(Textures.px, _object.location, Color.Red * 0.25f);
            }
        }

        public void RemoveCampFires()
        {
            List<ObjectList> tmpObjList = new List<ObjectList>();

            foreach (ObjectList _object in objectList)
            {
                if (_object.name == "CampFire")
                    tmpObjList.Add(_object);
            }

            foreach (ObjectList _object in tmpObjList)
            {
                objectList.Remove(_object);
            }
        }

        public List<TileProperties> getTileList()
        {
            return tileList;
        }

        public List<ObjectList> getObjectList()
        {
            return objectList;
        }
    }

    struct TileProperties
    {
        public Rectangle sourceRectangle;
        public Rectangle location;
        public Color colourTint;
        public Texture2D sourceImage;
    }

    class ObjectList
    {
        public string name;
        public Rectangle sourceRectangle;
        public Rectangle location;
        public Color colourTint;
        public Texture2D sourceImage;
        public byte drawDepth;
        public bool animated;

        public Point GetCentre()
        {
            //Get the centre point of the object
            return new Point(location.X + (location.Width / 2), location.Y + (location.Height / 2));
        }

    }
}
