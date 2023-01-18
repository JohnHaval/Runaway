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
using Runaway.MiniWindows;
using Microsoft.Win32;

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







        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Main.Content = new View.GameScreen();
        }



        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "Загрузка игры",
                Filter = "Сохранение игры(*.runsave*) |*.runsave",
                DefaultExt = ".runsave",
            };
            if (open.ShowDialog() == true) DataControl.LoadData(open.FileName);
        }



        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Title = "Сохранение игры",
                Filter = "Сохранение игры(*.runsave*) |*.runsave",
                DefaultExt = ".runsave",
            };
            if (save.ShowDialog() == true) DataControl.SaveData(save.FileName);
        }








        private void Store_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Main.Content = new View.StoreScreen();
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
            AboutProgramWindow win = new AboutProgramWindow();
            win.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWin.Close();
        }

    }
}
