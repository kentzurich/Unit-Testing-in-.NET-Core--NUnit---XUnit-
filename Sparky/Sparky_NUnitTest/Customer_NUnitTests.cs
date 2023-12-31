﻿using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class Customer_NUnitTests
    {
        private Customer _customer;
        [SetUp] 
        public void SetUp() 
        { 
            _customer = new Customer();
        }

        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
           // var customer = new Customer();

            //Act
            _customer.GreetAndCombineNames("Kent", "Zurich");

            Assert.Multiple(() =>
            {
                //Assert
                Assert.AreEqual(_customer.GreetMessage, "Hello, Kent Zurich");

                Assert.That(_customer.GreetMessage, Is.EqualTo("Hello, Kent Zurich"));
                Assert.That(_customer.GreetMessage, Does.Contain("Kent Zurich"));
                Assert.That(_customer.GreetMessage, Does.Contain("kent zurich").IgnoreCase);
                Assert.That(_customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(_customer.GreetMessage, Does.EndWith("Zurich"));
                Assert.That(_customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //Arrange
            //var customer = new Customer();

            //Act


            //Assert
            Assert.IsNull(_customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountRange()
        {
            int result = _customer.Discount;

            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastname_ReturnsNotNull()
        {
            _customer.GreetAndCombineNames("ben", "");

            Assert.IsNotNull(_customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(_customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstname_ThrowsException()
        {
            var exceptionDetails = Assert
                .Throws<ArgumentException>(() => 
                    _customer.GreetAndCombineNames("", "Zurich"));

            //Exception With Message
            Assert.AreEqual("Empty firstName", exceptionDetails?.Message);

            Assert.That(() => 
                _customer.GreetAndCombineNames("", "Zurich"), 
                Throws.ArgumentException.With.Message.EqualTo("Empty firstName"));


            //Exception Without message
            Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Zurich"));

            Assert.That(() =>
                _customer.GreetAndCombineNames("", "Zurich"), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 10;
            var result = _customer.GetCustomerDetails();

            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 110;
            var result = _customer.GetCustomerDetails();

            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
