using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action.Device;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Action.Scene
{
    class Title : IScene
    {
        private bool isEndFlag;
        private Sound sound;

        public Title()
        {
            isEndFlag = false;
            sound = GameDevice.Instance().GetSound();
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("block", Vector2.Zero);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            sound.PlayBGM("endingbgm");
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.GamePlay;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            if( Input.GetKeyTrigger(Keys.Space) )
            {
                isEndFlag = true;
            }
        }
    }
}
