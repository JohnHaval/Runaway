using Runaway.Objects;
using Runaway.Objects.GUI_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Runaway.View
{
    /// <summary>
    /// Логика взаимодействия для GameScreen.xaml
    /// </summary>
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();

            GameField = MainGameField;
            if (GamerStats.WaveState % 5 != 0) Control.RaidWaveField();
            else Control.BossWaveField();            
        }

        public static Canvas GameField;

        bool IsPause = false;
        WaveControl Control = new WaveControl();
        public void MainWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                Control.GamerShip.ShipPosition.X -= 10;
                if (Control.GamerShip.ShipPosition.X <= 0) Control.GamerShip.ShipPosition.X = 744;
                else Canvas.SetLeft(GamerShip, Control.GamerShip.ShipPosition.X);
            }
            if (e.Key == Key.Right)
            {
                Control.GamerShip.ShipPosition.X += 10;
                if (Control.GamerShip.ShipPosition.X >= 744) Control.GamerShip.ShipPosition.X = 0;
                else Canvas.SetLeft(GamerShip, Control.GamerShip.ShipPosition.X);
            }
            if (e.Key == Key.Up)
            {
                CreateGUIEnemies();
            }
        }


        public void CreateGUIEnemies()
        {
            var senemy1 = new Image
            {
                Source = new BitmapImage(new Uri("Images\\smallenemy.png", UriKind.Relative)),
                Height = 50,
                Width = 50,
                Stretch = Stretch.Fill,
            };
            Canvas.SetLeft(senemy1, 130);
            Canvas.SetTop(senemy1, 110);
            MainGameField.Children.Add(senemy1);
        }
        public void CreateGUIBoss()
        {

        }

    }        
}
