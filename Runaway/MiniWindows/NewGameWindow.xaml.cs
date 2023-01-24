using Runaway.Objects;
using Runaway.Utilities;
using System;
using System.Windows;
using System.Windows.Input;

namespace Runaway.MiniWindows
{
    /// <summary>
    /// Логика взаимодействия для NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
            NickName.Focus();
        }

        private void AcceptName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonSounds.PlayClickSound();
                GamerStats.NickName = NickName.Text;
                DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Необходимо ввести корректное имя!", "Некорректное имя для беглеца", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSounds.PlaySelectSound();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ButtonSounds.PlayClickSound();
        }
    }
}
