using System.Collections.Generic;

namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal class Invoker
    {
        private ICommand _commandPlayer;
        private ICommand _commandAi;
        private readonly Stack<ICommand> _undoPlayerCommands = new Stack<ICommand>();
        public void SetCommandPlayer(ICommand command)
        {
            _commandPlayer = command;
        }
        public void SetCommandAi(ICommand command)
        {
            _commandAi = command;
        }
        public void PlayerMakesMove()
        {
            _undoPlayerCommands.Push(_commandPlayer);
            _commandPlayer.Execute();
        }
        public void AiMakesMove()
        {
            _commandAi.Execute();
        }

        public void PlayerUndo()
        {
            if (_undoPlayerCommands.Count > 0)
                _undoPlayerCommands.Pop().Undo();
        }
    }
}
