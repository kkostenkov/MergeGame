using System;
using Merge.Board.Conditions;

namespace Merge.Board.Abilities
{
    public class RechargeableAbilityInstance : AbilityInstance
    {
        protected new RechargeableAbilityData Data => base.Data as RechargeableAbilityData;
        protected new RechargeableAbilityInstanceData InstanceData => 
            base.InstanceData as RechargeableAbilityInstanceData;

        public RechargeableAbilityInstance(AbilityData data, AbilityInstanceData instanceData) 
            : base(data, instanceData)
        {
        }

        public override void CustomUpdate(float deltaTime)
        {
            if (Data.RechargeCondition is TimerCondition rechargeTimerCondition)
            {
                InstanceData.RechargeTimerElapsed += deltaTime;
                var interval = rechargeTimerCondition.IntervalSeconds;
                if (rechargeTimerCondition.IntervalSeconds >= interval)
                {
                    rechargeTimerCondition.IntervalSeconds -= interval;
                    InstanceData.CurrentCharges += 1;
                    InstanceData.CurrentCharges = InstanceData.CurrentCharges.Clamp(0, Data.ChargesCapacity);
                }
            }
            base.CustomUpdate(deltaTime);
        }
        
        protected override bool CheckActivationRequirements()
        {
            return InstanceData.CurrentCharges >= 0 && base.CheckActivationRequirements();
        }
    }
}