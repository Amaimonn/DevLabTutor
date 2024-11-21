using System.Collections.Generic;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
using mBuilding.Scripts.Game.State.Buildings;
using R3;
using UnityEngine;

namespace mBuilding.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        public readonly int BuildingEntityId;
        public readonly string TypeId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }

        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        private readonly BuildingsService _buildingsService;
        private Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();


        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingSettings buildingSettings,
            BuildingsService buildingsService)
        {
            BuildingEntityId = buildingEntity.Id;
            TypeId = buildingEntity.TypeId;
            Level = buildingEntity.Level;
            
            _buildingEntity = buildingEntity;
            _buildingSettings = buildingSettings;

            foreach (var buildingLevelSettings in buildingSettings.LevelSettings)
            {
                _levelSettingsMap[buildingLevelSettings.Level] = buildingLevelSettings;
            }

            _buildingsService = buildingsService;

            Position = buildingEntity.Position;
        }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}