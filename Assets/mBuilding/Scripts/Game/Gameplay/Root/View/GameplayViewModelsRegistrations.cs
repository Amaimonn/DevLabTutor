﻿using BaCon;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Gameplay.View.UI;

namespace mBuilding.Scripts.Game.Gameplay.Root.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new GameplayUIManager(container)).AsSingle();
            container
                .RegisterFactory(c => new UIGameplayRootViewModel())
                .AsSingle();
                
            container
                .RegisterFactory(c => new WorldGameplayRootViewModel(
                    // c.Resolve<BuildingsService>(), 
                    c.Resolve<ResourcesService>()))
                .AsSingle();
        }
    }
}