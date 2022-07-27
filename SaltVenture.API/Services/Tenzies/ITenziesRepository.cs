using SaltVenture.API.Models;
using SaltVenture.API.Models.Games;

namespace SaltVenture.API.Services;

public interface ITenziesRepository
{
    Task<Tenzie> GetActiveGame(int claimedId);
    Task<Tenzie> GetGame(int gameId);
    Task<Tenzie> CreateGame(Tenzie game);
    Task<Tenzie> UpdateGame(Tenzie game);

}