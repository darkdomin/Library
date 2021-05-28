using System;

namespace Library.libraryModel.models
{
    public abstract class User : CsvConvertible
    {

        private string _firstName;
        private string _lastName;
        private string _pesel;

        public User(string firstName, string lastName, string pesel)
        {
            _firstName = firstName;
            _lastName = lastName;
            _pesel = pesel;
        }

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Pesel { get { return _pesel; } set { _pesel = value; } }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   _firstName == user._firstName &&
                   _lastName == user._lastName &&
                   _pesel == user._pesel &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   Pesel == user.Pesel;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, _pesel, FirstName, LastName, Pesel);
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName + " " + _pesel;
        }

        public abstract string ToCSV();

    }
}
