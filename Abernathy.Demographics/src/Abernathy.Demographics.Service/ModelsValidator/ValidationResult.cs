using System.Collections.Generic;

namespace Abernathy.Demographics.Service.ModelsValidator
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            ErrorMessages = new Dictionary<string, string>();
        }
        public bool IsValid { get; set; }
        public Dictionary<string, string> ErrorMessages { get; set; }
    }
}