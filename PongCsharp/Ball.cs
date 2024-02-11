using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCsharp
{
    internal class Ball : SpriteMouvement
    {
        public Ball(Texture2D texture, Vector2 position, float scale) : base(texture, position, scale)
        {
            Speed = 800f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
