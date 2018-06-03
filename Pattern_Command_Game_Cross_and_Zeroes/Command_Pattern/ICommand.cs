namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }
}
