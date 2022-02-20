using System;

namespace Merge.Board
{
    public class PieceSpawnedArgs : EventArgs
    {
        public CellCoordinates Coords;
        public PieceInstance Piece;
    }
}