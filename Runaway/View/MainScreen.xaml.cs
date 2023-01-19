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
            GamerNickName.Content = $"{GamerStats.NickName}";
            WaveCount.Content = $"Волна:{GamerStats.WaveState}";
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
            ButtonSounds.PlayClickSound();
            if (GamerStats.NickName == "*NoName*")
            {
                MessageBox.Show("Беглец, нам необходимо знать твое имя! Нельзя вот так бродить по космосу, не имея его!", "Имя беглеца", MessageBoxButton.OK, MessageBoxImage.Warning);
                NewGameWindow win = new NewGameWindow()
                {
                    Owner = MainWindow.MainWin
                };
                if (win.ShowDialog() == true)
                {
                    MainWindow.Main.Content = new GameScreen();
                }
            }
            else MainWindow.Main.Content = new GameScreen();
        }



        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "Загрузка игры",
                Filter = "Сохранение игры(*.runsave*) |*.runsave",
                DefaultExt = ".runsave",
            };
            if (open.ShowDialog() == true)
            {
                DataControl.LoadData(open.FileName);

                GamerNickName.Content = $"{GamerStats.NickName}";
                WaveCount.Content = $"Волна:{GamerStats.WaveState}";
            }
        }



        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
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
            ButtonSounds.PlayClickSound();
            MessageBox.Show($"Имя: {GamerStats.NickName}\n" +
                $"Укрепление корабля({ShipStats.LvlHP} ур.): {ShipStats.HP}\n" +
                $"Оружие({ShipStats.LvlWeaponDamage} ур.): {ShipStats.WeaponDamage}\n" +
                $"Скорость пули({ShipStats.LvlBulletSpeed} ур.): {ShipStats.BulletSpeed}\n" +
                $"Мощность выстрела({ShipStats.LvlFirePower} ур.): {ShipStats.FirePower})\n" +
                $"Волна: {GamerStats.WaveState}\n" +
                $"Боссов побеждено: {GamerStats.DestroyedBosses}", 
                "Статистика",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
            AboutProgramWindow win = new AboutProgramWindow()
            {
                Owner = MainWindow.MainWin
            };
            win.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
            MainWindow.MainWin.Close();
        }

    }
}
