using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCsharp
{
    internal class Sprite
    {
        public Texture2D Texture;
        public Vector2 Position;
        public float Scale;

        public Rectangle Rect
        {

            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)((float)Texture.Width*Scale), (int)((float)Texture.Height*Scale));
            }

        }

        public Sprite(Texture2D texture, Vector2 position, float scale)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
        }

        public virtual void Update(GameTime gameTime) { }
        
    }
}
