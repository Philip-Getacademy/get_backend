using get_backend.D.AbstractObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects;

namespace get_backend.D.UserSubObjects.PersonSubObjects
{
    internal class Contact : AMuteable<Contact>
    {
        private readonly Email E;   
        private readonly Phone P;  
        private readonly Address A;

        internal Contact()
        {
            E = new Email(); 
            P = new Phone(); 
            A = new Address();
        }

        internal Contact(Email e, Phone p, Address a)
        {
            E = e; 
            P = p; 
            A = a;
        }

        internal string Email   => E.Value;
        internal string Number  => P.Value;
        internal string Street => A.Street;

        internal override Contact Clone => this;

        internal override void Change ( Contact C ) => ChangeContact( C.E, C.P, C.A );
        private void ChangeContact    ( Email e, Phone p, Address a ) { ChangeEmail(e); ChangePhone(p); ChangeAddress(a); }
        private void ChangeEmail      ( Email e   ) => E.Change(e);
        private void ChangePhone      ( Phone p   ) => P.Change(p);
        private void ChangeAddress    ( Address a ) => A.Change(a);
    }
}