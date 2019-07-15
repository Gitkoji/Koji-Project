using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.Scene
{
    interface IGameObjectMediator
    {
        object GetPlayer();
        bool IsPlayerDead();
    }
}
