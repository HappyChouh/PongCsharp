using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;

namespace PongCsharp
{
    internal class Ball : SpriteMouvement
    {
        public bool PreviousMovement = false;
        public bool IsOnMovement = false;
        public Ball(Texture2D texture, Vector2 position, float scale) : base(texture, position, scale)
        {
            Speed = 80f;
        }

        public override void Update(GameTime gameTime)
        {
            Random random = new Random();

            if (random.Next() % 2 == 0)
            {
                Debug.WriteLine("paire");
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            else
            {
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Debug.WriteLine("impaire");
            }
            base.Update(gameTime);
        }
    }
}
