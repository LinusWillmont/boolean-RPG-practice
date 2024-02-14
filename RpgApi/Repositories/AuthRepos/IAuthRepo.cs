using RpgApi.Models;

namespace RpgApi.Repositories.PlayersRepos
{
    public interface IAuthRepo
    {
        public Task<Player?> RegisterPlayerAsync(string username, string email, string password);

        public Task<Tuple<Player,string>?> LoginPlayerAsync(string email, string password);

        public Task<Player?> GetPlayerAsync(string email);
    }
}
