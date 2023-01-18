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
            Timer.Tick+= Timer_Tick;

            Speed = ShipStats.BulletSpeed;

            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 15,
                Height = 15,
                Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.Relative))
            };
            SpawnNew();
        }
        protected void SpawnNew()
        {
            BulletPosition = new Rect(Control.GamerShip.ShipPosition.X + 17, Control.GamerShip.ShipPosition.Y - 15, 15, 15);
            Canvas.SetBottom(Look, BulletPosition.Y);
            Canvas.SetLeft(Look, BulletPosition.X);
            GameField.Children.Add(Look);
            base.Start();
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            BulletMove();
        }
        public void BulletMove()
        {
            Canvas.SetBottom(Look, BulletPosition.Y += ShipStats.FirePower);
            ObjectIntersects();
        }
        public void ObjectIntersects()
        {
            if (BulletPosition.IntersectsWith(Control.FirstEnemy.EnemyPosition) == true)
            {
                GameSounds.PlayHit();

                Control.FirstEnemy.HP -= ShipStats.WeaponDamage;
                if (Control.FirstEnemy.HP <= 0)
                {
                    Control.FirstEnemy.HPLabel.Content = 0;
                    Control.FirstEnemy.HPLine.Width = 0;
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


                    GameField.Children.Remove(Look);

                    if (Control.FirstEnemy.HP == 0 && Control.SecondEnemy.HP == 0)
                    {
                        WaveEnd();
                    }
                }
                else Control.FirstEnemy.HPLabel.Content = Control.FirstEnemy.HP;
            }



            if (BulletPosition.IntersectsWith(Control.SecondEnemy.EnemyPosition) == true)
            {
                GameSounds.PlayHit();

                Control.SecondEnemy.HP -= ShipStats.WeaponDamage;

                if (Control.SecondEnemy.HP <= 0)
                {
                    Control.SecondEnemy.HPLabel.Content = 0;
                    Control.SecondEnemy.HPLine.Width = 0;
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

                    GameField.Children.Remove(Look);

                    if (Control.FirstEnemy.HP == 0 && Control.SecondEnemy.HP == 0)
                    {
                        WaveEnd();
                    }

                }
                else Control.SecondEnemy.HPLabel.Content = Control.SecondEnemy.HP;
            }




            else if (BulletPosition.IntersectsWith(Borders.TopBorder) == true)
            {
                Stop();
                GameField.Children.Remove(Look);
            }
        } 
        public void WaveEnd()
        {
            Control.StopWave();
            Inventory.GetWinItems();
        }

        public new void Start()
        {
            SpawnNew();
        }
    }
}
