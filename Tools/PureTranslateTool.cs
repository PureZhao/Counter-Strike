using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureGame.Codes;

namespace PureGame.Tools
{
    public class PureTranslateTool
    {
        public static int WeaponTypeToInt(WeaponType weaponType) {
            switch (weaponType) {
                case WeaponType.Rifle: return 0;
                case WeaponType.Pistol: return 1;
                case WeaponType.Knife: return 2;
                case WeaponType.Grenade: return 3;
                case WeaponType.Bomb: return 4;
            }
            return -1;
        }

    }
}
