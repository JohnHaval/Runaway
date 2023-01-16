using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Runaway.Objects.GUI_Control
{
    public class Enemy
    {
        public Rect EnemyPosition { get; set; }
        public bool IsStoped { get; set; }
        public bool IsShooting { get; set; }
        public bool IsRightWay { get; set; }
        public Enemy(Rect position)
        {
            EnemyPosition = position;
        }

    }
}
