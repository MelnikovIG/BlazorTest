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

        public Color GenerateSelectedCellColor(Color baseColor, int currentLevel)
        {
            if (currentLevel > GameConfiguration.MaxGameLevel)
            {
                currentLevel = GameConfiguration.MaxGameLevel;
            }

            var levelsCompletePercent = (GameConfiguration.MaxGameLevel - currentLevel) / (float)GameConfiguration.MaxGameLevel;
            var maxSpreadDiff = GameConfiguration.MaxColorSpread - GameConfiguration.MinColorSpread;

            var minDiff = GameConfiguration.MinColorSpread;
            var maxDiff = (int)(GameConfiguration.MinColorSpread + maxSpreadDiff * levelsCompletePercent);

            var newR = GetColorPart(baseColor.R, minDiff, maxDiff);
            var newG = GetColorPart(baseColor.G, minDiff, maxDiff);
            var newB = GetColorPart(baseColor.B, minDiff, maxDiff);

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

        private int GetColorPart(int basePart, int minDiff, int maxDiff)
        {
            var diff = rnd.Next(minDiff, maxDiff);

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
                return rnd.Next(100) % 2 > 0 ? upColor : downColor;
            }
        }

        public Color GenerateBorderCellColor(Color baseColor)
        {
            var maxDiff = 10;
            var minDiff = 5;

            var newR = GetColorPart(baseColor.R, minDiff, maxDiff);
            var newG = GetColorPart(baseColor.G, minDiff, maxDiff);
            var newB = GetColorPart(baseColor.B, minDiff, maxDiff);

            return Color.FromArgb(baseColor.A, newR, newG, newB);
        }
    }
}
