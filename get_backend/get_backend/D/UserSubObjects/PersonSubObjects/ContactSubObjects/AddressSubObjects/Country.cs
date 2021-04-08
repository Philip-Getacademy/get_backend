using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects.AddressSubObjects
{
    internal class Country : ARigid<Country>
    {
        private readonly Label L;

        private Country(Label l) => L = InspectFormat(l.Value) ? new Label(l.Value) : new Label();

        internal Country() => L = new Label();
        internal Country(Country a) : this(a.L) { }

        internal string Value => L.Value;
        internal override Country Clone => this;

        internal override void Change(Country a) => L.Change(a.L.Value);

        protected sealed override bool InspectFormat(string s)
            => Regex.IsMatch(s, @"^[a-zA-ZæøåÆØÅ\s]{32}$");

    }
}
