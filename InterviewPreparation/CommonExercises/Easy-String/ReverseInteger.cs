namespace InterviewPreparation.CommonExercises.Easy_String
{
    class ReverseInteger
    {
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/
        public int Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                // Shitty condition
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }
    }
}
