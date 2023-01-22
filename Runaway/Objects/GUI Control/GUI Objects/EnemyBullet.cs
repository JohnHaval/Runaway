using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Xml.Linq;
using Runaway.Utilities;
using Runaway.Objects.Enemy_Control;

namespace Runaway.Objects.GUI_Control.GUI_Objects
{
    public class EnemyBullet : Base
    {
        public Rect EnemyPosition;
        public Rect BulletPosition;
        public bool IsFirstEnemy;
        public EnemyBullet(bool isFirstEnemy)
        {
            Timer.Tick += Timer_Tick;

            Speed = SpeedControl.EnemySpeed / 10;

            IsFirstEnemy = isFirstEnemy;

            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 15,
                Height = 15,
                Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.Relative)),
                RenderTransformOrigin = new Point(0.5, 0.5)
            };
            SpawnNew();
            GameField.Children.Add(Look);
        }
        protected void SpawnNew()
        {
            GameSounds.PlayFire();
            if (IsFirstEnemy)
            {
                BulletPosition = new Rect(Control.FirstEnemy.EnemyPosition.X + 17, Control.FirstEnemy.EnemyPosition.Y - 15, 13, 13);
                Canvas.SetBottom(Look, BulletPosition.Y);
                Canvas.SetLeft(Look, BulletPosition.X);
            }
            else
            {
                BulletPosition = new Rect(Control.SecondEnemy.EnemyPosition.X + 17, Control.SecondEnemy.EnemyPosition.Y - 15, 13, 13);
                Canvas.SetBottom(Look, BulletPosition.Y);
                Canvas.SetLeft(Look, BulletPosition.X);
            }
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

                Control.GamerShip.HP -= DamageControl.EnemyDamage;
                if ((Control.GamerShip.HP) <= 0)
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
