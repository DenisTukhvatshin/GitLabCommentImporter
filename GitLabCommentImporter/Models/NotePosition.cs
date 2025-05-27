using System.Text.Json.Serialization;

namespace GitLabCommentImporter.Models;

public class NotePosition
{
    [JsonPropertyName("new_path")]
    public string? NewPath { get; set; }

    [JsonPropertyName("old_path")]
    public string? OldPath { get; set; }

    [JsonPropertyName("new_line")]
    public int? NewLine { get; set; }
}
