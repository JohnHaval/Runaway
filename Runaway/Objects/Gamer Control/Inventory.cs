using System;
using System.Windows;

namespace Runaway.Objects
{
    public static class Inventory
    {
        public static long Wallet { get; set; }
        public static int EnergyBlockCount { get; set; }
        public static int UFODebrisCount { get; set; }
        public static int MeteoritDebrisCount { get; set; }
        public static int UFOSlimeCount { get; set; }
        public static int MonolithPartCount { get; set; }

        public static void ResetInventory()
        {
            Wallet = 0;
            EnergyBlockCount = 0;
            UFODebrisCount = 0;
            MeteoritDebrisCount = 0;
            UFOSlimeCount = 0;
            MonolithPartCount = 0;
        }
        static Random rnd;
        public static void GetWinItems()
        {
            rnd = new Random();
            int wallet = rnd.Next(GamerStats.WaveState * 50, GamerStats.WaveState * 250);
            Wallet += wallet;


            int energy = rnd.Next(0, 3);
            EnergyBlockCount += energy;


            int debris = rnd.Next(0, 2);
            UFODebrisCount += debris;


            int meteorit = 0;
            int meteoritChance = rnd.Next(1, 5);
            if (meteoritChance == 3)//шансы выпадения элементов в конце волны при победе
            {
                meteorit = rnd.Next(1, 3);
                UFOSlimeCount += meteorit;
            }

            int slime = 0;
            int slimeChance = rnd.Next(1, 10);
            if (slimeChance == 5)
            {
                slime = rnd.Next(1, 3);
                UFOSlimeCount += slime;
            }

            int monolith = 0;
            int monolithChance = rnd.Next(1, 20);
            if (monolithChance == 5)
            {
                MonolithPartCount++;
                monolith++;
            }
            if (GamerStats.WaveState % 5 == 0)
            {
                MonolithPartCount++;
                monolith++;
            }
            MessageBox.Show($"Получено денег: {wallet} " +
            $"Ru\nЛут:\n-Получено энергоблоков: {energy}x\n" +
            $"-Получено обломков НЛО: {debris}x\n" +
            $"-Получено осколков метеорита: {meteorit}x\n" +
            $"-Получено кусочков инопланетной слизи: {slime}x\n" +
            $"-Получено частей монолита: {monolith}x",
            "Победа ^.^",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
        }
    }
}
