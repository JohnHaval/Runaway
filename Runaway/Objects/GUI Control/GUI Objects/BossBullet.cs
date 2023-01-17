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
        private Rect _bulletPosition;
        public Rect BulletPosition { get => _bulletPosition; set => _bulletPosition = value; }

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
        }
        //protected override void SpawnNew()
        //{
        //    _bulletPosition = new Rect(SSBoss.X + 105, SSBoss.Y - 22, 15, 15);
        //    Canvas.SetBottom(bbullet, BBullet.Y);
        //    Canvas.SetLeft(bbullet, BBullet.X);
        //}
        //protected new void Timer_Tick(object sender, EventArgs e)
        //{
        //    base.Timer_Tick(sender, e);
        //    BulletMove();
        //}
        //public void BulletMove()
        //{
        //    Canvas.SetBottom(bbullet, BBullet.Y -= BulletPosition);
        //    ObjectIntersects();
        //}
        //public void ObjectIntersects()
        //{
        //    if (BulletPosition.IntersectsWith(Control.GamerShip.ShipPosition) == true)
        //    {
        //        GameSounds.PlayHit();
        //        double currentHP = Convert.ToDouble(Control.GamerShip.HP.Content);
        //        if ((currentHP -= DamageControl.EnemyDamage) < 0)
        //        {
        //            Control.GamerShip.HP.Content = 0;
        //            Control.GamerShip.HPLine.Width = 0;
        //            var boom = new Image
        //            {
        //                Source = new BitmapImage(new Uri("images\\bigbom.png", UriKind.Relative)),
        //                Stretch = Stretch.Fill,
        //                Width = 50,
        //                Height = 50,
        //            };
        //            Canvas.SetBottom(boom, Control.GamerShip.ShipPosition.Y);
        //            Canvas.SetLeft(boom, Control.GamerShip.ShipPosition.X);
        //            GameField.Children.Add(boom);

        //            GameSounds.PlayBoom();


        //            GameField.Children.Remove(Look);
        //            Control.StopWave();

        //            MessageBox.Show("К сожалению, вы проиграли :c\nВ результате сражения вы ничего не получили", "YOU LOSE ^.^", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }

        //        else Control.GamerShip.HP.Content = currentHP;
        //    }
        //    else if (BulletPosition.IntersectsWith(Borders.TopBorder) == true)
        //    {
        //        SpawnNew();
        //    }
    }
}

