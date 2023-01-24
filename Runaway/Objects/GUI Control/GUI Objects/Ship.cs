using Runaway.Objects.GUI_Control.GUI_Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Runaway.Objects.GUI_Control
{
    public class Ship : Base
    {
        private long _hp;

        public Rect ShipPosition = new Rect(371, 30, 40, 30);
        public long HP { get => _hp; set { HPStateChanger.HPChanged(this, value); _hp = value; } }
        public Rectangle HPLine { get; set; }
        public Label HPLabel { get; set; }


        public ShipBullet Bullet { get; set; }


        public Ship() : base()
        {
            _hp = ShipStats.HP;

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
            };
            Canvas.SetLeft(Look, ShipPosition.X);
            Canvas.SetBottom(Look, ShipPosition.Y);
        }
        public void Fire()
        {
            if (Bullet == null) Bullet = new ShipBullet();//Проверка используется на случай первого появления объекта в памяти
            else if (Bullet.IsStopped) Bullet.Fire();
        }
        public new void Start()
        {
            if (Bullet != null)//На случай стопа без экземпляра пули корабля
                if (Bullet.IsStopped) Bullet.Start();
        }
        public new void Stop()
        {
            if (Bullet != null) Bullet.Stop();
        }
    }
}
