using System.Reflection;
using FluentValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CustomerController(IValidator<Customer> validator) : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        var result = validator.Validate(customer);
        var errors = result.Errors.Select(x => new
        {
            Property = x.PropertyName,
            Message = x.ErrorMessage
        });
        if (!result.IsValid)
            return BadRequest(errors);

        return Ok("Customer is valid");
    }
}