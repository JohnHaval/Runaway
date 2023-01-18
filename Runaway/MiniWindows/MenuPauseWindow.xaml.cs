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
    /// Логика взаимодействия для MenuPauseWindow.xaml
    /// </summary>
    public partial class MenuPauseWindow : Window
    {
        public MenuPauseWindow()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
            MainWindow.Main.Content = new View.GameScreen();
            Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSounds.PlaySelectSound();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
            MainWindow.Main.Content = new View.MainScreen();
            Close();
        }
    }
}
