namespace SFNotes.Server.Entites
{
    public partial class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Username { get; set; }

        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}