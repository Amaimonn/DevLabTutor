using R3;

namespace mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings
{
    public class BuildingEntityModel : MergeableEntityModel
    {
        public readonly ReactiveProperty<double> LastClickedTimeMs;
        public readonly ReactiveProperty<bool> IsAutoCollectionEnabled;
        
        public BuildingEntityModel(BuildingEntityState state) : base(state)
        {
            LastClickedTimeMs = new ReactiveProperty<double>(state.LastClickedTimeMS);
            LastClickedTimeMs.Subscribe(newLastClickedTime => state.LastClickedTimeMS = newLastClickedTime);

            IsAutoCollectionEnabled = new ReactiveProperty<bool>(state.IsAutoCollectionEnabled);
            IsAutoCollectionEnabled.Subscribe(newValue => state.IsAutoCollectionEnabled = newValue);
        }
    }
}