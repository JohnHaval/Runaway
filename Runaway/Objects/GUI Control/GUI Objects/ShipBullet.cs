using Runaway.Objects.Enemy_Control;
using Runaway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Runaway.Objects.GUI_Control.GUI_Objects
{
    public class ShipBullet : Base
    {
        public Rect BulletPosition;
        public ShipBullet()
        {
            Timer.Tick += Timer_Tick;

            Speed = ShipStats.BulletSpeed;

            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 15,
                Height = 15,
                Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.Relative))
            };
            Fire();
        }
        protected void SpawnNew()
        {
            BulletPosition = new Rect(Control.GamerShip.ShipPosition.X + 17, Control.GamerShip.ShipPosition.Y + 50, 15, 15);
            Canvas.SetBottom(Look, BulletPosition.Y);
            Canvas.SetLeft(Look, BulletPosition.X);
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);//Проверка состояния "стоп" для объекта
            BulletMove();
        }
        public void BulletMove()
        {
            Canvas.SetBottom(Look, BulletPosition.Y += ShipStats.FirePower);
            ObjectIntersects();
        }
        public void ObjectIntersects()
        {
            if (Control.FirstEnemy != null)
            {
                if (BulletPosition.IntersectsWith(Control.FirstEnemy.EnemyPosition) == true && Control.FirstEnemy.HP > 0)
                {
                    GameSounds.PlayHit();

                    Control.FirstEnemy.HP -= ShipStats.WeaponDamage;
                    if (Control.FirstEnemy.HP <= 0)
                    {
                        var boom = new Image
                        {
                            Source = new BitmapImage(new Uri("/Images/bigbom.png", UriKind.Relative)),
                            Stretch = Stretch.Fill,
                            Width = 50,
                            Height = 50,
                        };
                        Canvas.SetBottom(boom, Control.FirstEnemy.EnemyPosition.Y);
                        Canvas.SetLeft(boom, Control.FirstEnemy.EnemyPosition.X);
                        GameField.Children.Add(boom);

                        GameSounds.PlayBoom();

                        Control.FirstEnemy.Stop();

                        GameField.Children.Remove(Control.FirstEnemy.Bullet.Look);

                        GameField.Children.Remove(Look);

                        if (Control.FirstEnemy.HP <= 0 && Control.SecondEnemy.HP <= 0)
                        {
                            WaveEnd();
                        }
                    }
                    ResetBullet();
                }


                if (BulletPosition.IntersectsWith(Control.SecondEnemy.EnemyPosition) == true && Control.SecondEnemy.HP > 0)
                {
                    GameSounds.PlayHit();

                    Control.SecondEnemy.HP -= ShipStats.WeaponDamage;

                    if (Control.SecondEnemy.HP <= 0)
                    {
                        Control.SecondEnemy.HP = 0;
                        var boom = new Image
                        {
                            Source = new BitmapImage(new Uri("/Images/bigbom.png", UriKind.Relative)),
                            Stretch = Stretch.Fill,
                            Width = 50,
                            Height = 50,
                        };
                        Canvas.SetBottom(boom, Control.SecondEnemy.EnemyPosition.Y);
                        Canvas.SetLeft(boom, Control.SecondEnemy.EnemyPosition.X);
                        GameField.Children.Add(boom);

                        GameSounds.PlayBoom();

                        Control.SecondEnemy.Stop();

                        GameField.Children.Remove(Control.SecondEnemy.Bullet.Look);

                        GameField.Children.Remove(Look);

                        if (Control.FirstEnemy.HP <= 0 && Control.SecondEnemy.HP <= 0)
                        {
                            WaveEnd();
                        }

                    }
                    ResetBullet();
                }
                else if (BulletPosition.IntersectsWith(Borders.TopBorder) == true)
                {
                    ResetBullet();
                }
            }
          


            if (Control.WaveBoss != null)
            {
                if (BulletPosition.IntersectsWith(Control.WaveBoss.BossPosition) == true && Control.WaveBoss.HP > 0)
                {
                    GameSounds.PlayHit();

                    Control.WaveBoss.HP -= ShipStats.WeaponDamage;
                    if (Control.WaveBoss.HP <= 0)
                    {
                        var boom = new Image
                        {
                            Source = new BitmapImage(new Uri("/Images/bigbom.png", UriKind.Relative)),
                            Stretch = Stretch.Fill,
                            Width = 150,
                            Height = 150,
                        };
                        Canvas.SetBottom(boom, Control.WaveBoss.BossPosition.Y - 22);
                        Canvas.SetLeft(boom, Control.WaveBoss.BossPosition.X + 105);
                        GameField.Children.Add(boom);

                        GameSounds.PlayBoom();

                        Control.WaveBoss.Stop();

                        GameField.Children.Remove(Control.WaveBoss.Bullet.Look);

                        WaveEnd();
                    }
                    ResetBullet();
                }
                else if (BulletPosition.IntersectsWith(Borders.TopBorder) == true)
                {
                    ResetBullet();
                }
            }

        } 
        public void WaveEnd()
        {
            Control.StopWave();

            GameSounds.PlayWaveResultsSound();

            Inventory.GetWinItems();

            GamerStats.WaveState++;


            MiniWindows.EndGameWindow win = new MiniWindows.EndGameWindow(false)
            {
                Owner = MainWindow.MainWin
            };
            win.ShowDialog();
        }
        public void Fire()
        {
            GameSounds.PlayFire();
            SpawnNew();
            Start();
        }
        public new void Start()
        {
            if (!GameField.Children.Contains(Look))
            {
                GameField.Children.Add(Look);
            }
            base.Start();
        }

        public void ResetBullet()
        {
            Stop();
            GameField.Children.Remove(Look);
            SpawnNew();
        }
    }
}
