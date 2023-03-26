namespace ConsoleGame
{
    public static class Text
    {
        private static Language _language;
        public static Language Language
        {
            get
            {
                if (_language == null)
                {
                    throw new Exception("language is not loaded yet");
                }
                return _language;
            }
        }
        public static void LoadLanguage(Language language)
        {
            _language = language;
        }
    }
}