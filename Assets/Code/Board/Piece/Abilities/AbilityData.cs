using Merge.Board.Conditions;

namespace Merge.Board.Abilities
{
    public class AbilityData
    {
        public string Id;
        public Condition ActivationCondition;
    }

    public class RechargeableAbilityData : AbilityData
    {
        public int InitialChargesCount;
        public int ChargesCapacity;
        public Condition RechargeCondition;
    }

    public class ProducerAbilityData : RechargeableAbilityData
    {
        public string SpawnId;
    }
}