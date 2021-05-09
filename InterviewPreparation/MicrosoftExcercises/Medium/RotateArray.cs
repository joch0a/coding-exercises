namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            if (k % nums.Length != 0)
            {
                var shifted = 0;
                var i = 0;
                while (shifted < nums.Length)
                {
                    var actualIndex = i;
                    int? prev = null;

                    do
                    {
                        var next = (i + k) % nums.Length;
                        var tmp = nums[next];

                        nums[next] = prev ?? nums[i];

                        prev = tmp;
                        i = next;
                        shifted++;

                    } while (i != actualIndex);

                    i++;
                }
            }
        }
    }
}
