using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGame.Codes
{
    public enum EventCode : byte
    {
        SyncStatus,
        SyncTransform,
        JoinServer,
        NewPlayer,
        Damage,
        SyncDropWeapon,
        DeleteDropWeapon,
        PlayerDead,
        KillMessage,
        GameProcess,
        DeletePlayer
    }
}
