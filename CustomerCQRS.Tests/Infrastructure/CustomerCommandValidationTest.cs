using CustomerCQRS.Core.Common;
using CustomerCQRS.Infrastructure.Customers.Commands;
using FluentValidation.TestHelper;
using Moq;
using System;
using Xunit;

namespace CustomerCQRS.Tests.Infrastructure
{
    public class CustomerCommandValidationTest
    {
        private readonly UpdateCustomerCommandValidator _updateCustomerValidator;
        private readonly CreateCustomerCommandValidator _createCustomerValidator;

        public CustomerCommandValidationTest()
        {
            var dateTime = new Mock<IDateTime>();
            dateTime.Setup(d=> d.Now).Returns(new DateTime(2021,1,1));

            _createCustomerValidator = new CreateCustomerCommandValidator(dateTime.Object);
            _updateCustomerValidator = new UpdateCustomerCommandValidator(dateTime.Object);
        }

        #region Create Customer Tests

        [Fact]
        public void CreateCustomer_ValidatesAllNullFields ()
        {
            // Arange
            var customer = new CreateCustomerCommand();

            // Act
            var result = _createCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveAnyValidationError();
        }

        [Fact]
        public void CreateCustomer_ValidatesFirstName()
        {
            // Arange
            var customer = new CreateCustomerCommand()
            {
                LastName = "Smith",
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            // Act
            var result = _createCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x=> x.FirstName);
        }

        [Fact]
        public void CreateCustomer_ValidatesLastName()
        {
            // Arange
            var customer = new CreateCustomerCommand()
            {
                FirstName = "Ted",
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            // Act
            var result = _createCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void CreateCustomer_ValidatesNullDate()
        {
            // Arange
            var customer = new CreateCustomerCommand()
            {
                FirstName = "Ted",
                LastName = "Smith"
            };

            // Act
            var result = _createCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [Fact]
        public void CreateCustomer_ValidatesPersonWhoIsTooOld()
        {
            // Arange
            var customer = new CreateCustomerCommand()
            {
                FirstName = "Ted",
                LastName = "Smith",
                DateOfBirth = DateTime.Now.AddYears(-300)
            };

            // Act
            var result = _createCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth)
                .WithErrorMessage("Cannot be older than 100");
        }

        [Fact]
        public void CreateCustomer_ValidatesPersonWhoIsBornInTheFuture()
        {
            // Arange
            var customer = new CreateCustomerCommand()
            {
                FirstName = "Ted",
                LastName = "Smith",
                DateOfBirth = DateTime.Now.AddYears(+300)
            };

            // Act
            var result = _createCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth)
                .WithErrorMessage("Date of birth cannot be in the future");
        }

        #endregion

        #region Update Customer Tests

        [Fact]
        public void UpdateCustomer_ValidatesAllNullFields()
        {
            // Arange
            var customer = new UpdateCustomerCommand();

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveAnyValidationError();
        }

        public void UpdateCustomer_ValidatesDefaultIdField()
        {
            // Arange
            var customer = new UpdateCustomerCommand()
            {
                Id = default(Guid)
            };

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveAnyValidationError();
        }

        [Fact]
        public void UpdateCustomer_ValidatesFirstName()
        {
            // Arange
            var customer = new UpdateCustomerCommand()
            {
                LastName = "Smith",
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void UpdateCustomer_ValidatesLastName()
        {
            // Arange
            var customer = new UpdateCustomerCommand()
            {
                FirstName = "Ted",
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void UpdateCustomer_ValidatesNullDate()
        {
            // Arange
            var customer = new UpdateCustomerCommand()
            {
                FirstName = "Ted",
                LastName = "Smith"
            };

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [Fact]
        public void UpdateCustomer_ValidatesPersonWhoIsTooOld()
        {
            // Arange
            var customer = new UpdateCustomerCommand()
            {
                FirstName = "Ted",
                LastName = "Smith",
                DateOfBirth = DateTime.Now.AddYears(-300)
            };

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth)
                .WithErrorMessage("Cannot be older than 100");
        }

        [Fact]
        public void UpdateCustomer_ValidatesPersonWhoIsBornInTheFuture()
        {
            // Arange
            var customer = new UpdateCustomerCommand()
            {
                FirstName = "Ted",
                LastName = "Smith",
                DateOfBirth = DateTime.Now.AddYears(+300)
            };

            // Act
            var result = _updateCustomerValidator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth)
                .WithErrorMessage("Date of birth cannot be in the future");
        }

        #endregion
    }
}
