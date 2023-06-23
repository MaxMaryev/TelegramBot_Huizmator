namespace TelegramBot_Huizmator
{
    internal class LatinLettersChecker
    {
        internal static bool Check(string input)
        {
            foreach (char c in input)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
