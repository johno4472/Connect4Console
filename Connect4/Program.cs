// See https://aka.ms/new-console-template for more information
using Connect4;

Console.WriteLine("Let's Play Connect 4!");

bool gameOver = false;
int player = 1;
GridStatus game = new GridStatus();

while (!gameOver)
{
    game.ShowGrid();
    Console.Write($"Player {player}'s turn\nSelect your column: ");

    int columnChoice = Convert.ToInt32(Console.ReadLine());
    
    string addResponse = game.AddPiece(columnChoice, player);
    
    if (addResponse != "")
    {
        game.RedoTurn = true;
        Console.WriteLine(addResponse);

    }

    if (!game.RedoTurn) { player = game.ChangePlayer(player); }
    else { game.RedoTurn = false; }

}

