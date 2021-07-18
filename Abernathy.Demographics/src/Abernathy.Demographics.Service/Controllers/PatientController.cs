using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Abernathy.Demographics.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        //IPatientService
        public PatientController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok();
        }
    }
}