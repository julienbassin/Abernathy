using System;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record AddressDto(int Id, 
                            string StreetName, 
                            int HouseNumber, 
                            string ZipCode, 
                            string Town, 
                            string State, 
                            DateTimeOffset CreatedDate);
    public record CreatedAddressDto(string StreetName,
                                    int HouseNumber,
                                    string ZipCode,
                                    string Town,
                                    string State);
    public record UpdateAddressto(string StreetName,
                                    int HouseNumber,
                                    string ZipCode,
                                    string Town,
                                    string State);
}