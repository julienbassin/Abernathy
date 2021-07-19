using System.Threading.Tasks;
using Abernathy.Demographics.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abernathy.Demographics.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _patientService.GetAll();
            return Ok(result);
        }
    }
}