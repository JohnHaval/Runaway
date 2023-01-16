using Runaway.Objects.Enemy_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Runaway.Objects.GUI_Control
{
    public class Meteorit : Base
    {
        public Rect MeteoritPosition { get; set; } = new Rect(0, 335, 50, 50);

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
