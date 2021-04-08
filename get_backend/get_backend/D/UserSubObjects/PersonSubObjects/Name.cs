using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects
{
    internal class Name : ARigid<Name>
    {
        private readonly Label F; // First Name
        private readonly Label M; // Middle Name
        private readonly Label L; // Last Name

        internal Name()
        {
            F = new Label();
            M = new Label();
            L = new Label();
        }

        internal Name( Label f, Label m, Label l )
        {
            F = InspectFormat(f.Value) ? f : new Label();
            M = InspectFormat(m.Value) ? m : new Label();
            L = InspectFormat(l.Value) ? l : new Label();
        }

        internal Name(Name n)
        {
            F = new Label(n.First);
            M = new Label(n.Middle);
            L = new Label(n.Last);
        }

        internal override Name Clone => this;
        internal string First    => F.Value;
        internal string Middle   => M.Value;
        internal string Last     => L.Value;
        internal string Full     => First + Middle + Last == string.Empty ? string.Empty : string.Join((char)32, First, Middle, Last);

        protected sealed override bool InspectFormat(string s) => Regex.IsMatch(s, @"^[a-zA-ZæøåÆØÅ\s]+?$");

        internal override void Change ( Name  N ) => ChangeWholeName( N.F, N.M, N.L );
        private void ChangeWholeName  ( Label f, Label m, Label l ) { ChangeFirstName(f); ChangeMiddleName(m); ChangeLastName(l); }
        private void ChangeFirstName  ( Label f ) => F.Change(f.Value);
        private void ChangeMiddleName ( Label m ) => M.Change(m.Value);
        private void ChangeLastName   ( Label l ) => L.Change(l.Value);
    }
}
