namespace Ofek_List.Models;

public class Player
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Goals { get; set; }
    public Club Club { get; set; }
    public string Position { get; set; }
}