using Runaway.Objects.Enemy_Control;
using Runaway.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Runaway.Objects.GUI_Control.GUI_Objects
{
    public class BossBullet : Base
    {
        public Rect BulletPosition;

        public BossBullet()
        {
            Timer.Tick += Timer_Tick;

            Speed = SpeedControl.BossSpeed / 10;

            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 25,
                Height = 25,
                Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.Relative)),
            };
            SpawnNew();
            GameField.Children.Add(Look);
        }

        protected void SpawnNew()
        {
            GameSounds.PlayFire();
            BulletPosition = new Rect(Control.WaveBoss.BossPosition.X + 105, Control.WaveBoss.BossPosition.Y - 22, 20, 20);
            Canvas.SetBottom(Look, BulletPosition.Y);
            Canvas.SetLeft(Look, BulletPosition.X + 4.5);
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);//Проверка состояния "стоп" для объекта
            BulletMove();
        }
        public void BulletMove()
        {
            Canvas.SetBottom(Look, BulletPosition.Y -= 4);
            ObjectIntersects();
        }
        public void ObjectIntersects()
        {
            if (BulletPosition.IntersectsWith(Control.GamerShip.ShipPosition) == true)
            {
                GameSounds.PlayHit();

                Control.GamerShip.HP -= DamageControl.BossDamage;

                if (Control.GamerShip.HP <= 0)
                {
                    var boom = new Image
                    {
                        Source = new BitmapImage(new Uri("/Images/bigbom.png", UriKind.Relative)),
                        Stretch = Stretch.Fill,
                        Width = 50,
                        Height = 50,
                    };
                    Canvas.SetBottom(boom, Control.GamerShip.ShipPosition.Y);
                    Canvas.SetLeft(boom, Control.GamerShip.ShipPosition.X);
                    GameField.Children.Add(boom);

                    GameSounds.PlayBoom();


                    Control.StopWave();

                    GameSounds.PlayFailedResultsSound();

                    MessageBox.Show("К сожалению, вы проиграли :c\nВ результате сражения вы ничего не получили", "Поражение ^.^", MessageBoxButton.OK, MessageBoxImage.Error);

                    MiniWindows.EndGameWindow win = new MiniWindows.EndGameWindow(true)
                    {
                        Owner = MainWindow.MainWin
                    };
                    win.ShowDialog();
                }
                else SpawnNew();
            }
            else if (BulletPosition.IntersectsWith(Borders.BottomBorder) == true)
            {
                SpawnNew();
            }
        }
    }
}

