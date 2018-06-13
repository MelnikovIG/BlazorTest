using System.Drawing;

namespace ColorGameComponent
{
    public interface IColorGenerator
    {
        Color GenerateBorderCellColor(Color baseColor);
        Color GenerateSelectedCellColor(Color borderColor, int currentLevel);
    }
}
