using System.Text.Json.Serialization;

namespace GitLabCommentImporter.Models;

public class MergeRequestNote
{
    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("position")]
    public NotePosition? Position { get; set; }

    [JsonPropertyName("author")]
    public User Author { get; set; }
}
