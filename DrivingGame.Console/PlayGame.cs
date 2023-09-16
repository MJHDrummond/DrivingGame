using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingGame.Console;
using DrivingGame.Console.Helpers;

namespace DrivingGame.Console
{
    public class PlayGame
    {
        ConfigurationItem _config = new ConfigurationItem();
        public void Play(ConfigurationItem config, RoadGenerator roadGenerator)
        {
            _config = config;


            bool continueGame = true;
            while (continueGame)
            {

                Task.Run(() => continueGame = UpdateCarPosition());
                continueGame = MoveCarToNextRoadSection();
                roadGenerator.GenerateNextGameLineDuringPlay();

                Stopwatch stopwatch = Stopwatch.StartNew();
                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds >= _config.CurrentRoadRefreshRate)
                    {
                        break;
                    }
                }

                System.Console.Clear();
                Array.ForEach(_config.CurrentRoadState, System.Console.WriteLine);


            }
            System.Console.WriteLine("Game Over!");
        }

        private bool UpdateCarPosition()
        {
            while (true)
            {
                var ch = System.Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Escape:
                        return false;
                    case ConsoleKey.LeftArrow:
                        _config.CurrentCarPosition -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        _config.CurrentCarPosition += 1;
                        break;
                }
            }
        }

        private bool MoveCarToNextRoadSection()
        {
            string nextRoadSection = _config.CurrentRoadState[_config.CurrentRoadState.Length - 2];

            _config.CurrentLeftRoadLimit = nextRoadSection.IndexOf(" ") - 1;
            _config.CurrentRightRoadLimit = nextRoadSection.LastIndexOf(" ") + 1;

            if (_config.CurrentCarPosition <= _config.CurrentLeftRoadLimit || _config.CurrentCarPosition >= _config.CurrentRightRoadLimit)
            {
                char[] charArrRoadSection = nextRoadSection.ToCharArray();
                charArrRoadSection[_config.CurrentCarPosition] = 'X'; // freely modify the array
                _config.CurrentRoadState[_config.CurrentRoadState.Length - 2] = new string(charArrRoadSection); // create a new string with array contents.
                return false;
            }
            else
            {
                char[] charArrRoadSection = nextRoadSection.ToCharArray();
                charArrRoadSection[_config.CurrentCarPosition] = '^'; // freely modify the array
                _config.CurrentRoadState[_config.CurrentRoadState.Length - 2] = new string(charArrRoadSection); // create a new string with array contents.
                return true;
            }
        }
    }
}
