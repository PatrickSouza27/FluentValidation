namespace FluentValidation.Models;

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    
    public bool ActiveIdentity { get; set; }
    
    public bool Identity { get; set; }
    public List<string> Roles { get; set; }
    
    public Customer(string name, string email, int age, DateTime birthDate, bool activeIdentity, bool identity, List<string> roles)
    {
        Name = name;
        Email = email;
        Age = age;
        BirthDate = birthDate;
        ActiveIdentity = activeIdentity;
        Identity = identity;
        Roles = roles;
    }
}