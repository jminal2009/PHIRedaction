using System;
using System.IO;
using System.Text.RegularExpressions;

public class RedactorService
{
    private static readonly (string Pattern, string Replacement)[] Patterns = {
        (@"Patient Name:\s*([\w\s]+)", "Patient Name: [REDACTED]"),
        (@"\b\d{2}/\d{2}/\d{4}\b", "Date of Birth: [REDACTED]"),
        (@"Social Security Number:\s*\d{3}-\d{2}-\d{4}", "SSN: [REDACTED]"),
        (@"Phone Number:\s*\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}", "Phone: [REDACTED]"),
        (@"Email:\s*\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b", "Email: [REDACTED]"),
        (@"Medical Record Number:\s*\S+", "MRN: [REDACTED]"),
        (@"Address:\s*\d{1,5}\s[\w\s]+(?:St|Ave|Blvd|Rd|Dr|Ln|Way|Court|Plaza|Circle|Parkway)[.,]?\s*\w*,?\s*\w*", "Address: [REDACTED]")
    };

    public string RedactPHI(string content)
    {
        foreach (var (pattern, replacement) in Patterns)
        {
            content = Regex.Replace(content, pattern, replacement, RegexOptions.IgnoreCase);
        }
        return content;
    }
}
