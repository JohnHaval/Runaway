using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Runaway.Objects
{
    public static class Inventory
    {
        public static int Wallet { get; set; }
        public static int EnergyBlockCount { get; set; }
        public static int UFODebrisCount { get; set; }
        public static int MeteoritDebrisCount { get; set; }
        public static int UFOSlimeCount { get; set; }
        public static int MonolithPartCount { get; set; }
		
		public static void GetWinItems()
		{		
			Random rnd = new Random();
			int wallet = rnd.Next(GamerStats.WaveState * 50, GamerStats.WaveState * 250);            
            Wallet += wallet;
			int energy = rnd.Next(0, 3);            
            EnergyBlockCount += energy;
			int debris = rnd.Next(0, 3);
            UFODebrisCount += debris;
			int meteorit = rnd.Next(0, 1);            
            MeteoritDebrisCount += meteorit;
			int slime = rnd.Next(0, 2);
            UFOSlimeCount += slime;
			
			int monolith;
            int chance = rnd.Next(1, 20);
            if (chance == 5)
            {                
                monolith = 1;
				MonolithPartCount += monolith;
            }
			MessageBox.Show($"Получено денег: {wallet}" + 
			"Ru\nЛут:\n-Получено энергоблоков: {energy}x\n" +
			"-Получено обломков НЛО: {debris}x\n" +
			"-Получено осколков метеорита: {meteorit}x\n" +
			"-Получено кусочков инопланетной слизи: {slime}x\n" +
			"-Получено частей монолита: {monolith}x",
			"Победа ^.^",
			MessageBoxButton.OK,
			MessageBoxImage.Information);
		}
    }
}
