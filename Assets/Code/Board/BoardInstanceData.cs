using System.Collections.Generic;


namespace Merge.Board
{
    public class BoardInstanceData
    {
        public readonly string DataId;
        public readonly Dictionary<CellCoordinates, CellInstanceData> Cells = 
            new Dictionary<CellCoordinates, CellInstanceData>();

        public BoardInstanceData(string dataId)
        {
            DataId = dataId;
        }
        
    }
}