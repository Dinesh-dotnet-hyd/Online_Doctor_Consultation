using PatientService.DTOs;

namespace PatientService.Service
{
    public interface IPatientService
    {
        Task<PatientResponseDto> CreatePatient(PatientCreateDto dto);
        Task<PatientResponseDto> GetPatient(int id);
        Task<IEnumerable<PatientResponseDto>> GetAllPatients();
        Task<PatientResponseDto> UpdatePatient(int id, PatientUpdateDto dto);
        Task DeletePatient(int id);
    }
}
