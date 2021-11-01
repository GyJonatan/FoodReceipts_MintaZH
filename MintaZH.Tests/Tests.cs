using NUnit.Framework;
using System;

namespace MintaZH.Tests
{
    /*
     a) Alakítson ki egy olyan különálló DLL-t, melyben unittesztelést hajthatunk végre a félév során tanultak
        alapján. (2 pont)
            Ez igazából a külön projectet jelenti. Létrehozunk egy új class libraryt, feltesszük rá a

                - Microsoft.Net.Test.Sdk
                - NUnit
                - NUnit3TestAdapter

            csomagokat és már kész is vagyunk.

    b) Készítsen egy osztályt az AttributeHelper osztályhoz, melyben háromféleképpen leteszteli a
       GetPropertyDisplayName() metódus működését:

     */

    [TestFixture]
    public class Tests
    {
        AttributeHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new AttributeHelper();
        }

         //a. olyan osztály tulajdonságára, melyen található (saját) DisplayName attribútum (1,5 pont)
        [Test]
        public void ExistingDisplayNameTest()
        {
            string displayName = helper.GetPropertyDisplayName<Product>(nameof(Product.Amount));

            Assert.That(displayName, Is.EqualTo("Mennyiség"));
        }

        //b. olyan osztály tulajdonságra, melyen nem található DisplayName attribútum (1,5 pont)
        [Test]
        public void NotExistingDisplayNameTest()
        {
            string displayName = helper.GetPropertyDisplayName<Refigerator>(nameof(Refigerator.Products));

            Assert.That(displayName, Is.EqualTo("Products"));
        }
        /*
         c. null értékre. Az esetlegesen keletkező kivételt kezelje le olyan módszerrel, mint amit a félév során
            tanultunk (1,5 pont)
         */
        [Test]
        public void NullCheckTest()
        {
            Assert.Throws(typeof(NullReferenceException),
                () => helper.GetPropertyDisplayName<Refigerator>("whatever"));
        }
    }
}
