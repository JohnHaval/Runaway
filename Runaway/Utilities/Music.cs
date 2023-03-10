using System;
using System.Windows.Media;

namespace Runaway.Utilities
{
    public static class Music
    {
        private static bool _isEnabled = true;
        public static bool IsEnabled { get => _isEnabled; set => EnableChange(value); }
        private static readonly MediaPlayer PlayingMusic = new MediaPlayer();
        private static readonly Random Rnd = new Random();
        public static Enivironment EnivironmentState { get; private set; }
        public enum Enivironment
        {
            Menu,
            Marketplace,
            Raid,
            Boss,
            FollowMe
        }
        //Массив путей к медиа файлам, чтобы открыть нужный относительно требования
        private readonly static Uri[] PathsMusic =
        {
            new Uri(@"..\..\Music\Menu\Bossfight - Intro.mp3", UriKind.Relative),//0

            new Uri(@"..\..\Music\Menu\F.O.O.L - Time Spender.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Menu\Bossfight - Outro.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Menu\World End.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Marketplace\Bossfight, F.O.O.L - Mercy.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Marketplace\F.O.O.L, Power Glove - Mercenary.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Marketplace\Open Space.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\Alien Planet.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\Black Hole.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\F.O.O.L - Conflict.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\F.O.O.L - Criminals.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\Predict.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\Soul Destroy.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Raid\To The City.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\Boss Fight.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\Bossfight - Endgame.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\Enemy Ship.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\Fight Inside.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\KROWW - Call Of The Void.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\Meet Of God.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\Boss\Pain.mp3", UriKind.Relative),

            new Uri(@"..\..\Music\ShockOne, Blanke - Follow Me.mp3", UriKind.Relative)

        };

        static Music()
        {
            PlayingMusic.MediaEnded += Media_Ended;
        }

        private static void Media_Ended(object sender, EventArgs e)
        {
            if (!IsEnabled) return;
            if (EnivironmentState == Enivironment.Menu) PlayingMusic.Open(PathsMusic[Rnd.Next(0, 4)]);//Случайное воспроизведение музыки, относительно текущего статуса демонстратора
            else if (EnivironmentState == Enivironment.Marketplace) PlayingMusic.Open(PathsMusic[Rnd.Next(4, 7)]);
            else if (EnivironmentState == Enivironment.Raid) PlayingMusic.Open(PathsMusic[Rnd.Next(7, 14)]);
            else if (EnivironmentState == Enivironment.Boss) PlayingMusic.Open(PathsMusic[Rnd.Next(14, 21)]);
            else PlayingMusic.Open(PathsMusic[21]);
            PlayingMusic.Play();
        }



        public static void PlayMenuSound()
        {
            if (!IsEnabled) return;
            EnivironmentState = Enivironment.Menu;
            PlayingMusic.Open(PathsMusic[Rnd.Next(0)]);
            PlayingMusic.Play();
        }

        public static void PlayMarketplaceSound()
        {
            if (!IsEnabled) return;
            EnivironmentState = Enivironment.Marketplace;
            PlayingMusic.Open(PathsMusic[Rnd.Next(4, 7)]);
            PlayingMusic.Play();
        }

        public static void PlayRaidSound()
        {
            if (!IsEnabled) return;
            EnivironmentState = Enivironment.Raid;
            PlayingMusic.Open(PathsMusic[Rnd.Next(7, 14)]);
            PlayingMusic.Play();
        }

        public static void PlayBossSound()
        {
            if (!IsEnabled) return;
            EnivironmentState = Enivironment.Boss;
            PlayingMusic.Open(PathsMusic[Rnd.Next(14, 21)]);
            PlayingMusic.Play();
        }

        public static void PlayFollowMeSound()
        {
            if (!IsEnabled) return;
            EnivironmentState = Enivironment.FollowMe;
            PlayingMusic.Open(PathsMusic[21]);
            PlayingMusic.Play();
        }
        private static void EnableChange(bool value)
        {
            _isEnabled = value;
            if (value) PlayMenuSound();
            else PlayingMusic.Stop();
        }

    }
}
