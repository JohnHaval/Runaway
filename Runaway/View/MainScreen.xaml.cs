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

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            byte green, red, blue;
            Random rnd = new Random();
            green = Convert.ToByte(rnd.Next(0, 255));
            red = Convert.ToByte(rnd.Next(0, 255));
            blue = Convert.ToByte(rnd.Next(0, 255));
            ((Rectangle)sender).Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
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
    }
}
