using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Runaway.Utilities
{
    public static class Music
    {
        private static readonly MediaPlayer PlayingMusic = new MediaPlayer();
        private static readonly Random Rnd = new Random();
        public static Enivironment EnivironmentState { get; private set; }
        public enum Enivironment
        {
            Menu,
            Raid,
            Boss
        }

        static Music()
        {
            PlayingMusic.MediaEnded += Media_Ended;
        }

        private static  Uri[] PathsMusic =
        {
            new Uri(@"..\..\Music\Menu\Bossfight - Intro.mp3", UriKind.Relative),//0

            new Uri(@"..\..\Music\Menu\F.O.O.L - Time Spender.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Menu\Bossfight - Intro.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Menu\Bossfight - Intro.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Menu\Bossfight - Intro.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Menu\Bossfight - Intro.mp3", UriKind.Relative)
        };

        public static void PlayMenuSound()
        {
            EnivironmentState = Enivironment.Menu;
            PlayingMusic.Open(PathsMusic[0]);
            PlayingMusic.Play();
        }

        public static void PlayRaidSound()
        {
            EnivironmentState = Enivironment.Raid;
            PlayingMusic.Open(PathsMusic[Rnd.Next(2,3)]);
            PlayingMusic.Play();
        }
        /// <summary>
        /// Используется для прокрутки музыкальных композиций в зависимости
        /// от текущего окружения 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}
