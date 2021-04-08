



using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects
{
    internal class Email : ARigid<Email>
    {
        private readonly Label L;

        internal Email() => L = new Label();
        internal Email(Label l) => L = InspectFormat(l.Value) ? new Label(l.Value) : new Label();
        protected Email(Email e) : this(e.L) { }

        internal string Value => L.Value;
        internal override Email Clone => this;

        internal override void Change( Email E ) => L.Change( E.L.Value );

        protected sealed override bool InspectFormat(string s) 
            => Regex.IsMatch(s, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]+?[^.@\s]?[0-9]?$");
    }
}


