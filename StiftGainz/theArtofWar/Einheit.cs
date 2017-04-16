using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace theArtofWar
{
    public class Einheit
    {
        private Microsoft.Xna.Framework.Graphics.Texture2D mInfTexture01;

        public Microsoft.Xna.Framework.Graphics.Texture2D InfTexture01
        {
            get { return mInfTexture01; }
            set { mInfTexture01 = value; }
        }

        public Vector2 Pos;
        
        public Einheit(int x, int y)
        {
            Pos = new Vector2(x, y);
        }

        public void Walk()
        {
        }
    }
}
