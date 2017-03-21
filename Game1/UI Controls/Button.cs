using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1 {
    class Button : SpriteObject {


        Texture2D Normal;
        Texture2D Hover;
        Texture2D Click;

        public Button(Texture2D Normal, Texture2D Hover, Texture2D Click, Vector2 Position) : base(Normal, Position) {

            this.Normal = Normal;
            this.Hover = Hover;
            this.Click = Click;
            
        }

        public override void Draw(SpriteBatch Batch) {

            Batch.Draw(Sprite, Position, Color.White);

            Texture2D rect = new Texture2D(Game1.GraphicsDeviceManager.GraphicsDevice, this.Bounds.Width, this.Bounds.Height);

            //Color[] data = new Color[this.Bounds.Width * this.Bounds.Height];
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            //rect.SetData(data);

            Vector2 coor = new Vector2(10, 20);
            Batch.Draw(rect, this.Bounds, Color.White);
        }




        public override void Update(GameTime GameTime) {
            base.Update(GameTime);

            MouseState mouseState = Mouse.GetState();
            Rectangle MousePosition = new Rectangle((int)mouseState.X, (int)mouseState.Y, 1, 1);


            if (MousePosition.Intersects(Bounds)) {

                this.Sprite = Hover;

                if (mouseState.LeftButton == ButtonState.Pressed) {
                    this.Sprite = Click;
                }
            } else {
                this.Sprite = Normal;
            }
            



        }
    }
}
