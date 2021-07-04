﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class SolveMyPow
    {
        public double MyPow(double x, int n)
        {
            if (n < 0) return 1 / x * MyPow(1 / x, -(n + 1));
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n % 2 == 0) return MyPow(x * x, n / 2);
            return x * MyPow(x * x, n / 2);
        }
    }
}
