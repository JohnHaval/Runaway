using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using Runaway.Objects.Enemy_Control;
using Runaway.Objects.GUI_Control.GUI_Objects;

namespace Runaway.Objects.GUI_Control
{
    public class Enemy : Base
    {
        public Rect EnemyPosition;
        public long HP { get; set; }
        public Label HPLabel { get; set; }
        public Rectangle HPLine { get; set; }


        public bool IsFirstEnemy { get; set; }


        public bool IsRightWay { get; set; }
        public EnemyBullet Bullet { get; set; }
        public Enemy(bool isFirstEnemy) : base()
        {

            Timer.Tick += Timer_Tick;


            Speed = 100;

            HP = HPControl.EnemyHP;
            Look = new Image()
            {
                Source = new BitmapImage(new Uri("/Images/smallenemy.png", UriKind.Relative)),
                Height = 50,
                Width = 50,
                Stretch = Stretch.Fill
            };

            HPLine = new Rectangle()
            {
                Fill = Brushes.Red,
                Width = 392,
                Height = 28,
                Stroke = Brushes.Black,
                StrokeThickness = 3,
            };
            

            HPLabel = new Label
            {
                Content = HPControl.EnemyHP,
                Width = 392,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 12,
                BorderBrush = null,
                Foreground = Brushes.LightBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };


            if (IsFirstEnemy = isFirstEnemy)
            {
                EnemyPosition = new Rect(130, 260, 50, 50);

                Canvas.SetLeft(HPLabel, 0);
                Canvas.SetTop(HPLabel, 0);
                Canvas.SetTop(HPLine, 0);
                Canvas.SetLeft(HPLine, 0);
                Canvas.SetLeft(Look, 130);
                Canvas.SetTop(Look, 110);                
            }
            else
            {
                Canvas.SetTop(HPLabel, 0);
                Canvas.SetLeft(HPLabel, 392);
                EnemyPosition = new Rect(600, 260, 50, 50);
                Canvas.SetTop(HPLine, 0);
                Canvas.SetLeft(HPLine, 392);
                Canvas.SetLeft(Look, 600);
                Canvas.SetTop(Look, 110);
            }
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            EnemyMove();
        }

        private void EnemyMove()
        {
            if (IsRightWay == true) Canvas.SetLeft(Look, EnemyPosition.X += 15);
            else if (IsRightWay == false) Canvas.SetLeft(Look, EnemyPosition.X -= 15);
            if (IsFirstEnemy)
            {
                if (EnemyPosition.X <= 0) IsRightWay = true;
                else if (EnemyPosition.X >= 310) IsRightWay = false;
            }
            else
            {
                if (EnemyPosition.X <= 370) IsRightWay = true;
                else if (EnemyPosition.X >= 740) IsRightWay = false;
            }
        }


        public new void Stop()
        {
            Bullet.Stop();
            base.Stop();
        }

        public new void Start()
        {
            if (Bullet == null) Bullet = new EnemyBullet(IsFirstEnemy);
            Bullet.Start();
            base.Start();
        }
    }
}
