#r "nuget: HtmlAgilityPack, 1.11.46"

using HtmlAgilityPack;

var rawHtmlDocument = await File.ReadAllTextAsync(Args[0]);
var document = new HtmlDocument();
document.LoadHtml(rawHtmlDocument);

Console.WriteLine($"# {document.DocumentNode.SelectNodes("//div[contains(@class,'bookTitle')]").FirstOrDefault().InnerText.Trim()}");
Console.WriteLine($"");
Console.WriteLine($"### Metadata");
Console.WriteLine($"");
Console.WriteLine($"- Author: {document.DocumentNode.SelectNodes("//div[contains(@class,'authors')]").FirstOrDefault().InnerText.Trim()}");
Console.WriteLine($"- Full Title: {document.DocumentNode.SelectNodes("//div[contains(@class,'bookTitle')]").FirstOrDefault().InnerText.Trim()}");
Console.WriteLine($"- Category: #books");
Console.WriteLine($"");
Console.WriteLine($"### Highlights");
Console.WriteLine($"");

foreach(HtmlNode div in document.DocumentNode.SelectNodes("//div[contains(@class,'noteText')]"))
{
    Console.WriteLine($"- {div.InnerText.Trim()}{Environment.NewLine}");
}
