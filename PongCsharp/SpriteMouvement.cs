using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongCsharp
{
    abstract class SpriteMouvement : Sprite
    {
        public float Speed;
        protected SpriteMouvement(Texture2D texture, Vector2 position, float scale) : base(texture, position, scale)
        {
            
        }
    }
}
