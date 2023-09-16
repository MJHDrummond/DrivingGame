using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingGame.Console
{
    public class ConfigurationItem
    {
        public int CurrentCenterPoint { get; set; }
        public int CurrentCarPosition { get; set; }
        public string[]? CurrentRoadState { get; set; }
        public int CurrentLeftRoadLimit { get; set; }
        public int CurrentRightRoadLimit { get; set; }
        public int CurrentRoadRefreshRate = 1000; //Refresh rate in ms
    }
}
