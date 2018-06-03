using System;

namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal interface IGame
    {
        int [] FieldCells { get; set; }
        int IsWinner { get; set; }
        event Action<int> SomethingHappendOnTheField;
        event Action Reset;
        event Action PlayerUndo;
    }
}
