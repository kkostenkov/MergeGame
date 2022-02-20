using Merge.Board.Conditions;
using Merge.Session;

namespace Merge.Board.Abilities
{
    public class AbilityInstance : IUpdatable
    {
        protected AbilityData Data;
        protected AbilityInstanceData InstanceData;

        private float activationWaitingTime;
        
        public AbilityInstance(AbilityData data, AbilityInstanceData instanceData)
        {
            this.Data = data;
            this.InstanceData = instanceData;
        }

        public virtual void CustomUpdate(float deltaTime)
        {
            if (Data.ActivationCondition is TimerCondition activationTimerCondition)
            {
                activationWaitingTime += deltaTime;
            }

            var ready = CheckIfAbilityIsReady();
        }

        protected virtual bool CheckActivationRequirements()
        {
            return Data.ActivationCondition is TimerCondition activationTimerCondition
                && activationWaitingTime >= activationTimerCondition.IntervalSeconds;
        }

        public bool CheckIfAbilityIsReady()
        {
            var ready = CheckActivationRequirements();
            return ready;

        }
    }
}