using Microsoft.Win32;
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
            MainContent.Content = new MainScreen();
        }
        /// <summary>
        /// Переменная главного окна, которая является ссылкой для взаимодействия с его элементами
        /// </summary>
        public static MainWindow MainWin;
        /// <summary>
        /// Демонстратор содержимого для окна. Используется как ссылка для доступа к нему. (Изменение содержимого окна через нее)
        /// </summary>
        public static ContentPresenter Main;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ((GameScreen)MainContent.Content).MainWin_KeyDown(sender, e);//Передача данных нажатой клавиши для функций, прописанных в GameScreen
            }
            catch { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataControl.SaveData();
            if (!DataControl.IsSaved)//проверка на успешность проведения сохранения
            {
                e.Cancel = FixSave();
            }
        }


        /// <summary>
        /// Функция для выполнения пользователем исправления сохранения при случае, если указанный в файле Path.lp путь не найден.
        /// При сохранении новый путь впишется и "ошибка сохранения" пропадет.
        /// </summary>
        /// <returns>true - окно можно закрыть после вопроса, false - отменить закрытие окна</returns>
        private bool FixSave()
        {
             MessageBoxResult result = MessageBox.Show("Во время сохранения произошла непредвиденная ошибка! " +
                   "Хотите сохранить вручную? В случае отказа, данные будут утеряны!", "Ошибка сохранения", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Сохранение игры",
                    Filter = "Сохранение игры(*.runsave*) |*.runsave",
                    DefaultExt = ".runsave",
                };
                if (save.ShowDialog() == true)
                {
                    DataControl.SaveData(save.FileName);
                    MessageBox.Show("Сохранение успешно выполнено!", "Сохранение", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (result == MessageBoxResult.Cancel) return false;
            return true;
        }
    }
}
