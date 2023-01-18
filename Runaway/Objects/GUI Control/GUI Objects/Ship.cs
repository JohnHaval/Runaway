using Runaway.Objects.Enemy_Control;
using Runaway.Objects.GUI_Control.GUI_Objects;
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
        public long HP { get; set; }
        public Rectangle HPLine { get; set; }
        public Label HPLabel { get; set; }


        public ShipBullet Bullet { get; set; } 


        public Ship() : base()
        {
            HP = ShipStats.HP;

            HPLabel = new Label()
            {
                Content = ShipStats.HP.ToString(),
                Width = 784,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 12,
                BorderBrush = null,
                Foreground = Brushes.LightGreen,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };
            Canvas.SetLeft(HPLabel, 0);
            Canvas.SetBottom(HPLabel, 0);

            HPLine = new Rectangle()
            {                
                Fill = Brushes.Green,
                Width = 784,
                Height = 28,
                Stroke = Brushes.Black,
                StrokeThickness = 3,
            };
            Canvas.SetLeft(HPLine, 0);
            Canvas.SetBottom(HPLine, 0);

            Look = new Image()
            {
                Source = new BitmapImage(new Uri("/Images/spaceship.png", UriKind.Relative)),
                Height = 50,
                Width = 50,
                Stretch = Stretch.Fill,
                RenderTransformOrigin = new Point(0.434, 0.408),
            };
            Canvas.SetLeft(Look, 371);
            Canvas.SetBottom(Look, 30);
        }
        public void Fire()
        {
            if (Bullet == null) Bullet = new ShipBullet();
            else if (Bullet.IsStopped) Bullet.Start();
        }
        public new void Stop()
        {
            if (Bullet != null) Bullet.Stop();
            base.Stop();
        }
    }
}
