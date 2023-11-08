using Xunit;

namespace Sparky
{
    public class Customer_XUnitTests
    {
        private Customer _customer;
        public Customer_XUnitTests()
        {
            _customer = new Customer();
        }

        [Fact]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            // var customer = new Customer();

            //Act
            _customer.GreetAndCombineNames("Kent", "Zurich");

            //Assert
            Assert.Equal("Hello, Kent Zurich", _customer.GreetMessage);
            Assert.Contains("Kent Zurich".ToLower(), _customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello", _customer.GreetMessage);
            Assert.EndsWith("Zurich", _customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _customer.GreetMessage);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //Arrange
            //var customer = new Customer();

            //Act

                
            //Assert
            Assert.Null(_customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountRange()
        {
            int result = _customer.Discount;

            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastname_ReturnsNotNull()
        {
            _customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(_customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(_customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstname_ThrowsException()
        {
            var exceptionDetails = Assert
                .Throws<ArgumentException>(() =>
                    _customer.GreetAndCombineNames("", "Zurich"));

            //Exception With Message
            Assert.Equal("Empty firstName", exceptionDetails?.Message);

            //Exception Without message
            Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Zurich"));
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 10;
            var result = _customer.GetCustomerDetails();

            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 110;
            var result = _customer.GetCustomerDetails();

            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
