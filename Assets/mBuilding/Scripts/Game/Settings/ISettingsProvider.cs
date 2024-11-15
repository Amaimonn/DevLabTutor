using System.Threading.Tasks;

namespace mBuilding.Scripts.Game.Settings
{
    public interface ISettingsProvider
    {
        public GameSettings GameSettings { get; }
        public ApplicationSettings ApplicationSettings { get; }
        public Task<GameSettings> LoadGameSettings();
    }
}
