using Merge.Board.Abilities;

namespace Merge.Session
{
    public static class AbilityFactory
    {
        public static AbilityInstance CreateAbility(AbilityData abilityData, 
            AbilityInstanceData abilityInstanceData)
        {
            AbilityInstance newAbility;
            switch (abilityData)
            {
                case ProducerAbilityData producer:
                {
                    if (abilityInstanceData == null)
                    {
                        abilityInstanceData = new ProducerAbilityInstanceData() {DataId = abilityData.Id};
                    }
                    newAbility = new ProducerAbilityInstance(abilityData, abilityInstanceData);
                    break;
                }
                case RechargeableAbilityData rechargable:
                {
                    if (abilityInstanceData == null)
                    {
                        abilityInstanceData = new RechargeableAbilityInstanceData() {DataId = abilityData.Id};
                    }
                    newAbility = new RechargeableAbilityInstance(abilityData, abilityInstanceData);
                    break;
                }
                default:
                {
                    if (abilityInstanceData == null)
                    {
                        abilityInstanceData = new AbilityInstanceData() {DataId = abilityData.Id};
                    }
                    newAbility = new AbilityInstance(abilityData, abilityInstanceData); 
                    break;
                }
            }

            return newAbility;
        }
    }
}