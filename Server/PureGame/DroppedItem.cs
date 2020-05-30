using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGame
{
    public class DroppedItem
    {
        private string uniqueName;

        private BaseWeapon bw = new BaseWeapon();
        private TransformData trans = new TransformData();

        public string UniqueName
        {
            get { return uniqueName; }
            set { uniqueName = value; }
        }
        public BaseWeapon Bw
        {
            get { return bw; }
            set { bw = value; }
        }
        public TransformData Trans
        {
            get { return trans; }
            set { trans = value; }
        }

        
    }
}
