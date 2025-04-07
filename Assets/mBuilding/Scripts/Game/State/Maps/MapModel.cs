using System.Linq;
using ObservableCollections;
using R3;

using mBuilding.Scripts.Game.State.Entities;

namespace mBuilding.Scripts.Game.State.Maps
{
    public class MapModel
    {
        public int Id => Origin.Id;
        public ObservableList<EntityModel> Entities { get; } = new();
        public MapState Origin { get; }

        public MapModel(MapState mapState)
        {
            Origin = mapState;
            mapState.Entities.ForEach(entityData => Entities.Add(EntityModelsFactory.CreateEntity(entityData)));

            Entities.ObserveAdd().Subscribe(e =>
            {
                var addedEntity = e.Value;
                mapState.Entities.Add(addedEntity.Origin);
            });

            Entities.ObserveRemove().Subscribe(e =>
            {
                var removedEntity = e.Value;
                var removedEntityData = mapState.Entities.FirstOrDefault(b => b.UniqueId == removedEntity.UniqueId);
                mapState.Entities.Remove(removedEntityData);
            });
        }
    }
}