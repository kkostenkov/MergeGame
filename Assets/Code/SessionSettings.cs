using Merge.Board;

namespace Merge
{
    public class SessionSettings
    {
        public string Id;
        
        public PieceData[] StartingPieces;
        public BoardData BoardData { get; set; }
    }
}