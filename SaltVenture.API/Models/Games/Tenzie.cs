namespace SaltVenture.API.Models.Games;

public class Tenzie
{
    public int Id { get; set; }
    public User? User {get;set;}
    public bool IsCompleted {get; set;}
    public string? Grid {get; set;}
    public string? Holding {get; set;}

    public int Round {get; set;}
}
