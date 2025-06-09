using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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

        public int CurrentPlayer { get; set; } = 1;

        public List<List<int>> WinningSet { get; set; } = [];

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

        public bool FindAndMakeWinningSet(int startRow, int startColumn, int rowDirection, int columnDirection)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Grid[startRow + i * rowDirection][startColumn + i * columnDirection] != CurrentPlayer)
                {
                    return false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                WinningSet.Add([startRow + i * rowDirection, startColumn + i * columnDirection]);
            }
            return true;
        }

        public bool CheckIfWinner()
        {
            List<List<int>> PotentialWinner = [[]];
            for (int j = 0; j < Grid[0].Count; j++)
            {
                for (int i = 0; i < Grid.Count; i++)
                {
                    if (Grid[i][j] == 0) { break; }
                    else if (Grid[i][j] != CurrentPlayer) { continue; }

                    if (i >= 3 && j <= 4)
                    {
                        if (FindAndMakeWinningSet(i, j, -1, 1))
                        {
                            return true;
                        }
                    }
                    if (j <= 4)
                    {
                        if (FindAndMakeWinningSet(i, j, 0, 1))
                        {
                            return true;
                        }
                    }
                    if (i <= 2 && j <= 4)
                    {
                        if (FindAndMakeWinningSet(i, j, 1, 1))
                        {
                            return true;
                        }
                    }
                    if (i <= 2)
                    {
                        if (FindAndMakeWinningSet(i, j, 1, 0))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckIfEndGame()
        {
            if (CheckIfWinner())
            {
                for (int i = 0; i < 4; i++)
                {
                    Grid[WinningSet[i][0]][WinningSet[i][1]] = 8;
                }
                return true;
            }
            return false;
        }
    }
}
