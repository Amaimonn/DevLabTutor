using System.Linq;
using mBuilding.Scripts.Game.State.GameResources;
using mBuilding.Scripts.Game.State.Maps;
using ObservableCollections;
using R3;

namespace mBuilding.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        private readonly GameState _gameState;
        public readonly ReactiveProperty<int> CurrentMapId = new();
        public ObservableList<Map> Maps { get; } = new();
        public ObservableList<Resource> Resources { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;

            InitMaps(gameState);
            InitResources(gameState);

            CurrentMapId.Subscribe(e => _gameState.CurrentMapId = e);
        }

        public int CreateEntityId()
        {
            return _gameState.CreateEntityId();
        }

        private void InitMaps(GameState gameState)
        {
            foreach (var mapOrigin in gameState.Maps)
            {
                Maps.Add(new Map(mapOrigin));
            }
            
            Maps.ObserveAdd().Subscribe(e =>
            {
                var addedMap = e.Value;
                gameState.Maps.Add(addedMap.Origin);
            });
            
            Maps.ObserveRemove().Subscribe(e =>
            {
                var removedMap = e.Value;
                var removedMapState = gameState.Maps.FirstOrDefault(b => b.Id == removedMap.Id);
                gameState.Maps.Remove(removedMapState);
            });
        }

        private void InitResources(GameState gameState)
        {
            foreach (var resourceOrigin in  gameState.Resources)
            {
                Resources.Add(new Resource(resourceOrigin));
            }
            
            Resources.ObserveAdd().Subscribe(e =>
            {
                var addedResource = e.Value;
                gameState.Resources.Add(addedResource.Origin);
            });
            
            Resources.ObserveRemove().Subscribe(e =>
            {
                var removedResource = e.Value;
                var removedResourceOrigin = gameState.Resources
                    .FirstOrDefault(b => b.ResourceType == removedResource.ResourceType);
                gameState.Resources.Remove(removedResourceOrigin);
            });
        }
    }
}