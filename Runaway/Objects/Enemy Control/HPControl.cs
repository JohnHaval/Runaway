namespace Runaway.Objects.Enemy_Control
{
    public static class HPControl
    {
        public static long BossHP { get => GamerStats.WaveState * 4; }
        public static long EnemyHP { get => GamerStats.WaveState * 2; }
    }
}
