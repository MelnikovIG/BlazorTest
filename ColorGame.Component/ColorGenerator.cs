using ColorGame.Component;
using System;
using System.Drawing;

namespace ColorGameComponent
{
    public class ColorGenerator : IColorGenerator
    {
        public IGameConfiguration GameConfiguration { get; }
        public Random rnd = new Random();

        public ColorGenerator(IGameConfiguration gameConfiguration)
        {
            GameConfiguration = gameConfiguration;
        }

        public Color GenerateColor(Color baseColor, int currentLevel)
        {
            var levelsCompletePercent = (GameConfiguration.MaxGameLevel - currentLevel) / (float)currentLevel;
            var spreadDiff = GameConfiguration.MaxColorSpread - GameConfiguration.MinColorSpread;
            var diff = (int)(spreadDiff * levelsCompletePercent);

            var newR = GetColorPart(baseColor.R, diff);
            var newG = GetColorPart(baseColor.G, diff);
            var newB = GetColorPart(baseColor.B, diff);

            return Color.FromArgb(baseColor.A, newR, newG, newB);
        }

        private int GetUpColor(int basePart, int diff)
        {
            return basePart + GameConfiguration.MinColorSpread + diff;
        }

        private int GetDownColor(int basePart, int diff)
        {
            return basePart - GameConfiguration.MinColorSpread - diff;
        }

        private int GetColorPart(int basePart, int diff)
        {
            var upColor = GetUpColor(basePart, diff);
            var downColor = GetDownColor(basePart, diff);

            if (upColor > 255)
            {
                return downColor;
            }
            else if (downColor < 0)
            {
                return upColor;
            }
            else
            {
                return rnd.Next(0, 1) > 0 ? upColor : downColor;
            }
        }
    }
}
