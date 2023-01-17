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

namespace Runaway.Objects.GUI_Control.GUI_Objects
{
    public class EnemyBullet : Base
    {
        private Rect _bulletPosition;
        public Rect BulletPosition { get => _bulletPosition; set => _bulletPosition = value; }
        public EnemyBullet(Rect objectRect)
        {
            BulletPosition = objectRect;
            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 15,
                Height = 15,
                Source = new BitmapImage(new Uri("images\\bullet.png", UriKind.Relative)),
            };
            SpawnNew();
        }
        protected void SpawnNew()
        {
            _bulletPosition = new Rect(BulletPosition.X + 17, BulletPosition.Y - 15, 15, 15);
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
            Canvas.SetBottom(Look, _bulletPosition.Y -= 4);
			ObjectIntersects();
        }
        public void ObjectIntersects()
        {
            if (BulletPosition.IntersectsWith(Control.GamerShip.ShipPosition) == true)
            {
                GameSounds.PlayHit();
                if ((Control.GamerShip.HP -= DamageControl.EnemyDamage) < 0)
                {
                    Control.GamerShip.HP = 0;
                    var boom = new Image
                    {
                        Source = new BitmapImage(new Uri("images\\bigbom.png", UriKind.Relative)),
                        Stretch = Stretch.Fill,
                        Width = 50,
                        Height = 50,
                    };
                    Canvas.SetBottom(boom, Control.GamerShip.ShipPosition.Y);
                    Canvas.SetLeft(boom, Control.GamerShip.ShipPosition.X);
                    GameField.Children.Add(boom);

                    GameSounds.PlayBoom();


                    GameField.Children.Remove(Look);
                    Control.StopWave();

                    MessageBox.Show("К сожалению, вы проиграли :c\nВ результате сражения вы ничего не получили", "YOU LOSE ^.^", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (BulletPosition.IntersectsWith(Borders.BottomBorder) == true)
            {
                SpawnNew();
            }            
        }
    }
}
