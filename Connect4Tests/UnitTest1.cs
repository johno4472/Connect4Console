using System.Security.Cryptography.X509Certificates;
using Connect4;
using FluentAssertions;

namespace Connect4Tests
{
    public class Connect4UnitTests
    {
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("8")]
        [InlineData("1.2")]
        [InlineData("12")]
        [InlineData("hello")]
        [Theory]
        public void OutOfRangeColumnsNotAccepted(string userInput)
        {
            //Arrange
            ConsoleLogic consoleHelper = new ConsoleLogic();
            Gameplay game = new Gameplay();

            //Act
            consoleHelper.PlayerChooseColumn(game, userInput);

            //Assert
            game.RedoTurn.Should().BeTrue();
            consoleHelper.InputParseSuccess.Should().BeFalse();
        }

        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [Theory]
        public void InRangeColumnsAccepted(string userInput)
        {
            //Arrange
            ConsoleLogic consoleHelper = new ConsoleLogic();
            Gameplay game = new Gameplay();

            //Act
            consoleHelper.PlayerChooseColumn(game, userInput);

            //Assert
            game.RedoTurn.Should().BeFalse();
            consoleHelper.InputParseSuccess.Should().BeTrue();
        }
    }
}