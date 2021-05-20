public class RotateString
{
    public bool Solve(string s, string pat)
    {

        var txt = s + s;
        int M = pat.Length;
        int N = txt.Length;

        if (s.Length != M)
        {
            return false;
        }

        if (s.Length == 0)
        {
            return true;
        }
        // create lps[] that will hold the longest
        // prefix suffix values for pattern

        int[] lps = computeLPSArray(pat, M);
        int j = 0; // index for pat[]

        // Preprocess the pattern (calculate lps[]
        // array)


        int i = 0; // index for txt[]

        while (i < N)
        {
            if (pat[j] == txt[i])
            {
                j++;
                i++;
            }

            if (j == M)
            {
                return true;
            }

            // mismatch after j matches
            else if (i < N && pat[j] != txt[i])
            {
                // Do not match lps[0..lps[j-1]] characters,
                // they will match anyway
                if (j != 0)
                    j = lps[j - 1];
                else
                    i = i + 1;
            }
        }

        return false;
    }

    public int[] computeLPSArray(string pat, int M)
    {
        int[] lps = new int[pat.Length];
        // length of the previous longest prefix suffix
        int len = 0;
        int i = 1;
        lps[0] = 0; // lps[0] is always 0

        // the loop calculates lps[i] for i = 1 to M-1
        while (i < M)
        {
            if (pat[i] == pat[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else // (pat[i] != pat[len])
            {
                // This is tricky. Consider the example.
                // AAACAAAA and i = 7. The idea is similar
                // to search step.
                if (len != 0)
                {
                    len = lps[len - 1];

                    // Also, note that we do not increment
                    // i here
                }
                else // if (len == 0)
                {
                    lps[i] = len;
                    i++;
                }
            }
        }

        return lps;
    }
}
