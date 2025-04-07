using R3;

namespace mBuilding.Scripts.Game.State.Entities.Mergeable
{
    public abstract class MergeableEntityModel : EntityModel
    {
        public readonly ReactiveProperty<int> Level;
        
        public MergeableEntityModel(MergeableEntityState data) : base(data)
        {
            Level = new ReactiveProperty<int>(data.Level);
            Level.Subscribe(newValue => data.Level = newValue);
        }
    }
}