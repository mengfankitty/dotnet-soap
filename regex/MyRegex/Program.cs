using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml;

namespace MyRegex
{
    static class Program
    {
        static void Main(string[] args)
        {
            var rx = new Regex(@"^/(?<re1>individuals)/(?<id1>[0-9a-zA-Z-]+)((/photo|/programs|/onlineid)(/[0-9a-zA-Z-]+)?)?$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var texts = new List<string>
            {
                "/individuals/111123",
                "/individuals/111123/photo",
                "/individuals/111123/programs",
                "/individuals/111123/onlineid",
                "/individuals/111123/programs/1232jlj",
                "/individuals/111123/programs/1232jlj/jj",
                "/individuals/111123/happy",
            };

            texts.ForEach(e =>
            {
                var match = rx.Match(e);
                Console.WriteLine(e);
                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine(match.Success);
                Console.WriteLine(match.Groups["re1"]);
                Console.WriteLine(match.Groups["id1"]);
                Console.WriteLine("".PadRight(30, '-'));
            });
        }
    }
}
