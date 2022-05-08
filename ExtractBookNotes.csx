#r "nuget: HtmlAgilityPack, 1.11.42"

using HtmlAgilityPack;

var rawHtmlDocument = await File.ReadAllTextAsync(Args[0]);
var document = new HtmlDocument();
document.LoadHtml(rawHtmlDocument);

Console.WriteLine($"### Highlights {Environment.NewLine}");
foreach(HtmlNode div in document.DocumentNode.SelectNodes("//div[contains(@class,'noteText')]"))
{
    Console.WriteLine($"- {div.InnerText.Trim()}{Environment.NewLine}");
}