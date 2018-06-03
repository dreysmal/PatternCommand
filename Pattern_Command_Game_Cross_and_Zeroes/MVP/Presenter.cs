namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal class Presenter
    {
        private readonly IGame _igame;
        private readonly ModelClient _modelClient = new ModelClient();

        public Presenter(IGame igame)
        {
            _igame = igame;
            _igame.SomethingHappendOnTheField += Igame_SomethingHappendOnTheField;
            _igame.Reset += () => _modelClient.Reset();
            _igame.PlayerUndo += PlayerUndo;
        }

        public void Igame_SomethingHappendOnTheField(int pos)
        {
            _modelClient.MakeMove(pos);
            _igame.IsWinner = _modelClient.WhoIsWinner;
            _igame.FieldCells = _modelClient.FieldCells;
        }

        public void PlayerUndo()
        {
            _modelClient.UndoPlayer();
            _igame.FieldCells = _modelClient.FieldCells;
        }
    }
}
