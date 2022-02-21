using System.Collections.Generic;
using System.Linq;
using Merge.Board.Abilities;
using Merge.Session;

namespace Merge.Board
{
    public class PieceInstance : IUpdatable
    {
        public string ViewSettingsId => data.ViewSettingsId;
        
        private PieceData data; 
        private PieceInstanceData instanceData;
        private List<AbilityInstance> abilities = new List<AbilityInstance>(); 
        
        public PieceInstance(PieceData data, PieceInstanceData instanceData, Queue<ICanGenerateEffect> pendingEffects)
        {
            this.data = data;
            this.instanceData = instanceData;

            if (data.Abilities != null)
            {
                foreach (var abilityData in data.Abilities)
                {
                    var dataId = abilityData.Id;
                    instanceData.Abilities.TryGetValue(dataId, out var abilityInstanceData);
                    var ability = AbilityFactory.CreateAbility(abilityData, abilityInstanceData, pendingEffects);
                    abilities.Add(ability);
                }
            }
        }

        public void CustomUpdate(float deltaTime)
        {
            for (int i = 0; i < abilities.Count; i++)
            {
                abilities[i].CustomUpdate(deltaTime);
            }
        }
    }
}