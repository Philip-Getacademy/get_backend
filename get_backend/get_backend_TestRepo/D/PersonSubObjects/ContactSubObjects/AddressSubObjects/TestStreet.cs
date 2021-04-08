using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects.ContactSubObjects.AddressSubObjects;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using static get_backend_TestRepo.GlobalStaticTestGoodies.StaticTestGoodies;

namespace get_backend_TestRepo.D.PersonSubObjects.ContactSubObjects.AddressSubObjects
{
    internal class TestStreet
    {
        private Street A;
        private Street B;
        private Street C;
        private Street D;
        private Street E;
        private Street F;
        private Street G;
        private Street H;
        private Street I;

        private const string BTest = "123 wrong address format 7";
        private const string CTest = "Correct 7";
        private const string DTest = "Correct address format 7";
        private const string ETest = "Correct address format 7a";
        private const string FTest = "Correct address format 77a";
        private const string GTest = "Testing value from ctor init without ending number";
        private const string HTest = "Testing value from ctor init with ending number 7";
        private const string ITest = HTest;


        [SetUp] public void Setup()
        {

            A = new Street();
            B = new Street();
            C = new Street();
            D = new Street();
            E = new Street();
            F = new Street();
            G = new Street(new Label(GTest));
            H = new Street(new Label(HTest));
            I = new Street();

            B.Change(new Street(new Label(BTest)));
            C.Change(new Street(new Label(CTest)));
            D.Change(new Street(new Label(DTest)));
            E.Change(new Street(new Label(ETest)));
            F.Change(new Street(new Label(FTest)));
            I.Change(H.Clone);
        }
        
        [Test] public void DefautCtor()                                                      => TestForStringEmpty(A.Value);
        [Test] public void WrongFormat()                                                     => TestForStringEmpty(B.Value);
        [Test] public void CorrectFormatSingularSpaceAndNumber()                             => AreEqual(CTest, C.Value);
        [Test] public void CorrectFormatMultipleSpacesAndNumber()                            => AreEqual(DTest, D.Value);
        [Test] public void CorrectFormatMultipleSpacesAndNumberAndSubletter()                => AreEqual(ETest, E.Value);
        [Test] public void CorrectFormatMultipleSpacesAndNumbersAndSubletter()               => AreEqual(FTest, F.Value);
        [Test] public void CheckingThatValueIsSetThroughCtorInstanceiation()                 => AreEqual(GTest, G.Value);
        [Test] public void CheckingThatValueIsSetThroughCtorInstanceiationWithEndingLetter() => AreEqual(HTest, H.Value);
        [Test] public void CheckingClone() => AreEqual(ITest, I.Value);
    }
}
