namespace Runaway.Objects
{
    /// <summary>
    /// Основоположник цен для магазина.
    /// </summary>
    public static class Marketplace
    {
        public static long HPCost { get => 5000 * ShipStats.LvlHP; }
        public static long WeaponDamageCost { get => 5000 * ShipStats.LvlWeaponDamage; }
        public static long BulletSpeedCost { get => 10000 * ShipStats.LvlBulletSpeed * GetWaveUpPrice(); }
        public static long FirePowerCost { get => 15000 * ShipStats.LvlFirePower * GetWaveUpPrice(); }
        public static long ShipSpeedCost { get => 15000 * ShipStats.LvlShipSpeed * GetWaveUpPrice(); }
        public static long EnergyBlockCost { get => 100 * GetWaveUpPrice(); }
        public static long UFODebrisCost { get => 200 * GetWaveUpPrice(); }
        public static long MeteoritDebrisCost { get => 1000 * GetWaveUpPrice(); }
        public static long UFOSlimeCost { get => 2000 * GetWaveUpPrice(); }
        public static long MonolithPartCost { get => 5000 * GetWaveUpPrice(); }
        private static long GetWaveUpPrice()
        {
            long waveUpPrice = 1, tempPrice = GetRatioAfterBoss();
            if (tempPrice != 0) waveUpPrice += tempPrice;
            return waveUpPrice;
        }
        private static long GetRatioAfterBoss()
        {
            return (GamerStats.WaveState - 1) / 5;
        }

    }
}
