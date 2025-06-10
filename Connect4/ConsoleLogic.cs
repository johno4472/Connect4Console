using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class ConsoleLogic
    {
        public int ColumnChoice { get; set; }

        public bool InputParseSuccess { get; set; }

        public string ResponseMessage { get; set; } = "";

        public List<string> ValidColumns = ["1",  "2", "3", "4", "5", "6", "7"];

        public int PlayerChooseColumn(Gameplay game)
        {
            Console.Write($"Player {game.CurrentPlayer}'s turn\nSelect your column: ");
            string? playerResponse = Console.ReadLine();
            if (playerResponse == null || !ValidColumns.Contains(playerResponse))
            {
                ResponseMessage = "Incorrect input for column choice";
                InputParseSuccess = false;
                game.RedoTurn = true;
                Console.WriteLine("Not a valid response. Please enter a digit 1-7");
                return ColumnChoice;
            }
            InputParseSuccess = true;
            ResponseMessage = "Correct Input for column choice";
            return Convert.ToInt32(playerResponse);
        } 
    }
}
