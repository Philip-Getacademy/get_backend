using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects.AddressSubObjects;
using NUnit.Framework;
using static get_backend_TestRepo.GlobalStaticTestGoodies.StaticTestGoodies;

namespace get_backend_TestRepo.D.PersonSubObjects
{
    class TestContact
    {
        private Contact A;
        private Contact B;

        private const string StreetAddress = "Hakkebakkeskogen 10a";
        private const string Email = "espen@kykkelikokkos.no";
        private const string Number = "81549300";

        private static readonly string[] Contact = { StreetAddress, Email, Number };
        private string[] BTest => new []{ B.Street, B.Email, B.Number };

        [SetUp]
        public void Setup()
        {
            A = new Contact();
            B = new Contact();

            var address = new Address(new Street(new Label(StreetAddress)), new Country(), new PostalCode());
            var email = new Email(new Label(Email));
            var number = new Phone(new Label(Number));
            B.Change(new Contact(email, number, address));
        }

        [Test] public void DefaultCtor() => TestMultipleForStringEmpty(A.Street, A.Email, A.Number);
        [Test] public void EmptyInstantiationWithMethodValueMutation() => TestMultipleForStringAsParameters(Contact, BTest);
    }
}
