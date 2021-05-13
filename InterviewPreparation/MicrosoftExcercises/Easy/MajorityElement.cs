namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class MajorityElement
    {
        public int Solve(int[] nums)
        {
            int? candidate = null;
            int count = 0;

            foreach (var num in nums)
            {
                if (candidate == null)
                {
                    candidate = num;
                    count++;
                }
                else if (num == candidate)
                {
                    count++;
                }
                else
                {
                    count--;

                    if (count == 0)
                    {
                        candidate = num;
                        count = 1;
                    }
                }
            }

            return candidate.Value;
        }
    }
}
