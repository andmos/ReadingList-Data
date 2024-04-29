using System.Linq;
using System.Text.RegularExpressions;

var rawDocument = await File.ReadAllTextAsync(Args[0]);

var titlePattern = @"Excerpt from:\n(.*)\n"; // Next line after "Excerpt from:" is the title.
var titleMatch = Regex.Match(rawDocument, titlePattern);
var bookTitle = titleMatch.Groups[1].Value;
var authorPattern = $@"{bookTitle}\n(.*)\n"; // Next line after the title is the author.
var authorMatch = Regex.Match(rawDocument, authorPattern);
var author = authorMatch.Groups[1].Value;

var quotePattern = @"“[^”]*”";

Console.WriteLine($"# {bookTitle}");
Console.WriteLine($"");
Console.WriteLine($"### Metadata");
Console.WriteLine($"");
Console.WriteLine($"- Author: {author}");
Console.WriteLine($"- Full Title: {bookTitle}");
Console.WriteLine($"- Category: #books");
Console.WriteLine($"");
Console.WriteLine($"### Highlights");
var matches = Regex.Matches(rawDocument, quotePattern);

foreach (Match match in matches)
{
    string leftQuote = "\u201C"; // Unicode for “
    string rightQuote = "\u201D"; // Unicode for ”

    var quote = match.Value.Replace(leftQuote, "").Replace(rightQuote, "");
    quote = quote.Replace("\n", " ");
    Console.WriteLine($"- {quote}{Environment.NewLine}");
}
