using Moq;
using Xunit;

namespace Sparky
{
    public class Product_XUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.IsPlatinum).Returns(true);

            Product product = new() { Price = 50 };

            var result = product.GetPriceMOQAbuse(customer.Object);

            Assert.Equal(40, result);
        }
    }
}
