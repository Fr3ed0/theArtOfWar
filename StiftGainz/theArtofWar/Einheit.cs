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
        public bool isColliding = false;
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

        public float GetDirection(Vector2 destination)
        {
            Vector2 direction = destination - Pos;
            direction.Normalize();
            return (float)(Math.Atan2((double)direction.Y, (double)direction.X) + Math.PI / 2);
        }

        public void Walk(Vector2 destination, float speed = 1)
        {
            Vector2 direction = destination - Pos;
            direction.Normalize();
            direction *= speed;
            Pos += direction;
        }

        public bool IsCollided(Einheit other)
        {
            if ((Pos - other.Pos).Length() < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
