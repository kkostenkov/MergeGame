using System.Collections.Generic;
using Merge.Board;
using Merge.Storage;

namespace Merge
{
    public interface IPieceFactory
    {
        IEnumerable<PieceInstance> Create(PieceData[] pieces);
        PieceInstance Create(PieceData pieceData);
    }
    
    public class PieceFactory : IPieceFactory
    {
        private IDataStorage dataStorage;
        
        public PieceFactory(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public IEnumerable<PieceInstance> Create(PieceData[] pieces)
        {
            foreach (var pieceData in pieces)
            {
                yield return Create(pieceData);
            }
        }

        public PieceInstance Create(PieceData data)
        {
            var pieceData = dataStorage.GetPiece(data.Id);
            var instanceData = new PieceInstanceData(data.Id);
            var piece = new PieceInstance(pieceData, instanceData);
            return piece;
        }
    }
}