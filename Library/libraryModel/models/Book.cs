using Library.libraryModel.models;
using System;
using System.Collections.Generic;

namespace Library
{
    [Serializable]
    public class Book : Publication
    {
        public const string TYPE = "książka";
        private string author;
        private int pages;
        private string isbn;

        public Book(string title, string author, int releaseDate, int pages, string publisher, string isbn) : base(title, publisher, releaseDate)
        {
            this.author = author;
            this.pages = pages;
            this.isbn = isbn;
        }

        public string Author
        {
            get { return author; }
            set { value = author; }
        }

        public int Pages
        {
            get { return pages; }
            set { value = pages; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { value = isbn; }
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   base.Equals(obj) &&
                   Title == book.Title &&
                   ReleaseDate == book.ReleaseDate &&
                   Publisher == book.Publisher &&
                   author == book.author &&
                   pages == book.pages &&
                   isbn == book.isbn &&
                   Author == book.Author &&
                   Pages == book.Pages &&
                   Isbn == book.Isbn;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Title);
            hash.Add(ReleaseDate);
            hash.Add(Publisher);
            hash.Add(author);
            hash.Add(pages);
            hash.Add(isbn);
            hash.Add(Author);
            hash.Add(Pages);
            hash.Add(Isbn);
            return hash.ToHashCode();
        }

        public override string ToCSV()
        {
            string info = TYPE + ";" +
                   Title + ";" +
                   Publisher + ";" +
                   ReleaseDate + ";" +
                   pages + ";" +
                   Publisher + ";";

            if (!string.IsNullOrEmpty(isbn))
            {
                info += isbn;
            }
            return info;
        }

        public override string ToString()
        {
            string info = base.ToString() + " " + pages + " " + Publisher;

            if (!string.IsNullOrEmpty(isbn))
            {
                info += " " + isbn;
            }

            return info;
        }
    }
}
