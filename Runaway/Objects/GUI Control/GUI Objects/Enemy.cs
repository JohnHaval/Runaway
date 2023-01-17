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
        public Rect EnemyPosition;
        public bool IsRightWay { get; set; }
        public bool IsFirstEnemy { get;set; }
        public EnemyBullet Bullet { get; set; }
        public Enemy(bool isFirstEnemy) : base()
        {
            if (IsFirstEnemy = isFirstEnemy)
            {
                EnemyPosition = new Rect(130, 260, 50, 50);
            }
            else
            {
                EnemyPosition = new Rect(600, 260, 50, 50);
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
            if (IsRightWay == true) Canvas.SetLeft(Look, EnemyPosition.X += 1);
            else if (IsRightWay == false) Canvas.SetLeft(Look, EnemyPosition.X -= 1);
            if (IsFirstEnemy)
            {
                if (EnemyPosition.X == 0) IsRightWay = true;
                else if (EnemyPosition.X == 310) IsRightWay = false;
            }
            else
            {
                if (EnemyPosition.X == 370) IsRightWay = true;
                else if (EnemyPosition.X == 740) IsRightWay = false;
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
