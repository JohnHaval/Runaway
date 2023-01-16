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
    public class Boss
    {
        public Rect BossPosition { get; set; } = new Rect(283, 320, 215, 144);
        public Rect HPBackgroundLine { get; set; } = new Rect(0, 385, 794, 30);
        public Rectangle HPLine { get; set; }
        public bool IsStoped { get; set; }
        public bool IsShooting { get; set; }
        public bool IsRightWay { get; set; }
        public Label HP { get; private set; }
        public Rectangle HPBackground
        {
            get
            {
                var background = new Rectangle()
                {
                    Fill = Brushes.Black,
                    Width = 784,
                    Height = 28
                };
                Canvas.SetLeft(background, 0);
                Canvas.SetTop(background, 0);
                return background;
            }
        }
        public Image Look { get; private set; }
        public Boss()
        {
            HP = new Label()
            {
                Content = Enemy_Control.HPControl.EnemyHP.ToString(),
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
                Source = new BitmapImage(new Uri("images\\boss.png", UriKind.Relative)),
                Height = 144,
                Width = 215,
                Stretch = Stretch.Fill,
            };
        }

    }
}
