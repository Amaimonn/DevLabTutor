using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingsSettings", menuName = "Scriptable Objects/Settings/BuildingsSettings")]
    public class BuildingsSettings : ScriptableObject
    {        
        public List<BuildingSettings> AllBuildings;
    }
}
