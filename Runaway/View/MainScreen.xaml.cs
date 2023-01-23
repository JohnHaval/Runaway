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

            SetSoundImage(ButtonSounds.IsEnabled);
            SetMusicImage(Music.IsEnabled);                        
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

        private void Plot_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("   Однажды, на Великой и процветающей планете Руна произошла трагедия.\n\n" +
                "В один прекрасный день на планету неожиданно появились инопланетные захватчики. Не известны их истинные мотивы, но всем жителям " +
                "оставалось делать только одно - покидать планету как можно скорее. " +
                "В процессе попыток бегства погибло немало жителей. Это являлось началом конца той утопии, которую удалось реализовать " +
                "за столь долгие годы развития.\n" +
                "   Большинство кораблей не было оснащено столь мощным оружием, чтобы противостоять натиску, " +
                "но были способны на функции познания совершенствования, что являлось их плюсом - возможность " +
                "быстрого развертывания новых технологий защиты, а также изучение оснащения врагов.\n" +
                "   К сожалению, пока вы покидали планету, как и все жители, которые имели на то возможность, " +
                "планета была уничтожена. Чем дальше вы пробирались, тем меньше беглецов оставалось в живых. Вы начинали ощущать " +
                "тяжелые чувства...\n" +
                "   После успешного побега, попытки связаться с другими выжившими оставались безуспешными. На тот момент вас не покидало чувство " +
                "ненависти и желание уничтожить каждого на своем пути. Вы решаетесь вернуться туда, где когда-то было так приятно, " +
                "красиво, уютно, чтобы продемонстрировать гнев жителя планеты Руна...","Предыстория", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MusicEnabler_Click(object sender, RoutedEventArgs e)
        {
            if (Music.IsEnabled)
            {
                Music.IsEnabled = false;
                SetMusicImage(false);
            }
            else
            {
                Music.IsEnabled = true;
                SetMusicImage(true);
            }
        }

        private void SoundEnabler_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonSounds.IsEnabled == true)
            {
                ButtonSounds.IsEnabled =
                GameSounds.IsEnabled = false;
                SetSoundImage(false);
            }
            else
            {
                ButtonSounds.IsEnabled =
                GameSounds.IsEnabled = true;
                SetSoundImage(true);
            }
        }

        private void SetSoundImage(bool isEnable)
        {
            if (isEnable)
            {
                SoundEnabler.Content = new Image()
                {
                    Margin = new Thickness(5),
                    Source = new BitmapImage(new Uri("/Images/volume.png", UriKind.Relative))
                };
            }
            else
            {
                SoundEnabler.Content = new Image()
                {
                    Margin = new Thickness(5),
                    Source = new BitmapImage(new Uri("/Images/volume-mute.png", UriKind.Relative))
                };
            }
        }
        private void SetMusicImage(bool isEnable)
        {
            if (isEnable)
            {
                MusicEnabler.Content = new Image()
                {
                    Margin = new Thickness(5),
                    Source = new BitmapImage(new Uri("/Images/musical-note.png", UriKind.Relative))
                };
            }
            else
            {
                MusicEnabler.Content = new Image()
                {
                    Margin = new Thickness(5),
                    Source = new BitmapImage(new Uri("/Images/music.png", UriKind.Relative))
                };
            }
        }

        private void ResetGameProgress_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите сбросить игровой прогресс до начального уровлня? Сохранение останется, но его придется загружать вручную.",
                "Сброс прогресса", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                GamerStats.ResetGamerStats();
                ShipStats.ResetShipStats();
                Inventory.ResetInventory();
                DataControl.ResetLastPath();
            }
        }
    }
}
