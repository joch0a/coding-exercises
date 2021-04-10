namespace InterviewPreparation.CommonExercises.Easy_String
{
    class ReverseString
    {
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/
        public void Reverse(char[] s)
        {
            int i = 0;
            int j = s.Length - 1;
            char tmp;

            while (i < j)
            {
                tmp = s[i];
                s[i] = s[j];
                s[j] = tmp;

                j--;
                i++;
            }
        }
    }
}
