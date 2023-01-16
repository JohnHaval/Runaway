﻿using System;
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
            HP = 20;
            WeaponDamage = 5;
            BulletSpeed = 10;
            FirePower = 1;
        }
        public static long HP { get; set; }
        public static long LvlHP { get => HP - 20 / 10 + 1; }        
        public static long WeaponDamage { get; set; }
        public static long LvlWeaponDamage { get => WeaponDamage - 5 / 5 + 1; }
        public static int BulletSpeed { get; set; }
        public static int LvlBulletSpeed { get => Math.Abs(BulletSpeed - 10) / 1 + 1; }
        public static int MaxBulletSpeed { get => 1; }
        public static int FirePower { get; set; }
        public static int LvlFirePower { get => FirePower - 1 / 1 + 1; }
        public static int MaxFirePower { get => 5; }

    }
}