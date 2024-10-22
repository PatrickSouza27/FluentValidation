using FluentValidation.Models;
using FluentValidation.TestHelper;
using FluentValidation.Validators;

namespace TestValidationTest;

[TestClass]
public class CustomerTest
{
    private readonly CustomerValidator _validator;
    private readonly Customer _customer;

    public CustomerTest()
    {
        _validator = new CustomerValidator();
        _customer = new Customer("Patrick", "test@example.com", 25, new DateTime(2000, 1, 1), true, true, ["Doctor"]);
    }

    [TestMethod]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        _customer.Name = "";
        var result = _validator.TestValidate(_customer);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }
    
    [TestMethod]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        _customer.Email = "invalid-email";
        var result = _validator.TestValidate(_customer);
        result.ShouldHaveValidationErrorFor(c => c.Email);
    }
    
    [TestMethod]
    public void Should_Have_Error_When_Age_Is_Out_Of_Range()
    {
        _customer.Age = 17;
        var result = _validator.TestValidate(_customer);
        result.ShouldHaveValidationErrorFor(c => c.Age);
    }
    
    [TestMethod]
    public void Should_Not_Have_Error_When_Model_Is_Valid()
    {
        var result = _validator.TestValidate(_customer);
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [TestMethod]
    public void Should_Have_Error_When_Email_Domain_Is_Invalid()
    {
        _customer.Email = "test@invalid.com";
        var result = _validator.TestValidate(_customer);
        result.ShouldHaveValidationErrorFor(c => c.Email).WithErrorMessage("Email domain must be example.com");
    }
}