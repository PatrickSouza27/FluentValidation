using FluentValidation.Models;

namespace FluentValidation.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x=> x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email address");
        
        RuleFor(x => x.Age)
            .InclusiveBetween(18, 60)
            .WithMessage("Age must be between 18 and 60");
        
        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now)
            .WithMessage("Birth date must be less than current date");
        
        RuleForEach(x=> x.Roles)
            .NotEmpty()
            .WithMessage("Role is Required");
        
        RuleFor(x => x.Identity)
            .NotEmpty().When(c=> c.ActiveIdentity)
            .WithMessage("Identity is required when ActiveIdentity is true");
        
        RuleFor(x => x.Email)
            .Must(BeAValidDomain)
            .WithMessage("Email domain must be example.com");
    }
    private bool BeAValidDomain(string email)
    {
        return email.EndsWith("@example.com");
    }
}