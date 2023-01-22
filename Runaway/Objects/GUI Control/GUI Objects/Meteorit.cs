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
        public Rect MeteoritPosition;
        public double RectYSpeed { get; private set; }

        private Random rnd = new Random();
        public Meteorit() : base()
        {
            Timer.Tick += Timer_Tick;

            Speed = SpeedControl.MeteoritSpeed;
            Look = new Image
            {
                Stretch = Stretch.Uniform,
                Width = 40,
                Height = 70,
                Source = new BitmapImage(new Uri("/Images/fireball.png", UriKind.Relative)),
            };
            SpawnNew();
        }
        public void SpawnNew()
        {
            int metx = rnd.Next(50, 734);
            RectYSpeed = rnd.Next(4, 15);
            MeteoritPosition = new Rect(metx, 235, 33, 50);            
            Canvas.SetBottom(Look, MeteoritPosition.Y - 5);
            Canvas.SetLeft(Look, MeteoritPosition.X + 1);
            Start();
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {            
            base.Timer_Tick(sender, e);//Проверка состояния "стоп" для объекта
            MeteoritMove();
        }

        private void MeteoritMove()
        {
            MeteoritPosition.Y -= RectYSpeed;
            Canvas.SetBottom(Look, MeteoritPosition.Y);
            ObjectInterspects();
        }
        private void ObjectInterspects()
        {
            if (MeteoritPosition.IntersectsWith(Control.GamerShip.ShipPosition) == true)
            {
                Control.GamerShip.HP -= DamageControl.MeteoritDamage;
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


                    GameField.Children.Remove(Look);
                    GameField.Children.Add(boom);

                    GameSounds.PlayBoom();


                    Control.StopWave();


                    GameSounds.PlayFailedResultsSound();

                    MessageBox.Show("К сожалению, вы проиграли :c\nВ результате сражения вы ничего не получили", "YOU LOSE ^.^", MessageBoxButton.OK, MessageBoxImage.Error);


                    MiniWindows.EndGameWindow win = new MiniWindows.EndGameWindow(false)
                    {
                        Owner = MainWindow.MainWin
                    };
                    win.ShowDialog();
                }
                else SpawnNew();
            }
            else if (MeteoritPosition.IntersectsWith(Borders.BottomBorder) == true)
            {
                SpawnNew();
            }
        }
    }
}
