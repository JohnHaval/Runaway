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
    public class BossBullet : Base
    {
        public Rect BulletPosition;

        public BossBullet(Rect objectRect)
        {
            BulletPosition = objectRect;

            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 25,
                Height = 25,
                Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.Relative)),
            };
            SpawnNew();
        }

        protected void SpawnNew()
        {
            BulletPosition = new Rect(BulletPosition.X + 105, BulletPosition.Y - 22, 15, 15);
            Canvas.SetBottom(Look, BulletPosition.Y);
            Canvas.SetLeft(Look, BulletPosition.X);
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            BulletMove();
        }
        public void BulletMove()
        {
            Canvas.SetBottom(Look, BulletPosition.Y -= 2);
            ObjectIntersects();
        }
        public void ObjectIntersects()
        {
            if (BulletPosition.IntersectsWith(Control.GamerShip.ShipPosition) == true)
            {
                GameSounds.PlayHit();
                if ((Control.GamerShip.HP -= DamageControl.BossDamage) < 0)
                {

                    Control.GamerShip.HPLabel.Content = 0;
                    Control.GamerShip.HPLine.Width = 0;
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

                    MessageBox.Show("К сожалению, вы проиграли :c\nВ результате сражения вы ничего не получили", "YOU LOSE ^.^", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                Control.GamerShip.HPLabel.Content = Control.GamerShip.HP;
            }
            else if (BulletPosition.IntersectsWith(Borders.TopBorder) == true)
            {
                SpawnNew();
            }
        }
    }
}

