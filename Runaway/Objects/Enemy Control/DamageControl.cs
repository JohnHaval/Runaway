using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class DamageControl
    {
        public static long BossDamage { get => GamerStats.WaveState * 4; }
        public static long EnemyDamage { get => GamerStats.WaveState * 2; }
        public static long MeteoritDamage { get => GamerStats.WaveState * 3; }
    }
}
