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
using Runaway.Utilities;
using Runaway.Objects;

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
