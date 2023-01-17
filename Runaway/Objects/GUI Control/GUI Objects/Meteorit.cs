using Runaway.Objects.Enemy_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using Runaway.View;
using System.Xml.Linq;
using Runaway.Utilities;

namespace Runaway.Objects.GUI_Control
{
    public class Meteorit : Base
    {
        private Rect _meteoritPosition = new Rect(0, 335, 50, 50);
        public Rect MeteoritPosition { get => _meteoritPosition; set => _meteoritPosition = value; } 
        public double RectYSpeed { get; private set; }

        public Meteorit() : base()
        {
            Speed = SpeedControl.MeteoritSpeed;
            Look = new Image
            {
                Stretch = Stretch.Fill,
                Width = 70,
                Height = 70,
                Source = new BitmapImage(new Uri("Images\\fireball.png", UriKind.Relative)),
            };
            SpawnNew();
        }
        public void SpawnNew()
        {
            Random rnd = new Random();
            int metx = rnd.Next(50, 734);
            RectYSpeed = rnd.Next(1, 3);
            MeteoritPosition = new Rect(metx, 285, 10, 10);            
            Canvas.SetBottom(Look, MeteoritPosition.Y);
            Canvas.SetLeft(Look, MeteoritPosition.X - 27);
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {            
            base.Timer_Tick(sender, e);
            MeteoritMove();
        }

        private void MeteoritMove()
        {
            _meteoritPosition.Y -= RectYSpeed;
            Canvas.SetBottom(Look, MeteoritPosition.Y);
            //ObjectInterspects();
        }
        //private void ObjectInterspects()
        //{
        //    if (MeteoritPosition.IntersectsWith(Control.GamerShip.ShipPosition) == true)
        //    {
        //        IsStopped = false;
        //        double currentHP = Convert.ToDouble(Control.GamerShip.HP.Content);
        //        if ((currentHP -= DamageControl.EnemyDamage) < 0)
        //        {
        //            Control.GamerShip.HP.Content = 0;
        //            Control.GamerShip.HPLine.Width = 0;
        //            var boom = new Image
        //            {
        //                Source = new BitmapImage(new Uri("Images\\bigbom.png", UriKind.Relative)),
        //                Stretch = Stretch.Fill,
        //                Width = 50,
        //                Height = 50,
        //            };
        //            Canvas.SetBottom(boom, Control.GamerShip.ShipPosition.Y);
        //            Canvas.SetLeft(boom, Control.GamerShip.ShipPosition.X);
        //            GameField.Children.Add(boom);

        //            GameSounds.PlayBoom();


        //            GameField.Children.Remove(this.Look);
        //            Control.StopWave();

        //            MessageBox.Show("К сожалению, вы проиграли :c\nВ результате сражения вы ничего не получили", "YOU LOSE ^.^", MessageBoxButton.OK, MessageBoxImage.Error);            
        //        }     
        //        else Control.GamerShip.HP.Content = currentHP;
        //    }
        //    else if (MeteoritPosition.IntersectsWith(Borders.BottomBorder) == true)
        //    {
        //        SpawnNew();
        //    }
        //}
    }
}
