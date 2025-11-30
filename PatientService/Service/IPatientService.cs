using PatientService.DTOs;

namespace PatientService.Service
{
    public interface IPatientService
    {
        Task<PatientCreateDto> CreatePatient(PatientCreateDto dto);
        Task<PatientResponseDto> GetPatient(int id);
        Task<IEnumerable<PatientResponseDto>> GetAllPatients();
        Task<PatientUpdateDto> UpdatePatient( PatientUpdateDto dto);
        Task DeletePatient(int id);
    }
}
