using R3;
using mBuilding.Scripts.Game.State.GameResources;

namespace mBuilding.Scripts.Game.Gameplay.View.GameResources
{
    public class ResourceViewModel
    {
        public readonly ResourceType ResourceType;
        public readonly ReadOnlyReactiveProperty<int> Amount;

        public ResourceViewModel(Resource resource)
        {
            ResourceType = resource.ResourceType;
            Amount = resource.Amount;
        }
    }
}