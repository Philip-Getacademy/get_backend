using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects.AddressSubObjects
{
    internal class PostalCode : ARigid<PostalCode>
    {
        private readonly Label L;

        private PostalCode(Label l) => L = InspectFormat(l.Value) ? new Label(l.Value) : new Label();

        internal PostalCode() => L = new Label();
        internal PostalCode(PostalCode a) : this(a.L) { }

        internal string Value => L.Value;
        internal override PostalCode Clone => this;

        internal override void Change(PostalCode a) => L.Change(a.L.Value);

        protected sealed override bool InspectFormat(string s)
            => Regex.IsMatch(s, @"^[0-9]{4}$");
    }
}
