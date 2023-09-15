using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingGame.Console;

namespace DrivingGame.Console
{
    public class IntialiseRoad
    {
        ConfigurationItem _config = new ConfigurationItem();
        Constants Constants = new Constants();  

        public Task GenerateStartingRoad(ConfigurationItem config)
        {
            _config = config;
            _config.CurrentRoadState = new string[Constants.LENGTH];
            _config.CurrentCenterPoint = (Constants.WIDTH - 1) / 2;

            GenerateFirstGameLine();
            for (int y = Constants.LENGTH - 2; y >= 0; y--)
            {
                GenerateNextGameLine(y);
            }
            Array.ForEach(_config.CurrentRoadState, System.Console.WriteLine);
            return Task.CompletedTask;
        }

        private void GenerateFirstGameLine()
        {
            string firstLine = string.Empty;
            for (int x = 0; x < Constants.WIDTH; x++)
            {
                if (x == _config.CurrentCenterPoint)
                {
                    firstLine += "^";
                }
                else if (x >= (GetLeftRoadLimit()) && x <= (GetRightRoadLimit()))
                {
                    firstLine += "o";
                }
                else
                {
                    firstLine += "*";
                }
            }
            //System.Console.Write(firstLine);
            //System.Console.WriteLine("");
            _config.CurrentRoadState[_config.CurrentRoadState.Length - 1] = firstLine;
            //_gameBoard[] = { { }, { } }
        }

        private void GenerateNextGameLine(int verticalSection)
        {
            ShiftCurrentCenterPoint();

            string newGameLine = string.Empty;
            for (int x = 0; x < Constants.WIDTH; x++)
            {
                if (x >= (GetLeftRoadLimit()) && x <= (GetRightRoadLimit()))
                {
                    newGameLine += "o";
                }
                else
                {
                    newGameLine += "*";
                }
            }
            //System.Console.Write(newGameLine);
            //System.Console.WriteLine("");
            _config.CurrentRoadState[verticalSection] = newGameLine;
        }
        private void ShiftCurrentCenterPoint()
        {
            if (_config.CurrentCenterPoint == 1 || _config.CurrentCenterPoint == Constants.WIDTH - 1)
            {
                return;
            }

            Random rnd = new Random();
            int chanceLeftOrRight = rnd.Next(1, 6);
            if (chanceLeftOrRight == 1)
            {
                _config.CurrentCenterPoint -= 1;
            }
            else if (chanceLeftOrRight == 5)
            {
                _config.CurrentCenterPoint += 1;
            }
        }

        private int GetLeftRoadLimit()
        {
            return _config.CurrentCenterPoint - ((Constants.ROADWIDTH - 1) / 2);
        }
        private int GetRightRoadLimit()
        {
            return _config.CurrentCenterPoint + ((Constants.ROADWIDTH - 1) / 2);
        }
    }
}
