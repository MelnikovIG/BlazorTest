using ColorGameComponent;
using Moq;
using System.Drawing;
using Xunit;

namespace ColorGame.Component.Test
{
    public class ColorGeneratorTest
    {
        [Fact]
        public void GenerateSelectedCellColor()
        {
            //Arrange
            var gameConfigurationMock = new Mock<IGameConfiguration>();
            gameConfigurationMock.Setup(x => x.MinColorSpread).Returns(10);
            gameConfigurationMock.Setup(x => x.MaxColorSpread).Returns(100);
            gameConfigurationMock.Setup(x => x.MaxGameLevel).Returns(100);

            Color baseColor = Color.Tomato;
            var colorGenerator = new ColorGenerator(gameConfigurationMock.Object);

            //Act
            var result = colorGenerator.GenerateSelectedCellColor(baseColor, 1);

            //Assert
            Assert.InRange(result.R, 0, 255);
            Assert.InRange(result.G, 0, 255);
            Assert.InRange(result.B, 0, 255);
        }

        [Fact]
        public void GenerateBorderCellColor()
        {
            //Arrange
            var gameConfigurationMock = new Mock<IGameConfiguration>();

            Color baseColor = Color.Tomato;
            var colorGenerator = new ColorGenerator(gameConfigurationMock.Object);

            //Act
            var result = colorGenerator.GenerateBorderCellColor(baseColor);

            //Assert
            Assert.InRange(result.R, 0, 255);
            Assert.InRange(result.G, 0, 255);
            Assert.InRange(result.B, 0, 255);
        }
    }
}
