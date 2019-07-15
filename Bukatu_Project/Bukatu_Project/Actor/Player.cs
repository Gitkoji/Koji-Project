using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action.Def;
using Action.Device;
using Action.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Action.Actor
{
    class Player : GameObject
    {
        private IGameObjectMediator mediator;
        private Vector2 velocity;
        private bool isJump;
        public Player(Vector2 position,IGameObjectMediator mediator) : 
            base("player", position, 32, 32)
        {
            velocity = Vector2.Zero;
            isJump = true;
            this.mediator = this.mediator;
        }

        public Player(Player other)
            :this(other.position,other.mediator)
        { }

        public override object Clone()
        {
            return new Player(this);
        }



        public override void Update(GameTime gameTime)
        {
            if((isJump == false)&&
                Input.GetKeyTrigger(Keys.X))
            {
                velocity.Y = -8.0f;
                isJump = true;
            }
            else
            {
                velocity.Y = velocity.Y + 0.4f;
                velocity.Y = (velocity.Y > 16.0f) ? (16.0f) : (velocity.Y);
            }

            float speed = 4.0f;
            if(Input.GetKeyState(Keys.Z))
            {
                speed = 8.0f;
            }
            velocity.X = Input.Velocity().X * speed;

            position = position + velocity;

            setDisplayModify();
        }

        private void hitBlock(GameObject gameObject)
        {
            Direction dir = this.CheckDirection(gameObject);

            if(dir == Direction.Top)
            {
                if (position.Y > 0.0f)
                {
                    position.Y = gameObject.getRectangle().Top - this.height;
                    velocity.Y = 0.0f;
                    isJump = false;
                }
            }
            else if(dir == Direction.Right)
            {
                position.X = gameObject.getRectangle().Right;
            }
            else if (dir == Direction.Left)
            {
                position.X = gameObject.getRectangle().Left;
            }
            else if(dir == Direction.Bottom)
            {
                position.Y = gameObject.getRectangle().Bottom;

                if(isJump)
                {
                    velocity.Y = 0.0f;
                }
            }
        }

        public override void Hit(GameObject gameObject)
        {
            Direction dir = this.CheckDirection(gameObject);
            if (gameObject is Block)
            {
                hitBlock(gameObject);
            }
            else if (dir == Direction.Bottom)
            {
                position.Y = gameObject.getRectangle().Bottom;

                if (isJump)
                {
                    velocity.Y = 0.0f;
                }
            }

            setDisplayModify();

        }

        private void setDisplayModify()
        {
            gameDevice.SetDisplayModify(new Vector2(-position.X +
                (Screen.Width / 2 - width / 2), 0.0f));

            if(position.X < 400)
            {
                gameDevice.SetDisplayModify(Vector2.Zero);
            }
        }
    }
}
