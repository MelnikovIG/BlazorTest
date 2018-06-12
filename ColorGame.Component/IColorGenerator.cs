using System.Drawing;

namespace ColorGameComponent
{
    public interface IColorGenerator
    {
        Color GenerateColor(Color baseColor, int currentLevel);
    }
}
