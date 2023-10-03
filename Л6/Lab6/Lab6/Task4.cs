using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab6;
public class Task4
{
    public void MainMethod()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine()!;

        string pattern = @"(?<!\S)\d+[.,]\d+(?!\S)"; // with ints (?<!\S)\d+([.,]\d+)?(?!\S)

        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count > 0)
        {
            double sum = 0;
            var formatInfo = new NumberFormatInfo
            {
                CurrencyDecimalSeparator = "."
            };

            foreach (var match in matches.Cast<Match>())
            {
                string matchedValue = match.Value;
                matchedValue = matchedValue.Replace(',', '.'); 

                if (double.TryParse(matchedValue, NumberStyles.Any, formatInfo, out double number))
                {
                    sum += number;
                }
            }

            Console.WriteLine($"Found float nums: {string.Join(", ", matches)}");
            Console.WriteLine($"Sum: {sum}");
        }
        else
        {
            Console.WriteLine("No float nums found.");
        }
    }
}
