using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    class IntegerToEnglishWords
    {
        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            var billions = num / 1000000000;
            var millions = (num % 1000000000) / 1000000;
            var thousand = (num % 1000000000 % 1000000) / 1000;
            var rest = num % 1000000000 % 1000000 % 1000;

            var sb = new StringBuilder();

            if (billions > 0)
            {
                sb.Append($"{GenerateBlock(billions)} Billion");
            }

            if (millions > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append($"{GenerateBlock(millions)} Million");
            }

            if (thousand > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append($"{GenerateBlock(thousand)} Thousand");
            }

            if (rest > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append($"{GenerateBlock(rest)}");
            }

            return sb.ToString();
        }

        private string One(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }

            return "";
        }

        private string TwoLessThan20(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }

            return "";
        }

        private string Ten(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }

            return "";
        }

        private string Two(int num)
        {
            if (num == 0)
            {
                return "";
            }

            if (num < 10)
            {
                return One(num);
            }

            if (num < 20)
            {
                return TwoLessThan20(num);
            }

            // handle 20 - 99

            var firstDigit = num / 10;
            var secondDigit = num % 10;
            var result = Ten(firstDigit);

            if (secondDigit > 0)
            {
                result += $" {One(secondDigit)}";
            }

            return result;
        }

        private string GenerateBlock(int num)
        {
            int hundred = num / 100;
            int rest = num % 100;

            if (hundred != 0 && rest != 0)
            {
                return $"{One(hundred)} Hundred {Two(rest)}";
            }

            if (hundred != 0 && rest == 0)
            {
                return $"{One(hundred)} Hundred";
            }
            if (hundred == 0 && rest != 0)
            {
                return Two(rest);
            }

            return "";
        }
    }
}
