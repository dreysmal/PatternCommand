namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal class CommandAiMove : ICommand
    {
        private readonly Game _game;
        public CommandAiMove(Game game)
        {
            _game = game;
        }
        public void Execute()
        {
            _game.AI_Move();
        }

        public void Undo()
        {
            //do nothing here(
        }
    }
}
