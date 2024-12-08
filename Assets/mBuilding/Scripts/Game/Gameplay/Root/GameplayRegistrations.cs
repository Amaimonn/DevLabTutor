using System;
using System.Linq;
using BaCon;
using mBuilding.Scripts.Game.Gameplay.Commands;
using mBuilding.Scripts.Game.Gameplay.Services;
using mBuilding.Scripts.Game.Settings;
using mBuilding.Scripts.Game.State;
using mBuilding.Scripts.Game.State.cmd;

namespace mBuilding.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;
            var settingsProvider = container.Resolve<ISettingsProvider>();
            var gameSettings = settingsProvider.GameSettings;
            var cmd = new CommandProcessor(gameStateProvider);
            
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            cmd.RegisterHandler(new CmdCreateMapStateHandler(gameState, gameSettings));
            cmd.RegisterHandler(new CmdResourcesAddHandler(gameState));
            cmd.RegisterHandler(new CmdResourcesSpendHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);

            var loadingMapId = gameplayEnterParams.MapId;
            var loadingMap = gameStateProvider.GameState.Maps.FirstOrDefault(x => x.Id == loadingMapId);

            if (loadingMap == null)
            {
                var command = new CmdCreateMapState(loadingMapId);
                var success = cmd.Process(command);

                if (!success)
                {
                    throw new Exception($"Failed to create map state with id = {loadingMapId}");
                }

                loadingMap = gameStateProvider.GameState.Maps.FirstOrDefault(x => x.Id == loadingMapId);
            }
            
            container.RegisterFactory(_ => new BuildingsService(
                loadingMap.Buildings, 
                gameSettings.BuildingsSettings, 
                cmd)
            ).AsSingle();
        }
    }
}