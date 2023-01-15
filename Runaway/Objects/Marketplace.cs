using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class Marketplace
    {
        static Marketplace()
        {
            HPCost = 3000;
            WeaponDamageCost = 3000;
            BulletSpeedCost = 5000;
            FirePowerCost = 30000;

            EnergyBlockCost = 500;
            UFODebrisCost = 300;
            MeteoritDebrisCost = 2000;
            UFOSlimeCost = 1000;
            MonolithPartCost = 15000;
        }
        public static int HPCost { get; set; }
        public static int WeaponDamageCost { get; set; }
        public static int BulletSpeedCost { get; set; }
        public static int FirePowerCost { get; set; }
        public static int EnergyBlockCost { get; set; }
        public static int UFODebrisCost { get; set; }
        public static int MeteoritDebrisCost { get; set; }
        public static int UFOSlimeCost { get; set; }
        public static int MonolithPartCost { get; set; }
    }
}
