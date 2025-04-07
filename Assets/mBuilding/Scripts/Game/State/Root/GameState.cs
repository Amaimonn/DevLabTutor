using System;
using System.Collections.Generic;

using mBuilding.Scripts.Game.State.GameResources;
using mBuilding.Scripts.Game.State.Maps;

namespace mBuilding.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId { get; set; }
        public int CurrentMapId { get; set; }
        public List<MapState> Maps { get; set; }
        public List<ResourceData> Resources { get; set; }

        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}