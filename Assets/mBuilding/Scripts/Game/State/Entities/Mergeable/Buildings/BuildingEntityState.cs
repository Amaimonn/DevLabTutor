namespace mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings
{
    public class BuildingEntityState : MergeableEntityState
    {
        public double LastClickedTimeMS { get; set; }
        public bool IsAutoCollectionEnabled { get; set; }
    }
}
