using System;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record PhoneNumberDto(int Id, string number, string PhoneType);
    //public record CreatedPhoneNumberDto(string number, string PhoneType);
    //public record UpdatePhoneNumberDto(string number, string PhoneType);
}