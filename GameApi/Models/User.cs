namespace GameApi.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string[] Regions { get; set; }

        public static List<User> Users = new List<User>
        {
            new User { Username = "player1", Password = "player1pass", Role = "player", Regions = new[] { "b_game" } },
            new User { Username = "admin1", Password = "admin1pass", Role = "admin", Regions = new[] { "b_game", "vip_character_personalize" } }
        };
    }
}
