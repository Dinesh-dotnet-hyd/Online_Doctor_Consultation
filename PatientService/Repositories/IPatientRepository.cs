using PatientService.DTOs;
using PatientService.Models;

namespace PatientService.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> CreateAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
        Task<bool> LoginPatient(PatientLoginDto patientLoginDto);
    }
}
