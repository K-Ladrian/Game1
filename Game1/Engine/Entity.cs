using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Engine {
    public abstract class Entity : SpriteObject {

        // Inside of the entity abstract class you should have properties like
        // public int Health {get;set;} and other stuff
        // Those values such as health and damage should be the reason why you have an entity class
        public Vector2 Center { get; set; }
        public Entity(Texture2D Sprite, Vector2 Position) : base(Sprite, Position) {

        }
        
        public override void Update(GameTime GameTime) {
            base.Update(GameTime);
            this.Center = Position + new Vector2((float)Sprite.Width / 2, (float)Sprite.Height / 2);
        }

    }
}
