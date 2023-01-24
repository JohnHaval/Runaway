using Runaway.Utilities;
using System;
using System.Windows;

namespace Runaway
{
    /// <summary>
    /// Логика взаимодействия для AboutProgramWindow.xaml
    /// </summary>
    public partial class AboutProgramWindow : Window
    {
        public AboutProgramWindow()
        {
            InitializeComponent();
            Music.PlayFollowMeSound();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ButtonSounds.PlayClickSound();
            Music.PlayMenuSound();
        }
    }
}
