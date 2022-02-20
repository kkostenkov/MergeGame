namespace Merge.Board
{
    public class PieceInstance
    {
        private PieceData data; 
        private PieceInstanceData instanceData;
        
        public PieceInstance(PieceData data, PieceInstanceData instanceData)
        {
            this.data = data;
            this.instanceData = instanceData;
        }
    }
}