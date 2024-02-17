using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCsharp
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player playerOne;
        private Player playerTwo;

        private Ball ball;

        private float scale = 0.35f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D playerOneTexture = Content.Load<Texture2D>("player_1");
            Texture2D playerTwoTexture = Content.Load<Texture2D>("player_2");
            Texture2D ballTexture = Content.Load<Texture2D>("ball");

            playerOne = new Player(playerOneTexture, new Vector2(_graphics.PreferredBackBufferWidth / 25, _graphics.PreferredBackBufferHeight / 2), scale);
            playerTwo = new Player(playerTwoTexture, new Vector2((_graphics.PreferredBackBufferWidth - _graphics.PreferredBackBufferWidth / 25), _graphics.PreferredBackBufferHeight / 2), scale);
            ball = new(ballTexture, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), scale);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();
            Random random = new Random();

            float maxHeightPlayer = (float)_graphics.PreferredBackBufferHeight;
            float minHeightPlayer = 0;


            //new Vector2(playerTwo.Texture.Height / 2)

            if (keyboardState.IsKeyDown(Keys.A) && playerOne.Position.Y <= maxHeightPlayer)
                playerOne.Position.Y += playerOne.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.E) && playerOne.Position.Y >= minHeightPlayer)
                playerOne.Position.Y -= playerOne.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (keyboardState.IsKeyDown(Keys.Left) && playerTwo.Position.Y <= maxHeightPlayer)
                playerTwo.Position.Y += playerOne.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.Right) && playerTwo.Position.Y >= minHeightPlayer)
                playerTwo.Position.Y -= playerOne.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!ball.IsOnMovement && keyboardState.IsKeyDown(Keys.Space))
            {
                if (random.Next() % 2 == 0)
                {
                    if (random.Next() % 2 == 0)
                        ball.SetDirectionTopLeft();
                    else
                        ball.SetDirectionTopRight();

                }
                else
                {
                    if (random.Next() % 2 == 0)
                        ball.SetDirectionBotLeft();
                    else
                        ball.SetDirectionBotRight();
                }
            }


            ball.Update(gameTime);

            if (ball.Rect.Y <= 0f)
            {
                ball.SetDirectionBot();
            }
            else if (ball.Rect.Y >= (float)_graphics.PreferredBackBufferHeight)
            {
                ball.SetDirectionTop();
            }

            if (ball.IsTouchingLeft(playerOne))
            {
                ball.Directions["top"] = !ball.Directions["top"];
                ball.Directions["bot"] = !ball.Directions["bot"];
                ball.Directions["right"] = !ball.Directions["right"];
                ball.Directions["left"] = !ball.Directions["left"];
            }
            else if(ball.Rect.Intersects(playerTwo.Rect))
            {
                ball.Directions["top"] = !ball.Directions["top"];
                ball.Directions["bot"] = !ball.Directions["bot"];
                ball.Directions["right"] = !ball.Directions["right"];
                ball.Directions["left"] = !ball.Directions["left"];
            }


            Debug.WriteLine(playerOne.Position + " " + playerOne.Speed + " max :" + maxHeightPlayer + " min :" + minHeightPlayer);
            Debug.WriteLine(ball.Position + " " + ball.Speed);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(playerOne.Texture, playerOne.Position, null, Color.White, 0f, new Vector2(playerOne.Texture.Width / 2, playerOne.Texture.Height / 2), new Vector2(playerOne.Scale), SpriteEffects.None, 0f);
            _spriteBatch.Draw(playerTwo.Texture, playerTwo.Position, null, Color.White, 0f, new Vector2(playerTwo.Texture.Width / 2, playerTwo.Texture.Height / 2), new Vector2(playerTwo.Scale), SpriteEffects.None, 0f);
            _spriteBatch.Draw(ball.Texture, ball.Position, null, Color.White, 0f, new Vector2(ball.Texture.Width / 2, ball.Texture.Height / 2), new Vector2(ball.Scale), SpriteEffects.None, 0f);
            _spriteBatch.DrawString(Content.Load<SpriteFont>("font"), playerOne.Position.ToString(), Vector2.One, Color.White);
            _spriteBatch.DrawString(Content.Load<SpriteFont>("font"), playerTwo.Position.ToString(), new Vector2(1120, 1), Color.White);
            _spriteBatch.DrawString(Content.Load<SpriteFont>("font"), ball.Position.ToString(), new Vector2(650, 500), Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
