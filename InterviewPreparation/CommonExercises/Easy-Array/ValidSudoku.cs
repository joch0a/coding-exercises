using System.Collections.Generic;

namespace InterviewPreparation.CommonExercises.Easy_Array
{
    //https://leetcode.com/problems/valid-sudoku
    class ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {

            var columnsHs = new Dictionary<char, int>[9];

            for (int i = 0; i < columnsHs.Length; i++)
            {
                columnsHs[i] = new Dictionary<char, int>();
            }

            for (int i = 0; i < board.Length; i++)
            {
                var rowHs = new HashSet<char>();

                for (int j = 0; j < board[0].Length; j++)
                {
                    var actual = board[i][j];

                    if (actual != '.')
                    {
                        if (rowHs.Contains(actual) || columnsHs[j].ContainsKey(actual) || SameBox(actual, i, j, columnsHs))
                        {
                            return false;
                        }
                        else
                        {
                            rowHs.Add(actual);
                            columnsHs[j].Add(actual, CalculateBox(i, j));
                        }
                    }
                }
            }

            return true;
        }

        private bool SameBox(char actual, int i, int j, Dictionary<char, int>[] columns)
        {
            var actualBox = CalculateBox(i, j);
            int currentBox;
            if (j <= 2)
            {
                if (columns[0].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
                if (columns[1].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
                if (columns[2].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
            }
            else if (j <= 5)
            {
                if (columns[3].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
                if (columns[4].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
                if (columns[5].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
            }
            else
            {
                if (columns[6].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
                if (columns[7].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
                if (columns[8].TryGetValue(actual, out currentBox) && currentBox == actualBox)
                {
                    return true;
                }
            }

            return false;
        }

        private int CalculateBox(int i, int j)
        {
            if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
            {
                return 1;
            }
            if (i >= 3 && i <= 5 && j >= 0 && j <= 2)
            {
                return 2;
            }
            if (i >= 6 && i <= 8 && j >= 0 && j <= 2)
            {
                return 3;
            }
            //-----------------
            if (i >= 3 && i <= 5 && j >= 0 && j <= 2)
            {
                return 4;
            }
            if (i >= 3 && i <= 5 && j >= 3 && j <= 5)
            {
                return 5;
            }
            if (i >= 3 && i <= 5 && j >= 6 && j <= 8)
            {
                return 6;
            }
            //------------------
            if (i >= 6 && i <= 8 && j >= 0 && j <= 2)
            {
                return 7;
            }
            if (i >= 6 && i <= 8 && j >= 3 && j <= 5)
            {
                return 8;
            }
            if (i >= 6 && i <= 8 && j >= 6 && j <= 8)
            {
                return 9;
            }
            return 1;
        }
    }
}
