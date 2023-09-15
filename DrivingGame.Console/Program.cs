﻿using System;
using System.Threading.Tasks;
using DrivingGame.Console;

namespace DrivingGame.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var _config = new ConfigurationItem();

            var init = new IntialiseRoad();
            await init.GenerateStartingRoad(_config);

            // var game = new ProperGame();
            //var game = new TrainingGame();
            //await game.PlayAsync();
            var game = new PlayGame();
            game.Play(_config);

            System.Console.ReadLine();
        }
    }
}