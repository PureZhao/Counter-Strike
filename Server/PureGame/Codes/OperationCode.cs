using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGame.Codes
{
    public enum OperationCode : byte
    {
        SyncStatus,
        SyncTransform,
        CreateGame,
        JoinGame,
        TeamChoose,
        Damage,
        SyncDropWeapon,
        DeleteDropWeapon,
        PlayerDead,
        Restart
    }
}
