using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Runaway.Objects.GUI_Control
{
    /// <summary>
    /// Используется для удаления пуль/метеоритов при достижении границ, указанных в данном классе.
    /// </summary>
    public static class Borders
    {
        public static Rect TopBorder { get; set; } = new Rect(0, 385, 794, 30);
        public static Rect BottomBorder { get; set; } = new Rect(0, 0, 794, 30);
        public static Rectangle HPBackground
        {
            get
            {
                var background = new Rectangle()
                {
                    Fill = Brushes.Black,
                    Width = 784,
                    Height = 28
                };
                Canvas.SetLeft(background, 0);
                Canvas.SetTop(background, 0);
                return background;
            }
        }

    }
}
