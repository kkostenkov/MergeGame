using System.Collections.Generic;
using Merge.Board;
using Merge.Storage;

namespace Merge.Session
{
    public interface IPieceFactory
    {
        IEnumerable<PieceInstance> Create(PieceData[] pieces, Queue<ICanGenerateEffect> pendingEffects);
        PieceInstance Create(PieceData pieceData, Queue<ICanGenerateEffect> pendingEffects);
    }
    
    public class PieceFactory : IPieceFactory
    {
        private IDataStorage dataStorage;
        
        public PieceFactory(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public IEnumerable<PieceInstance> Create(PieceData[] pieces, Queue<ICanGenerateEffect> pendingEffects)
        {
            foreach (var pieceData in pieces)
            {
                yield return Create(pieceData, pendingEffects);
            }
        }

        public PieceInstance Create(PieceData data, Queue<ICanGenerateEffect> pendingEffects)
        {
            var pieceData = dataStorage.GetPiece(data.Id);
            var instanceData = new PieceInstanceData(data.Id);
            var piece = new PieceInstance(pieceData, instanceData, pendingEffects);
            return piece;
        }
    }
}