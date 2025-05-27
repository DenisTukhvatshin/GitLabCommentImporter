using GitLabCommentImporter.Models;
using System.Text;

namespace GitLabCommentImporter.Export;

public static class MergeRequestNoteCsvExporter
{
    public static async Task ExportAsync(List<MergeRequestNote> notes, string filePath)
    {
        var lines = new List<string> { "File;Line;Comment;Author" };

        foreach (var note in notes)
        {
            string file = note.Position?.NewPath ?? note.Position?.OldPath ?? "General comment";
            string line = note.Position?.NewLine?.ToString() ?? "N/A";
            string body = EscapeCsvField(note.Body);
            string author = EscapeCsvField(note.Author?.Username ?? "");

            lines.Add($"{EscapeCsvField(file)};{line};{body};{author}");
        }

        await File.WriteAllTextAsync(filePath, "\uFEFF" + string.Join(Environment.NewLine, lines), Encoding.UTF8);
    }

    private static string EscapeCsvField(string? value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;

        var needsQuotes = value.Contains(';') || value.Contains('"') || value.Contains('\n');
        var escaped = value.Replace("\"", "\"\"");
        return needsQuotes ? $"\"{escaped}\"" : escaped;
    }
}
