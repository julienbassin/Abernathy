using System;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record PatientDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreatedPatientDto(string Name, string Description, decimal Price);
    public record UpdatePatientDto(string Name, string Description, decimal Price);
}