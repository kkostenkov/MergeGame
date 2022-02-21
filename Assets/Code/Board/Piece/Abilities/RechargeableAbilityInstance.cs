using System;
using System.Collections.Generic;
using Merge.Board.Abilities.Effects;
using Merge.Board.Conditions;
using Merge.Session;

namespace Merge.Board.Abilities
{
    public class RechargeableAbilityInstance : AbilityInstance
    {
        protected new RechargeableAbilityData Data => base.Data as RechargeableAbilityData;
        protected new RechargeableAbilityInstanceData InstanceData => 
            base.InstanceData as RechargeableAbilityInstanceData;

        public RechargeableAbilityInstance(AbilityData data, AbilityInstanceData instanceData, 
            Queue<ICanGenerateEffect> pendingEffects) : base(data, instanceData, pendingEffects)
        {
        }

        public override void CustomUpdate(float deltaTime)
        {
            if (Data.RechargeCondition is TimerCondition rechargeTimerCondition)
            {
                InstanceData.RechargeTimerElapsed += deltaTime;
                var interval = rechargeTimerCondition.IntervalSeconds;
                if (InstanceData.RechargeTimerElapsed >= interval)
                {
                    InstanceData.RechargeTimerElapsed -= interval;
                    InstanceData.CurrentCharges += 1;
                    InstanceData.CurrentCharges = InstanceData.CurrentCharges.Clamp(0, Data.ChargesCapacity);
                }
            }
            base.CustomUpdate(deltaTime);
        }
        
        protected override bool CheckActivationRequirements()
        {
            return InstanceData.CurrentCharges > 0 && base.CheckActivationRequirements();
        }
    }
}