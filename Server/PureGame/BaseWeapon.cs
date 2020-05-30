using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureGame.Codes;

namespace PureGame
{
    public class BaseWeapon
    {
        private WeaponType weaponClass = WeaponType.None;
        private int curBulletQuantity = -1;             //当前弹夹子弹数量
        private int maxBulletQuantity = -1;                //弹夹满仓
        private int backBulletQuantity = -1;        //备用子弹
        private int maxBackbackBulletQuantity;
        private bool isHaveSpecial = false;         //有无特殊功能
        private string weaponName;              //武器名称
        private int price = -1;             //价格

        public WeaponType WeaponClass
        {
            get { return weaponClass; }
            set { weaponClass = value; }
        }
        public int CurBulletQuantity
        {
            get { return curBulletQuantity; }
            set { curBulletQuantity = value; }
        }
        public int MaxBulletQuantity
        {
            get { return maxBulletQuantity; }
            set { maxBulletQuantity = value; }
        }
        public int BackBulletQuantity
        {
            get { return backBulletQuantity; }
            set { backBulletQuantity = value; }
        }
        public int MaxBackbackBulletQuantity
        {
            get { return maxBackbackBulletQuantity; }
            set { maxBackbackBulletQuantity = value; }
        }
        public bool IsHaveSpecial
        {
            get { return isHaveSpecial; }
            set { isHaveSpecial = value; }
        }
        public string WeaponName
        {
            get { return weaponName; }
            set { weaponName = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
