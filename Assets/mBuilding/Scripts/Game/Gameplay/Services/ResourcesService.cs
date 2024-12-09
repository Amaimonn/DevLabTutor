using System;
using System.Collections.Generic;
using ObservableCollections;
using R3;
using mBuilding.Scripts.Game.Gameplay.Commands;
using mBuilding.Scripts.Game.Gameplay.View.GameResources;
using mBuilding.Scripts.Game.State.GameResources;
using mBuilding.Scripts.Game.State.cmd;

namespace mBuilding.Scripts.Game.Gameplay.Services
{
    public class ResourcesService
    {
        public IObservableCollection<ResourceViewModel> Resources => _resources;

        private readonly ICommandProcessor _cmd;
        private readonly ObservableList<ResourceViewModel> _resources = new();
        private readonly Dictionary<ResourceType, ResourceViewModel> _resourcesMap = new();

        public ResourcesService(IObservableCollection<Resource> resources, ICommandProcessor cmd)
        {
            _cmd = cmd;

            foreach (var resource in resources)
            {
                CreateResourceViewModel(resource);
            }

            resources.ObserveAdd().Subscribe(e => CreateResourceViewModel(e.Value));
            resources.ObserveRemove().Subscribe(e => RemoveResourceViewModel(e.Value));
            _cmd = cmd;
        }

        public bool AddResources(ResourceType resourceType, int amount)
        {
            var command = new CmdResourcesAdd(resourceType, amount);
            var result = _cmd.Process(command);

            return result;
        }

        public bool TrySpendResources(ResourceType resourceType, int amount)
        {
            var command = new CmdResourcesSpend(resourceType, amount);
            var result = _cmd.Process(command);

            return result;
        }

        public bool IsEnoughResources(ResourceType resourceType, int amount)
        {
            if (_resourcesMap.TryGetValue(resourceType, out var resourceViewModel))
                return resourceViewModel.Amount.CurrentValue >= amount;

            return false;
        }

        public Observable<int> ObserveResource(ResourceType resourceType)
        {
            if (_resourcesMap.TryGetValue(resourceType, out var resourceViewModel))
                return resourceViewModel.Amount;

            throw new Exception($"Resource of type {resourceType} doesn't exist");
        }

        private void CreateResourceViewModel(Resource resource)
        {
            var resourceViewModel = new ResourceViewModel(resource);

            _resourcesMap[resource.ResourceType] = resourceViewModel;
            _resources.Add(resourceViewModel);
        }

        private void RemoveResourceViewModel(Resource resource)
        {
            if (_resourcesMap.TryGetValue(resource.ResourceType, out var resourceViewModel))
            {
                _resources.Remove(resourceViewModel);
                _resourcesMap.Remove(resource.ResourceType);
            }
        }
    }
}