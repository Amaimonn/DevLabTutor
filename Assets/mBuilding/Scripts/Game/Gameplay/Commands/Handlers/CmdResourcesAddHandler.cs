using System.Linq;
using mBuilding.Scripts.Game.State.cmd;
using mBuilding.Scripts.Game.State.Root;
using mBuilding.Scripts.Game.State.GameResources;

namespace mBuilding.Scripts.Game.Gameplay.Commands
{
    public class CmdResourcesAddHandler : ICommandHandler<CmdResourcesAdd>
    {
        private readonly GameStateProxy _gameState;

        public CmdResourcesAddHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        
        public bool Handle(CmdResourcesAdd command)
        {
            var requiredResourceType = command.ResourceType;
            var requiredResource = _gameState.Resources.FirstOrDefault(x => x.ResourceType == requiredResourceType);

            requiredResource ??= CreateNewResource(requiredResourceType);
            requiredResource.Amount.Value += command.Amount;

            return true;
        }

        private Resource CreateNewResource(ResourceType resourceType)
        {
            var resourceData = new ResourceData()
            {
                ResourceType = resourceType,
                Amount = 0
            };
            var resource = new Resource(resourceData);

            _gameState.Resources.Add(resource);

            return resource;
        }
    }
}