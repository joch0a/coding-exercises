using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class EncodeAndDecodeTinyUrl
    {

        private Dictionary<string, string> dict = new Dictionary<string, string>();

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(longUrl);
            var encode = System.Convert.ToBase64String(plainTextBytes);
            var tinyUrl = $"http://tinyurl.com/{encode}";

            dict.Add(tinyUrl, longUrl);

            return tinyUrl;
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            return dict[shortUrl];
        }
    }
}
