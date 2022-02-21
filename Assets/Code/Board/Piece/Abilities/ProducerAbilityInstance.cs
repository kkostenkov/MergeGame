using System.Collections.Generic;
using Merge.Board.Abilities.Effects;
using Merge.Session;

namespace Merge.Board.Abilities
{
    public class ProducerAbilityInstance : RechargeableAbilityInstance
    {
        protected new ProducerAbilityData Data => base.Data as ProducerAbilityData;
        protected new ProducerAbilityInstanceData InstanceData => 
            base.InstanceData as ProducerAbilityInstanceData;
        
        public ProducerAbilityInstance(AbilityData data, AbilityInstanceData instanceData, 
            Queue<ICanGenerateEffect> pendingEffects) : base(data, instanceData, pendingEffects)
        {
            instanceData = instanceData ?? new ProducerAbilityInstanceData(){ DataId = data.Id };
        }
        
        protected override bool CheckActivationRequirements()
        {
            return base.CheckActivationRequirements();
        }

        public override Effect GenerateEffect()
        {
            if (!IsAbilityReady)
            {
                return Effect.None;
            }

            InstanceData.CurrentCharges -= 1;
            
            return new SpawnPieceEffect() {Id = Data.SpawnId};
        }
    }
}