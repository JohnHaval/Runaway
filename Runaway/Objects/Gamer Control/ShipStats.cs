using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class ShipStats
    {        
        static ShipStats()
        {
            ResetShipStats();
        }
        public static long HP { get; set; }
        public static long LvlHP { get => (HP - 20) / 10 + 1; }        
        public static long WeaponDamage { get; set; }
        public static long LvlWeaponDamage { get => (WeaponDamage - 5) / 5 + 1; }
        public static int BulletSpeed { get; set; }
        public static int LvlBulletSpeed { get => Math.Abs(BulletSpeed - 20) / 1 + 1; }
        public static int MaxBulletSpeed { get => 5; }
        public static int FirePower { get; set; }
        public static int LvlFirePower { get => (FirePower - 1) / 1 + 1; }
        public static int MaxFirePower { get => 5; }

        public static int ShipSpeed { get; set; }
        public static int LvlShipSpeed { get => Math.Abs(ShipSpeed - 1) / 1 + 1; }
        public static int MaxShipSpeed { get => 10; }
        public static void ResetShipStats()
        {
            HP = 20;
            WeaponDamage = 5;
            BulletSpeed = 20;
            FirePower = 1;
            ShipSpeed = 1;
        }

    }
}
