using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using get_backend.D.AbstractObjects;
using get_backend.D.CollectionObjects;
using get_backend.D.Interfaces;
using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects;
using get_backend.D.UserSubObjects.PersonSubObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects;
using static get_backend.D.StaticObjects.Id;

namespace get_backend.D
{
    internal sealed class User : AMuteable<User>, IDatabaseObject<User>
    {
        /* IDatabaseObject<T> */
        public Type NameOf => GetType();
        public List<FieldInfo> FieldsOf => GetType().GetFields().ToList();
        public List<PropertyInfo> PropertiesOf => GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).ToList();

        /* Fields */
        private readonly Passport Passport;
        private readonly DateTime CreationTime;
        private readonly Guid UId;
        private readonly Person Person;
        private readonly Properties Properties;

        private readonly List<Application> Applications;
        private readonly List<Assignment> Assignments;

        internal string NewProperty => "hei";

        public User()
        {
            CreationTime = DateTime.Now;
            UId = newUserId();
            Passport = new Passport(UId);
            //Applications = new List<Application>();
            //Applications.Add(new Application(UId, EApplicationType.moduleOne));
            //Assignments.Add(new Assignment(UId));

            Person = new Person();
            Properties = new Properties();
        }

        internal User(User U)
        {
            UId = U.UId;
            CreationTime = DateTime.Now;
            Passport = new Passport(U.Passport, U.UId);
            Person = new Person(U.Person);
            Properties = new Properties(U.Properties);
            //Applications = new List<Application>(U.Applications);
            //Assignments = new List<Assignment>(U.Assignments);
        }

        internal override User Clone => this;
        internal override void Change(User t)
        {
            ChangePersonBirthDate(BirthDate);
            ChangePersonName(t.FirstName, t.MiddleName, t.LastName);
            //ChangePersonContact(t.EmailAddress, t.PhoneNumber, t.HomeAddress);
        }

        


        internal string UserId       => UId.ToString();
        internal string TimeStamp    => CreationTime.ToString(@"dd\/MM\/yyyy");

        internal string PersonId     => Person.Id;
        internal string BirthDate    => Person.BirthDate;
        internal string FirstName    => Person.FirstName;
        internal string MiddleName   => Person.MiddleName;
        internal string LastName     => Person.LastName;
        internal string FullName     => Person.FullName;
        internal string EmailAddress => Person.EmailAddress;
        internal string PhoneNumber  => Person.PhoneNumber;
        internal string HomeAddress  => Person.HomeAddress;

        internal void ChangePersonBirthDate(string DDMMYYYY) => Person.ChangeBirthDate(Date(DDMMYYYY));
        internal void ChangePersonName     (string F, string M, string L) => Person.ChangeName(Name(F, M, L));
        //internal void ChangePersonContact  (string E, string P, string H) => Person.ChangeContactInfo(Contact(E, P, H));

        internal bool   CanDriveCar  => Properties.CanDriveCar.Value;
        internal bool   AccessToCar  => Properties.AccessToCar.Value;
        internal bool   UserCanMove  => Properties.UserCanMove.Value;
        internal bool   FullTimeJob  => Properties.FullTimeJob.Value;
        internal bool   PartTimeJob  => Properties.PartTimeJob.Value;
        internal bool   WillCommute  => Properties.WillCommute.Value;
        internal bool   PublishUser  => Properties.PublishUser.Value;

        internal void ChangeCanDriveCar(bool b) => Properties.CanDriveCar.Change(b);
        internal void ChangeAccessToCar(bool b) => Properties.AccessToCar.Change(b);
        internal void ChangeUserCanMove(bool b) => Properties.UserCanMove.Change(b);
        internal void ChangeFullTimeJob(bool b) => Properties.FullTimeJob.Change(b);
        internal void ChangePartTimeJob(bool b) => Properties.PartTimeJob.Change(b);
        internal void ChangeWillCommute(bool b) => Properties.WillCommute.Change(b);
        internal void ChangePublishUser(bool b) => Properties.PublishUser.Change(b);

        //internal void ChangeApplication(string E, string R, string Q) => _application.Change(newApplication(E, R, Q));


        //private Application newApplication(string e, string r, string q) => new Application(Label(e), Label(r), Label(q));

        private static Date Date(string DDMMYYY) => new Date
        {
            Day   = ParseTwo(DDMMYYY.ToCharArray(), new[] { 0, 1 }), 
            Month = ParseTwo(DDMMYYY.ToCharArray(), new[] { 2, 4 }), 
            Year = ParseFour(DDMMYYY.ToCharArray(), new[] { 4, 5, 6, 7 })
        };

        private static int ParseTwo(char[] a, int[] i) => Convert.ToInt32(string.Concat(a[i[0]], a[i[1]]));
        private static int ParseFour(char[] a, int[] i) => Convert.ToInt32(string.Concat(a[i[0]], a[i[1]], a[i[2]], a[i[3]]));

        private Name Name(string f, string m, string l) => new Name(Label(f), Label(m), Label(l));

        //private Contact Contact(string e, string p, string h) => new Contact(Email(e), Phone(p), Address(h));
        private Phone Phone(string content) => new Phone(Label(content));
        private Email Email(string content) => new Email(Label(content));
        //private Address Address(string content) => new Address(Label(content));
        private Label Label(string content) => new Label(content);

    }
}
