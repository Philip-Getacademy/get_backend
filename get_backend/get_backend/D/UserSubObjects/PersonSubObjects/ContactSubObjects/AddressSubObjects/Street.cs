using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects.AddressSubObjects
{
    internal class Street : ARigid<Street>
    {
        private readonly Label L;

        internal Street(Label l) => L = InspectFormat(l.Value) ? new Label(l.Value) : new Label();

        internal Street() => L = new Label();
        internal Street(Street a) : this(a.L) { }

        internal string Value => L.Value;
        internal override Street Clone => this;

        internal override void Change(Street a) => L.Change(a.L.Value);

        protected sealed override bool InspectFormat(string s)
            => Regex.IsMatch(s, @"^[a-zA-ZæøåÆØÅ\s]+?[0-9]?[0-9a-zA-ZæøåÆØÅ]*$");
    }
}
