using Runaway.Objects.Enemy_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Runaway.Objects.GUI_Control
{
    public abstract class Base
    {
        public DispatcherTimer Timer { get; set; }
        public double Speed { get; set; }
        public bool IsStopped { get; private set; }
        public Image Look { get; protected set; }

        public Base()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(Speed);
        }
        protected abstract void Timer_Tick(object sender, EventArgs e);
        public void Stop()
        {
            Timer.IsEnabled = IsStopped = true;
        }
        public void Start()
        {
            Timer.IsEnabled = IsStopped = false;
        }

    }
}
