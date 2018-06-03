using System;
using System.Collections.Generic;

namespace Pattern_Command_Game_Cross_and_Zeroes
{
    internal class Game : ICloneable
    {
        public int[] Field { get; set; } = new int[9];
        public int Count { get; set; }
        public bool IsMoveSuccessful { get; set; }
        public int WhoIsWinner { get; set; }

        public void Player_Move(int pos)
        {
            if (Field[pos] != 0) return;
            IsMoveSuccessful = true;
            Field[pos] = 1;
            Count++;
            if (WinnerCheck(1))
                WhoIsWinner = 1;
        }

        public void AI_Move()
        {
            var flag = true;
            if(Count < 9)
            {
                while(flag)
                {
                    var choose = new Random(Guid.NewGuid().GetHashCode()).Next(0, 9);
                    if (Field[choose] != 0) continue;
                    Field[choose] = 2;
                    flag = false;
                    Count++;
                }
            }
            if (WinnerCheck(2))
                WhoIsWinner = 2;
            IsMoveSuccessful = default(bool);
        }

        private bool WinnerCheck(int i)
        {
            return Field[0] == i && Field[1] == i && Field[2] == i ||
                   Field[3] == i && Field[4] == i && Field[5] == i ||
                   Field[6] == i && Field[7] == i && Field[8] == i ||

                   Field[0] == i && Field[3] == i && Field[6] == i ||
                   Field[1] == i && Field[4] == i && Field[7] == i ||
                   Field[2] == i && Field[5] == i && Field[8] == i ||

                   Field[0] == i && Field[4] == i && Field[8] == i ||
                   Field[2] == i && Field[4] == i && Field[6] == i;
        }

        public object Clone()
        {
            var temp = new Game();
            for (var i = 0; i < 9; i++)
            {
                temp.Field[i] = Field[i];
            }
            temp.Count = Count;
            temp.IsMoveSuccessful = IsMoveSuccessful;
            return temp;
        }
    }
}

