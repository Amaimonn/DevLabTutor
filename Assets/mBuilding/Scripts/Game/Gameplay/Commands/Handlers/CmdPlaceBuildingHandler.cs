using System.Linq;
using UnityEngine;
// using mBuilding.Scripts.Game.State.Buildings;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Root;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private readonly GameStateProxy _gameState;

        public CmdPlaceBuildingHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        
        public bool Handle(CmdPlaceBuilding command)
        {
            // var currentMap = _gameState.Maps.FirstOrDefault(x => x.Id == _gameState.CurrentMapId.Value);

            // if(currentMap == null)
            // {
            //     Debug.LogError($"Can't find Map with id {_gameState.CurrentMapId.Value}");
            //     return false;
            // }

            // var entityId = _gameState.CreateEntityId();
            // var newBuildingEntity = new BuildingEntity
            // {
            //     Id = entityId,
            //     Position = command.Position,
            //     TypeId = command.BuildingTypeId
            // };

            // var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            
            // currentMap.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}