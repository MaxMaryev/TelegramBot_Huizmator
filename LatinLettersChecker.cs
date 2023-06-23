namespace TelegramBot
{
    static bool ContainsLatinLetters(string input)
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
