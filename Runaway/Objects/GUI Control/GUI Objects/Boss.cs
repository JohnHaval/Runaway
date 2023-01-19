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
    public class Boss : Base
    {
        private long _hp;
        public Rect BossPosition = new Rect(283, 320, 215, 144);
        public long HP { get => _hp; set { HPStateChanger.HPChanged(this, value); _hp = value; } }
        public Rectangle HPLine { get; set; }
        public Label HPLabel { get; private set; }
        public bool IsRightWay { get; set; }

        public BossBullet Bullet { get; set; }

        public Boss() : base()
        {

            Timer.Tick += Timer_Tick;



            _hp = HPControl.BossHP;



            Speed = SpeedControl.BossSpeed;


            HPLabel = new Label()
            {
                Content = HPControl.BossHP,
                Width = 784,
                Height = 28,
                Background = null,
                FontWeight = FontWeights.Bold,
                FontSize = 12,
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
                Source = new BitmapImage(new Uri("/Images/boss.png", UriKind.Relative)),
                Height = 144,
                Width = 215,
                Stretch = Stretch.Fill,
            };
            Canvas.SetLeft(Look, 283);
            Canvas.SetTop(Look, 0);
        }
        protected new void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            BossMove();
        }

        private void BossMove()
        {
            if (IsRightWay == true) Canvas.SetLeft(Look, BossPosition.X += 5);
            else if (IsRightWay == false) Canvas.SetLeft(Look, BossPosition.X -= 5);
            if (BossPosition.X <= 0) IsRightWay = true;
            else if (BossPosition.X >= 565) IsRightWay = false;
        }


        public new void Stop()
        {
            Bullet.Stop();
            base.Stop();
        }

        public new void Start()
        {
            if (Bullet == null) Bullet = new BossBullet();
            Bullet.Start();
            base.Start();
        }
    }
}
