﻿// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using ObservableCollections;
// using R3;
// using mBuilding.Scripts.Game.Gameplay.Commands;
// using mBuilding.Scripts.Game.Gameplay.View.Buildings;
// using mBuilding.Scripts.Game.Settings.Gameplay.Buildings;
// using mBuilding.Scripts.Game.State.cmd;

// namespace mBuilding.Scripts.Game.Gameplay.Services
// {
//     public class BuildingsService
//     {
//         public IObservableCollection<BuildingViewModel> AllBuildings => _allBuildings;

//         private readonly ICommandProcessor _cmd;
//         private readonly ObservableList<BuildingViewModel> _allBuildings = new();
//         private readonly Dictionary<int, BuildingViewModel> _buildingsMap = new();
//         private readonly Dictionary<string, BuildingSettings> _buildingSettingsMap = new();

//         public BuildingsService(IObservableCollection<BuildingEntityProxy> buildings, BuildingsSettings buildingsSettings,
//             ICommandProcessor cmd)
//         {
//             _cmd = cmd;

//             foreach (var buildingSettings in buildingsSettings.AllBuildings)
//             {
//                 _buildingSettingsMap[buildingSettings.TypeId] = buildingSettings;
//             }

//             foreach (var buildingEntity in buildings)
//             {
//                 CreateBuildingViewModel(buildingEntity);
//             }

//             buildings.ObserveAdd().Subscribe(e =>
//             {
//                 CreateBuildingViewModel(e.Value);
//             });

//             buildings.ObserveRemove().Subscribe(e =>
//             {
//                 RemoveBuildingViewModel(e.Value);
//             });
//         }

//         public bool PlaceBuilding(string buildingTypeId, Vector3Int position)
//         {
//             var command = new CmdPlaceBuilding(buildingTypeId, position);
//             var result = _cmd.Process(command);

//             return result;
//         }
        
//         public bool MoveBuilding(int buildingEntityId, Vector3Int newPosition)
//         {
//             throw new NotImplementedException();
//         }

//         public bool DeleteBuilding(int buildingEntityId)
//         {
//             throw new NotImplementedException();
//         }

//         private void CreateBuildingViewModel(BuildingEntityProxy buildingEntity)
//         {
//             var buildingSettings = _buildingSettingsMap[buildingEntity.TypeId];
//             var buildingViewModel = new BuildingViewModel(buildingEntity, buildingSettings, this);
            
//             _allBuildings.Add(buildingViewModel);
//             _buildingsMap[buildingEntity.Id] = buildingViewModel;
//         }

//         private void RemoveBuildingViewModel(BuildingEntityProxy buildingEntity)
//         {
//             if (_buildingsMap.TryGetValue(buildingEntity.Id, out var buildingViewModel))
//             {
//                 _allBuildings.Remove(buildingViewModel);
//                 _buildingsMap.Remove(buildingEntity.Id);
//             }
//         }
//     }
// }