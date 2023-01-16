using Runaway.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Runaway.Objects.GUI_Control
{
    public class WaveControl
    {
        Meteorit Meteor;
        Enemy FirstEnemy;
        Enemy SecondEnemy;
        Ship GamerShip;
        Boss WaveBoss;

        public void RaidWaveField()
        {
            AddShip();
        }

        public void BossWaveField()
        {
            InitializeBossObjects();
            AddShip();
            GameScreen.GameField.Children.Add(WaveBoss.Look);
            GameScreen.GameField.Children.Add(WaveBoss.HPLine);
            GameScreen.GameField.Children.Add(WaveBoss.HPBackground);
            GameScreen.GameField.Children.Add(WaveBoss.HP);
        }

        public void InitializeRaidObjects()
        {
            Meteor = new Meteorit();
            GamerShip = new Ship();
            FirstEnemy = new Enemy(new Rect(130, 260, 50, 50));
            SecondEnemy = new Enemy(new Rect(600, 260, 50, 50));
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
    }
}
