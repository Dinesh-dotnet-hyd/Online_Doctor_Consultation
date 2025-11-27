using Microsoft.EntityFrameworkCore;
using PatientService.Data;
using PatientService.DTOs;
using PatientService.Models;

namespace PatientService.Repositories
{
    public class PatientRepositoy : IPatientRepository
    {
        private readonly AppDbContext _context;
        public PatientRepositoy(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.patients.FirstOrDefaultAsync(x => x.PatientId == id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {

            return await _context.patients.ToListAsync();
        }
        public async Task<Patient> CreateAsync(Patient patient)
        {
            await _context.patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task UpdateAsync(Patient patient)
        {
            var pat = await GetByIdAsync(patient.PatientId);
            if (pat != null)
            {
                pat.Email = patient.Email;
                pat.FirstName = patient.FirstName;
                pat.LastName = patient.LastName;
                pat.BloodGroup = patient.BloodGroup;
                pat.UpdatedAt = DateTime.Now;
                pat.DateOfBirth = DateTime.Now;
                pat.Phone = patient.Phone;
                pat.Allergies = patient.Allergies;
                pat.MedicalHistory = patient.MedicalHistory;
                pat.PassHash = patient.PassHash;
                await _context.SaveChangesAsync();


            }
        }
        public async Task DeleteAsync(int id)
        {
            var pat = await GetByIdAsync(id);
            if (pat != null)
            {
                _context.patients.Remove(pat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> LoginPatient(PatientLoginDto patientLoginDto)
        {
            var pat = await _context.patients.FirstOrDefaultAsync(x => x.Email == patientLoginDto.Email);
            if (pat == null)
            {
                return false;
            }
            if (pat.PassHash == patientLoginDto.Password)
            {
                return true;
            }
            return false;
        }
    }
}
