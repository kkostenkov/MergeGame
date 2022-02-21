using System.Collections.Generic;
using Merge.Session;

namespace Merge.Board
{
    public interface ICell
    {
        
    }
    
    
    public class CellInstance : ICell
    {
        public CellCoordinates Coords => data.Coords;

        private CellData data;
        private CellInstanceData instanceData;

        public PieceInstance OccupantPiece
        {
            get;
            private set;
        }
        
        public CellInstance(CellData data, CellInstanceData instanceData)
        {
            this.data = data;
            this.instanceData = instanceData;
        }

        public void PlacePiece(PieceInstance piece)
        {
            OccupantPiece = piece;
        }

        public PieceInstance RemovePiece()
        {
            var piece = OccupantPiece;
            OccupantPiece = null;
            return piece;
        }
    }
}