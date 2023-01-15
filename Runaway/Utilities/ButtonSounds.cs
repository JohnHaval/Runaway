using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Runaway.Utilities
{
    public static class ButtonSounds
    {
        private readonly static MediaPlayer SelectSound = new MediaPlayer();
        private readonly static MediaPlayer ClickSound = new MediaPlayer();

        static ButtonSounds()
        {
            SelectSound.Open(new Uri(@"..\..\Sound\button_select.wav", UriKind.Relative));
            ClickSound.Open(new Uri(@"..\..\Sound\button_click.wav", UriKind.Relative));
        }

        public static void PlayClickSound()
        {
            MainSoundFunc.StartAgain(ClickSound);
        }

        public static void PlaySelectSound()
        {
            MainSoundFunc.StartAgain(SelectSound);
        }
    }
}
