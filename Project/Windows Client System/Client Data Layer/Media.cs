using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace BinarySoftCo.ChatSystem.ClientDataLayer
{
    public class Media
    {
        static SoundPlayer sp;

        public static void PlayMessageSound()
        {
            sp = new SoundPlayer(Properties.Resources.Message);
            sp.Play();
        }

        public static void PlayLunchApplicationSound()
        {
            sp = new SoundPlayer(Properties.Resources.SignIn);
            sp.Play();
        }

        public static void PlayExitApplicationSound()
        {
            sp = new SoundPlayer(Properties.Resources.SignOut);
            sp.PlaySync();
        }
    }
}
