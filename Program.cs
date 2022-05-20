using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            //vytvoření desky s počáteční konfigurací
            Board.Tile[,] board = Board.GenerateStartingBoard();
            string CurrentPlayer = "bílá";
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "Dáma";

            while (Board.VictoryCheck(board) != false)
            {
          
                Board.PrintCurrentStatus(board);
         
                Console.WriteLine("Na tahu je hráč barvy: " + CurrentPlayer);

                Console.WriteLine("Vyberte řádek:");
                int row = int.Parse(Console.ReadLine());
                Console.WriteLine("Vyberte sloupec:");
                int column = int.Parse(Console.ReadLine());

                //pokud hráč vybere prázdné pole, nebo pole na kterém je protihráčova figurka, program se zeptá znovu
                while ((board[row, column] == Board.Tile.empty) 
                    || ((board[row, column] == Board.Tile.queen_Wh || board[row, column] == Board.Tile.pawn_Wh) && CurrentPlayer == "černá")
                    || ((board[row, column] == Board.Tile.queen_Bl || board[row, column] == Board.Tile.pawn_Bl) && CurrentPlayer == "bílá"))
                {
                    Console.WriteLine("Vybrané pole je neplatné, zkuste vybrat znovu");
                    Console.WriteLine("Vyberte řádek:");
                    row = int.Parse(Console.ReadLine());
                    Console.WriteLine("Vyberte sloupec:");
                    column = int.Parse(Console.ReadLine());
                }



                Console.WriteLine("Vyberte cílový řádek:");
                int targetRow = int.Parse(Console.ReadLine());              

                //kámen se může posunout jen o jedno pole nahoru či dolů, podle toho jaké je barvy
                while((targetRow != row+1) && (board[row, column] == Board.Tile.pawn_Wh))   
                {
                    Console.WriteLine("!Vybraný cílový řádek je neplatný, zkuste vybrat znovu");
                    Console.WriteLine("!Vyberte cílový řádek:");
                    targetRow = int.Parse(Console.ReadLine());
                }

                while ((targetRow != row - 1) && (board[row, column] == Board.Tile.pawn_Bl))
                {
                    Console.WriteLine("!Vybraný cílový řádek je neplatný, zkuste vybrat znovu");
                    Console.WriteLine("!Vyberte cílový řádek:");
                    targetRow = int.Parse(Console.ReadLine());
                }

                

               
                Console.WriteLine("Vyberte cílový sloupec:");
                int targetColumn = int.Parse(Console.ReadLine());

                while ((Math.Abs(targetColumn-column) != 1 || Math.Abs(column-targetColumn) != 1) && (board[row, column] == Board.Tile.pawn_Wh || board[row, column] == Board.Tile.pawn_Bl))
                {
                    Console.WriteLine("!Vybraný cílový sloupec je neplatný, zkuste vybrat znovu");
                    Console.WriteLine("!Vyberte cílový sloupec:");
                    targetColumn = int.Parse(Console.ReadLine());
                }
                
                //podmínka pro pohyb dam
                while ((board[row, column] == Board.Tile.queen_Bl || board[row, column] == Board.Tile.queen_Wh)
                    &&  (Math.Abs(column - targetColumn) != Math.Abs(row - targetRow)))
                {
                    Console.WriteLine("Vybraný cílový řádek je neplatný, zkuste vybrat znovu");
                    Console.WriteLine("Vyberte cílový řádek:");
                    targetRow = int.Parse(Console.ReadLine());

                    Console.WriteLine("Vybraný cílový sloupec je neplatný, zkuste vybrat znovu");
                    Console.WriteLine("Vyberte cílový sloupec:");
                    targetColumn = int.Parse(Console.ReadLine());
                }
                
                //akce přeskočení 
                //bílá
                if ((board[row, column] == Board.Tile.pawn_Wh || board[row, column] == Board.Tile.queen_Wh) && (board[targetRow, targetColumn] == Board.Tile.pawn_Bl || board[targetRow, targetColumn] == Board.Tile.queen_Bl))
                {
                    board[targetRow, targetColumn] = Board.Tile.empty;
                    if (board[row, column] == Board.Tile.queen_Wh && row > targetRow)
                    {
                        targetRow--;
                    }
                    else
                    {
                        targetRow++;
                    }
                    if (column > targetColumn)
                    {
                        targetColumn--;
                    }
                    else
                    {
                        targetColumn++;
                    }
                    

                }
                //černá
                if ((board[row, column] == Board.Tile.pawn_Bl || board[row, column] == Board.Tile.queen_Bl) && (board[targetRow, targetColumn] == Board.Tile.pawn_Wh || board[targetRow, targetColumn] == Board.Tile.queen_Wh))
                {
                    board[targetRow, targetColumn] = Board.Tile.empty;
                    if (board[row, column] == Board.Tile.queen_Bl && row < targetRow)
                    {
                        targetRow++;
                    }
                    else
                    {
                        targetRow--;
                    }
                    if (column > targetColumn)
                    {
                        targetColumn--;
                    }
                    else
                    {
                        targetColumn++;
                    }


                }

                

                
                

                




                if (CurrentPlayer == "bílá")
                {
                    if (board[row, column] == Board.Tile.pawn_Wh && targetRow == 7)
                    {
                        board[targetRow, targetColumn] = Board.Tile.queen_Wh;
                    }
                    else if (board[row, column] == Board.Tile.queen_Wh)
                    {
                        board[targetRow, targetColumn] = Board.Tile.queen_Wh;
                    }
                    else
                    {
                        board[targetRow, targetColumn] = Board.Tile.pawn_Wh;
                    }
                    board[row, column] = Board.Tile.empty;
                    CurrentPlayer = "černá";                   
                }

                else
                {
                    if (board[row, column] == Board.Tile.pawn_Bl && targetRow == 0)
                    {
                        board[targetRow, targetColumn] = Board.Tile.queen_Bl;
                    }
                    else if (board[row, column] == Board.Tile.queen_Bl)
                    {
                        board[targetRow, targetColumn] = Board.Tile.queen_Bl;
                    }
                    else
                    {
                        board[targetRow, targetColumn] = Board.Tile.pawn_Bl;
                    }
                    board[row, column] = Board.Tile.empty;
                    CurrentPlayer = "bílá";
                }

                




            }




        }
    }
}
