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

        [Fact]
        public void PieceAddedToColumnLandsAtBottomRow()
        {
            //Arrange
            Gameplay game = new Gameplay();

            //Act
            game.AddPiece(1, 1);

            //Assert
            game.RedoTurn.Should().BeFalse();
            game.Grid[0][0].Should().Be(1);
        }

        [Fact]
        public void CanAddPiecesToTheTopRow()
        {
            //Arrange
            Gameplay game = new Gameplay();

            //Act
            for (int i = 0; i < 6; i++)
            {
                game.AddPiece(1, 1);
            }

            //Assert
            game.RedoTurn.Should().BeFalse();
            for (int i = 0; i < 6; i++) { game.Grid[i][0].Should().Be(1); }
        }

        [Fact]
        public void AddingToFullColumnMakesTurnRedo()
        {
            //Arrange
            Gameplay game = new Gameplay();
            for (int i = 0; i < 6; i++)
            {
                game.AddPiece(1, 1);
            }

            //Act
            game.AddPiece(1, 1);

            //Assert
            game.RedoTurn.Should().BeTrue();
        }
    }
}