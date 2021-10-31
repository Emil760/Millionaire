using System;
using System.Timers;
using System.Windows.Media;

namespace Millioner.Models
{
    class Game
    {
        private Timer timer;
        private MediaPlayer player;

        private int non_fire_number;

        public Game()
        {
            timer = new Timer();

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
