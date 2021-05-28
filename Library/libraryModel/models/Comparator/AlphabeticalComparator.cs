using System.Collections.Generic;

namespace Library.libraryModel.models.Comparator
{
    class AlphabeticalComparator : IComparer<Publication>
    {
        public int Compare(Publication p1, Publication p2)
        {
            if(p1 == null && p2 == null)
            {
                return 0;
            }
            if(p1 == null)
            {
                return 1;
            }
            if(p2 == null)
            {
                return -1;
            }
            return p1.Title.CompareTo(p2.Title);
        }
    }
}
