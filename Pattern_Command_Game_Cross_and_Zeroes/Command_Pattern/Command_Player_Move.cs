using System.Collections.Generic;

namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal class CommandPlayerMove : ICommand
    {
        private readonly Game _game;
        private readonly Game _prevGame;
        private readonly int _position;

        public CommandPlayerMove(Game game, int position)
        {
            _prevGame = (Game)game.Clone();
            _game = game;
            _position = position;
        }

        public void Execute()
        {
            _game.Player_Move(_position);
        }

        public void Undo()
        {
            for (var i = 0; i < 9; i++)
            {
                _game.Field[i] = _prevGame.Field[i];
            }
            _game.IsMoveSuccessful = _prevGame.IsMoveSuccessful;
            _game.Count = _prevGame.Count;
        }
    }
}
