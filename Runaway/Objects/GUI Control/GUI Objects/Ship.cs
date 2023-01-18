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
    public class Ship : Base
    {
        public Rect ShipPosition = new Rect(371, 30, 50, 50);
        public Rectangle HPLine { get; set; }
        public Label HP { get; set; }
        public Ship() : base()
        {
            Speed = ShipStats.BulletSpeed;
            HP = new Label()
            {
                Content = ShipStats.HP,
                Width = 784,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                BorderBrush = null,
                Foreground = Brushes.LightGreen,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };
            Canvas.SetLeft(HP, 0);
            Canvas.SetBottom(HP, 0);
            HPLine = new Rectangle()
            {
                Fill = Brushes.Red,
                Width = 784,
                Height = 28,
                Stroke = Brushes.Black,
                StrokeThickness = 3,
            };
            Canvas.SetLeft(HPLine, 0);
            Canvas.SetBottom(HPLine, 0);

            Look = new Image()
            {
                Source = new BitmapImage(new Uri("Images\\spaceship.png", UriKind.Relative)),
                Height = 50,
                Width = 50,
                Stretch = Stretch.Fill,
                RenderTransformOrigin = new Point(0.434, 0.408),
            };
            Canvas.SetLeft(Look, 371);
            Canvas.SetBottom(Look, 30);
        }
    }
}
