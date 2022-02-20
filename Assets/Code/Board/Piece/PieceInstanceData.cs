using System.Collections.Generic;
using Merge.Board.Abilities;

namespace Merge.Board
{
    public class PieceInstanceData
    {
        public readonly string DataId;
        public Dictionary<string, AbilityInstanceData> Abilities = new Dictionary<string, AbilityInstanceData>();

        public PieceInstanceData(string dataId)
        {
            DataId = dataId;
        }
    }
}