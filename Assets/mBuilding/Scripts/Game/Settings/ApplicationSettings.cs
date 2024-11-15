using UnityEngine;

namespace mBuilding.Scripts.Game.Settings
{
    [CreateAssetMenu(fileName = "ApplicationSetting", menuName = "Scriptable Objects/Settings/ApplicationSetting")]
    public class ApplicationSettings : ScriptableObject
    {
        public int MusicVolume;
        public int SFXVolume;
        public string Difficulty;
    }
}
