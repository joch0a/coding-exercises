using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RemoveAllOcurrences
    {
        public string RemoveOccurrences(string s, string part)
        {
            var result = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                result.Append(s[i]);

                if (result.Length >= part.Length &&
                   result.ToString().Substring(result.Length - part.Length) == part)
                {
                    result.Length -= part.Length;
                }
            }

            return result.ToString();
        }
    }
}
