using Runaway.Objects;
using Runaway.Objects.GUI_Control;
using Runaway.Utilities;
using System.Windows.Controls;
using System.Windows.Input;

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

            if (GamerStats.WaveState % 5 != 0)
            {
                Music.PlayRaidSound();
                Control.RaidWaveField();
            }
            else
            {
                Music.PlayBossSound();
                Control.BossWaveField();
            }
        }

        public static Canvas GameField;

        public static bool IsEndWave = false;
        WaveControl Control = new WaveControl();
        public void MainWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsEndWave)
            {
                if (e.Key == Key.Left)
                {
                    Control.GamerShip.ShipPosition.X -= ShipStats.ShipSpeed;
                    if (Control.GamerShip.ShipPosition.X <= 0) Control.GamerShip.ShipPosition.X = 0;
                    Canvas.SetLeft(Control.GamerShip.Look, Control.GamerShip.ShipPosition.X);
                }
                if (e.Key == Key.Right)
                {
                    Control.GamerShip.ShipPosition.X += ShipStats.ShipSpeed;
                    if (Control.GamerShip.ShipPosition.X >= 744) Control.GamerShip.ShipPosition.X = 744;
                    Canvas.SetLeft(Control.GamerShip.Look, Control.GamerShip.ShipPosition.X);
                }
                if (e.Key == Key.Up)
                {
                    Fire();
                }
                if (e.Key == Key.Escape)
                {
                    Control.StopWave();
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
