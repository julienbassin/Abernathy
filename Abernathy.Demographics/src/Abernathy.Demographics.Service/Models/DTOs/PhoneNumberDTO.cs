using System;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record PhoneNumberDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreatedPhoneNumberDto(string Name, string Description, decimal Price);
    public record UpdatePhoneNumberDto(string Name, string Description, decimal Price);
}