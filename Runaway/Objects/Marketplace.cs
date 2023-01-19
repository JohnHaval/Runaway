using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class Marketplace
    {
        public static long HPCost { get => 3000 * ShipStats.LvlHP; }
        public static long WeaponDamageCost { get => 3000 * ShipStats.LvlWeaponDamage; }
        public static long BulletSpeedCost { get => 5000 * ShipStats.LvlBulletSpeed; }
        public static long FirePowerCost { get => 30000 * ShipStats.LvlFirePower; }
        public static long ShipSpeedCost { get => 6000 * ShipStats.LvlShipSpeed; }
        public static long EnergyBlockCost { get => 300; }
        public static long UFODebrisCost { get => 500; }
        public static long MeteoritDebrisCost { get => 1000; }
        public static long UFOSlimeCost { get => 2000; }
        public static long MonolithPartCost { get => 15000; }
        
    }
}
