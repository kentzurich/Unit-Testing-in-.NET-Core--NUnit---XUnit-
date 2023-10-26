using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class Product_NUnitTests
    {
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.IsPlatinum).Returns(true);

            Product product = new() { Price = 50 };

            var result = product.GetPriceMOQAbuse(customer.Object);

            Assert.That(result, Is.EqualTo(40));
        }
    }
}
