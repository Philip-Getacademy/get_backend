using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using static get_backend_TestRepo.GlobalStaticTestGoodies.StaticTestGoodies;

namespace get_backend_TestRepo.D.PersonSubObjects.ContactSubObjects
{
    class TestEmail
    {
        private Email A;
        private Email B;
        private Email C;
        private Email D;
        private Email E;
        private Email F;
        private Email G;

        private const string BTest = "23456";
        private const string CTest = "23456@123";
        private const string DTest = "23456@123.10";
        private const string ETest = "23456@123.abc10";
        private const string FTest = "23456@123.ab";
        private const string GTest = "valid@email.com";

        [SetUp]
        public void Setup()
        {
            A = new Email();
            B = new Email();
            C = new Email();
            D = new Email();
            E = new Email();
            F = new Email();
            G = new Email();

            B.Change(new Email(new Label(BTest)));
            C.Change(new Email(new Label(CTest)));
            D.Change(new Email(new Label(DTest)));
            E.Change(new Email(new Label(ETest)));
            F.Change(new Email(new Label(FTest)));
            G.Change(new Email(new Label(GTest)));
        }

        [Test] public void DefautCtor()                                                   => TestForStringEmpty(A.Value);
        [Test] public void WrongFormatOnlyNumbers()                                       => TestForStringEmpty(B.Value);
        [Test] public void WrongFormatOnlyNumbersAndAtChar()                              => TestForStringEmpty(C.Value);
        [Test] public void WrongFormatOnlyNumbersAndAtCharWithOnlyNumbersInDomain()       => TestForStringEmpty(D.Value);
        [Test] public void CorrectFormatOnlyNumbersAndAtCharWithNumbersInDomainAtTheEnd() => AreEqual(ETest, E.Value);
        [Test] public void CorrectFormatOnlyNumbersAndAtCharWithCharsAtTheEnd()           => AreEqual(FTest, F.Value);
        [Test] public void CorrectFormatStandardEmailAddressTest()                        => AreEqual(GTest, G.Value);

    }
}
