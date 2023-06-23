namespace TelegramBot_Huizmator
{
    public class LatinLettersChecker
    {
        public static bool ContainsLatin(string input)
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
