using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SaltVenture.API.Models;
using SaltVenture.API.Models.Games;
using SaltVenture.API.Services;

namespace SaltVenture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenziesController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    private readonly ITenziesRepository _tenziesRepository;
   
    

    public TenziesController(IUsersRepository usersRepository, ITenziesRepository tenziesRepository)
    {
        _usersRepository = usersRepository;
        _tenziesRepository = tenziesRepository;
    }
    
    [HttpPost("getreward")]
    public async Task<IActionResult> getReward()
    {
        // SAMe as all the others
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        // Gets list of claims.
        IEnumerable<Claim> claim = identity!.Claims;

        // Gets name from claims. Generally it's an email address.
        var idClaim = claim
            .Where(x => x.Type == ClaimTypes.UserData)
            .FirstOrDefault()!.Value;

        if (!int.TryParse(idClaim, out var claimedId)) return Unauthorized();

        var user = await _usersRepository.GetUserWithId(claimedId);
        if (user == null) return NotFound();
        var activeGame = await _tenziesRepository.GetActiveGame(claimedId);
        if (activeGame == null) {
            return NotFound();

        }
        if(!TenziesLogic.IsFinished(activeGame.Grid!))
        {
            return BadRequest("The Game s not finished yet!");
        }
        var newBalance = user.Balance + 10;
        activeGame.IsCompleted = true;
        await _tenziesRepository.UpdateGame(activeGame);
        user = await _usersRepository.UpdateBalance(newBalance, user);
        var response = new User(){
            Id = user.Id,
            Balance = user.Balance
        };
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetTenziesGame()
    {
 // get user
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        // Gets list of claims.
        IEnumerable<Claim> claim = identity!.Claims;

        // Gets name from claims. Generally it's an email address.
        var idClaim = claim
            .Where(x => x.Type == ClaimTypes.UserData)
            .FirstOrDefault()!.Value;

        if (!int.TryParse(idClaim, out var claimedId)) return Unauthorized();
        var user = await _usersRepository.GetUserWithId(claimedId);

        if (user == null) return Unauthorized();

         var activeGame = await _tenziesRepository.GetActiveGame(claimedId);
        if (activeGame != null) {
            return Ok(activeGame);

        }
        // Change Balance

       

        var game = new Tenzie()
        {
            User = user,
            IsCompleted = false,
            Grid = TenziesLogic.GenerateNewGrid(),
            Holding = "0000000000",
            Round = 0

        };
        game = await _tenziesRepository.CreateGame(game);
        return Ok(game);

    }

    [HttpPost("pick/{holding}")]
    public async Task<IActionResult> GetNewRound(string holding)
    {
       var identity = HttpContext.User.Identity as ClaimsIdentity;
        // Gets list of claims.
        IEnumerable<Claim> claim = identity!.Claims;

        // Gets name from claims. Generally it's an email address.
        var idClaim = claim
            .Where(x => x.Type == ClaimTypes.UserData)
            .FirstOrDefault()!.Value;

        if (!int.TryParse(idClaim, out var claimedId)) return Unauthorized();
        var user = await _usersRepository.GetUserWithId(claimedId);

        if (user == null) return Unauthorized();

         var game = await _tenziesRepository.GetActiveGame(claimedId);
        if (game == null) {
            return NotFound();
        }   
        if(holding.Length != 10) return BadRequest("holding Dices length shoulld be 10!");

        var blenderedGrid = TenziesLogic.BlenderGridWithHolding(game.Grid!, holding);
        game.Grid = TenziesLogic.GenerateNewGrid(blenderedGrid);
        game.Holding = holding;
        game.Round++;
        game = await _tenziesRepository.UpdateGame(game);
        return Ok(game);

    }
}
