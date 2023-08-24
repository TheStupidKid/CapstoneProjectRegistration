namespace CapstoneProjectRegistrationWeb.Models
{
    public class RegisterViewModel
    {
        string Email { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string PhoneNumber { get; set; }
        string Avatar { get; set; }
        DateTime Dob { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
    }
}
