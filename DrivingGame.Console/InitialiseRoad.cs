using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingGame.Console;
using DrivingGame.Console.Helpers;

namespace DrivingGame.Console
{
    public class InitialiseRoad
    {
        //ConfigurationItem _config = new ConfigurationItem();
        Constants Constants = new Constants();  

        public Task GenerateStartingRoad(ConfigurationItem _config, RoadGenerator roadGenerator)
        {
            System.Console.SetWindowSize(Constants.WIDTH, Constants.LENGTH);
            //ConfigurationItem _config = config;
            _config.CurrentRoadState = new string[Constants.LENGTH];
            _config.CurrentCenterPoint = (Constants.WIDTH - 1) / 2;
            _config.CurrentCarPosition = (Constants.WIDTH - 1) / 2;

            //var roadGenerator = new RoadGenerator();

            roadGenerator.GenerateFirstGameLine(_config);
            for (int y = Constants.LENGTH - 2; y >= 0; y--)
            {
                roadGenerator.GenerateNextGameLine(y);
            }

            Array.ForEach(_config.CurrentRoadState, System.Console.WriteLine);
            return Task.CompletedTask;
        }

    }
}
