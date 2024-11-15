using UnityEngine;

using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;

namespace mBuilding.Scripts.Game.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public BuildingsSettings BuildingsSettings;
    }
}
