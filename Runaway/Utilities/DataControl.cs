using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Runaway.Objects;
using System.Windows.Documents;

namespace Runaway.Utilities
{
    public static class DataControl
    {
        public static string LastPath { get; set; }
        public static bool IsSaved { get; set; } = true;
        static DataControl()
        {
            LoadLastPath();
        }
        public static void LoadData()
        {
            try
            {
                LoadData(LastPath);
            }
            catch 
            {
                ResetLastPath();
            }
        }
        public static void LoadData(string filePath)
        {
            LastPath = filePath;
            StreamReader dataReader = new StreamReader(filePath);
            GamerStats.NickName = Convert.ToString(dataReader.ReadLine());
            GamerStats.WaveState = Convert.ToInt32(dataReader.ReadLine());
            Inventory.Wallet = Convert.ToInt32(dataReader.ReadLine());
            Inventory.EnergyBlockCount = Convert.ToInt32(dataReader.ReadLine());
            Inventory.UFODebrisCount = Convert.ToInt32(dataReader.ReadLine());
            Inventory.MeteoritDebrisCount = Convert.ToInt32(dataReader.ReadLine());
            Inventory.UFOSlimeCount = Convert.ToInt32(dataReader.ReadLine());
            Inventory.MonolithPartCount = Convert.ToInt32(dataReader.ReadLine());
            ShipStats.WeaponDamage = Convert.ToInt32(dataReader.ReadLine());
            ShipStats.HP = Convert.ToInt32(dataReader.ReadLine());
            ShipStats.BulletSpeed = Convert.ToInt32(dataReader.ReadLine());
            ShipStats.FirePower = Convert.ToInt32(dataReader.ReadLine());
            ShipStats.ShipSpeed = Convert.ToInt32(dataReader.ReadLine());
            dataReader.Close();
            SaveLastPath();
            IsSaved = true;
        }

        public static void SaveData()
        {
            try
            {
                SaveData(LastPath);
            }
            catch 
            {
                IsSaved = false;
            }
        }

        public static void SaveData(string filePath)
        {
            LastPath = filePath;
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(GamerStats.NickName);
            writer.WriteLine(GamerStats.WaveState);
            writer.WriteLine(Inventory.Wallet);
            writer.WriteLine(Inventory.EnergyBlockCount);
            writer.WriteLine(Inventory.UFODebrisCount);
            writer.WriteLine(Inventory.MeteoritDebrisCount);
            writer.WriteLine(Inventory.UFOSlimeCount);
            writer.WriteLine(Inventory.MonolithPartCount);
            writer.WriteLine(ShipStats.WeaponDamage);
            writer.WriteLine(ShipStats.HP);
            writer.WriteLine(ShipStats.BulletSpeed);
            writer.WriteLine(ShipStats.FirePower);
            writer.WriteLine(ShipStats.ShipSpeed);
            writer.Close();
            SaveLastPath();
            IsSaved = true;
        }
        public static void SaveLastPath()
        {
            StreamWriter writer = new StreamWriter("Path.lp");
            writer.WriteLine(LastPath);
            writer.Close();
        }
        public static void LoadLastPath()
        {
            try
            {
                StreamReader reader = new StreamReader("Path.lp");
                LastPath = Convert.ToString(reader.ReadLine());
                reader.Close();
            }
            catch { }
        }
        public static void ResetLastPath()
        {
            LastPath = string.Empty;
            SaveLastPath();
            IsSaved = true;
        }
    }
}
