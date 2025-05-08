// See https://aka.ms/new-console-template for more information

using Boggle;

BoggleDice _dice = new BoggleDice();
DiceBoard _board = new DiceBoard(_dice);

_board.MakeBoard();
Console.WriteLine(_board);

