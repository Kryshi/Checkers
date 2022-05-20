using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Board
    {
        public enum Tile
        {
            empty = ' ',
            pawn_Wh = 'W',
            pawn_Bl = 'B',
            queen_Wh = 'Q',
            queen_Bl = 'q'

        }

        public static Tile[,] GenerateStartingBoard()
        {
            
            Tile[,] board =
            {
                {Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty},
                {Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh},
                {Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty},
                {Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty},
                {Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty},
                {Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl},
                {Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty},
                {Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl},
            };
            /*
            Tile[,] board =
            {
                {Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.empty, Tile.empty, Tile.pawn_Wh, Tile.empty},
                {Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.queen_Bl, Tile.empty, Tile.pawn_Wh},
                {Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty, Tile.pawn_Wh, Tile.empty},
                {Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty},
                {Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty, Tile.empty},
                {Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl},
                {Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty},
                {Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl, Tile.empty, Tile.pawn_Bl},
            };
            */
            return board;

        }

        public static void PrintCurrentStatus(Tile[,] board)
        {
            Console.Title = "Dáma";
            Console.WriteLine("  0 1 2 3 4 5 6 7 ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i);
                Console.Write(" ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write((char)board[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static bool VictoryCheck(Tile[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i,j] == Tile.pawn_Wh || board[i,j] == Tile.queen_Wh)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
