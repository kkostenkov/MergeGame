using System.Collections.Generic;
using Merge.Board.Abilities.Effects;
using Merge.Board.Conditions;
using Merge.Session;

namespace Merge.Board.Abilities
{
    public class AbilityInstance : IUpdatable, ICanGenerateEffect
    {
        protected AbilityData Data;
        protected AbilityInstanceData InstanceData;
        protected bool IsAbilityReady { get; set; }
        private Queue<ICanGenerateEffect> pendingEffects;

        private float activationWaitingTime;
        
        public AbilityInstance(AbilityData data, AbilityInstanceData instanceData, 
            Queue<ICanGenerateEffect> pendingEffects)
        {
            this.Data = data;
            this.InstanceData = instanceData;
            this.pendingEffects = pendingEffects;
        }

        public virtual void CustomUpdate(float deltaTime)
        {
            if (Data.ActivationCondition is TimerCondition activationTimerCondition)
            {
                activationWaitingTime += deltaTime;
            }

            IsAbilityReady = CheckActivationRequirements(); 
            if (IsAbilityReady)
            {
                pendingEffects.Enqueue(this);
            }
        }

        protected virtual bool CheckActivationRequirements()
        {
            return Data.ActivationCondition is TimerCondition activationTimerCondition
                && activationWaitingTime >= activationTimerCondition.IntervalSeconds;
        }

        public virtual Effect GenerateEffect()
        {
            return Effect.None;
        }
    }
}