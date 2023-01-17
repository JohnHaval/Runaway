using Runaway.Objects;
using Runaway.Objects.GUI_Control;
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
using System.Xml.Linq;

namespace Runaway.View
{
    /// <summary>
    /// Логика взаимодействия для GameScreen.xaml
    /// </summary>
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();

            GameField = MainGameField;
            if (GamerStats.WaveState % 5 != 0) Control.RaidWaveField();
            else Control.BossWaveField();            
        }

        public static Canvas GameField;

        bool IsPause = false;
        public WaveControl Control = new WaveControl();        
        
		private void MainWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsPause == true)
            {                                               
             
            }
        }
    }        
	
}
