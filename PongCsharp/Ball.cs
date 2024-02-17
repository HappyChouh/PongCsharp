using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongCsharp
{
    internal class Ball : SpriteMouvement
    {
        public Dictionary<string, bool> Directions = new Dictionary<string, bool>();

        public bool PreviousMovement = false;
        public bool IsOnMovement
        {
            get
            {
                foreach (KeyValuePair<string, bool> kvp in Directions)
                {
                    if (kvp.Value)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        public Ball(Texture2D texture, Vector2 position, float scale) : base(texture, position, scale)
        {
            Directions.Add("top", false);
            Directions.Add("bot", false);
            Directions.Add("left", false);
            Directions.Add("right", false);
            Speed = 800f;
        }

        public override void Update(GameTime gameTime)
        {
            if (Directions["top"])
            {
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Directions["bot"])
            {
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Directions["left"])
            {

                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Directions["right"])
            {

                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            base.Update(gameTime);
        }

        public void SetDirectionTopLeft()
        {
            Directions["top"] = true;
            Directions["left"] = true;
            Directions["bot"] = false;
            Directions["right"] = false;

        }
        public void SetDirectionBotLeft()
        {
            Directions["top"] = false;
            Directions["left"] = true;
            Directions["bot"] = true;
            Directions["right"] = false;

        }
        public void SetDirectionTopRight()
        {
            Directions["top"] = true;
            Directions["left"] = false;
            Directions["bot"] = false;
            Directions["right"] = true;

        }
        public void SetDirectionBotRight()
        {
            Directions["top"] = false;
            Directions["left"] = false;
            Directions["bot"] = true;
            Directions["right"] = true;

        }
        public void SetDirectionBot()
        {
            Directions["top"] = false;
            Directions["bot"] = true;

        }

        public void SetDirectionTop()
        {
            Directions["top"] = true;
            Directions["bot"] = false;

        }

        public bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rect.Right + this.Speed > sprite.Rect.Left &&
              this.Rect.Left < sprite.Rect.Left &&
              this.Rect.Bottom > sprite.Rect.Top &&
              this.Rect.Top < sprite.Rect.Bottom;
        }

        public bool IsTouchingRight(Sprite sprite)
        {
            return this.Rect.Left + this.Speed < sprite.Rect.Right &&
              this.Rect.Right > sprite.Rect.Right &&
              this.Rect.Bottom > sprite.Rect.Top &&
              this.Rect.Top < sprite.Rect.Bottom;
        }

    }
}
