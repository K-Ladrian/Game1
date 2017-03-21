using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Engine.Entities {
    class Monster : Entity {
        public Monster(Texture2D Sprite, Vector2 Position) : base(Sprite, Position) {

        }
        public override void Draw(SpriteBatch Batch) {
            Batch.Draw(Sprite, Position, Color.White);
        }

        public override void Update(GameTime GameTime) {
            base.Update(GameTime);

            Vector2 DestinationVector = Game1.GameObjects["Player"].Center;
            Vector2 OriginVector = this.Center;

            Vector2 DirectionVector = DestinationVector - OriginVector;
            Vector2 DirectionVectorNormalized = Vector2.Normalize(DirectionVector) * 5;

            this.Position += DirectionVectorNormalized;

            base.Update(GameTime);
        }
    }
}
