using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runaway.Objects
{
    public static class GamerStats
    {
        static GamerStats()
        {
            NickName = "*NoName*";
            WaveState = 1;
            DestroyedBosses = 0;
        }
        public static string NickName { get; set; }
        public static int WaveState { get; set; }
        public static int DestroyedBosses { get; set; }
    }
}
