using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using mBuilding.Scripts.Game.Settings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Root;
using mBuilding.Scripts.Game.State.Maps;
using mBuilding.Scripts.Game.State.Entities;
using mBuilding.Scripts.Game.State.Entities.Mergeable.Buildings;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdCreateMapStateHandler : ICommandHandler<CmdCreateMapState>
    {
        private readonly GameStateProxy _gameState;
        private readonly GameSettings _gameSettings;

        public CmdCreateMapStateHandler(GameStateProxy gameState, GameSettings gameSettings)
        {
            _gameState = gameState;
            _gameSettings = gameSettings;
        }

        public bool Handle(CmdCreateMapState command)
        {
            var isMapAlreadyExist = _gameState.Maps.Any(x => x.Id == command.MapId);

            if (isMapAlreadyExist)
            {
                Debug.LogError($"Map with id {command.MapId} Idalready exist");
                return false;
            }

            var newMapSettings = _gameSettings.MapsSettings.AllMaps.First(x => x.MapId == command.MapId);
            var newMapInitialStateSettings = newMapSettings.InitialStateSettings;
            var initialEntities = new List<EntityState>();

            foreach (var buildingSettings in newMapInitialStateSettings.Buildings)
            {
                var initialBuilding = new BuildingEntityState
                {
                    UniqueId = _gameState.CreateEntityId(),
                    ConfigId = buildingSettings.TypeId,
                    Type = EntityType.Building,
                    Position = buildingSettings.Position,
                    Level = buildingSettings.Level,
                    IsAutoCollectionEnabled = false,
                    LastClickedTimeMS = 0
                };

                initialEntities.Add(initialBuilding);
            }

            var newMapState = new MapState
            {
                Id = command.MapId,
                Entities = initialEntities
            };
            var newMap = new MapModel(newMapState);
            
            _gameState.Maps.Add(newMap);

            return true;
        }
    }
}