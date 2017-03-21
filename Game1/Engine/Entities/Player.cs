using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Engine.Entites {
    class Player : Entity {


        public Player(Texture2D Sprite, Vector2 Position) : base(Sprite, Position) {

        }

        public override void Draw(SpriteBatch Batch) {

            Batch.Draw(Sprite, Position, Color.White);



            /* MAKES HITBOXES */

            //Texture2D rect = new Texture2D(Game1.GraphicsDeviceManager.GraphicsDevice, this.Bounds.Width, this.Bounds.Height);

            //Color[] data = new Color[this.Bounds.Width * this.Bounds.Height];
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            //rect.SetData(data);

            //Vector2 coor = new Vector2(10, 20);
            //Batch.Draw(rect, this.Bounds, Color.White);
        }

        public override void Update(GameTime GameTime) {
            base.Update(GameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D)) {
                if (Position.X + Sprite.Width <= GlobalResources.ScreenWidth) {
                    Rectangle FuturePosition = new Rectangle((int)Position.X + 5, (int)Position.Y, Sprite.Width, Sprite.Height);
                    if (Game1.CanMove(FuturePosition, Bounds)) {
                        Position = new Vector2(Position.X + 5, Position.Y);
                    }
                }
            } /*else*/
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) {
                if (Position.X >= 0) {
                    Rectangle FuturePosition = new Rectangle((int)Position.X - 5, (int)Position.Y, Sprite.Width, Sprite.Height);
                    if (Game1.CanMove(FuturePosition, Bounds)) {
                        Position = new Vector2(Position.X - 5, Position.Y);
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W)) {
                if (Position.Y >= 0) {
                    Rectangle FuturePosition = new Rectangle((int)Position.X, (int)Position.Y - 5, Sprite.Width, Sprite.Height);
                    if (Game1.CanMove(FuturePosition, Bounds)) {
                        Position = new Vector2(Position.X, Position.Y - 5);
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S)) {
                if (Position.Y + Sprite.Height <= GlobalResources.ScreenHeight) {
                    Rectangle FuturePosition = new Rectangle((int)Position.X, (int)Position.Y + 5, Sprite.Width, Sprite.Height);
                    if (Game1.CanMove(FuturePosition, Bounds)) {
                        Position = new Vector2(Position.X, Position.Y + 5);
                    }
                }
            }

            //Vector2 DirectionVector = DestinationVector - OriginVector;
            //Vector2 DirectionVectorNormalized = Vector2.Normalize(DirectionVector);

            //this.Position += DirectionVectorNormalized ;

        }
    }
}
