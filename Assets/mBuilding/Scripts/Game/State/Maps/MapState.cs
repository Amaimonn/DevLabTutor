using System;
using System.Collections.Generic;

using mBuilding.Scripts.Game.State.Entities;

namespace mBuilding.Scripts.Game.State.Maps
{
    [Serializable]
    public class MapState
    {
        public int Id;
        public List<EntityState> Entities;
    }
}