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
        private readonly static MediaPlayer BuySound = new MediaPlayer();
        private readonly static MediaPlayer SellSound = new MediaPlayer();
        private readonly static MediaPlayer CancelSound = new MediaPlayer();

        static ButtonSounds()
        {
            SelectSound.Open(new Uri(@"..\..\Sound\button_select.wav", UriKind.Relative));
            ClickSound.Open(new Uri(@"..\..\Sound\button_click.wav", UriKind.Relative));
            BuySound.Open(new Uri(@"..\..\Sound\buy.wav", UriKind.Relative));
            SellSound.Open(new Uri(@"..\..\Sound\sell.wav", UriKind.Relative));
            CancelSound.Open(new Uri(@"..\..\Sound\cancel.wav", UriKind.Relative));
        }

        public static void PlayClickSound()
        {
            StartAgain(ClickSound);
        }

        public static void PlaySelectSound()
        {
            StartAgain(SelectSound);
        }

        public static void StartAgain(object sender)
        {
            ((MediaPlayer)sender).Position = TimeSpan.Zero;
            ((MediaPlayer)sender).Play();
        }
        public static void PlayBuySound()
        {
            StartAgain(BuySound);
        }
        public static void PlaySellSound()
        {
            StartAgain(SellSound);
        }
        public static void PlayCancelSound()
        {
            StartAgain(CancelSound);
        }
    }
}
