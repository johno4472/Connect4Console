// See https://aka.ms/new-console-template for more information
using Connect4;

while (true)
{
    Console.WriteLine("Let's Play Connect 4!");

    bool gameOver = false;
    Gameplay game = new Gameplay();
    ConsoleLogic consoleHelper = new ConsoleLogic();
    game.ShowGrid();


    while (!gameOver)
    {
        

        int columnChoice = consoleHelper.PlayerChooseColumn(game);
        
        if (!game.RedoTurn)
        {
            game.AddPiece(columnChoice);

            if (!game.RedoTurn && game.CheckIfEndGame())
            {
                Console.WriteLine($"Game over! Player {game.CurrentPlayer} wins.");
                game.ShowGrid();
                Console.WriteLine("We changed the winning set with the number 8 for you to spot it. Good game!");
                gameOver = true;
            }
        }


        if (!game.RedoTurn) 
        { 
            game.ChangePlayer();
            game.ShowGrid();
        }
        else { game.RedoTurn = false; }

    }

    Console.WriteLine("Want to play again? y/n");
    string? playAgain = Console.ReadLine();
    if (playAgain == "n")
    {
        Console.WriteLine("See ya!");
        Thread.Sleep(1000);
        return;
    }
    else if (playAgain != "y")
    {
        Console.WriteLine("Well you didn't say 'y' or 'n', so I'm gonna take that as a yes");
    }
}

