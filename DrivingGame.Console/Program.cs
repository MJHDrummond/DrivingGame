﻿using System;
using System.Threading.Tasks;
using DrivingGame.Console;
using DrivingGame.Console.Helpers;

namespace DrivingGame.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var _config = new ConfigurationItem();
            var roadGenerator = new RoadGenerator();


            var init = new InitialiseRoad();
            await init.GenerateStartingRoad(_config, roadGenerator);

            // var game = new ProperGame();
            //var game = new TrainingGame();
            //await game.PlayAsync();
            var game = new PlayGame();
            game.Play(_config, roadGenerator);

            System.Console.ReadLine();
        }
    }
}