using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1 {
    public abstract class SpriteObject : Drawable {


        public Texture2D Sprite { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public SpriteObject(Texture2D Sprite, Vector2 Position) {
            this.Sprite = Sprite;
            this.Position = Position;
            UpdateBounds();
        }

        public override void Update(GameTime GameTime) {
            UpdateBounds();
        }

        public virtual void UpdateBounds() {
            this.Bounds = new Rectangle((int)Position.X, (int)Position.Y, Sprite.Width, Sprite.Height);
        }
    }
}
