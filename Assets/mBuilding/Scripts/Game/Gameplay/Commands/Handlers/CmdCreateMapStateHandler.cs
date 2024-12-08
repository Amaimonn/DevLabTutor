using System.Linq;
using UnityEngine;
using mBuilding.Scripts.Game.Settings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Root;
using System.Collections.Generic;
using mBuilding.Scripts.Game.State.Buildings;
using mBuilding.Scripts.Game.State.Maps;

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
            var initialBuildings = new List<BuildingEntity>();

            foreach (var buildingSettints in newMapInitialStateSettings.Buildings)
            {
                var initialBuilding = new BuildingEntity
                {
                    Id = _gameState.CreateEntityId(),
                    TypeId = buildingSettints.TypeId,
                    Position = buildingSettints.Position,
                    Level = buildingSettints.Level
                };

                initialBuildings.Add(initialBuilding);
            }

            var newMapState = new MapState
            {
                Id = command.MapId,
                Buildings = initialBuildings
            };
            var newMap = new Map(newMapState);
            
            _gameState.Maps.Add(newMap);

            return true;
        }
    }
}