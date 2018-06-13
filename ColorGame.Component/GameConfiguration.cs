using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Component
{
    public class GameConfiguration : IGameConfiguration
    {
        public int MaxGameLevel { get; set; } = 15;
        public int MaxColorSpread { get; set; } = 15;
        public int MinColorSpread { get; set; } = 7;
    }
}
