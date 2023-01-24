namespace Runaway.Objects
{
    public static class GamerStats
    {
        static GamerStats()
        {
            ResetGamerStats();
        }
        public static string NickName { get; set; }
        public static int WaveState { get; set; }
        public static int DestroyedBosses { get => (WaveState - 1) / 5; }
        public static void ResetGamerStats()
        {
            NickName = "*NoName*";
            WaveState = 1;
        }
    }
}
