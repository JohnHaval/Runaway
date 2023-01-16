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

namespace Runaway.Objects.GUI_Control
{
    public class Enemy : Base
    {
        public Rect EnemyPosition { get; set; }
        public Rectangle HPLine { get; set; }
        public Label HP { get; set; }
        public bool IsRightWay { get; set; }
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
                Content = DamageControl.EnemyDamage,
                Width = 392,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                BorderBrush = null,
                Foreground = Brushes.LightBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };



            if (isFirstEnemy)
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
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
        }
    }
}
