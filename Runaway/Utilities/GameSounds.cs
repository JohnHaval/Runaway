﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Runaway.Utilities
{
    public static class GameSounds
    {
    
        private readonly static MediaPlayer Boom = new MediaPlayer();
        private readonly static MediaPlayer Hit = new MediaPlayer();
        private readonly static MediaPlayer Fire = new MediaPlayer();
        private readonly static MediaPlayer NewWave = new MediaPlayer();
        private readonly static MediaPlayer WaveResults = new MediaPlayer();
        private readonly static MediaPlayer Failed = new MediaPlayer();

        static GameSounds()
        {
            Boom.Open(new Uri(@"..\..\Sound\boom.wav", UriKind.Relative));
            Hit.Open(new Uri(@"..\..\Sound\hit.wav", UriKind.Relative));
            Fire.Open(new Uri(@"..\..\Sound\startfire.wav", UriKind.Relative));
            NewWave.Open(new Uri(@"..\..\Sound\playnw.wav", UriKind.Relative));
            WaveResults.Open(new Uri(@"..\..\Sound\resultsofwave.wav", UriKind.Relative));
            Failed.Open(new Uri(@"..\..\Sound\callofbox.wav", UriKind.Relative));
        }

        public static void PlayBoom()
        {
            StartAgain(Boom);
        }

        public static void PlayHit()
        {
            StartAgain(Hit);
        }
        public static void PlayFire()
        {
            StartAgain(Fire);
        }
        public static void PlayNewWaveSound()
        {
            StartAgain(NewWave);
        }
        public static void PlayWaveResultsSound()
        {
            StartAgain(WaveResults);
        }
        public static void PlayFailedResultsSound()
        {
            StartAgain(Failed);
        }

        public static void StartAgain(object sender)
        {
            ((MediaPlayer)sender).Position = TimeSpan.Zero;
            ((MediaPlayer)sender).Play();
        }
    }
}
