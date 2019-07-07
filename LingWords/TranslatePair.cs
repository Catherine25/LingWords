namespace LingWords
{
    class TranslatePair
    {
        public TranslatePair() { }

        public TranslatePair(string _foreign, string _native, int _studyRating)
        {
            foreign = _foreign;
            native = _native;
            studyRating = _studyRating;
        }

        public string foreign, native;
        public int studyRating;
    }
}
