using System.Collections.Generic;

namespace Library.libraryModel.models.Comparator
{
    class AlphabeticalComparatorUser : IComparer<User>
    {
        public int Compare(User p1, User p2)
        {
            if (p1 == null && p2 == null)
            {
                return 0;
            }
            if (p1 == null)
            {
                return 1;
            }
            if (p2 == null)
            {
                return -1;
            }
            return p1.LastName.CompareTo(p2.LastName);
        }
    }
}

