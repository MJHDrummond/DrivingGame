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

                //Move car to next line in same position
                //Create new road section
                //Print to console
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

        private bool MoveCarToNextRoadSection()
        {
            string nextRoadSection = _config.CurrentRoadState[_config.CurrentRoadState.Length - 2];

            _config.CurrentLeftRoadLimit = nextRoadSection.IndexOf("o") - 1;
            _config.CurrentRightRoadLimit = nextRoadSection.LastIndexOf("o") + 1;

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
