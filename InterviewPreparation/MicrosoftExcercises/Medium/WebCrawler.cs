using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class WebCrawler
    {
        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {
            var crawled = new List<string>();
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var hostName = GetHostName(startUrl);

            Console.WriteLine(hostName);

            queue.Enqueue(startUrl);

            while (queue.Count > 0)
            {
                var actual = queue.Dequeue();

                if (!visited.Contains(actual))
                {
                    visited.Add(actual);

                    if (GetHostName(actual) == hostName)
                    {
                        crawled.Add(actual);

                        foreach (var node in htmlParser.GetUrls(actual))
                        {
                            queue.Enqueue((string)node);
                        }
                    }
                }
            }

            return crawled;
        }

        private string GetHostName(string url)
        {
            var i = 0;
            var sb = new StringBuilder();

            if (url[0] == 'h')
            {
                while (url[i] != '/')
                {
                    i++;
                }

                while (url[i] == '/')
                {
                    i++;
                }
            }

            for (int index = i; i < url.Length && url[i] != '/'; i++)
            {
                sb.Append(url[i]);
            }

            return sb.ToString();
        }
    }
}
