using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.libraryModel.models.Comparator
{
     class DateComparator : IComparer<Publication>
    {
        public int Compare(Publication p1, Publication p2)
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
            
            return p1.ReleaseDate.CompareTo(p2.ReleaseDate);
        }
    }
}
