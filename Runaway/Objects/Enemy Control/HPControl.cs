using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects.Enemy_Control
{
    public static class HPControl
    {
        public static long BossHP { get => GamerStats.WaveState * 100; }
        public static long EnemyHP { get => GamerStats.WaveState * 10; }
    }
}
