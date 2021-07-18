using System;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record AddressDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreatedAddressDto(string Name, string Description, decimal Price);
    public record UpdateAddressto(string Name, string Description, decimal Price);
}