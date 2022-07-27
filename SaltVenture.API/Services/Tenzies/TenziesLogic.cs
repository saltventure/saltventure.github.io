using SaltVenture.API.Models;
using SaltVenture.API.Models.Games;

namespace SaltVenture.API.Services;

public static class TenziesLogic
{

    public static string GenerateNewGrid(string oldGrid)
    {
        var random = new Random();
        var gameString = "";
        foreach (var dice in oldGrid)
        {
            if (dice == 'x')
            {
                gameString += random.Next(1, 7);
            }
            else
            {
                gameString += dice;
            }
        }
        return gameString;
    }
    public static bool IsFinished(string grid)
    {
        var number = grid[0];
        foreach (var item in grid)
        {
            if (item != number)
            {
                return false;
            }
        }
        return true;
    }
    public static string BlenderGridWithHolding(string grid, string holding)
    {
        if(grid.Length != holding.Length) throw new ArgumentException("grid and holding must have the same length!");
        var list = new List<char>(grid);
        for (int i = 0; i < grid.Length; i++)
        {
            list[i] = holding[i] == '1' ? list[i] : 'x';
        }
        return new string(list.ToArray());
    }
    public static string GenerateNewGrid()
    {
        var random = new Random();
        var gameString = "";
        for (int i = 0; i < 10; i++)
        {
            gameString += random.Next(1, 7);
        }
        return gameString;
    }
}