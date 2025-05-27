using GitLabCommentImporter.Export;
using GitLabCommentImporter.Services;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = config.GetSection("GitLab");
var output = config.GetSection("Output");

using var httpClient = new HttpClient();
var fetcher = new GitLabMergeRequestNoteFetcher(
    httpClient,
    settings["Url"]!,
    settings["ProjectId"]!,
    settings["MergeRequestIid"]!,
    settings["PrivateToken"]!
);

var notes = await fetcher.FetchAllNotesAsync();
await MergeRequestNoteCsvExporter.ExportAsync(notes, output["CsvPath"] ?? "report.csv");

Console.WriteLine("Report successfully created.");