// See https://aka.ms/new-console-template for more information
using Connect4;

while (true)
{
    Console.WriteLine("Let's Play Connect 4!");

    bool gameOver = false;
    GridStatus game = new GridStatus();


    while (!gameOver)
    {
        game.ShowGrid();
        Console.Write($"Player {game.CurrentPlayer}'s turn\nSelect your column: ");

        int columnChoice = Convert.ToInt32(Console.ReadLine());

        string addResponse = game.AddPiece(columnChoice, game.CurrentPlayer);

        if (addResponse != "")
        {
            game.RedoTurn = true;
            Console.WriteLine(addResponse);

        }

        if (game.CheckIfEndGame())
        {
            Console.WriteLine($"Game over! Player {game.CurrentPlayer} wins.");
            game.ShowGrid();
            Console.WriteLine("We changed the winning set with the number 8 for you to spot it. Good game!");
            gameOver = true;
        }

        if (!game.RedoTurn) { game.ChangePlayer(); }
        else { game.RedoTurn = false; }

    }

    Console.WriteLine("Want to play again? y/n");
    string playAgain = Console.ReadLine();
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

