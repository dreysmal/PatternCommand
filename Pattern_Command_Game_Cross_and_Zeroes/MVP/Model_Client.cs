namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal class ModelClient
    {
        private Game _game = new Game();
        private readonly Invoker _invoker = new Invoker();

        public int[] FieldCells { get; set; }
        public int WhoIsWinner { get; set; }

        public ModelClient()
        {
            _invoker.SetCommandAi(new CommandAiMove(_game));
        }
        public void MakeMove(int pos)
        {
            _invoker.SetCommandPlayer(new CommandPlayerMove(_game, pos));

            _invoker.PlayerMakesMove();

            if (_game.WhoIsWinner == 1)
            {
                WhoIsWinner = _game.WhoIsWinner;
                return;
            }

            if (!_game.IsMoveSuccessful)
            {
                _invoker.PlayerUndo();
                return;
            }

            _invoker.AiMakesMove();

            FieldCells = _game.Field;
            if (_game.WhoIsWinner == 2)
            {
                WhoIsWinner = _game.WhoIsWinner;
            }
        }

        public void UndoPlayer()
        {
            _invoker.PlayerUndo();
            FieldCells = _game.Field;
        }

        public void Reset()
        {
            _game = new Game();
            WhoIsWinner = _game.WhoIsWinner;
            _invoker.SetCommandAi(new CommandAiMove(_game));
        }
    }
}
