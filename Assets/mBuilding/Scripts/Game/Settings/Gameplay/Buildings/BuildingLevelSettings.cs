using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingLevelSettings", menuName = "Scriptable Objects/Settings/BuildingLevelSettings")]
    public class BuildingLevelSettings : ScriptableObject
    {
        public int Level;
        public double BaseIncome;
    }
}
