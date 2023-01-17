using Runaway.Objects.Enemy_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Runaway.Objects.GUI_Control
{
    public class Boss : Base
    {
        public Rect BossPosition { get; set; } = new Rect(283, 320, 215, 144);
        public Rectangle HPLine { get; set; }
        public Label HP { get; private set; }
        public bool IsRightWay { get; set; }
        public Boss() : base()
        {
            Speed = SpeedControl.BossSpeed;
            HP = new Label()
            {
                Content = Enemy_Control.HPControl.EnemyHP,
                Width = 784,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                BorderBrush = null,
                Foreground = Brushes.LightBlue,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };
            HPLine = new Rectangle()
            {
                Fill = Brushes.Red,
                Width = 784,
                Height = 28,
                Stroke = Brushes.Black,
                StrokeThickness = 3,
            };
            Canvas.SetTop(HPLine, 0);
            Canvas.SetLeft(HPLine, 0);
            Look = new Image()
            {
                Source = new BitmapImage(new Uri("Images\\boss.png", UriKind.Relative)),
                Height = 144,
                Width = 215,
                Stretch = Stretch.Fill,
            };
        }
    }
}
