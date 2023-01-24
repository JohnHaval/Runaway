using Runaway.Objects.GUI_Control;
using Runaway.Utilities;
using System.Windows;
using System.Windows.Input;

namespace Runaway.MiniWindows
{
    /// <summary>
    /// Логика взаимодействия для MenuPauseWindow.xaml
    /// </summary>
    public partial class MenuPauseWindow : Window
    {
        public MenuPauseWindow(WaveControl control)
        {
            InitializeComponent();
            CurrentControl = control;
        }
        WaveControl CurrentControl;
        bool IsNext;
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            IsNext = true;
            ButtonSounds.PlayClickSound();
            CurrentControl.StartWave();
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
