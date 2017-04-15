using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int mPosX = 0;
        public int PosX
        {
            get { return mPosX; }
            set { mPosX = value; }
        }
        private int mPosY = 0;
        public int PosY
        {
            get { return mPosY; }
            set { mPosY = value; }
        }
        public Einheit(int x, int y)
        {
            mPosX = x;
            mPosY = y;
        }

        public void Walk()
        {
        }
    }
}
