using System;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Easy
{
    class PerformShiftString
    {
        public string StringShift(string s, int[][] shifts)
        {
            var leftShifts = 0;
            var rightShifts = 0;

            foreach (var shift in shifts)
            {
                var direction = shift[0];
                var total = shift[1];

                if (direction == 0)
                {
                    leftShifts += total;
                }
                else
                {
                    rightShifts += total;
                }
            }

            var totalShifts = (rightShifts - leftShifts) % s.Length;

            if (totalShifts == 0)
            {
                return s;
            }

            return GetShiftedString(s, totalShifts < 0, Math.Abs(totalShifts));
        }

        private string GetShiftedString(string s, bool isLeft, int total)
        {
            var shifted = new StringBuilder();

            if (isLeft)
            {
                for (int i = total; i < total + s.Length; i++)
                {
                    var index = i % s.Length;

                    shifted.Append(s[index]);
                }
            }
            else
            {
                var start = (s.Length - total);

                for (int i = start; i < start + s.Length; i++)
                {
                    var index = i % s.Length;

                    shifted.Append(s[index]);
                }
            }

            return shifted.ToString();
        }
    }
}
