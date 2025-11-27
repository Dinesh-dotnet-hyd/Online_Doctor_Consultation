using DoctorRegistration.Model;
using DoctorRegistration.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace DoctorRegistration.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _repo;

        public DoctorController(IDoctorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAll()
        {
            var res = await _repo.GetAll();
            return Ok(res);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterDoctors([FromQuery] DoctorFilterRequest filter)
        {
            var doctors = await _repo.FilterDoctorsAsync(filter);
            return Ok(doctors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _repo.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor([FromBody] Doctor doctor)
        {
            await _repo.RegisterDoctor(doctor);
            return Ok();
        }

        [HttpGet("login")]
        public async Task<ActionResult<bool>> DoctorLogin([FromQuery] LoginDTO login)
        {
            var flag = await _repo.LoginDoctor(login);

            if (!flag)
                return Unauthorized(false);

            return Ok(true);
        }
    }

}
