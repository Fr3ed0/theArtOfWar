using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theArtofWar
{
    public class Einheit
    {
        private Microsoft.Xna.Framework.Graphics.Texture2D _InfTexture01;

        public Microsoft.Xna.Framework.Graphics.Texture2D InfTexture01
        {
            get { return _InfTexture01; }
            set { _InfTexture01 = value; }
        }

        private int _PosX = 0;
        public int PosX
        {
            get { return _PosX; }
            set { _PosX = value; }
        }
        private int _PosY = 0;
        public int PosY
        {
            get { return _PosY; }
            set { _PosY = value; }
        }
        public Einheit(int x, int y)
        {
            _PosX = x;
            _PosY = y;
        }

        public void walk()
        {
        }
    }
}
