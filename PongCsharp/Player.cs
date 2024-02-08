using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongCsharp
{
    internal class Player : Sprite
    {
        private float speed;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
