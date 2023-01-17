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
using Runaway.Utilities;

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

            GameScreen.GameField.Children.Add(FirstEnemy.Look);
            GameScreen.GameField.Children.Add(FirstEnemy.HPLine);
            GameScreen.GameField.Children.Add(FirstEnemy.HP);            

            GameScreen.GameField.Children.Add(SecondEnemy.Look);
            GameScreen.GameField.Children.Add(SecondEnemy.HPLine);
            GameScreen.GameField.Children.Add(SecondEnemy.HP);


        }

        public void BossWaveField()
        {
            InitializeBossObjects();

            GameScreen.GameField.Children.Add(WaveBoss.Look);
            GameScreen.GameField.Children.Add(WaveBoss.HPLine);
            GameScreen.GameField.Children.Add(WaveBoss.HP);

        }







        public void InitializeRaidObjects()
        {
            Meteor = new Meteorit();
            GamerShip = new Ship();
            FirstEnemy = new Enemy(true);
            SecondEnemy = new Enemy(false);
            GameSounds.BeginWave.Position = TimeSpan.Zero;
        }

        public void InitializeBossObjects()
        {
            Meteor = new Meteorit();
            GamerShip = new Ship();
            WaveBoss = new Boss();
            GameSounds.BeginWave.Position = TimeSpan.Zero;
        }




        public void StartWave()
        {
            GameSounds.BeginWave.Play();
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
