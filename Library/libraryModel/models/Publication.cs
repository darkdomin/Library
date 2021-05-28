using System;

namespace Library.libraryModel.models
{
    [Serializable]
    public abstract class Publication : IComparable<Publication>, CsvConvertible
    {
        private string title;
        private int releaseDate;
        private string publisher;

        public Publication(string title, string publisher, int releaseDate )
        {
            this.title = title;
            this.publisher = publisher;
            this.releaseDate = releaseDate; 
        }

        public string Title
        {
            get { return title; }
            set { value = title; }
        }

        public int ReleaseDate
        {
            get { return releaseDate; }
            set { value = releaseDate; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { value = publisher; }
        }

        public  override string ToString()
        {
            return title + " " + publisher + " " + releaseDate;
        }

       // public abstract string ToCSV();

        public int CompareTo(Publication publication)
        {
            return title.CompareTo(publication.title);
        }

        public abstract string ToCSV();

        public override bool Equals(object obj)
        {
            return obj is Publication publication &&
                   title == publication.title &&
                   releaseDate == publication.releaseDate &&
                   publisher == publication.publisher &&
                   Title == publication.Title &&
                   ReleaseDate == publication.ReleaseDate &&
                   Publisher == publication.Publisher;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(title, releaseDate, publisher, Title, ReleaseDate, Publisher);
        }
    }
}
