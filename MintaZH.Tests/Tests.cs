using NUnit.Framework;
using System;

namespace MintaZH.Tests
{
    [TestFixture]
    public class Tests
    {
        AttributeHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new AttributeHelper();
        }


        [Test]
        public void ExistingDisplayNameTest()
        {
            string displayName = helper.GetPropertyDisplayName<Product>(nameof(Product.Amount));

            Assert.That(displayName, Is.EqualTo("Mennyiség"));

        }

        [Test]
        public void NotExistingDisplayNameTest()
        {
            string displayName = helper.GetPropertyDisplayName<Refigerator>(nameof(Refigerator.Products));

            Assert.That(displayName, Is.EqualTo("Products"));
        }

        [Test]
        public void NullCheckTest()
        {
            Assert.Throws(typeof(NullReferenceException),
                () => helper.GetPropertyDisplayName<Refigerator>("whatever"));
        }
    }
}
