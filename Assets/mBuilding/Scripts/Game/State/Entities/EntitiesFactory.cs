using System;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;
using mBuilding.Scripts.Game.State.Entities.Mergeable.ResourcesEntities;

namespace mBuilding.Scripts.Game.State.Entities
{
    public static class EntityModelsFactory
    {
        public static EntityModel CreateEntity(EntityState entityState)
        {
            switch (entityState.Type)
            {
                case EntityType.Building:
                    return new BuildingEntityModel(entityState as BuildingEntityState);

                case EntityType.Resource:
                    return new ResourceEntityModel(entityState as ResourceEntityState);

                default:
                    throw new Exception("Unsupported entity type: " + entityState.Type);
            }
        }
    }
}