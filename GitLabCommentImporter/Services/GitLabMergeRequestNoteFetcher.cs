using GitLabCommentImporter.Models;
using System.Text.Json;

namespace GitLabCommentImporter.Services;

public class GitLabMergeRequestNoteFetcher
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;
    private readonly string _privateToken;

    public GitLabMergeRequestNoteFetcher(HttpClient httpClient, string url, string projectId, string mrIid, string token)
    {
        _httpClient = httpClient;
        _apiUrl = $"{url}/api/v4/projects/{projectId}/merge_requests/{mrIid}/notes";
        _privateToken = token;
    }

    public async Task<List<MergeRequestNote>> FetchAllNotesAsync()
    {
        var result = new List<MergeRequestNote>();
        int page = 1;
        const int perPage = 100;

        while (true)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}?per_page={perPage}&page={page}");
            request.Headers.Add("PRIVATE-TOKEN", _privateToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var notes = JsonSerializer.Deserialize<List<MergeRequestNote>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new();

            if (notes.Count == 0)
                break;

            result.AddRange(notes);
            page++;
        }

        return result;
    }
}
