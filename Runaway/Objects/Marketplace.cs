using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class Marketplace
    {
        public static long HPCost { get => 5000 * ShipStats.LvlHP; }
        public static long WeaponDamageCost { get => 5000 * ShipStats.LvlWeaponDamage; }
        public static long BulletSpeedCost { get => 15000 * ShipStats.LvlBulletSpeed * (GamerStats.WaveState /5); }
        public static long FirePowerCost { get => 30000 * ShipStats.LvlFirePower * (GamerStats.WaveState / 5); }
        public static long ShipSpeedCost { get => 20000 * ShipStats.LvlShipSpeed * (GamerStats.WaveState / 5); }
        public static long EnergyBlockCost { get => 100 * GamerStats.WaveState; }
        public static long UFODebrisCost { get => 200 * GamerStats.WaveState; }
        public static long MeteoritDebrisCost { get => 1000 * GamerStats.WaveState; }
        public static long UFOSlimeCost { get => 2000 * GamerStats.WaveState; }
        public static long MonolithPartCost { get => 5000 * GamerStats.WaveState; }
        
    }
}
