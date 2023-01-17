using Runaway.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Runaway.Objects.GUI_Control
{
    public class WaveControl
    {
        public Meteorit Meteor;
        public Enemy FirstEnemy;
        public Enemy SecondEnemy;
        public Ship GamerShip;
        public Boss WaveBoss;
        public WaveControl()
        {
            ThisWave = this;
        }

        public static WaveControl ThisWave { get; private set; }

        public void RaidWaveField()
        {
            InitializeRaidObjects();
            AddShip();
            GameScreen.GameField.Children.Add(Borders.HPBackground);



        }

        public void BossWaveField()
        {
            InitializeBossObjects();
            AddShip();
            GameScreen.GameField.Children.Add(Borders.HPBackground);


        }







        public void InitializeRaidObjects()
        {
            Meteor = new Meteorit();
            GamerShip = new Ship();
            FirstEnemy = new Enemy(true);
            SecondEnemy = new Enemy(false);
        }

        public void InitializeBossObjects()
        {
            Meteor = new Meteorit();
            GamerShip = new Ship();
            WaveBoss = new Boss();
        }





        public void AddShip()
        {
            GameScreen.GameField.Children.Add(GamerShip.HP);
            GameScreen.GameField.Children.Add(GamerShip.HPLine);
            GameScreen.GameField.Children.Add(GamerShip.HPBackground);
            GameScreen.GameField.Children.Add(GamerShip.Look);
        }


        public void StartWave()
        {
            Meteor.Start();
            GamerShip.Start();
            if (GamerStats.WaveState % 5 == 0) WaveBoss.Start();
            else
            {
                FirstEnemy.Start();
                SecondEnemy.Start();
            }
        }
        public void StopWave()
        {
            Meteor.Stop();
            GamerShip.Stop();
            if (GamerStats.WaveState % 5 == 0) WaveBoss.Stop();
            else
            {
                FirstEnemy.Stop();
                SecondEnemy.Stop();
            }
        }

    }
}
