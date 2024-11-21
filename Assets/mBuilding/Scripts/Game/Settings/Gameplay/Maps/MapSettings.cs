using UnityEngine;

namespace mBuilding.Scripts.Game.Settings.Gameplay.Maps
{
    [CreateAssetMenu(fileName = "MapSettings", menuName = "Scriptable Objects/Settings/Maps/Map Settings")]
    public class MapSettings : ScriptableObject
    {
        public int MapId;
        public MapInitialStateSettings InitialStateSettings;
    }
}