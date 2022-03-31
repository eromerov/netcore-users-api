using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace UsersApi.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        public UserDto()
        {

        }
    }
}
