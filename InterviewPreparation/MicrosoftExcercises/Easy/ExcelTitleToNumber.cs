namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class ExcelTitleToNumber
    {
        public int TitleToNumber(string columnTitle)
        {
            var result = 0;

            for (int i = 0; i < columnTitle.Length; i++)
            {
                result = result * 26 + (columnTitle[i] - 'A' + 1);
            }

            return result;
        }
    }
}
