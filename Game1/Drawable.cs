using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1 {
    public abstract class Drawable {
        public abstract void Update(GameTime GameTime);

        public abstract void Draw(SpriteBatch Batch);
    }
}
