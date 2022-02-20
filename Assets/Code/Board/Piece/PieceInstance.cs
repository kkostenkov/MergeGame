namespace Merge.Board
{
    public class PieceInstance
    {
        public string ViewSettingsId => data.ViewSettingsId;
        
        private PieceData data; 
        private PieceInstanceData instanceData;
        
        public PieceInstance(PieceData data, PieceInstanceData instanceData)
        {
            this.data = data;
            this.instanceData = instanceData;
        }
    }
}