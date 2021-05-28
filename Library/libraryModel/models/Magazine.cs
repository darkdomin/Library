using System;

namespace Library.libraryModel.models
{
    [Serializable]
    public class Magazine : Publication
    {
        public const string TYPE = "Magazyn";
        private string language;

        public Magazine(string title, string publisher, int releaseDate, string language) : base(title, publisher, releaseDate)
        {
            this.language = language;
        }

        public string Language
        {
            get { return language; }
            set { value = language; }
        }

        public override bool Equals(object obj)
        {
            return obj is Magazine magazine &&
                   base.Equals(obj) &&
                   Title == magazine.Title &&
                   ReleaseDate == magazine.ReleaseDate &&
                   Publisher == magazine.Publisher &&
                   language == magazine.language &&
                   Language == magazine.Language;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Title, ReleaseDate, Publisher, language, Language);
        }

        public override string ToCSV()
        {
            return TYPE + ";" +
                   Title + ";" +
                   Publisher + ";" +
                   ReleaseDate + ";" +
                   language;
        }

        public override string ToString()
        {
            string info = base.ToString() + " " + language;

            return info;
        }
    }
}
