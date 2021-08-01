using System;

namespace InterviewPreparation.MicrosoftExcercises.Medium
{
    class RectangleArea
    {
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            var areaRectangle1 = Math.Abs(A - C) * Math.Abs(B - D);
            var areaRectangle2 = Math.Abs(E - G) * Math.Abs(F - H);

            if (areaRectangle1 == 0 || areaRectangle2 == 0)
            {
                return Math.Max(areaRectangle2, areaRectangle1);
            }

            var overlappedArea = GetOverlappedArea(A, B, C, D, E, F, G, H);

            return areaRectangle1 + areaRectangle2 - overlappedArea;
        }

        private int GetOverlappedArea(int x0, int y0, int x1, int y1, int x00, int y00, int x11, int y11)
        {
            if ((x0 <= x00 && x0 >= x11 && x1 <= x00 && x1 >= x11) ||
               (x00 <= x0 && x00 >= x1 && x11 <= x0 && x11 >= x1) ||
               (y0 <= y00 && y0 >= y11 && y1 <= y00 && y1 >= y11) ||
               (y00 <= y0 && y00 >= y1 && y11 <= y0 && y11 >= y1)
              )
            {
                return 0;
            }

            int xOverlap = 0;

            if ((x0 <= x11 && x11 <= x1) && (x0 <= x00 && x00 <= x1))
            {
                xOverlap = Math.Abs(x00 - x11);
            }
            else if ((x00 <= x0 && x0 <= x11) && (x00 <= x1 && x1 <= x11))
            {
                xOverlap = Math.Abs(x0 - x1);
            }
            else if ((x0 <= x11 && x11 <= x1) || (x00 <= x0 && x0 <= x11))
            {
                xOverlap = Math.Abs(x0 - x11);
            }
            else if ((x0 <= x00 && x00 <= x1) || (x00 <= x1 && x1 <= x11))
            {
                xOverlap = Math.Abs(x00 - x1);
            }

            int yOverlap = 0;

            if ((y0 <= y11 && y11 <= y1) && (y0 <= y00 && y00 <= y1))
            {
                yOverlap = Math.Abs(y00 - y11);
            }
            else if ((y00 <= y0 && y0 <= y11) && (y00 <= y1 && y1 <= y11))
            {
                yOverlap = Math.Abs(y0 - y1);
            }
            else if ((y0 <= y11 && y11 <= y1) || (y00 <= y0 && y0 <= y11))
            {
                yOverlap = Math.Abs(y0 - y11);
            }
            else if ((y0 <= y00 && y00 <= y1) || (y00 <= y1 && y1 <= y11))
            {
                yOverlap = Math.Abs(y00 - y1);
            }

            return yOverlap * xOverlap;
        }
    }
}
