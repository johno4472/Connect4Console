using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class GridStatus
    {
        public List<List<int>> Grid { get; set; } =
        [
            [0,0,0,0,0,0,0],
            [0,0,0,0,0,0,0],
            [0,0,0,0,0,0,0],
            [0,0,0,0,0,0,0],
            [0,0,0,0,0,0,0],
            [0,0,0,0,0,0,0]
        ];

        public bool RedoTurn { get; set; } = false;

        public int ChangePlayer(int player)
        {
            if (player == 2) { return 1; } else { return 2; }
        }

        public int GetLowestRow(int column)
        {
            for (int i = 0; i < Grid.Count; i++)
            {
                if (Grid[i][column] == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public string AddPiece(int column, int player)
        {
            int row = GetLowestRow(column - 1);
            if (row == -1)
            {
                return $"Column {column - 1} is full. Try again\n";
            }
            Grid[row][column - 1] = player;
            return "";
        }

        public void ShowGrid()
        {
            for (int i = 1; i <= Grid.Count; i++)
            {
                for (int j = 0; j < Grid[^i].Count; j++)
                {
                    Console.Write($"{Grid[^i][j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n1 2 3 4 5 6 7");
        }
    }
}
