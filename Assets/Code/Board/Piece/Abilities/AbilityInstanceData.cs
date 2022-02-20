namespace Merge.Board.Abilities
{
    public class AbilityInstanceData
    {
        public string DataId;
    }

    public class RechargeableAbilityInstanceData : AbilityInstanceData
    {
        public int CurrentCharges;
        public float RechargeTimerElapsed;
    }

    public class ProducerAbilityInstanceData : RechargeableAbilityInstanceData
    {
        
    }
}