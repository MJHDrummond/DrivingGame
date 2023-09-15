using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingGame.Console;

namespace DrivingGame.Console
{
    public class PlayGame
    {
        ConfigurationItem _config = new ConfigurationItem();
        public void Play(ConfigurationItem config)
        {
            _config = config;
        }

    }
}
