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
            GameField = null;
            GameField = MainGameField;
            if (GamerStats.WaveState % 5 != 0) Control.RaidWaveField();
            else Control.BossWaveField();            
        }

        public static Canvas GameField;

        public static bool IsEndWave = false;
        WaveControl Control = new WaveControl();
        public bool IsPause = false;
        public void MainWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsEndWave)
            {
                if (e.Key == Key.Left)
                {
                    Control.GamerShip.ShipPosition.X -= 10;
                    if (Control.GamerShip.ShipPosition.X <= 0) Control.GamerShip.ShipPosition.X = 744;
                    else Canvas.SetLeft(Control.GamerShip.Look, Control.GamerShip.ShipPosition.X);
                }
                if (e.Key == Key.Right)
                {
                    Control.GamerShip.ShipPosition.X += 10;
                    if (Control.GamerShip.ShipPosition.X >= 744) Control.GamerShip.ShipPosition.X = 0;
                    else Canvas.SetLeft(Control.GamerShip.Look, Control.GamerShip.ShipPosition.X);
                }
                if (e.Key == Key.Up)
                {
                    Fire();
                }
                if (e.Key == Key.Escape)
                {
                    Control.StopWave();
                    IsPause = true;
                    MiniWindows.MenuPauseWindow win = new MiniWindows.MenuPauseWindow(Control)
                    {
                        Owner = MainWindow.MainWin
                    };
                    win.ShowDialog();
                }
            }
        }


        private void Fire()
        {
            Control.GamerShip.Fire();
        }

    }        
}
