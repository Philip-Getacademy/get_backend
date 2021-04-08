using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace get_backend_TestRepo.GlobalStaticTestGoodies
{
    internal static class StaticTestGoodies
    {

        public static void TestForStringEmpty(string input)              => AreEqual(string.Empty, input, "Test resulted in a string not being empty");
        public static void TestMultipleForStringEmpty(params string[] a) => a.ToList().ForEach(TestForStringEmpty);

        

        public static void TestMultipleForStringAsParameters(string[] a, string[] b) => a.Zip(b, Tuple.Create).ToList().ForEach(t => TestForStringAsParameter(t.Item1, t.Item2));
        private static void TestForStringAsParameter(string a, string b) => AreEqual(a, b);


        public static void s(string[] a, string[] b, string[] c) => 
            a.z(b).t(c).TupleList().ForEach(t => AreEqual(t.Item1, t.Item2, t.Item3));

        private static IEnumerable<Tuple<string, string>> z(this string[] a, string[] b) => a.Zip(b, Tuple.Create).ToList();
        private static IEnumerable<Tuple<Tuple<string, string>, string>> t(this IEnumerable<Tuple<string, string>> a, string[] b) => a.Zip(b, Tuple.Create).ToList();

        private static List<Tuple<string, string, string>> TupleList(this IEnumerable<Tuple<Tuple<string, string>, string>> x) =>
            x.Select(i => Tuple.Create(i.Item1.Item1, i.Item1.Item2, i.Item2)).ToList();


        // Docummentation for TestMultipleForStringAsParameters, this does the same thing
        //public static void TestMultipleForStringAsParameters(string[] a, string[] b)
        //{
        //    for (var i = 0; i < a.Length; i++)
        //        TestForStringAsParameter(a[i], b[i]);
        //}
    }
}
