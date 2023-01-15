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
        public static void LoadData(string filePath)
        {
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
            senemyspeedbullet2 = Convert.ToInt32(dataReader.ReadLine());
            bossspeedbullet = Convert.ToInt32(dataReader.ReadLine());
            timebossspeedbullet = Convert.ToInt32(dataReader.ReadLine());
            timese2speedbullet = Convert.ToInt32(dataReader.ReadLine());
            intervalboss = Convert.ToInt32(dataReader.ReadLine());
            intervalse2 = Convert.ToInt32(dataReader.ReadLine());
            schpboss = Convert.ToInt32(dataReader.ReadLine());
            schpsenemy2 = Convert.ToInt32(dataReader.ReadLine());
            cbdamage = Convert.ToInt32(dataReader.ReadLine());
            cse2damage = Convert.ToInt32(dataReader.ReadLine());
            dataReader.Close();
        }
        public static void SaveData()
        {
            StreamWriter gssave = new StreamWriter(save.FileName);
            gssave.WriteLine(GamerStats.NickName);
            gssave.WriteLine(GamerStats.WaveState);
            gssave.WriteLine(Inventory.Wallet);
            gssave.WriteLine(Inventory.EnergyBlockCount);
            gssave.WriteLine(Inventory.UFODebrisCount);
            gssave.WriteLine(Inventory.MeteoritDebrisCount);
            gssave.WriteLine(Inventory.UFOSlimeCount);
            gssave.WriteLine(Inventory.MonolithPartCount);
            gssave.WriteLine(ShipStats.WeaponDamage);
            gssave.WriteLine(ShipStats.HP);
            gssave.WriteLine(ShipStats.BulletSpeed);
            gssave.WriteLine(ShipStats.FirePower);
            gssave.WriteLine(senemyspeedbullet2);
            gssave.WriteLine(bossspeedbullet);
            gssave.WriteLine(timebossspeedbullet);
            gssave.WriteLine(timese2speedbullet);
            gssave.WriteLine(intervalboss);
            gssave.WriteLine(intervalse2);
            gssave.WriteLine(schpboss);
            gssave.WriteLine(schpsenemy2);
            gssave.WriteLine(cbdamage);
            gssave.WriteLine(cse2damage);
            gssave.Close();
        }
    }
}
