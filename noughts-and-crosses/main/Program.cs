// See https://aka.ms/new-console-template for more information

using System;
using static Board;
namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board("X", "O");
            
            board.StartGame();

            
        }
    }
}
