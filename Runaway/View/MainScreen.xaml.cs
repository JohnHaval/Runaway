using Runaway.Objects;
using Runaway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Runaway.View
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {            
            InitializeComponent();
            Music.PlayMenuSound();
        }
        
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = new SolidColorBrush(Colors.Black);
            ButtonSounds.PlaySelectSound();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = new SolidColorBrush(Colors.Yellow);
        }



















        private void Store_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Имя: {GamerStats.NickName}\n" +
                $"Укрепление корабля({ShipStats.LvlHP} ур.): {ShipStats.HP}\n" +
                $"Оружие({ShipStats.LvlWeaponDamage} ур.): {ShipStats.WeaponDamage}\n" +
                $"Скорость пули({ShipStats.LvlBulletSpeed} ур.): {ShipStats.BulletSpeed}\n" +
                $"Мощность выстрела({ShipStats.LvlFirePower} ур.): {ShipStats.FirePower})\n" +
                $"Волна: {GamerStats.WaveState}\n" +
                $"Боссов побеждено: {GamerStats.DestroyedBosses / 5}", 
                "Статистика",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MiniWindows.AboutProgramWindow win = new MiniWindows.AboutProgramWindow();
            win.ShowDialog(); 
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWin.Close();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWin.Content = new GameScreen();
        }
    }
}
