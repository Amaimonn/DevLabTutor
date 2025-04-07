using UnityEngine;

namespace mBuilding.Scripts.Game.State.Entities
{
    public class EntityState
    {
        public int UniqueId { get; set; }
        public string ConfigId { get; set; }
        public EntityType Type { get; set; }
        public Vector2Int Position { get; set; }
    }
}