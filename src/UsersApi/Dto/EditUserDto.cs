using System;
using System.Text.Json.Serialization;

namespace UsersApi.Dto
{
    public class EditUserDto
    {
        public Guid? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; }

        public EditUserDto()
        {
        }
    }
}
