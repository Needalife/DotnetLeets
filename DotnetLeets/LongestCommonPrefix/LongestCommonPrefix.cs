namespace DotnetLeets.LongestCommonPrefix
{
    internal class LongestCommonPrefix
    {
        public static string ReturnString(string[] s)
        {   
            if (s.Length < 1) return "";
            if (s.Length == 1) return s[0];

            string first = s[0];

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 1; j < s.Length; j ++)
                {
                    
                    if (i >= s[j].Length || first[i] != s[j][i])
                    {
                        return first.Substring(0, i);
                    }
                }
            }

            return "";
        }
    }
}
