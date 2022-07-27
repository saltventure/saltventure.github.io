using Microsoft.EntityFrameworkCore;
using SaltVenture.API.Data;
using SaltVenture.API.Models;
using SaltVenture.API.Models.Games;

namespace SaltVenture.API.Services;

public class TenziesRepository : ITenziesRepository
{
    private readonly SaltVentureDbContext _context;

    public TenziesRepository(SaltVentureDbContext context)
    {
        _context = context;
    }

    public async Task<Tenzie> CreateGame(Tenzie game)
    {
        _context.Tenzies!.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Tenzie> GetActiveGame(int claimedId)
    {
        return (await _context.Tenzies!
            .Include(c => c.User)
            .OrderBy(c => c.Id).LastOrDefaultAsync(g => g!.User!.Id == claimedId && !g.IsCompleted))!;
    }

    public async Task<Tenzie> GetGame(int gameId)
    {
        return (await _context.Tenzies!.FirstOrDefaultAsync(g => g.Id == gameId))!;

    }

    public async Task<Tenzie> UpdateGame(Tenzie game)
    {
        var updateGame = _context.Tenzies?.Update(game);
        await _context.SaveChangesAsync();
        return updateGame!.Entity;
    }
}