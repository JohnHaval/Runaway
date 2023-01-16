using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Runaway.Objects.GUI_Control
{
    public class Meteorit
    {
        public Rect MeteoritPosition { get; set; } = new Rect(0, 335, 50, 50);
        public bool IsStoped { get; set; }
    }
}
