using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Action.Actor
{
    class Block : GameObject
    {
        public Block(Vector2 position)
            : base("block",position,32,32)
        {

        }

        public Block(Block other)
            :this(other.position)
        { }

        public override object Clone()
        {
            return new Block(this);
        }

        public override void Hit(GameObject gameObject)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

    }
}
