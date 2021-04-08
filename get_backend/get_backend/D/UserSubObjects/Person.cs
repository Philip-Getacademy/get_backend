
/*
 * Person is used to store personal information 
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using get_backend.D.AbstractObjects;
using get_backend.D.Interfaces;
using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects;
using static get_backend.D.StaticObjects.Id;

namespace get_backend.D.UserSubObjects
{
    internal sealed class Person : AMuteable<Person>, IDatabaseObject<Person>
    {
        /* God mode */
        internal override Person Clone => this;
        internal override void Change(Person a)
        {
            
        }

        private readonly Date Birth;
        private readonly Date CreationDate;
        private readonly Guid PId;
        private readonly Name Name;
        private readonly Contact Contact;

        private Person(Guid g) => PId = g;
        private Person(Guid g, Date d) : this(g) => Birth = d;
        private Person(Guid g, Date d, Name n) : this(g, d) => this.Name = n;
        private Person(Guid g, Date d, Name n, Contact c) : this(g, d, n) => Contact = c;

        internal Person() : this(newPersonId(), new Date(DateTime.Now), new Name(), new Contact()) { }
        internal Person(Person P) : this(P.PId, P.Birth, new Name(P.Name), P.Contact) { }

        internal string Id => PId.ToString();
        internal string BirthDate => Birth.ToString(@"dd\/MM\/yyyy");
        internal string FirstName => Name.First;
        internal string MiddleName => Name.Middle;
        internal string LastName => Name.Last;
        internal string FullName => Name.Full;

        internal string EmailAddress => Contact.Email;
        internal string PhoneNumber => Contact.Number;
        internal string HomeAddress => Contact.Street;

        internal void ChangeName(Name n) => Name.Change(n);

        internal void ChangeContactInfo(Contact c) => Contact.Change(c);
        //internal void ChangeEmail(Email E) => Contact.ChangeE(E);
        //internal void ChangeNumber(Phone P) => Contact.ChangeP(P);
        //internal void ChangeAddress(Address A) => Contact.ChangeA(A);

        internal void ChangeBirthDate(Date D) => Birth.Change(new DateTime(D.Year, D.Month, D.Day));
        public Type NameOf { get; }
        public List<FieldInfo> FieldsOf { get; }
        public List<PropertyInfo> PropertiesOf { get; }


    }
}
