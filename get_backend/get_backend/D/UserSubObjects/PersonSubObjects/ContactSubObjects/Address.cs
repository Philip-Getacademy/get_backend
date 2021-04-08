



using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects.AddressSubObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects
{
    internal class Address : AMuteable<Address>
    {
        internal override Address Clone => this;

        internal override void Change(Address a)
        {
            S.Change(a.S);
        }

        internal Address(Street s, Country c, PostalCode p) : this(s, c) => P = new PostalCode(p);
        internal Address(Address a) : this(a.S, a.C, a.P) { }
        internal Address()
        {
            S = new Street(); // https://en.wikipedia.org/wiki/Address
            C = new Country(); // https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
            P = new PostalCode(); // https://en.wikipedia.org/wiki/List_of_postal_codes
        }

        internal string Street => S.Value;
        internal string Country => C.Value;
        

        private readonly Street S;
        private readonly Country C;
        private readonly PostalCode P;
        private Address(Street s) => S = new Street(s);
        private Address(Street s, Country c) : this(s) => C = new Country(c);
        


    }
}
