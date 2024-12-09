using System;
using ObservableCollections;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Gameplay.View.Buildings;
using mBuilding.Scripts.Game.State.GameResources;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        private readonly ResourcesService _resourceService;

        public WorldGameplayRootViewModel(BuildingsService buildingsService, ResourcesService resourcesService)
        {
            AllBuildings = buildingsService.AllBuildings;
            _resourceService = resourcesService;

            resourcesService.ObserveResource(ResourceType.SoftCurrency)
                .Subscribe(newValue => Debug.Log($"SoftCurrency: {newValue}"));

            resourcesService.ObserveResource(ResourceType.HardCurrency)
                .Subscribe(newValue => Debug.Log($"HardCurrency: {newValue}"));    
        }

        public void HandleTestInput()
        {
            var rResourceType = (ResourceType)Random.Range(1, Enum.GetNames(typeof(ResourceType)).Length + 1);
            var rAmount = Random.Range(0, 1001);
            var rCommand = Random.Range(0, 2);

            if (rCommand == 0)
            {
                _resourceService.AddResources(rResourceType, rAmount);
                return;
            }

            _resourceService.TrySpendResources(rResourceType, rAmount);
        }
    }
}