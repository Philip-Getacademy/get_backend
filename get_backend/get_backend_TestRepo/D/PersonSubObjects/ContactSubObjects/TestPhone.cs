using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using static get_backend_TestRepo.GlobalStaticTestGoodies.StaticTestGoodies;

namespace get_backend_TestRepo.D.PersonSubObjects.ContactSubObjects
{
    class TestPhone
    {
        private Phone A;
        private Phone B;
        private Phone C;
        private Phone D;

        private const string BTest = "abc";
        private const string CTest = "123456789";
        private const string DTest = "12345678";
        

        [SetUp]
        public void Setup()
        {
            A = new Phone();
            B = new Phone();
            C = new Phone();
            D = new Phone();

            B.Change(new Phone(new Label(BTest)));
            C.Change(new Phone(new Label(CTest)));
            D.Change(new Phone(new Label(DTest)));
        }

        [Test] public void DefautCtor()      => TestForStringEmpty(A.Value);
        [Test] public void WrongFormat()     => TestForStringEmpty(B.Value);
        [Test] public void IncorrectLength() => TestForStringEmpty(C.Value);
        [Test] public void CorrectFormat()   => AreEqual(DTest, D.Value);
    }
}
