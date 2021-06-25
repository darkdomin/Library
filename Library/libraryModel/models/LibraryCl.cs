using Library.libraryModel.ExceptionMy;
using System.Collections.Generic;
using System.Linq;

namespace Library.libraryModel.models
{
    public class LibraryCl
    {
        private readonly Dictionary<string, Publication> _publications = new Dictionary<string, Publication>();
        private readonly Dictionary<string, LibraryUser> _users = new Dictionary<string, LibraryUser>();

        public Dictionary<string, Publication> Publications { get { return _publications; } }

        public ICollection<Publication> GetSortedPublications(IComparer<Publication> comparator)
        {
            var values =(_publications.Values).ToList();
            values.Sort(comparator);
            return values;
        }

        public Dictionary<string, LibraryUser> Users { get { return _users; } }

        public ICollection<LibraryUser> GetSortedUsers(IComparer<LibraryUser> comparator)
        {
            var values = (_users.Values).ToList();
            values.Sort(comparator);
            return values;
        }

        public Publication AddPublication(Publication publication)
        {
            // to nie musi być pozycji w bibliotece takich samych może być kilka
            if (_publications.ContainsKey(publication.Title))
            {
                throw new PublicationAlreadyExistsException("Taka publikacja już istnieje");
            }

            _publications.Add(publication.Title,publication);

            return publication;
        }

        public LibraryUser AddUser(LibraryUser user)
        {
            // to nie musi być pozycji w bibliotece takich samych może być kilka
            if (_users.ContainsKey(user.Pesel))
            {
                throw new UserAlreadyExistsException("Taki użytkownik już istnieje!");
            }

            _users.Add(user.Pesel, user);

            return user;
        }

        public bool RemovePublication(Publication publication)
        {
            if(_publications.ContainsValue(publication))
            {
                _publications.Remove(publication.Title);
                return true;
            }

            return false;
        }
    }
}
