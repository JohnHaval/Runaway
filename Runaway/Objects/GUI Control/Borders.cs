using System.Windows;

namespace Runaway.Objects.GUI_Control
{
    /// <summary>
    /// Используется для удаления пуль/метеоритов при достижении границ, указанных в данном классе.
    /// </summary>
    public static class Borders
    {
        public static Rect TopBorder { get; set; } = new Rect(0, 385, 794, 30);
        public static Rect BottomBorder { get; set; } = new Rect(0, 0, 794, 30);
    }
}
