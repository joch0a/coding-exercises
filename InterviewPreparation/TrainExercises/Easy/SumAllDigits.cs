namespace InterviewPreparation.TrainExercises.Easy
{
    class SumAllDigits
    {
        //https://leetcode.com/problems/add-digits/submissions/
        public int AddDigits(int num)
        {
            var aux = num;

            while (aux > 9)
            {
                var tmp = aux;

                aux = 0;

                while (tmp > 0)
                {
                    aux += tmp % 10;
                    tmp = tmp / 10;
                }
            }

            return aux;
        }
    }
}
