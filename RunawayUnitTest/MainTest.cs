using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Runaway;
using Runaway.Objects;

namespace RunawayUnitTest
{
    [TestClass]
    public class MainTest
    {
        public MainTest()
        {
            GamerStats.WaveState = 15;
        }
        [TestMethod]
        public void _1TestEnemyDamage()
        {
            ShipStats.HP = 150;
            if (ShipStats.HP - DamageControl.EnemyDamage != 120) throw new Exception();
        }
        [TestMethod]
        public void _2TestBossDamage()
        {
            ShipStats.HP = 150;
            if (ShipStats.HP - DamageControl.BossDamage != 90) throw new Exception();
        }
        [TestMethod]
        public void _3TestBossDamage()
        {
            ShipStats.HP = 150;
            if (ShipStats.HP - DamageControl.MeteoritDamage != 105) throw new Exception();
        }
        [TestMethod]
        public void _4TestDestoroyedBossesCount()
        {
            if (GamerStats.DestroyedBosses != 2) throw new Exception();
        }
    }
}
