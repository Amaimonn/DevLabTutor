using System.Collections.Generic;
using mBuilding.Scripts.Game.Settings.Gameplay.Maps;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "MapsSettings", menuName = "Scriptable Objects/Settings/Maps/Maps Settings")]
    public class MapsSettings : ScriptableObject
    {        
        public List<MapSettings> AllMaps;
    }
}