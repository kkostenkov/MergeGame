namespace Merge.Board.Abilities
{
    public class ProducerAbilityInstance : RechargeableAbilityInstance
    {
        protected new ProducerAbilityData Data => base.Data as ProducerAbilityData;
        protected new ProducerAbilityInstanceData InstanceData => 
            base.InstanceData as ProducerAbilityInstanceData;
        
        public ProducerAbilityInstance(AbilityData data, AbilityInstanceData instanceData) 
            : base(data, instanceData)
        {
            instanceData = instanceData ?? new ProducerAbilityInstanceData(){ DataId = data.Id };
        }
        
        protected override bool CheckActivationRequirements()
        {
            return base.CheckActivationRequirements();
        }
    }
}