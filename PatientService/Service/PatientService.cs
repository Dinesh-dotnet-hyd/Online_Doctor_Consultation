using PatientService.DTOs;
using PatientService.Models;
using PatientService.Repositories;

namespace PatientService.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<PatientResponseDto> CreatePatient(PatientCreateDto dto)
        {
            var patient = new Patient
            {
                UserId = dto.UserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                Email = dto.Email,
                PassHash = dto.PassHash,
                DateOfBirth = dto.DateOfBirth,
                MedicalHistory = dto.MedicalHistory,
                Allergies = dto.Allergies,
                BloodGroup = dto.BloodGroup,
                //InsuranceProvider = dto.InsuranceProvider,
                //InsuranceNumber = dto.InsuranceNumber
            };

            var created = await _repo.CreateAsync(patient);

            return ToDto(created);
        }

        public async Task DeletePatient(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<PatientResponseDto>> GetAllPatients()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDto);
        }

        public async Task<PatientResponseDto> GetPatient(int id)
        {
            var patient = await _repo.GetByIdAsync(id);
            return patient == null ? null : ToDto(patient);
        }

        public async Task<PatientResponseDto> UpdatePatient(int id, PatientUpdateDto dto)
        {
            var patient = await _repo.GetByIdAsync(id);
            if (patient == null) return null;

            patient.Phone = dto.Phone;
            patient.MedicalHistory = dto.MedicalHistory;
            patient.Allergies = dto.Allergies;
            patient.BloodGroup = dto.BloodGroup;
            //patient.InsuranceProvider = dto.InsuranceProvider;
            //patient.InsuranceNumber = dto.InsuranceNumber;

            await _repo.UpdateAsync(patient);
            return ToDto(patient);
        }

        private PatientResponseDto ToDto(Patient p)
        {
            return new PatientResponseDto
            {
                PatientId = p.PatientId,
                UserId = p.UserId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Phone = p.Phone,
                DateOfBirth = p.DateOfBirth,
                MedicalHistory = p.MedicalHistory,
                Allergies = p.Allergies,
                BloodGroup = p.BloodGroup,
                //InsuranceProvider = p.InsuranceProvider,
                //InsuranceNumber = p.InsuranceNumber
            };
        }
    }
}
