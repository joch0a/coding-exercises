using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.MicrosoftExcercises.Hard
{
    public class SudokuSolver
    {
        private int totalCandidates;
        private bool solved;

        public void SolveSudoku(char[][] board)
        {
            solved = false;
            totalCandidates = 9 * 9;
            var candidates = GenerateCandidates(board);

            Backtrack(0, 0, board, candidates);
        }

        private void Backtrack(int i, int j, char[][] board, Dictionary<int, HashSet<int>> candidates)
        {
            Console.WriteLine(totalCandidates);
            if (totalCandidates == 0)
            {
                solved = true;
                return;
            }


            if (board[i][j] == '.')
            {
                var currentBox = GetBox(i, j);
                var currentCandidates = candidates[currentBox].ToList();

                if (currentCandidates.Count == 0)
                {
                    return;
                }

                foreach (var candidate in currentCandidates)
                {
                    if (IsValid(candidate, i, j, board))
                    {
                        totalCandidates--;
                        candidates[currentBox].Remove(candidate);
                        board[i][j] = (char)(candidate + '0');
                        Backtrack(i, j, board, candidates);

                        if (solved)
                        {
                            return;
                        }

                        board[i][j] = '.';
                        candidates[currentBox].Add(candidate);
                        totalCandidates++;
                    }
                }
            }
            else
            {
                GoNext(i, j, board, candidates);
            }
        }

        void GoNext(int row, int col, char[][] board, Dictionary<int, HashSet<int>> candidates)
        {
            if (totalCandidates == 0)
            {
                solved = true;
                return;
            }

            if (col == 8)
            {
                Backtrack(row + 1, 0, board, candidates);
            }
            else
            {
                Backtrack(row, col + 1, board, candidates);
            }
        }

        private int GetBox(int i, int j)
        {
            // ------------------------------------ first row 
            if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
            {
                return 1;
            }

            if (i >= 0 && i <= 2 && j >= 3 && j <= 5)
            {
                return 2;
            }

            if (i >= 0 && i <= 2 && j >= 6 && j <= 9)
            {
                return 3;
            }


            // ------------------------------------ second row 
            if (i >= 3 && i <= 5 && j >= 0 && j <= 2)
            {
                return 4;
            }

            if (i >= 3 && i <= 5 && j >= 3 && j <= 5)
            {
                return 5;
            }

            if (i >= 3 && i <= 5 && j >= 6 && j <= 9)
            {
                return 6;
            }


            // ------------------------------------ third row 
            if (i >= 6 && i <= 9 && j >= 0 && j <= 2)
            {
                return 7;
            }

            if (i >= 6 && i <= 9 && j >= 3 && j <= 5)
            {
                return 8;
            }

            if (i >= 6 && i <= 9 && j >= 6 && j <= 9)
            {
                return 9;
            }

            throw new Exception();
        }

        private bool IsValid(int c, int row, int col, char[][] board)
        {
            char candidate = (char)(c + '0');

            //vertical check
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][col] == candidate)
                {
                    return false;
                }
            }

            //horizontal check
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[row][j] == candidate)
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<int, HashSet<int>> GenerateCandidates(char[][] board)
        {
            var candidates = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < board.Length; i++)
            {
                var localCandidates = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                candidates.Add(i + 1, localCandidates);
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var actual = board[i][j];

                    if (actual != '.')
                    {
                        totalCandidates--;
                        candidates[GetBox(i, j)].Remove((int)actual - '0');
                    }
                }
            }

            return candidates;
        }
    }
}
