using Ofek_List.Models;

namespace Ofek_List.Services;

public class KDB
{
    public static List<Player> PlayersList = new List<Player>
    {
        new Player
        {
            Id = 1,
            Name = "Oz Bilu",
            Goals = 3,
            Position = "Forward"
        },

        new Player
        {
            Id = 2,
            Name = "Maor Levi",
            Goals = 5,
            Position = "Midfielder"
        },

        new Player
        {
            Id = 3,
            Name = "Itay Ben Shabat",
            Goals = 0,
            Position = "Defender"
        },

        new Player
        {
            Id = 4,
            Name = "Mateus Davo",
            Goals = 4,
            Position = "Forward"
        },

        new Player
        {
            Id = 5,
            Name = "Dolev Haziza",
            Goals = 2,
            Position = "Midfielder"
        }
    };
}