namespace TelegramBot_Huizmator
{
    internal static class Huizmator
    {
        internal static string SentenceToHuizm(string sentence)
        {
            string[] words = sentence.Split(' ');
            string huizm = "";

            foreach (var word in words)
                huizm += $" {WordToHuizm(word)}";

            return huizm;
        }

        internal static string WordToHuizm(string word)
        {
            string result = word.ToLower().Trim();

            if(TryFastAnswer(word, out string answer))
                return answer;

            string vowels = "аеёиоуыэюя";
            Dictionary<char, char> rules = new Dictionary<char, char>()
                {
                    {'а', 'я'},
                    {'о', 'е'},
                    {'у', 'ю'},
                    {'ы', 'и'},
                    {'э', 'е'}
                };

            while (result.Length > 0)
            {
                char letter = result[0];
                if (vowels.Contains(letter))
                {
                    if (rules.ContainsKey(letter))
                        result = rules[letter] + result.Substring(1);

                    break;
                }
                else
                {
                    result = result.Substring(1);
                }
            }
            return !string.IsNullOrEmpty(result) ? $"Ху{result}" : "Хуй";
        }

        private static bool TryFastAnswer(string word, out string answer) 
        {
            answer = word switch
            {
                "да" => "Хуй на!",
                "конечно" => "Хуешно",
                "хуй" => "Тебе в рот",
                "бот" => "В рот тебе насрёт",
                _ => ""
            };

            return answer.Length > 0;
        }
    }
}