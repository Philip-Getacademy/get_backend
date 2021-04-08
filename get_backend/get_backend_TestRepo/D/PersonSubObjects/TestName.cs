using System;
using System.Collections.Generic;
using System.Text;
using get_backend.D.PrimitiveObjects;
using get_backend.D.UserSubObjects.PersonSubObjects;
using NUnit.Framework;
using static get_backend_TestRepo.GlobalStaticTestGoodies.StaticTestGoodies;

namespace get_backend_TestRepo.D.PersonSubObjects
{
    class TestName
    {
        private Name A;
        private Name B;
        private Name C;
        private Name D;
        private Name E;

        private static readonly string[] ValidExampleName = {"Per", "Johan", "Pettersen"};
        private static readonly string[] InvalidExampleName = {"P3r", "Joh4n", "Pettersen@"};
        private static readonly string[] ValidExampleFirstNameRestInvalid = {"Per", "Joh4n", "Pettersen@"};
        private static readonly string[] ValidExampleFirstNameRestInvalidTest = {"Per", string.Empty, string.Empty};

        private string[] BTest => new [] { B.First, B.Middle, B.Last };
        private string[] CTest => new [] { C.First, C.Middle, C.Last };
        private string[] DTest => new [] { D.First, D.Middle, D.Last };
        private string[] ETest => new [] { E.First, E.Middle, E.Last };

        [SetUp]
        public void Setup()
        {
            A = new Name();
            B = new Name(new Label(ValidExampleName[0]), new Label(ValidExampleName[1]), new Label(ValidExampleName[2]));
            C = new Name(new Label(InvalidExampleName[0]), new Label(InvalidExampleName[1]), new Label(InvalidExampleName[2]));
            D = new Name(new Label(ValidExampleFirstNameRestInvalid[0]), new Label(ValidExampleFirstNameRestInvalid[1]), new Label(ValidExampleFirstNameRestInvalid[2]));
            E = new Name();

            var firstName = new Label(ValidExampleName[0]);
            var middleName = new Label(ValidExampleName[1]);
            var lastName = new Label(ValidExampleName[2]);
            E.Change(new Name(firstName, middleName, lastName));
        }

        [Test] public void DefaultCtor() => TestMultipleForStringEmpty(A.First, A.Middle, A.Last);
        [Test] public void CheckingFullNameProperty() => TestForStringEmpty(A.Full);
        [Test] public void CheckingCtorWithCorrectValues() => TestMultipleForStringAsParameters(ValidExampleName, BTest);
        [Test] public void CheckingCtorWithIncorrectValues() => TestMultipleForStringEmpty( CTest );
        [Test] public void CheckingCtorWithCorrectFirstNameOnly() => TestMultipleForStringAsParameters(ValidExampleFirstNameRestInvalidTest, DTest);
        [Test] public void DefaultCtorInjectionViaChange() => TestMultipleForStringAsParameters(ValidExampleName, ETest);

    }
}
