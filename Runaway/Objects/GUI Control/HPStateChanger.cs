using Runaway.Objects.Enemy_Control;
using Runaway.Utilities;

namespace Runaway.Objects.GUI_Control
{
    /// <summary>
    /// Меняет состояние GUI элементов в зависимости от состояния соответствующего им объекта.
    /// Используется для изменения статуса HP на экране пользователя.
    /// </summary>
    public static class HPStateChanger
    {
        public static void HPChanged(Boss boss, long value)
        {
            GameSounds.PlayHit();
            if (value > 0)
            {
                boss.HPLabel.Content = value;
                boss.HPLine.Width = boss.HPLine.Width * value / HPControl.BossHP;
            }
            else
            {
                boss.HPLabel.Content = 0;
                boss.HPLine.Width = 0;
            }
        }
        public static void HPChanged(Ship ship, long value)
        {
            GameSounds.PlayHit();
            if (value > 0)
            {
                ship.HPLabel.Content = value;
                ship.HPLine.Width = ship.HPLine.Width * value / ShipStats.HP;
            }
            else
            {
                ship.HPLabel.Content = 0;
                ship.HPLine.Width = 0;
            }
        }
        public static void HPChanged(Enemy enemy, long value)
        {
            GameSounds.PlayHit();
            if (value > 0)
            {
                enemy.HPLabel.Content = value;
                enemy.HPLine.Width = enemy.HPLine.Width * value / HPControl.EnemyHP;
            }
            else
            {
                enemy.HPLabel.Content = 0;
                enemy.HPLine.Width = 0;
            }
        }
    }
}
