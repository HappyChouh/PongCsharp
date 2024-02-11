using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCsharp
{
    internal class Player : SpriteMouvement
    {

        public Player(Texture2D texture, Vector2 position, float scale) : base(texture, position, scale)
        {
            Speed = 500f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
