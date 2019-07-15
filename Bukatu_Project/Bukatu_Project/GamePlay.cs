using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Action.Device;
using Microsoft.Xna.Framework.Input;
using Action.Actor;


namespace Action.Scene
{
    /// <summary>
    /// ゲームプレイクラス
    /// </summary>
    class GamePlay : IScene
    {
        private bool isEndFlag;//終了フラグ
        private Map map;
        private Player player;
        private GameObjectManager gameObjectManager;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GamePlay()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer">描画オブジェクト</param>
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("black", Vector2.Zero);
            renderer.DrawTexture("block", Vector2.Zero);

            map.Draw(renderer);
            gameObjectManager.Draw(renderer);
            player.Draw(renderer);


            renderer.End();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            //シーン終了フラグを初期化
            isEndFlag = false;

            gameObjectManager.Initialize();

            map = new Map();
            map.Load("stage01.csv","./csv/");//ここで読み込むマップデータを選択

            player = new Player(new Vector2(32 * 2, 32 * 12),gameObjectManager);

            gameObjectManager.Add(map);
            gameObjectManager.Add(player);
        }

        /// <summary>
        /// シーン終了か？
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return isEndFlag;
        }

        /// <summary>
        /// 次のシーンは
        /// </summary>
        /// <returns>次のシーン名</returns>
        public Scene Next()
        {
            Scene nextScene = Scene.Ending;        
            return nextScene;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Shutdown()
        {
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public void Update(GameTime gameTime)
        {
            if( Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
            }

            gameObjectManager.Update(gameTime);
            map.Update(gameTime);
            player.Update(gameTime);

            map.Hit(player);
        }
    }
}
