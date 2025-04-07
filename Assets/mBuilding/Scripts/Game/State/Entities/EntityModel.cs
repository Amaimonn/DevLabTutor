using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.State.Entities
{
    public abstract class EntityModel
    {
        public EntityState Origin { get; }
        public int UniqueId => Origin.UniqueId;
        public string ConfigId => Origin.ConfigId;
        public EntityType Type => Origin.Type;
        
        public readonly ReactiveProperty<Vector2Int> Position;

        public EntityModel(EntityState state)
        {
            Origin = state;

            Position = new ReactiveProperty<Vector2Int>(state.Position);
            Position.Skip(1).Subscribe(newPosition => { state.Position = newPosition; });
        }
    }
}