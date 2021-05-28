using System;
using System.Collections.Generic;

namespace Library.libraryModel.models
{
    public class LibraryUser : User
    {
        private List<Publication> _publicationHistory = new List<Publication>(10);
        private List<Publication> _borrowedPublication = new List<Publication>(10);
        public LibraryUser(string firstName, string lastName, string pesel) : base(firstName, lastName, pesel)
        {

        }

        public List<Publication> PublicationHistory { get { return _publicationHistory; } }
        public List<Publication> BorrowedPublication { get { return _borrowedPublication; } }

        public void AddToHistory(Publication publication)
        {
            _publicationHistory.Add(publication);
        }

        public void borrowPublication(Publication publication)
        {
            _borrowedPublication.Add(publication);
        }

        public override bool Equals(object obj)
        {
            return obj is LibraryUser user &&
                   base.Equals(obj) &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   Pesel == user.Pesel &&
                   EqualityComparer<List<Publication>>.Default.Equals(_publicationHistory, user._publicationHistory) &&
                   EqualityComparer<List<Publication>>.Default.Equals(_borrowedPublication, user._borrowedPublication) &&
                   EqualityComparer<List<Publication>>.Default.Equals(PublicationHistory, user.PublicationHistory) &&
                   EqualityComparer<List<Publication>>.Default.Equals(BorrowedPublication, user.BorrowedPublication);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), FirstName, LastName, Pesel, _publicationHistory, _borrowedPublication, PublicationHistory, BorrowedPublication);
        }

        public bool ReturnPublication(Publication publication)
        {
            if (_borrowedPublication.Contains(publication))
            {
                _borrowedPublication.Remove(publication);
                return true;
            }

            return false;
        }

        public override string ToCSV()
        {
            return FirstName + ";" + LastName + ";" + Pesel;
        }
    }
}
