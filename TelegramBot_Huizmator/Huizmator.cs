namespace TelegramBot_Huizmator
{
    public static class Huizmator
    {
        static List<char> glasnie = new List<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        static List<char> soglasnie = new List<char> { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        static List<char> znaki = new List<char> { 'ъ', 'ь' };

        private static List<string> SplitWordIntoSyllables(string word)
        {
            string next = "";
            List<string> array = new List<string>();
            foreach (char b in word)
            {
                bool isGlasnaya = glasnie.Contains(b);
                next = $"{next}{b}";
                if (isGlasnaya)
                {
                    array.Add(next);
                    next = "";
                }
            }
            if (next != "")
            {
                array[array.Count - 1] += next;
            }
            return array;
        }

        public static string WordToHuizm(string word)
        {
            word = word.ToLower();
            switch (word)
            {
                case "да":
                    return "Хуй на";
            }
            List<string> arr = SplitWordIntoSyllables(word);
            string huizm = arr[arr.Count - 1];
            if (arr.Count > 1)
            {
                huizm = arr[arr.Count - 2] + huizm;
            }
            foreach (char symbol in huizm)
            {
                bool isGlasnaya = glasnie.Contains(symbol);
                if (isGlasnaya)
                {
                    huizm = huizm.Substring(huizm.IndexOf(symbol));
                    break;
                }
            }
            char b = huizm[0];
            string prefix;
            switch (b)
            {
                case 'а':
                    prefix = "хуя";
                    huizm = huizm.Substring(1);
                    break;
                case 'о':
                    prefix = "хуё";
                    huizm = huizm.Substring(1);
                    break;
                case 'е':
                case 'э':
                    prefix = "хуе";
                    huizm = huizm.Substring(1);
                    break;
                case 'ы':
                    prefix = "хуи";
                    huizm = huizm.Substring(1);
                    break;
                case 'у':
                    prefix = "хую";
                    huizm = huizm.Substring(1);
                    break;
                case 'я':
                case 'ё':
                case 'и':
                case 'ю':
                    prefix = "ху";
                    break;
                default:
                    prefix = "хуй";
                    break;
            }
            huizm = prefix + huizm;
            huizm = char.ToUpper(huizm[0]) + huizm.Substring(1);
            return huizm;
        }

        public static string SentenceToHuizm(string sentence)
        {
            string[] words = sentence.Split(' ');
            string word = words[words.Length - 1];
            word = new string(word.Where(c => char.IsLetter(c) || c == 'ё' || c == 'Ё').ToArray());
            string huizm = WordToHuizm(word);
            return huizm;
        }
    }
}