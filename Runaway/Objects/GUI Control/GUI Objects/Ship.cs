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
        public Rect ShipPosition = new Rect(380, 30, 40, 40);
		public long HP { get; set; }
        public ShipBullet Bullet { get; set; }
        public Ship() : base()
        {
            Speed = ShipStats.BulletSpeed;
			HP = ShipStats.HP;
            //ShipBullet = new EnemyBullet(ShipPosition);
        }
		
		protected new void Timer_Tick(object sender, EventArgs e)
		{
			
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
    }
}
