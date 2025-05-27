using System.Text.Json.Serialization;

namespace GitLabCommentImporter.Models;

public class User
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
}