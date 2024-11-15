using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingSettings", menuName = "Scriptable Objects/Settings/BuildingSettings")]
    public class BuildingSettings : ScriptableObject
    {
        public string TypeId;
        public string LevelLID;
        public string DescriptionLID;
        public List<BuildingLevelSettings> LevelSettings;
    }
}
