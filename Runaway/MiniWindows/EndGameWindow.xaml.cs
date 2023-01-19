using Runaway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Runaway.MiniWindows
{
    /// <summary>
    /// Логика взаимодействия для EndGameWindow.xaml
    /// </summary>
    public partial class EndGameWindow : Window
    {
        public EndGameWindow(bool isFail)
        {
            InitializeComponent();
            if (isFail)
            {
                WinName.Header = "Повтор волны";
                NextWave.Content = "Повторить";
            }
        }
        bool IsNext;
        private void NextWave_Click(object sender, RoutedEventArgs e)
        {
            IsNext = true;
            ButtonSounds.PlayClickSound();
            MainWindow.Main.Content = new View.GameScreen();
            Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSounds.PlaySelectSound();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsNext)
            {
                ButtonSounds.PlayClickSound();
                MainWindow.Main.Content = new View.MainScreen();
            }
        }
    }
}
