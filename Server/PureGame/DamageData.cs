using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGame
{
   public class DamageData
    {
        private string damageMakerName;
        private string damagedPlayerName;
        private int damage;
        private BaseWeapon weapon;



        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public string DamageMakerName
        {
            get { return damageMakerName; }
            set { damageMakerName = value; }
        }
       public string DamagedPlayerName
       {
           get { return damagedPlayerName; }
           set { damagedPlayerName = value; }
       }
       public BaseWeapon Weapon
       {
           get { return weapon; }
           set { weapon = value; }
       }
    }
}
