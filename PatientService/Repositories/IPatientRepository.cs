using PatientService.DTOs;
using PatientService.Models;

namespace PatientService.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<PatientCreateDto> CreateAsync(PatientCreateDto patient);
        Task<PatientUpdateDto> UpdateAsync(PatientUpdateDto patient);
        Task DeleteAsync(int id);
        Task<bool> LoginPatient(PatientLoginDto patientLoginDto);
        //Task<PatientCreateDto> CreatePatient(PatientCreateDto patient);
    }
}
