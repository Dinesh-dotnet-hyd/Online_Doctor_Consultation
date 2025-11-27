using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientService.DTOs;
using PatientService.Service;

namespace PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto dto)
        {
            var result = await _service.CreatePatient(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetPatient(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllPatients();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientUpdateDto dto)
        {
            var result = await _service.UpdatePatient(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePatient(id);
            return NoContent();
        }

        //[HttpGet("login")]
        //public Task<ActionResult<bool>> PatientLogin(PatientLoginDto dto)
        //{

        //}
    }
}
