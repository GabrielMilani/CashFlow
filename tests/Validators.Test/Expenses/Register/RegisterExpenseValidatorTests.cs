using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.Should().BeTrue();
        }
        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Error_Title_Empty(string title)
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = title;
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The title is required."));
        }

        [Fact]
        public void Error_Date_Future()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Date = DateTime.UtcNow.AddDays(1);
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Expenses cannot be for the future."));
        }

        [Fact]
        public void Error_Payment_Type_Invalid()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.PaymentType = (EPaymentType)500;
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Payment type is not valid."));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void Error_Amount_Invalid(decimal amount)
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Amount = amount;
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The Amount must be greater than zero."));
        }
    }
}
