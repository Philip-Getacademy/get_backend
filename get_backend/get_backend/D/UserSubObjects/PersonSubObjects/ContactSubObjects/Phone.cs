



using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects
{
    internal class Phone : ARigid<Phone>
    {
        private readonly Label L;

        internal Phone() => L = new Label();
        internal Phone(Label l) => L = InspectFormat(l.Value) ? new Label(l.Value) : new Label();
        protected Phone(Phone p) : this(p.L) { }

        internal string Value => L.Value;
        internal override Phone Clone => this;

        internal override void Change( Phone P ) => L.Change(P.L.Value);

        protected sealed override bool InspectFormat(string s) 
            => Regex.IsMatch(s, @"^[0-9]{8}$");
    }
}


