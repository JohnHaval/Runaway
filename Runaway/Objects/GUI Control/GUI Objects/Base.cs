using Runaway.Objects.Enemy_Control;
using Runaway.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Runaway.Objects.GUI_Control
{
    public abstract class Base
    {
        public WaveControl Control = WaveControl.ThisWave;
        public static Canvas GameField = GameScreen.GameField;
        public DispatcherTimer Timer { get; set; }
        public double Speed { get; set; }
        public bool IsStopped { get; protected set; }
        public Image Look { get; protected set; }

        public Base()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
        }
        protected void Timer_Tick(object sender, EventArgs e)
        {
            if (IsStopped == true) Timer.IsEnabled = false;            
        }

        public void Start()
        {
            Timer.Interval = TimeSpan.FromMilliseconds(Speed);
            IsStopped = false;
        }
        public void Stop()
        {
            IsStopped = true;
        }
    }
}
