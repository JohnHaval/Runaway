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
using Runaway.Objects.GUI_Control.GUI_Objects;
using Runaway.Objects.Enemy_Control;

namespace Runaway.Objects.GUI_Control
{
    public class Enemy : Base
    {
        private Rect _enemyPosition;
        public Rect EnemyPosition { get => _enemyPosition; set => _enemyPosition = value; }
        public Rectangle HPLine { get; set; }
        public Label HP { get; set; }
        public bool IsRightWay { get; set; }
        public bool IsFirstEnemy { get;set; }
        public EnemyBullet Bullet { get; set; }
        public Enemy(bool isFirstEnemy) : base()
        {
            Look = new Image()
            {
                Source = new BitmapImage(new Uri("Images\\smallenemy.png", UriKind.Relative)),
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


            HP = new Label
            {
                Content = HPControl.EnemyHP,
                Width = 392,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                BorderBrush = null,
                Foreground = Brushes.LightBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Top,
            };



            if (IsFirstEnemy = isFirstEnemy)
            {
                EnemyPosition = new Rect(130, 260, 50, 50);
                Canvas.SetTop(HPLine, 0);
                Canvas.SetLeft(HPLine, 0);
                Canvas.SetLeft(Look, 130);
                Canvas.SetTop(Look, 110);
            }
            else
            {
                Canvas.SetLeft(HP, 392);
                EnemyPosition = new Rect(600, 260, 50, 50);
                Canvas.SetTop(HPLine, 0);
                Canvas.SetLeft(HPLine, 392);
                Canvas.SetLeft(Look, 600);
                Canvas.SetTop(Look, 110);
            }
            Bullet = new EnemyBullet(EnemyPosition);
        }
		
		
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            EnemyMove();
        }
		
        private void EnemyMove()
        {
            if (IsRightWay == true) Canvas.SetLeft(Look, _enemyPosition.X += 1);
            else if (IsRightWay == false) Canvas.SetLeft(Look, _enemyPosition.X -= 1);
            if (IsFirstEnemy)
            {
                if (_enemyPosition.X == 0) IsRightWay = true;
                else if (_enemyPosition.X == 310) IsRightWay = false;
            }
            else
            {
                if (_enemyPosition.X == 370) IsRightWay = true;
                else if (_enemyPosition.X == 740) IsRightWay = false;
            }
            if (Bullet.IsStopped) Bullet.Start();
        }
		
		
        public new void Stop()
		{
			Bullet.Stop();
			base.Stop();
		}
		
		public new void Start()
		{
			Bullet.Start();
			base.Start();
		}

        protected void SpawnNew()
        {
        }
    }
}
