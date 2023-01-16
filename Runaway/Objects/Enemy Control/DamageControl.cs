using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class DamageControl
    {
        public static long BossDamage { get => GamerStats.WaveState * 50; }
        public static long EnemyDamage { get => GamerStats.WaveState * 10; }
        public static long MeteoritDamage { get => GamerStats.WaveState * 30; }
    }
}
