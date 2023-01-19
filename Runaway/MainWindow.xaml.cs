using Runaway.Utilities;
using Runaway.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Runaway
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataControl.LoadData();

            MainWin = this;

            Main = MainContent;
            MainContent.Content = new View.MainScreen();
        }
        public static MainWindow MainWin;
        public static ContentPresenter Main;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ((GameScreen)this.MainContent.Content).MainWin_KeyDown(sender, e);
            }
            catch { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataControl.SaveData();
        }
    }
}
