namespace Runaway.Objects.Enemy_Control
{
    public static class SpeedControl
    {
        public static double BossSpeed { get => GetSpeed(); }
        public static double EnemySpeed { get => GetSpeed(); }
        public static double MeteoritSpeed { get => GetSpeed(); }
        public static double GetSpeed()
        {
            double speed = 500 - GamerStats.WaveState;
            if (speed < 100) return 100;
            else return speed;
        }
    }
}
